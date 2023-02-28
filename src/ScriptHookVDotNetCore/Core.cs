using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GTA;
using GTA.UI;

namespace SHVDN;
#region API bridge

public class ScriptDomain
{
    public static readonly ScriptDomain CurrentDomain = new();
    public bool IsKeyPressed(Keys k) => Core.IsKeyPressed(k);
    public void PauseKeyEvents(bool pause) => Core.PauseKeyEvents(pause);
    public IntPtr PinString(ReadOnlySpan<char> str) => Marshaller.PinString(str);

    public void ExecuteTask<T>(ref T task) where T : IScriptTask => Core.ExecuteTask(ref task);
}
public static class NativeFunc
{
    public static void PushLongString(ReadOnlySpan<char> str, PushCallBack cb) => Function.PushLongString(str, cb);
    public static void PushLongString(ReadOnlySpan<char> str) => Function.PushLongString(str);
}
public interface IScriptTask
{
    public void Run();
}

#endregion

public static unsafe partial class Core
{
#if NATIVEAOT
    public static HMODULE CurrentModule { get; private set; }
#endif
    private static bool[] KeyboardState = new bool[256];
    private static bool _recordKeyboardEvents = true;

    private static List<Script> _scripts = new();
    private static DWORD _mainThread;

    private static IScriptTask _toExecute;
    internal static LPVOID GameTls;

    /// <summary>
    /// List all scripts in this module
    /// </summary>
    /// <returns>A copy of all registered <see cref="Script"/> instances.</returns>
    public static List<Script> ListScripts()
    {
        lock (_scripts)
        {
            return new List<Script>(_scripts);
        }
    }

    public static Script ExecutingScript { get; private set; }

    public static void PauseKeyEvents(bool pause)
    {
        _recordKeyboardEvents = !pause;
    }

    public static bool IsKeyPressed(Keys key)
    {
        return KeyboardState[(int)key];
    }

    /// <summary>
    /// Abort alls scripts and delete associated fibers
    /// </summary>
    internal static void DisposeScripts()
    {
        lock (_scripts)
        {
            foreach (Script script in _scripts)
            {
                try
                {
                    script.Abort(new AbortedEventArgs() { IsUnloading = true });
                }
                catch (Exception ex)
                {
                    Logger.Error($"Error disposing script: {ex}");
                }
            }
            _scripts.Clear();
        }
    }

    /// <summary>
    /// Register a script instance, create associated fiber, register commands and begin the execution once the script thread has been launched
    /// </summary>
    /// <param name="script">The script instance to register</param>
    public static void RegisterScript(Script script)
    {
        // We don't use enumerator to iterate through scripts, so it's safe to add script in the same thread.
        lock (_scripts)
        {
            var type = script.Name;
            var attri = script.Attributes;
            if (attri.SingleInstance && _scripts.Any(x => x.Name == type))
                throw new InvalidOperationException($"A script with the same type has already been registered");

            if (_scripts.Any(x => ReferenceEquals(x, script)))
                throw new InvalidOperationException($"Same script object has already been registered");

            _scripts.Add(script);
            script.Start(!attri.NoScriptThread);
        }
    }


    /// <summary>
    /// Don't use
    /// </summary>
    public static void DoTick(LPVOID currentFiber)
    {
        _mainThread = GetCurrentThreadId();
        GameTls = GetTls();
        lock (_scripts)
        {
            // Execute running scripts
            for (int i = 0; i < _scripts.Count; i++)
            {

                var script = _scripts[i];

                if (script.Continue > GetTickCount64())
                    continue;

                _toExecute = null;
                ExecutingScript = script;

                try
                {
                    if (script.IsUsingThread)
                    {
                        bool finishedInTime;
                    nextTask:
                        finishedInTime = SignalAndWait(script.ContinueEvent, script.WaitEvent, 5000);

                        if (!finishedInTime && !Debugger.IsAttached)
                        {
                            throw new TimeoutException("Script execution has timed out after 5 seconds.");
                        }
                        if (_toExecute != null)
                        {
                            _toExecute.Run();
                            goto nextTask;
                        }
                    }
                    else
                    {
                        script.DoTick();
                    }
                    ExecutingScript = null;
                }
                catch (Exception ex)
                {
                    ExecutingScript = null;
                    script.HandleException(ex);
                }

            }

            CleanupStrings();
        }
    }

    /// <summary>
    /// Don't use
    /// </summary>
    public static void DoKeyEvent(DWORD key, bool down, bool ctrl, bool shift, bool alt)
    {
        if (key <= 0 || key >= 256)
            return;

        // Convert message into a key event
        var keys = (Keys)key;
        if (ctrl) keys |= Keys.Control;
        if (shift) keys |= Keys.Shift;
        if (alt) keys |= Keys.Alt;

        KeyboardState[key] = down;

        if (_recordKeyboardEvents)
        {
            var te = new Tuple<bool, KeyEventArgs>(down, new KeyEventArgs(keys));
            lock (_scripts)
            {
                foreach (Script script in _scripts)
                    script.KeyboardEvents.Enqueue(te);
            }
        }
    }

    public static void OnInit(IntPtr lparam)
    {
        _mainThread = GetCurrentThreadId();
        GameTls = GetTls();
        if (AsiVersion < ScriptingApiVersion)
        {
            MessageBoxA(default, $"Current ScriptHookVDotNetCore version is {AsiVersion}, while {ScriptingApiVersion} or higher is required. Update ScriptHookVDotNetCore if you experience random crashes", "Warning", default);
        }
#if NATIVEAOT

        CurrentModule = lparam;
#else
        if (lparam != default)
            FindAndRegisterAllScripts();
#endif
    }

    /// <summary>
    /// Don't use
    /// </summary>
    public static void OnUnload(HMODULE currentModule)
    {
#if NATIVEAOT
        CurrentModule = currentModule;
#endif
        DisposeScripts();
        _scripts = null;
        KeyboardState = null;
        GTA.Console.OnUnload();
        Marshaller.OnUnload();
        NativeLibrary.Free(AsiModule);
        for (int i = 0; i < 20; i++)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }

    /// <summary>
    /// Determine if the current thread is the main script thread
    /// </summary>
    public static bool IsMainThread() => GetCurrentThreadId() == _mainThread;

    internal static void EnsureMainThread()
    {
        if (!IsMainThread())
            throw new InvalidOperationException("This function can only be called from main thread.");
    }

    /// <summary>
    /// Dispatch the task to main thread and wait for it to finish if the script is running in a dedicated thread, otherwise, execute it directly
    /// </summary>
    /// <param name="task"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public static void ExecuteTask<T>(ref T task) where T : IScriptTask
    {
        if (GetTls() == GameTls)
        {
            task?.Run();
            return;
        }

        var script = ExecutingScript;
        if (script?.ScriptThread != Thread.CurrentThread)
            throw new InvalidOperationException("Cannot execute task from non-script thread");

        _toExecute = task;
        SignalAndWait(script.WaitEvent, script.ContinueEvent);
        task = (T)_toExecute;
        _toExecute = null;
    }

    static void SignalAndWait(SemaphoreSlim toSignal, SemaphoreSlim toWaitOn)
    {
        toSignal.Release();
        toWaitOn.Wait();
    }
    static bool SignalAndWait(SemaphoreSlim toSignal, SemaphoreSlim toWaitOn, int timeout)
    {
        toSignal.Release();
        return toWaitOn.Wait(timeout);
    }

    public static void TryBreakToDebugger()
    {
        if (Debugger.IsAttached)
            Debugger.Break();
    }
}