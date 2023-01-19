﻿using System.Collections.Concurrent;
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
    public event Action Started;

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
        var time = GetTickCount64();
        script.Continue = unchecked(time + ms);
        // Overflow check
        if (script.Continue < time || script.Continue < ms) script.Continue = ulong.MaxValue;
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
            Logger.Error($"Script {GetType()} was terminated as an unhandled exception has been caught:\n" + ex.ToString());
            Notification.Show("~r~Unhandled exception~s~ in script \"~h~" + GetType().ToString() + "~h~\"!~n~~n~~r~" + ex.GetType().Name + "~s~ " + ex.StackTrace.Split('\n').FirstOrDefault().Trim());
            var attribute = GetType().GetCustomAttributesData().FirstOrDefault(x => x.AttributeType.FullName == typeof(ScriptAttributes).FullName);
            var supportUrl = GetAttribute(typeof(ScriptAttributes), nameof(ScriptAttributes.SupportURL));
            if (supportUrl != null)
            {
                Logger.Error($"Please check the following site for support on the issue: {supportUrl}");
            }
        }

        Pause();

        // Continue yielding the execution, just in case
        while (true)
        {
            Yield();
        }
    }

    public object GetAttribute(Type attrType, string name)
    {
        var attribute = GetType().GetCustomAttributesData().FirstOrDefault(x => x.AttributeType == attrType);
        return (attribute?.NamedArguments.FirstOrDefault(x => x.MemberName == name))?.TypedValue;
    }

    /// <summary>
    /// Pause the script execution, can be called from any thread. If the call was made to and from currently executing script, the script will pause execution immediately until it was resumed by another script or thread
    /// </summary>
    public void Pause()
    {
        Continue = ulong.MaxValue;
        if (Core.IsMainThread() && this == Core.ExecutingScript) { Yield(); }
    }

    /// <summary>
    /// Resume script execution
    /// </summary>
    public void Resume()
    {
        Continue = 0;
    }

    /// <remarks>
    /// Remeber to call the base method when overriding
    /// </remarks>
    protected virtual void OnStart()
    {
        Started?.Invoke();
    }

    /// <remarks>
    /// Remeber to call the base method when overriding
    /// </remarks>
    protected virtual void OnTick()
    {
        Tick?.Invoke();
    }

    /// <remarks>
    /// Remeber to call the base method when overriding
    /// </remarks>
    protected virtual void OnKeyDown(KeyEventArgs e)
    {
        KeyDown?.Invoke(e);
    }

    /// <remarks>
    /// Remeber to call the base method when overriding
    /// </remarks>
    protected virtual void OnKeyUp(KeyEventArgs e)
    {
        KeyUp?.Invoke(e);
    }

    public void Dispose()
    {
        if (ScriptFiber != default) DeleteFiber(ScriptFiber);
    }
}