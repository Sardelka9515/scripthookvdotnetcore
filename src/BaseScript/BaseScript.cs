using GTA;
using GTA.UI;
using System;
using System.IO;
using System.Linq;

namespace SHVDN;

struct ConfigStruct
{
    public ushort UnloadKey;
    public ushort ReloadKey;
    public ushort MaxUnloadRetries;
    public ushort ConsoleKey;
}

internal unsafe class BaseScript : Script
{
    static ConfigStruct* _pConfig = (ConfigStruct*)Core.GetPtr("Config"); 

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
        if ((ushort)e.KeyCode == _pConfig->ConsoleKey)
        {
            Console.IsOpen = !Console.IsOpen;
        }
        Console.DoKeyEvent(e.KeyData, false);
    }

    #region Commands

    protected override void OnStart()
    {
        base.OnStart();
        try
        {
            ReloadConfig();
        }
        catch(Exception ex)
        {
            Logger.Error("Error loading configuration file: \n" + ex);
        }
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

    [ConsoleCommand("Unload and reload all scripts")]
    public static void Reload()
    {
        Core.ScheduleReload();
    }

    [ConsoleCommand("Print all avalible commands")]
    public static void Help()
    {
        Console.PrintHelpText();
    }

    [ConsoleCommand("Clear console output")]
    public static void Clear()
    {
        Console.Clear();
    }

    [ConsoleCommand("List all loaded modules")]
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

    [ConsoleCommand("Get object count of specified type, possible types are: ped,vehicle,prop,projectile")]
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

    [ConsoleCommand("Request a module to be unloaded")]
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

    [ConsoleCommand("Reload the ini configuration file")]
    public static void ReloadConfig()
    {
        string Default =
@"UnloadKey = End
ReloadKey = Home
MaxUnloadRetries = 256
ConsoleKey = F6";
        if (!File.Exists(CONFIG_PATH)) File.WriteAllText(CONFIG_PATH,Default);
        var lines = File.ReadAllLines(CONFIG_PATH);
        foreach(var kv in lines.Select(x=>x.Split('=',StringSplitOptions.RemoveEmptyEntries)) )
        {
            if (kv.Length < 2 || kv[0].StartsWith(';')) continue;
            var key = kv[0].Trim();
            var value = kv[1].Trim();
            switch (key)
            {
                case nameof(ConfigStruct.UnloadKey):
                    _pConfig->UnloadKey = (ushort)Enum.Parse<Keys>(value);
                    break;
                case nameof(ConfigStruct.ReloadKey):
                    _pConfig->ReloadKey = (ushort)Enum.Parse<Keys>(value);
                    break;
                case nameof(ConfigStruct.MaxUnloadRetries):
                    _pConfig->MaxUnloadRetries = ushort.Parse(value);
                    break;
                case nameof(ConfigStruct.ConsoleKey):
                    _pConfig->ConsoleKey = (ushort)Enum.Parse<Keys>(value);
                    break;
                default:
                    Logger.Error($"Unrecognized key: {value}");
                    break;
            }
        }
    }
    #endregion
}