using System.Diagnostics;
using System.Drawing;
using GTA;
using GTA.Native;
using GTA.UI;
using System.Threading.Tasks;
using static GTA.Native.Function;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics.Metrics;

namespace SHVDN;


internal unsafe class BaseScript : Script
{

    const Keys ConsoleKey = Keys.F6;

    protected override void OnStart()
    {
        base.OnStart();
        while (Game.IsLoading) Yield();
        Notification.Show($"ScriptHookVDotNetCore {typeof(Core).Assembly.GetName().Version} by Sardelka");
        Directory.CreateDirectory("CoreScripts");
        foreach (var script in Directory.GetFiles("CoreScripts", "*.dll"))
        {
            fixed (char* ptr = script)
            {
                Core.ScheduleLoad(ptr);
            }
        }
    }

    [GTA.ConsoleCommand("Unload and reload all scripts")]
    public static void Reload()
    {
        Core.ScheduleReload();
    }

    [GTA.ConsoleCommand("Print all avalible commands")]
    public static void Help()
    {
        Console.PrintHelpText();
    }

    [GTA.ConsoleCommand("Clear console output")]
    public static void Clear()
    {
        Console.Clear();
    }

    [GTA.ConsoleCommand("List all loaded modules")]
    public static void ListModules()
    {
        HMODULE* modus = stackalloc HMODULE[256];
        var cModu = Core.ListModules(modus, 256);
        Console.PrintInfo("List of loaded modules:");
        char* path = stackalloc char[256];
        for (int i = 0; i < cModu; i++)
        {
            var fSucess = GetModuleFileNameW(modus[i], path, 256) != 0;
            Console.PrintInfo($"    {String.Format("0x{0:X}", modus[i])} : {(fSucess ? Path.GetFileName(new string(path)) : "error")}");
        }
    }

    [GTA.ConsoleCommand("Get object count of specified type, possible types are: ped,vehicle,prop,projectile")]
    public static void GetObjectCount(string type)
    {
        var count = type switch
        {
            "ped" => World.PedCount,
            "vehicle" => World.VehicleCount,
            "prop" => World.PropCount,
            "projectile" => World.ProjectileCount,
            _ => throw new ArgumentException($"Type not found: {type}"),
        };
        Console.PrintInfo(count.ToString());
    }

    [GTA.ConsoleCommand("Request a module to be unloaded")]
    public static void Unload(string filename)
    {
        HMODULE* modus = stackalloc HMODULE[256];
        var cModu = Core.ListModules(modus, 256);

        char* path = stackalloc char[256];
        for (int i = 0; i < cModu; i++)
        {
            var fSucess = GetModuleFileNameW(modus[i], path, 256) != 0;
            if (fSucess && Path.GetFileName(new string(path)).ToLower() == filename.ToLower())
            {
                Core.ScheduleUnload(path);
                Console.PrintInfo($"Module {filename} scheduled for unload");
                return;
            }
        }
        throw new FileNotFoundException($"Specified module was not found: " + filename);
    }

    protected override void OnTick()
    {
        base.OnTick();
        Console.DoTick();
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);
        Console.DoKeyEvent(e.KeyData, true);
    }

    protected override void OnKeyUp(KeyEventArgs e)
    {
        base.OnKeyUp(e);
        if (e.KeyCode == ConsoleKey)
        {
            Console.IsOpen = !Console.IsOpen;
        }
        Console.DoKeyEvent(e.KeyData, false);
    }
}