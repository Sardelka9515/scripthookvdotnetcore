using GTA;
using GTA.UI;
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Runtime.Loader;

namespace SHVDN;

public static unsafe partial class Core
{
    static void LoadDependencies()
    {
        LoadToAssemblyToDefaultContext(Properties.Resources.Microsoft_CodeAnalysis);
        LoadToAssemblyToDefaultContext(Properties.Resources.Microsoft_CodeAnalysis_CSharp);
    }

    static void LoadToAssemblyToDefaultContext(byte[] rawAssembly)
    {
        using var stream = new MemoryStream(rawAssembly);
        AssemblyLoadContext.Default.LoadFromStream(stream);
    }

    [ScriptAttributes(NoScriptThread = true)]
    internal unsafe class BaseScript : Script
    {
        delegate void LogHandlerDelegate(ulong tick, uint level, IntPtr ptrAnsiMsg);
        static readonly LogHandlerDelegate _logHandler = PrintLogMessage;
        static readonly IntPtr _logHandler_fptr = Marshal.GetFunctionPointerForDelegate(_logHandler);
        public BaseScript()
        {
            Aborted += (e) =>
            {
                if (e.IsUnloading)
                {
                    RemoveLogHandler(_logHandler_fptr);
                }
            };
        }

        protected override void OnStart()
        {
            base.OnStart();
            AddLogHandler(_logHandler_fptr);
            try
            {
                ReloadConfig();
            }
            catch (Exception ex)
            {
                Logger.Error("Error loading configuration file: \n" + ex);
            }
            SHVDN.Console.PrintInfo($"~c~ --- ScriptHookVDotNetCore {Core.AsiVersion} by Sardelka. ---");
            SHVDN.Console.PrintInfo($"~c~ --- Type \"Help\" to list avalible commands ---");
        }

        static void PrintLogMessage(ulong time, uint level, IntPtr pMsg)
        {
            var msg = Marshal.PtrToStringAnsi(pMsg);
            switch (level)
            {
                case L_INF:
                    SHVDN.Console.PrintInfo(msg); break;
                case L_WRN:
                    SHVDN.Console.PrintWarning(msg); break;
                case L_ERR:
                    SHVDN.Console.PrintError(msg); break;
                default: break;
            }
        }

