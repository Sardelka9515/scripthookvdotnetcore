using GTA;
using GTA.UI;
using SHVDN.Loader;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;

namespace SHVDN
{
    public static unsafe partial class Core
    {
        #region Main assembly only

        static readonly Dictionary<string, ScriptDirectoryLoader> _loaders = new(StringComparer.OrdinalIgnoreCase);

        static readonly ConcurrentQueue<Action> _taskQueue = new();
        static BaseScript _baseScript;

        // Function that gets called from main thread by the c++ native host during startup
        static int CLR_EntryPoint(IntPtr asiModule, int cbArg)
        {
            Assert(cbArg == sizeof(HMODULE));
            DoImport(asiModule);

            IntPtr funcPtr;
            *(delegate* unmanaged<void>*)(&funcPtr) = &CLR_DoInit;
            SetPtr(KEY_CORECLR_INITFUNC, funcPtr);

            *(delegate* unmanaged<void>*)(&funcPtr) = &CLR_DoTick;
            SetPtr(KEY_CORECLR_TICKFUNC, funcPtr);

            *(delegate* unmanaged<DWORD, BOOL, BOOL, BOOL, BOOL, void>*)(&funcPtr) = &CLR_DoKeyboard;
            SetPtr(KEY_CORECLR_KBHFUNC, funcPtr);

            LoadDependencies();
            return 0;
        }

        [UnmanagedCallersOnly]
        static void CLR_DoInit()
        {
            // Set up main TLS and ThreadId
            OnInit(default);

            // Load base script
            if (_baseScript == null)
            {
                RegisterScript(_baseScript = new());
                GTA.Console.RegisterCommands(typeof(BaseScript));
                GTA.Console.RegisterCommands(typeof(BaseScript), _baseScript);
            }
            BaseScript.Load();
        }

