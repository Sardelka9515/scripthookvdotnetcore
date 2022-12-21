using System.ComponentModel;
using System.Runtime.InteropServices;
using GTA;

namespace SHVDN;

public static unsafe class Core
{
    public static HMODULE CurrentModule { get; set; }
    public static readonly HMODULE CoreModule = NativeLibrary.Load("ScriptHookVDotNetCore.asi");

    internal static readonly delegate* unmanaged<string, HMODULE> LoadModuleA = (delegate* unmanaged<string, HMODULE>)Import("LoadModuleA");
    private static readonly delegate* unmanaged<IntPtr, void> ScheduleCallback = (delegate* unmanaged<IntPtr, void>)Import("ScheduleCallback");

    private static readonly bool[] KeyboardState = new bool[256];
    private static bool _recordKeyboardEvents = true;


    private static List<Script> _scripts = new();
    private static int _executingScriptIndex = -1;
    private static DWORD _mainThread;
    private static LPVOID _mainFiber;

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

    public static Script ExecutingScript
    {
        get
        {
            lock (_scripts)
            {
                return _executingScriptIndex < 0 ? null : _scripts[_executingScriptIndex];
            }
        }
    }

    public static IntPtr Import(string entryPoint)
        => NativeLibrary.GetExport(CoreModule, entryPoint);

    public static void PauseKeyEvents(bool pause)
    {
        _recordKeyboardEvents = !pause;
    }

    public static bool IsKeyPressed(Keys key)
    {
        return KeyboardState[(int)key];
    }

    /// <summary>
    /// Used internally to dispose all scripts on module unload, don't call this manually
    /// </summary>
    public static void DisposeScripts()
    {
        lock (_scripts)
        {
            foreach (Script script in _scripts)
            {
                try
                {
                    script.Dispose();
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
    /// Register a script instance, create associated fibers and begin executing
    /// </summary>
    /// <param name="script"></param>
    /// <param name="callback"></param>
    public static void RegisterScript(Script script)
    {
        // We don't use enumerator to iterate through scripts, so it's safe to add script in the same thread.
        lock (_scripts)
        {
            Logger.Info("Registering script: " + script.GetType().ToString());
            script.ScriptFiber = CreateFiber(default, script.PtrFiberEntry, default);
            if (script.ScriptFiber == default) { throw new Win32Exception(Marshal.GetLastWin32Error(),"Failed to create fiber"); }
            _scripts.Add(script);
            Logger.Info("Script registered: " + script.GetType().ToString());
        }
    }

    /// <summary>
    /// Request the C++ core to load a module in the worker thread
    /// </summary>
    /// <param name="modulePath"></param>
    /// <param name="callback">The callback to invoke when the module is loaded, with an argument passing the handle of loaded module, or <see cref="IntPtr.Zero"/> if the module failed to load</param>
    public static void RequestModuleLoad(string modulePath, Action<HMODULE> callback = null)
    {
        ScheduleCallback(Marshal.GetFunctionPointerForDelegate(() =>
        {
            HMODULE module = LoadModuleA(modulePath);
            callback?.Invoke(module);
        }));
    }

    /// <summary>
    /// Used internally to process keyboard events, don't call this manually
    /// </summary>
    /// <param name="keys"></param>
    /// <param name="status"></param>
    public static void DoKeyEvent(Keys keys, bool status)
    {
        var e = new KeyEventArgs(keys);

        // Only update state of the primary key (without modifiers) here
        KeyboardState[(int)e.KeyCode] = status;

        if (_recordKeyboardEvents)
        {
            var te = new Tuple<bool, KeyEventArgs>(status, e);
            lock (_scripts)
            {
                foreach (Script script in _scripts)
                    script.KeyboardEvents.Enqueue(te);
            }
        }
    }

    /// <summary>
    /// Used internally to process tick events, don't call this manually
    /// </summary>
    /// <param name="currentFiber"></param>
    public static void DoTick(LPVOID currentFiber)
    {
        _mainFiber = currentFiber;
        _mainThread = GetCurrentThreadId();
        lock (_scripts)
        {
            if (_scripts.Count > 0)
            {
                _executingScriptIndex = -1;
                // Switch to the first script's fiber to begin the ticking chain and wait for the last script to switch back
                SwitchToNextFiber();
                CleanupStrings();
            }
        }
    }

    /// <summary>
    /// Switch to next script fiber or back to main fiber if all scripts have finished execution in this tick
    /// </summary>
    internal static void SwitchToNextFiber()
    {
        LPVOID fiber;
        var time = GetTickCount64();
        while (++_executingScriptIndex < _scripts.Count && _scripts[_executingScriptIndex].Continue > time) ;
        if (_executingScriptIndex >= _scripts.Count)
        {
            _executingScriptIndex = -1;
            fiber = _mainFiber;
        }
        else
        {
            fiber = _scripts[_executingScriptIndex].ScriptFiber;
        }
        SwitchToFiber(fiber);
    }

    internal static void EnsureMainThread()
    {
        if (GetCurrentThreadId() != _mainThread)
            throw new InvalidOperationException("This function can only be called from main thread.");
    }
}