        protected override void OnTick()
        {
            base.OnTick();
            SHVDN.Console.DoTick();

        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            SHVDN.Console.DoKeyDown(e);

            var key = (ushort)e.KeyCode;
            if (key == Core.Config->ConsoleKey)
                SHVDN.Console.IsOpen = !SHVDN.Console.IsOpen;

            else if (key == Core.Config->UnloadKey)
            {
                Unload();
            }
            else if (key == Core.Config->ReloadKey)
            {
                Load();
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
        }

        #region Commands

        [ConsoleCommand("Print all avalible commands")]
        public static void Help()
        {
            SHVDN.Console.PrintHelpText();
        }

        [ConsoleCommand("Clear console output")]
        public static void Clear()
        {
            SHVDN.Console.Clear();
        }

        [ConsoleCommand("Get object count of specified type: all,ped,vehicle,prop,projectile")]
        public static void GetObjectCount(string type = "all")
        {
            var count = type switch
            {
                "all" => NativeMemory.GetObjectCount(),
                "ped" => World.PedCount,
                "vehicle" => World.VehicleCount,
                "prop" => World.PropCount,
                "projectile" => World.ProjectileCount,
                _ => throw new ArgumentException($"Type not found: {type}"),
            };
            SHVDN.Console.PrintInfo(count.ToString());
        }

        [ConsoleCommand("Reload the ini configuration file")]
        public static void ReloadConfig()
        {
            string Default =
    @"ConsoleKey=F6
UnloadKey=End
ReloadKey=Home
MaxUnloadRetries=256
AllocDebugConsole=false
SkipLegalScreen=true";
            if (!File.Exists(CONFIG_PATH)) File.WriteAllText(CONFIG_PATH, Default);
            var lines = File.ReadAllLines(CONFIG_PATH);
            foreach (var kv in lines.Select(x => x.Split('=', StringSplitOptions.RemoveEmptyEntries)))
            {
                if (kv.Length < 2 || kv[0].StartsWith(';')) continue;
                var key = kv[0].Trim();
                var value = kv[1].Trim();
                switch (key)
                {
                    case nameof(ConfigStruct.UnloadKey):
                        Core.Config->UnloadKey = (ushort)Enum.Parse<Keys>(value);
                        break;
                    case nameof(ConfigStruct.ReloadKey):
                        Core.Config->ReloadKey = (ushort)Enum.Parse<Keys>(value);
                        break;
                    case nameof(ConfigStruct.MaxUnloadRetries):
                        Core.Config->MaxUnloadRetries = ushort.Parse(value);
                        break;
                    case nameof(ConfigStruct.ConsoleKey):
                        Core.Config->ConsoleKey = (ushort)Enum.Parse<Keys>(value);
                        break;
                    default:
                        // Logger.Error($"Unrecognized key: {key}");
                        break;
                }
            }
            Core.ReloadCoreConfig();
        }

        [ConsoleCommand("Load all scripts from specified path, be it managed script directory ot NativeAOT module")]
        public static void Load(string path = null)
        {
            if (path == null)
            {
                LoadModule(path);
                Core.CLR_ReloadAll();
            }
            else if (Directory.Exists(path))
            {
                Core.CLR_Load(Path.GetFullPath(path));
            }
            else
            {
                LoadModule(path);
            }
        }

        [ConsoleCommand("Unoad all scripts from specified path, be it managed script directory ot NativeAOT module")]
        public static void Unload(string path = null)
        {
            if (path == null)
            {
                UnloadModule(path);
                Core.CLR_UnloadAll();
            }
            else if (Directory.Exists(path))
            {
                Core.CLR_Unload(Path.GetFullPath(path));
            }
            else
            {
                UnloadModule(path);
            }
        }

        [ConsoleCommand("List all scripts")]
        public static void ListScripts()
        {
            SHVDN.Console.PrintInfo("~c~List of loaded scripts");
            HMODULE* modus = stackalloc HMODULE[256];
            var cModu = Core.ListModules(modus, 256);
            if (cModu > 0)
            {
                SHVDN.Console.PrintInfo("~h~[NativeAOT]");
                char* path = stackalloc char[256];
                for (int i = 0; i < cModu; i++)
                {
                    var fSucess = GetModuleFileNameW(modus[i], path, 256) != 0;
                    SHVDN.Console.PrintInfo($"  {String.Format("0x{0:X}", modus[i])} : {(fSucess ? Path.GetFileName(new string(path)) : "error")}");
                }
                SHVDN.Console.PrintInfo(" ");
            }

            SHVDN.Console.PrintInfo("~h~[CoreCLR]");
            foreach (var dir in Core.ListScriptDirectories())
            {
                try
                {
                    var scripts = Core.ListScriptObjects(dir);
                    if (!scripts.Any())
                        continue;

                    Console.PrintInfo(dir);
                    string assemblyName = null;
                    foreach (var script in scripts)
                    {
                        var name = script.GetType().Assembly.GetName().Name;
                        if (name != assemblyName)
                        {
                            Console.PrintInfo($"    ~c~[{name}]");
                            assemblyName = name;
                        }
                        bool running = !script.IsAborted;
                        Console.PrintInfo($"        ~h~{script.Name} {(running ? "~g~Running~w~" : "~o~Aborted~w~")}");
                    }
                }
                catch (Exception ex)
                {
                    Console.PrintError(ex.ToString());
                }
            }
            SHVDN.Console.PrintInfo(" ");
        }

        public static bool OptimizeConsoleExpression = false;

        [GTA.ConsoleCommand("Set whether or not to enable optimization when compiling next console expression")]
        public static void SetOptimize(bool toggle)
        {
            OptimizeConsoleExpression = toggle;
            Logger.Debug($"Optimization {(toggle ? "enabled" : "disabled")} for console input");
        }

        #endregion


        private static void LoadModule(string path = null)
        {
            if (path == null)
            {
                UnloadModule();
                Directory.CreateDirectory("CoreScripts");
                foreach (var script in Directory.GetFiles("CoreScripts", "*.dll").Where(x => !Core.IsManagedAssembly(x)))
                {
                    fixed (char* ptr = script)
                    {
                        Core.ScheduleLoad(ptr);
                        SHVDN.Console.PrintInfo($"Module {Path.GetFileName(script)} scheduled for loading");
                    }
                }
            }
            else
            {
                path = File.Exists(path) ? path : Path.Combine("CoreScripts", path);

                if (!File.Exists(path))
                    throw new FileNotFoundException("Module not found", path);

                fixed (char* p = path)
                {
                    Core.ScheduleLoad(p);
                    SHVDN.Console.PrintInfo($"Module {path} scheduled for loading");
                }
            }
        }

        private static void UnloadModule(string filename = null)
        {
            HMODULE* modus = stackalloc HMODULE[256];
            var cModu = Core.ListModules(modus, 256);
            char* path = stackalloc char[256];

            if (filename == null)
            {
                for (int i = 0; i < cModu; i++)
                {
                    var fSucess = GetModuleFileNameW(modus[i], path, 256) != 0;
                    var name = Path.GetFileName(new string(path));
                    if (fSucess && name.ToLower() != BASE_SCRIPT_NAME.ToLower())
                    {
                        Core.ScheduleUnload(path);
                        SHVDN.Console.PrintInfo($"Module {name} scheduled for unloading");
                    }
                }
            }
            else
            {
                for (int i = 0; i < cModu; i++)
                {
                    var fSucess = GetModuleFileNameW(modus[i], path, 256) != 0;
                    if (fSucess && Path.GetFileName(new string(path)).ToLower() == filename.ToLower())
                    {
                        Core.ScheduleUnload(path);
                        SHVDN.Console.PrintInfo($"Module {filename} scheduled for unloading");
                        return;
                    }
                }
                throw new FileNotFoundException($"Specified module was not found: " + filename);
            }
        }
    }
}