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
    
    /// <summary>
    /// Invoked every frame
    /// </summary>
    public event Action Tick;

    /// <summary>
    /// Invoked when a key is down
    /// </summary>
    public event Action<KeyEventArgs> KeyDown;

    /// <summary>
    /// Invoked when a key is up
    /// </summary>
    public event Action<KeyEventArgs> KeyUp;

    /// <summary>
    /// Invoked when the script is started
    /// </summary>
    public event Action Start;
    public Script()
    {
        // Need to store it somewhere to prevent GC from messing with it.
        ScriptEntry = ScriptMain;
    }

    /// <summary>
    /// Yield the execution back to other scripts and game engine for one frame
    /// </summary>
    public static void Yield() => Core.ScriptYield();

    /// <summary>
    /// Yield the execution and continue after specified time in milliseconds
    /// </summary>
    /// <param name="ms"></param>
    public static void Wait(ulong ms)
    {
        var start = GetTickCount64();
        do
        {
            Yield();
        }
        while (GetTickCount64() - start < ms);
    }

    /// <summary>
    /// Override this method only if you want to manually control the script fiber, you're responsible for the yielding and exception handling yourself.
    /// </summary>
    /// <param name="lParam"></param>
    protected virtual void ScriptMain(IntPtr lParam)
    {
        try
        {
            OnStart();
            while (true)
            {
                while (KeyboardEvents.TryDequeue(out var e))
                {
                    if (e.Item1)
                    {
                       OnKeyDown(e.Item2);
                    }
                    else
                    {
                        OnKeyUp(e.Item2);
                    }
                }
                OnTick();
                Core.ScriptYield();
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.ToString());
            UI.Notification.Show($"~r~{ex}");
        }
        // Continue yielding the execution
        while (true)
        {
            Core.ScriptYield();
        }
    }

    /// <summary>
    /// Remeber to call the base method when overriding
    /// </summary>
    protected virtual void OnStart()
    {
        Start?.Invoke();
    }

    /// <summary>
    /// Remeber to call the base method when overriding
    /// </summary>
    protected virtual void OnTick()
    {
        Tick?.Invoke();
    }

    /// <summary>
    /// Remeber to call the base method when overriding
    /// </summary>
    protected virtual void OnKeyDown(KeyEventArgs e)
    {
        KeyDown?.Invoke(e);
    }

    /// <summary>
    /// Remeber to call the base method when overriding
    /// </summary>
    protected virtual void OnKeyUp(KeyEventArgs e)
    {
        KeyUp?.Invoke(e);
    }
}
