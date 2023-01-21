using System.Diagnostics;
using System.Drawing;
using GTA;
using GTA.Native;
using GTA.UI;
using System.Threading.Tasks;
using static GTA.Native.Function;
using System.Threading;
using System.Runtime.InteropServices;

namespace SHVDN;

public static partial class EntryPoint
{
    static void ModuleSetup()
    {
        Core.RegisterScript(new BaseScript());
    }
}

internal unsafe class BaseScript : Script
{

    const Keys ConsoleKey = Keys.F6;

    protected override void OnStart()
    {
        base.OnStart();
        while (Game.IsLoading) Yield();
        Notification.Show($"ScriptHookVDotNetCore {typeof(Core).Assembly.GetName().Version} by Sardelka9515");
        Directory.CreateDirectory("CoreScripts");
        foreach (var script in Directory.GetFiles("CoreScripts", "*.dll"))
        {
            fixed (char* ptr = script)
            {
                Core.ScheduleLoad(ptr);
            }
        }
        Console.RegisterCommand(&GetObjectCount, "GetObjectCount", "[type]", "Get object count of specified type, possible types are: ped,vehicle,prop,projectile", typeof(BaseScript).Assembly.GetName().Name);
    }

    [UnmanagedCallersOnly]
    public static IntPtr GetObjectCount(int argc, char** argv)
    {
        try
        {
            int count = 0;
            var type = Console.GetArguments(argc, argv)[0];
            count = type switch
            {
                "ped" => World.PedCount,
                "vehicle" => World.VehicleCount,
                "prop" => World.PropCount,
                "projectile" => World.ProjectileCount,
                _ => throw new ArgumentException($"Type not found: {type}"),
            };
            Console.PrintInfo(count.ToString());
        }
        catch (Exception ex)
        {
            Console.PrintError(ex.Message);
        }
        return default;
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