        [UnmanagedCallersOnly]
        static void CLR_DoKeyboard(DWORD key, BOOL keydown, BOOL ctrl, BOOL shift, BOOL alt)
        {
            try
            {
                DoKeyEvent(key, keydown, ctrl, shift, alt);
                foreach (var l in _loaders)
                {
                    l.Value.DoKeyEvent(key, keydown, ctrl, shift, alt);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Keyboard event error: " + ex.ToString());
            }
        }

        [UnmanagedCallersOnly]
        static void CLR_DoTick()
        {
            try
            {

                while (_taskQueue.TryDequeue(out var task))
                {
                    try
                    {
                        task();
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("Error executing queued task: " + ex.ToString());
                    }
                }

                DoTick(default);
                lock (_loaders)
                {
                    foreach (var loader in _loaders)
                    {
                        loader.Value.DoTick(default);
                    }
                }
            }
            catch (Exception ex)
            {
                Assert(false, ex.ToString());
            }
        }
        internal static void CLR_Load(string dir)
        {
            lock (_loaders)
            {
                if (_loaders.ContainsKey(dir))
                    throw new ArgumentException("Script directory has already been loaded", nameof(dir));

                dir = Path.GetFullPath(dir);
                Logger.Debug($"Loading scripts from {dir}");
                var loader = new ScriptDirectoryLoader(dir);
                _loaders.Add(dir, loader);
                loader.DoInit(AsiModule);
            }
        }
        internal static void CLR_Unload(string dir)
        {
            lock (_loaders)
            {
                if (_loaders.TryGetValue(dir, out var loader))
                {
                    Logger.Info($"Unloading scripts in {dir}");
                    loader.Dispose();
                    _loaders.Remove(dir);
                    Logger.Info($"Unloaded scripts in {dir}");
                }
            }
        }
        internal static void CLR_UnloadAll()
        {
            foreach (var dir in _loaders.Keys)
            {
                try
                {
                    CLR_Unload(dir);
                }
                catch (Exception ex)
                {
                    Logger.Error($"Failed to unload scripts in directory {dir}");
                    Logger.Error(ex.ToString());
                }
            }

        }
        internal static void CLR_ReloadAll()
        {
            static bool canLoadFromThisDir(string dir)
            {
                dir = Path.GetFullPath(dir);
                return !_loaders.ContainsKey(dir) && Directory.GetFiles(dir, "*.dll").Any(IsManagedAssembly);
            }

            CLR_UnloadAll();

            List<string> toLoad = new();
            var scriptsRoot = Path.GetFullPath("CoreScripts");
            if (canLoadFromThisDir(scriptsRoot))
                toLoad.Add(scriptsRoot);

            foreach (var dir in Directory.GetDirectories(scriptsRoot))
            {
                if (canLoadFromThisDir(dir))
                    toLoad.Add(dir);
            }

            foreach (var l in toLoad)
            {
                try
                {
                    CLR_Load(l);
                }
                catch (Exception ex)
                {
                    Logger.Error($"Failed to load scripts from directory: {l}");
                    Logger.Error(ex.ToString());
                }
            }
            Assert(CurrentDirectory == null);
        }

        // These methods can be invoke using reflection API to control script load/unload

        [ReflectionEntry(Place = EntryPlace.MainAssembly)]
        private static void RequestLoad(string dir)
        {
            _taskQueue.Enqueue(() => CLR_Load(dir));
        }


        [ReflectionEntry(Place = EntryPlace.MainAssembly)]
        private static void RequestUnload(string dir)
        {
            _taskQueue.Enqueue(() => CLR_Unload(dir));
        }


        [ReflectionEntry(Place = EntryPlace.MainAssembly)]
        private static string[] ListScriptDirectories()
        {
            lock (_loaders)
            {
                return _loaders.Keys.ToArray();
            }
        }


        [ReflectionEntry(Place = EntryPlace.MainAssembly)]
        private static dynamic[] ListScriptObjects(string scriptDir)
        {
            if (_loaders.TryGetValue(scriptDir, out var loader))
                return (dynamic[])loader.InvokeCore(nameof(ListScripts));
            return null;
        }

        #endregion

        #region Set up by main assembly

        /// <summary>
        /// All assemblies loaded in to current context, indexed by their path to assembly
        /// </summary>
        [ReflectionEntry(Place = EntryPlace.ScriptAssemblies)]
        public static Dictionary<string, Assembly> ScriptAssemblies { get; private set; }

        /// <summary>
        /// The directory used by this load context
        /// </summary>
        [ReflectionEntry(Place = EntryPlace.ScriptAssemblies)]
        public static string CurrentDirectory { get; private set; }

        /// <summary>
        /// The main assembly that creates and loads the current <see cref="AssemblyLoadContext"/>
        /// </summary>
        [ReflectionEntry(Place = EntryPlace.ScriptAssemblies)]
        public static Assembly MainAssembly { get; private set; }
        #endregion

        static void FindAndRegisterAllScripts()
        {
            Assert(CurrentDirectory != null);
            Assert(ScriptAssemblies != null);
            Assert(MainAssembly != null);

            foreach (var asm in ScriptAssemblies.Values)
            {
                Logger.Debug($"Loading scripts in {asm}");
                try
                {
                    foreach (var scriptType in asm.GetTypes().Where(x => x.IsAssignableTo(typeof(Script)) && !x.IsAbstract))
                    {
                        try
                        {
                            var script = (Script)Activator.CreateInstance(scriptType);
                            RegisterScript(script);
                            GTA.Console.RegisterCommands(scriptType);
                            GTA.Console.RegisterCommands(scriptType, script);
                        }
                        catch (Exception ex)
                        {
                            Logger.Error($"Failed to register script {scriptType}");
                            Logger.Error(ex.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.ToString());
                }
            }
        }
        public static class RuntimeController
        {
            static readonly Type MainCoreType;
            static RuntimeController()
            {
                if (MainAssembly == null)
                    throw new InvalidOperationException("Can't use runtime controller in main assembly");

                MainCoreType = MainAssembly.GetType(typeof(Core).FullName);
            }
            static object Invoke(string methodName, params object[] args)
                => MainCoreType.GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic).Invoke(null, args);

            public static void RequestUnload(string dir) => Invoke(nameof(Core.RequestUnload), dir);

            public static void RequestLoad(string dir) => Invoke(nameof(Core.RequestLoad), dir);

            public static string[] ListScriptDirectories() => (string[])Invoke(nameof(Core.ListScriptDirectories));

            /// <summary>
            /// List all script objects in the load context of specified directory
            /// </summary>
            /// <param name="scriptDir"></param>
            /// <returns>An array of <see cref="Script"/> objects in <see langword="dynamic"/> form </returns>
            /// <remarks>As same type in different load context will actually be treated as two different types.
            /// Attempting to cast the returned values to <see cref="Script"/> will result in an <see cref="InvalidCastException"/></remarks>
            public static dynamic[] ListScriptObjects(string scriptDir) => (dynamic[])Invoke(nameof(Core.ListScriptObjects), scriptDir);
        }
    }
}
