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

public static partial class EntryPoint
{
    static void ModuleSetup()
    {
        Core.RegisterScript(new BaseScript());
        GTA.Console.RegisterCommands(typeof(BaseScript));
    }
}

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

    static string[] TestStrings = new string[]
        {
            "YLvbTGwqZDV7cAS3EO5T",
            "DQwHOet2gAxlopBD5YBv",
            "C89CSWjnagVh0dcUYjEf",
            "8y3EOW9RqtJdmQxC3Gfs",
            "cv1tNmGvQr8l5JcnORUW",
            "gDxF3FIMq45kJESchT3i",
            "gEfqkhLMYmn22HEBruMO",
            "XNqU1D86P5Fr07myMdHQ",
            "WKWk1ZGhnTNexlnldJP9",
            "1r979KceR5hU1wNZF3cL",
            "j08z0x0VKBSMgFFZ2j8U",
            "rihusSJOe3rny8GJFBrW",
            "pMv1SYHPQbfZpiSUmkkt",
            "s8TNthZnLcagI54FqxHx",
            "x9aYv10oNHSC7PBsDgp2",
            "LQo2gpJ9Fb418s27cgUd",
            "IbeZEys1ECZ09uWsALGV",
            "QJPwrldZN7XjWGFlzG7p",
            "eHbwowHZ9vYJH7RnBCGx",
            "pYY1vrv7VjPAmcye2gRa",
        };

    [GTA.ConsoleCommand("Benchmark GetHashKey performance")]
    public static void BenchMark()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < 10000; i++)
        {
            foreach (var str in TestStrings)
            {
                NativeMemory.GetHashKey(str);
            }
        }
        stopwatch.Stop();
        GTA.Console.PrintInfo("Elapsed ticks: " + stopwatch.ElapsedTicks);
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
        GTA.Console.PrintInfo(count.ToString());
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
                GTA.Console.PrintInfo($"Module {filename} scheduled for unload");
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