using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHVDN.Loader;
using System.Reflection;
using System.Diagnostics;
namespace SHVDN.Loader
{
    class ScriptDirectoryLoader : PluginLoader
    {
        public delegate void KeyEventDelegate(DWORD key, bool down, bool ctrl, bool shift, bool alt);
        public Assembly ApiAssembly { get; }
        public Action<IntPtr> DoInit { get; }
        public Action<IntPtr> DoUnload { get; }
        public Action<IntPtr> DoTick { get; }
        public KeyEventDelegate DoKeyEvent { get; }
        public Type CoreType { get; }
        public object InvokeCore(string methodName, params object[] args)
        {
            var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            return CoreType.GetMethod(methodName, flags).Invoke(null, args);
        }
        public ScriptDirectoryLoader(string folder) : base(GetConfig(folder))
        {
            var flags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

            ApiAssembly = LoadDefaultAssembly();
            CoreType = ApiAssembly.GetType(typeof(Core).FullName);

            var initMethod = getMethod(nameof(Core.OnInit));
            Debug.Assert(initMethod != null);

            var unloadMethod = getMethod(nameof(Core.OnUnload));
            Debug.Assert(unloadMethod != null);

            var tickMethod = getMethod(nameof(Core.DoTick));
            Debug.Assert(tickMethod != null);

            var keyEventMethod = getMethod(nameof(Core.DoKeyEvent));
            Debug.Assert(keyEventMethod != null);

            // Caching with delegates
            DoInit = (Action<IntPtr>)Delegate.CreateDelegate(typeof(Action<IntPtr>), initMethod);
            DoUnload = (Action<IntPtr>)Delegate.CreateDelegate(typeof(Action<IntPtr>), unloadMethod);
            DoTick = (Action<IntPtr>)Delegate.CreateDelegate(typeof(Action<IntPtr>), tickMethod);
            DoKeyEvent = (KeyEventDelegate)Delegate.CreateDelegate(typeof(KeyEventDelegate), keyEventMethod);

            Dictionary<string, Assembly> scriptAssemblies = new();
            foreach (var asmPath in Directory.GetFiles(folder, "*.dll").Where(Core.IsManagedAssembly))
            {
                // Skip loading of api assembly
                if (Path.GetFileNameWithoutExtension(asmPath) == typeof(Core).Assembly.GetName().Name)
                    continue;

                try
                {
                    Logger.Debug("Loading assembly: " + asmPath);
                    scriptAssemblies.Add(asmPath, LoadAssemblyFromPath(asmPath));
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.ToString());
                }
            }

            setProp(nameof(Core.CurrentDirectory), folder);
            setProp(nameof(Core.ScriptAssemblies), scriptAssemblies);
            setProp(nameof(Core.MainAssembly), typeof(Core).Assembly);
            void setProp(string name, object value)
            {
                var prop = CoreType.GetProperty(name, flags);
                Debug.Assert(prop != null, $"Property {name} not found");
                prop.SetValue(null, value);
            }
            MethodInfo getMethod(string name)
                => CoreType.GetMethod(name, flags);
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                DoUnload(default);
                _disposed = true;
            }

            // Call base class implementation.
            base.Dispose(disposing);
        }
        static PluginConfig GetConfig(string folderPath)
        {
            var files = Directory.GetFiles(folderPath, "*.dll");
            if (!files.Any(Core.IsManagedAssembly))
                throw new FileNotFoundException("No managed assemblies were found in this folder");

            var mainAssemblyPath = Path.Combine(folderPath, typeof(Core).Assembly.GetName().Name + ".dll"); // ScriptHookVDotNetCore.dll
            mainAssemblyPath = Path.GetFullPath(mainAssemblyPath);

            bool alwaysCopy = false;
#if DEBUG
            alwaysCopy = true;
#endif
            // Copy the API assembly if there's none
            if (!File.Exists(mainAssemblyPath) || alwaysCopy)
                File.Copy(typeof(Core).Assembly.Location, mainAssemblyPath, true);

            // Don't use shared type to allow different version of API assembly to be loaded at the same time
            return new(mainAssemblyPath)
            {
                EnableHotReload = false,
                IsUnloadable = true,
                LoadInMemory = true,
                PreferSharedTypes = false
            };
        }
    }
}
