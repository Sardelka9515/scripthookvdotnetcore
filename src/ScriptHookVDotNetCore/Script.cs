using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using GTA.UI;

namespace GTA;

public unsafe class Script : IDisposable
{
    public delegate void ScriptEntryDelegate(IntPtr lParam);
    private readonly ScriptEntryDelegate _fiberEntry;
    internal ulong Continue = 0;
    internal readonly LPVOID PtrFiberEntry;
    internal ConcurrentQueue<Tuple<bool, KeyEventArgs>> KeyboardEvents = new();
    internal LPVOID ScriptFiber;

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
        _fiberEntry = ScriptMain;
        PtrFiberEntry = Marshal.GetFunctionPointerForDelegate(_fiberEntry);
    }

    /// <summary>
    /// Yield the execution back to other scripts and game engine for one frame
    /// </summary>
    public static void Yield()
    {
        Core.EnsureMainThread();
        Core.SwitchToNextFiber();
    }

    /// <summary>
    /// Yield the execution and continue after specified time in milliseconds
    /// </summary>
    /// <param name="ms"></param>
    public static void Wait(ulong ms)
    {
        Core.EnsureMainThread();
        var script = Core.ExecutingScript;
        if (script == null) throw new InvalidOperationException("No script is currently executing");
        script.Continue = GetTickCount64() + ms;
        Core.SwitchToNextFiber();
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
                Yield();
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex.ToString());
            Notification.Show($"~r~{ex}");
        }

        // Continue yielding the execution
        while (true)
        {
            Yield();
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

    public void Dispose()
    {
        if (ScriptFiber != default) DeleteFiber(ScriptFiber);
    }
}