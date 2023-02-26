using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml.Linq;
using GTA.UI;

namespace GTA;
class NullTask : IScriptTask
{
    public void Run() { }
}
public unsafe abstract class Script
{
    private bool _aborted = false;

    /// <summary>
    /// Unmanaged thread id of the script thread
    /// </summary>
    internal uint ThreadId;
    internal SemaphoreSlim WaitEvent = null;
    internal SemaphoreSlim ContinueEvent = null;
    internal ulong Continue = 0;
    internal ConcurrentQueue<Tuple<bool, KeyEventArgs>> KeyboardEvents = new();
    public Type Name { get; private set; }

    /// <summary>
    /// Gets or sets the interval in ms between each <see cref="Tick"/>.
    /// </summary>
    public ulong Interval { get; set; }

    /// <summary>
    /// Gets whether this is the currently executing script.
    /// </summary>
    public bool IsExecuting => Core.ExecutingScript == this;

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

    /// <summary>
    /// Gets whether a dedicated thread is hosting the execution of this script.
    /// </summary>
    public bool IsUsingThread => ThreadId != default;

    public Script()
    {
        Name = GetType();
        _ = SHVDN.NativeMemory.ArmorOffset; // Initialize NativeMemory
    }

    internal void DoTick()
    {
        // Process keyboard events
        while (KeyboardEvents.TryDequeue(out Tuple<bool, KeyEventArgs> ev))
        {
            if (!ev.Item1)
                OnKeyUp(ev.Item2);
            else
                OnKeyDown(ev.Item2);
        }

        OnTick();
    }

    /// <summary>
    /// Starts execution of this script.
    /// </summary>
    public void Start(bool useThread = true)
    {
        try
        {
            if (useThread)
            {
                WaitEvent = new(0);
                ContinueEvent = new(0);
                CreateThread(default, 0, Marshal.GetFunctionPointerForDelegate(MainLoop), null, 0, out ThreadId);
            }
            else
            {
                OnStart();
            }
            Logger.Info($"Started script {Name}, thread:{ThreadId}.");
        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }

    /// <summary>
    /// Yield the execution back to other scripts and game engine for one frame
    /// </summary>
    public static void Yield()
    {
        var script = Core.ExecutingScript;
        if (script == null)
            throw new InvalidOperationException("No script is currently executing");

        Yield(script);
    }

    /// <summary>
    /// Yield the execution and continue after specified time in milliseconds
    /// </summary>
    /// <param name="ms"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public static void Wait(ulong ms)
    {
        var script = Core.ExecutingScript;
        if (script == null)
            throw new InvalidOperationException("No script is currently executing");

        Wait(script, ms);
    }

    /// <summary>
    /// Yield the execution back to other scripts and game engine for one frame
    /// </summary>
    public static unsafe void Yield(Script script)
    {
        if (!script.IsUsingThread)
            throw new InvalidOperationException("Cannot yield execution when not running in script thread");

        script.ThrowIfAborted();
        NullTask yieldTask = null;
        Core.ExecuteTask(ref yieldTask);
    }

    /// <summary>
    /// Yield the execution and continue after specified time in milliseconds
    /// </summary>
    /// <param name="script"></param>
    /// <param name="ms"></param>
    public static void Wait(Script script, ulong ms)
    {
        script.ThrowIfAborted();
        if (script.IsUsingThread)
        {
            var time = GetTickCount64();
            script.Continue = unchecked(time + ms);
            // Overflow check
            if (script.Continue < time || script.Continue < ms) script.Continue = ulong.MaxValue;

            Yield(script);
        }
        else
        {
            throw new InvalidOperationException($"Cannot yield execution as script {script.Name} is not running in a dedicated thread");
        }
    }

    /// <summary>
    /// Override this method only if you want to manually control the script execution flow, you're responsible for the yielding and exception handling yourself.
    /// </summary>
    protected virtual int MainLoop(IntPtr lparam)
    {
        try
        {
            ContinueEvent.Wait();
            OnStart();
            Yield(this);

            while (!_aborted)
            {
                DoTick();

                if (Interval != default)
                    Wait(this, Interval);
                else
                    Yield(this);
            }
        }
        catch (ScriptAbortedException) { }
        catch (Exception ex)
        {
            HandleException(ex);
        }
        return 0;
    }

    /// <summary>
    /// Generate respective error message and abort script execution
    /// </summary>
    /// <param name="ex"></param>
    internal void HandleException(Exception ex)
    {
        Logger.Error($"Script {Name} was terminated as an unhandled exception has been caught:\n" + ex.ToString());
        if (Core.GameTls == Core.GetTls())
        {
            Notification.Show($"~r~Unhandled exception~s~ in script \"~h~{Name}~h~\"!~n~~n~~r~" + ex.GetType().Name + "~s~ " + ex.StackTrace.Split('\n').FirstOrDefault().Trim());
        }
        var supportUrl = GetAttribute(nameof(ScriptAttributes.SupportURL));
        if (supportUrl != null)
        {
            Logger.Error($"Please check the following site for support on the issue: {supportUrl}");
        }
        if (!_aborted)
        {
            Abort(new AbortedEventArgs() { Exception = ex, IsUnloading = false });
        }
    }

    public object GetAttribute(string name) => GetAttribute(typeof(ScriptAttributes), name);

    public object GetAttribute(Type attrType, string name)
    {
        var attribute = Name.GetCustomAttributesData().FirstOrDefault(x => x.AttributeType == attrType);
        return (attribute?.NamedArguments.FirstOrDefault(x => x.MemberName == name))?.TypedValue.Value;
    }

    public void Pause()
    {
        Continue = ulong.MaxValue;
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

    public void Abort(AbortedEventArgs e)
    {
        try
        {
            OnAborted(e);
        }
        catch (Exception ex)
        {
            Logger.Error($"Error during script abortion:\n {ex}");
        }
        finally
        {
            Continue = ulong.MaxValue;
            _aborted = true;
            if (IsUsingThread)
            {
                var hThread = OpenThread(0x00100000, FALSE, ThreadId);
                if (hThread != default)
                {
                    ContinueEvent.Release();
                    if (WaitForSingleObject(hThread, 5000) != WAIT_OBJECT_0)
                    {
                        Logger.Error($"Failed to join script thread: {Name}, crash expected after module unload");
                    }
                    else
                    {
                        Logger.Debug($"Thread stopped: {Name}");
                    }
                    CloseHandle(hThread);
                }
                else
                {
                    Logger.Error("Failed to open script thread");
                }
            }
        }
    }

    internal void ThrowIfAborted()
    {
        if (_aborted) throw new ScriptAbortedException();
    }
}

public class ScriptAbortedException : Exception
{
    public ScriptAbortedException() : base("The script has been aborted") { }
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