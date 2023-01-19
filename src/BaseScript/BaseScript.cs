using System.Diagnostics;
using System.Drawing;
using GTA;
using GTA.Native;
using GTA.UI;
using System.Threading.Tasks;
using static GTA.Native.Function;
using System.Threading;

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
        Thread initNativeMemory = new(() =>
        {
            Logger.Debug($"Initializing {nameof(NativeMemory)}");
            var i = NativeMemory.ArmorOffset;
            Logger.Debug($"{nameof(NativeMemory)} initialized");
        });
        initNativeMemory.Start();
        while (initNativeMemory.IsAlive)
        {
            // Wait for memory scanning to complete without blocking game thread
            Yield();
        }
        Notification.Show($"ScriptHookVDotNetCore {typeof(Core).Assembly.GetName().Version} by Sardelka9515");
        Directory.CreateDirectory("CoreScripts");
        foreach (var script in Directory.GetFiles("CoreScripts", "*.dll"))
        {
            fixed (char* ptr = script)
            {
                Core.ScheduleLoad(ptr);
            }
        }
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