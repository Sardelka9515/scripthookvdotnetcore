using System.Diagnostics;
using System.Drawing;
using GTA;
using GTA.Native;
using GTA.UI;
using static GTA.Native.Function;

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
    protected override void OnStart()
    {
        base.OnStart();
        while (Game.IsLoading) Yield();
        Notification.Show("ScriptHookVDotNetCore 1.0.0 by Sardelka9515");
        Directory.CreateDirectory("CoreScripts");
        foreach (var script in Directory.GetFiles("CoreScripts"))
        {
            Core.RequestModuleLoad(script);
        }
    }

    protected override void OnTick()
    {
        base.OnTick();
    }
}