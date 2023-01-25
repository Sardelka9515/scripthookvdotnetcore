using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using GTA.UI;

namespace GTA;

public unsafe abstract class Script
{
    public delegate void ScriptEntryDelegate(IntPtr lParam);
    private readonly ScriptEntryDelegate _fiberEntry;
    private bool _aborted;
    public Type ScriptType { get; private set; }
    internal ulong Continue = 0;
    internal readonly LPVOID PtrFiberEntry;
    internal Queue<Tuple<bool, KeyEventArgs>> KeyboardEvents = new();
    internal LPVOID ScriptFiber;

    /// <summary>
    /// Invoked every frame
    /// </summary>
    public event Action Tick;


    /// <summary>
    /// Invoked when the script is aborted, whether during the module unload or a manual call to <see cref="Abort"/>
    /// </summary>
    public event Action<AbortedEventArgs> Aborted;

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
        ScriptType = GetType();
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
            Logger.Error($"Script {ScriptType} was terminated as an unhandled exception has been caught:\n" + ex.ToString());
            Notification.Show($"~r~Unhandled exception~s~ in script \"~h~{ScriptType}~h~\"!~n~~n~~r~" + ex.GetType().Name + "~s~ " + ex.StackTrace.Split('\n').FirstOrDefault().Trim());
            var attribute = ScriptType.GetCustomAttributesData().FirstOrDefault(x => x.AttributeType.FullName == typeof(ScriptAttributes).FullName);
            var supportUrl = GetAttribute(typeof(ScriptAttributes), nameof(ScriptAttributes.SupportURL));
            if (supportUrl != null)
            {
                Logger.Error($"Please check the following site for support on the issue: {supportUrl}");
            }

            Abort(new AbortedEventArgs() { Exception = ex, IsUnloading = false });
        }


        // Continue yielding the execution, just in case
        while (true)
        {
            Yield();
        }
    }

    public object GetAttribute(Type attrType, string name)
    {
        var attribute = ScriptType.GetCustomAttributesData().FirstOrDefault(x => x.AttributeType == attrType);
        return (attribute?.NamedArguments.FirstOrDefault(x => x.MemberName == name))?.TypedValue;
    }

    /// <summary>
    /// Pause the script execution, can be called from any thread. If the call was made to and from currently executing script, the script will pause execution and block the caller's context immediately and indefinitely until resumed
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
        if (_aborted)
            throw new InvalidOperationException("The script has been aborted");

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

    /// <summary>
    /// Invoked when the script is aborted, might be called multiple times.
    /// </summary>
    /// <param name="args">The event arguments for the script abortion</param>
    /// <remarks> This will be called when an unhandled exception is caught,
    /// the module is unloading, or <see cref="Abort(AbortedEventArgs)"/> is called by user. 
    /// Use <paramref name="args"/> to gather more information about the event.
    /// Remeber to call the base method when overriding. 
    /// </remarks>
    protected virtual void OnAborted(AbortedEventArgs args)
    {
        Aborted?.Invoke(args);
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
        if (!_aborted)
            throw new InvalidOperationException("The script has not been aborted yet");

        if (ScriptFiber != default)
        {
            DeleteFiber(ScriptFiber);
            ScriptFiber = default;
        }
    }

    /// <summary>
    /// Basically has the same effect as <see cref="Pause"/>. Repective virtual method and event handlers will be called
    /// </summary>
    /// <remarks>
    /// Unlike SHVDN, this method does not actually abort the execution thread. 
    /// As all script lives in the game thread, blocking it will cause the game to hang forever 
    /// and this method won't have any effect
    /// </remarks>
    public void Abort(AbortedEventArgs args)
    {
        try
        {
            OnAborted(args);
        }
        catch (Exception ex)
        {
            Logger.Error($"Error during script abortion:\n {ex}");
        }
        finally
        {
            _aborted = true;
            Pause();
        }
    }
}

public class AbortedEventArgs : EventArgs
{
    /// <summary>
    /// Indicates whether the event is caused by module unload
    /// </summary>
    public bool IsUnloading { get; internal set; } = false;

    /// <summary>
    /// Carry the information about the error occurred if script is aborted due to an unhandled exception, otherwise, null
    /// </summary>
    public Exception Exception { get; internal set; } = null;

    /// <summary>
    /// User-supplied object to store the context about the event
    /// </summary>
    public object Context { get; set; }
}