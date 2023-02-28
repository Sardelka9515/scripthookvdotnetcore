using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Linq;
using GTA.UI;

namespace GTA;
class NullTask : IScriptTask
{
    public static NullTask Null = null;
    public void Run() { }
}
public unsafe abstract class Script
{
    private bool _aborted = false;
    internal Thread ScriptThread;
    internal SemaphoreSlim WaitEvent = null;
    internal SemaphoreSlim ContinueEvent = null;
    internal ulong Continue = 0;
    internal ConcurrentQueue<Tuple<bool, KeyEventArgs>> KeyboardEvents = new();
    internal LPVOID ScriptTlsOrg;
    public readonly ScriptAttributes Attributes;
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
    public bool IsUsingThread => ScriptThread != null;

    public Script()
    {
        Name = GetType();
        _ = NativeMemory.ArmorOffset; // Initialize NativeMemory
        Attributes = GetType().GetCustomAttribute<ScriptAttributes>() ?? new();
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

                ScriptThread = new Thread(new ThreadStart(MainLoop));
                ScriptThread.Start();
            }
            else
            {
                OnStart();
            }
            Logger.Info($"Started script {Name}, thread:{(ScriptThread == null ? "null" : ScriptThread.ManagedThreadId)}.");
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
        Core.ExecuteTask(ref NullTask.Null);
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
    protected virtual void MainLoop()
    {
        try
        {
            ScriptTlsOrg = Core.GetTls();
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
        var supportUrl = Attributes.SupportURL;
        if (supportUrl != null)
        {
            Logger.Error($"Please check the following site for support on the issue: {supportUrl}");
        }
        if (!_aborted)
        {
            Abort(new AbortedEventArgs() { Exception = ex, IsUnloading = false });
        }
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
            Core.TryBreakToDebugger();
        }
        finally
        {
            Continue = ulong.MaxValue;
            _aborted = true;
            if (ScriptThread?.IsAlive == true)
            {
                ContinueEvent.Release();
                if (!ScriptThread.Join(5000))
                {
                    Logger.Error($"Failed to join script thread: {Name}, instability is expected after module unload");
                }
                else
                {
                    Logger.Debug($"Thread stopped: {Name}");
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