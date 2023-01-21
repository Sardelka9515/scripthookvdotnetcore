using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Text;

namespace SHVDN
{
    // Built-in console commands
    internal static unsafe partial class Console
    {
        static Console()
        {
            var asm = typeof(BaseScript).Assembly.GetName().Name;
            RegisterCommand(&Help, "Help", "", "List all avalible commands", asm);
            RegisterCommand(&Clear, "Clear", "", "Clear console output", asm);
            RegisterCommand(&Reload, "Reload", "", "Reload all scripts", asm);
            RegisterCommand(&ListModules, "ListModules", "", "List all loaded modules", asm);
        }

        [UnmanagedCallersOnly]
        static IntPtr ListModules(int argc, char** argv)
        {

            try
            {
                HMODULE* modus = stackalloc HMODULE[256];
                var cModu = Core.ListModules(modus, 256);

                char* path = stackalloc char[256];
                for (int i = 0; i < cModu; i++)
                {
                    var fSucess = GetModuleFileNameW(modus[i], path, 256) != 0;
                    PrintInfo($"{modus[i]} : {(fSucess ? new string(path) : "error")}");
                }
            }
            catch (Exception ex)
            {
                PrintError(ex.ToString());
            }
            return default;
        }
        
        [UnmanagedCallersOnly]
        static IntPtr Clear(int argc, char** argv)
        {
            Clear();
            return default;
        }

        [UnmanagedCallersOnly]
        static IntPtr Help(int argc, char** argv)
        {
            try
            {
                PrintHelpText();
                var args = GetArguments(argc, argv);
                if (args.Count > 0)
                {
                    PrintInfo("Passed arguments:");
                    foreach (var arg in args)
                    {
                        PrintInfo(arg);
                    }
                }
            }
            catch (Exception ex)
            {
                PrintError(ex.ToString());
            }
            return default;
        }

        [UnmanagedCallersOnly]
        static IntPtr Reload(int argc, char** argv)
        {
            Core.ScheduleReload();
            return default;
        }

    }
}
