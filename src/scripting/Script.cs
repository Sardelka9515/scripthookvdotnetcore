using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SHVDN;
namespace GTA;
public unsafe class Script
{
    public delegate void ScriptEntryDelegate(IntPtr lParam);
    internal readonly ScriptEntryDelegate ScriptEntry;
    internal ConcurrentQueue<Tuple<bool, KeyEventArgs>> KeyboardEvents = new();
    public event Action Tick;
    public event Action<KeyEventArgs> KeyDown;
    public event Action<KeyEventArgs> KeyUp;
    public event Action Start;
    public Script(IntPtr module)
    {
        // Need to store it somewhere to prevent GC from messing with it.
        ScriptEntry = ScriptMain;
        Core.ScheduleCallback(Marshal.GetFunctionPointerForDelegate(() =>
        {
            Core.RegisterScript(module, (delegate* unmanaged<IntPtr, void>)System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(ScriptEntry));
            Logger.Info($"Script registered: {GetType()}");
        }));
    }
    public static void Yield() => Core.ScriptYield();

    private void ScriptMain(IntPtr lParam)
    {
        try
        {
            Start?.Invoke();
            while (true)
            {
                while(KeyboardEvents.TryDequeue(out var e))
                {
                    if (e.Item1)
                    {
                        KeyDown?.Invoke(e.Item2);
                    }
                    else
                    {
                        KeyUp?.Invoke(e.Item2);
                    }
                }
                Tick?.Invoke();
                Core.ScriptYield();
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.ToString());
            UI.Notification.Show($"~r~{ex}");
        }
        while (true)
        {
            Core.ScriptYield();
        }
    }
}
