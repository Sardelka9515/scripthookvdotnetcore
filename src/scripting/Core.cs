using System.Runtime.InteropServices;
using GTA;

namespace SHVDN;

public static unsafe class Core
{
    public static HMODULE CurrentModule { get; set; }
    public static readonly HMODULE CoreModule = NativeLibrary.Load("ScriptHookVDotNetCore.asi");
    internal static delegate* unmanaged<void> ScriptYield = (delegate* unmanaged<void>)Import("ScriptYield");

    private static delegate* unmanaged<HMODULE, delegate* unmanaged<IntPtr, void>, bool> RegisterScriptFiber =
        (delegate* unmanaged<HMODULE, delegate* unmanaged<IntPtr, void>, bool>)Import("RegisterScript");

    private static delegate* unmanaged<IntPtr, void> ScheduleCallback =
        (delegate* unmanaged<IntPtr, void>)Import("ScheduleCallback");

    private static bool[] _keyboardState = new bool[256];
    private static bool _recordKeyboardEvents = true;

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

    private static List<Script> _scripts = new();

    public static IntPtr Import(string entryPoint)
        => NativeLibrary.GetExport(CoreModule, entryPoint);

    public static void PauseKeyEvents(bool pause)
    {
        _recordKeyboardEvents = !pause;
    }

    public static bool IsKeyPressed(Keys key)
    {
        return _keyboardState[(int)key];
    }

    /// <summary>
    /// Request a script fiber creation from the C++ core
    /// </summary>
    /// <param name="script">The script instance to create</param>
    /// <param name="callback">The callback to invoke when the script is registered or the request have failed</param>
    /// <remarks>The script is registerd from a worker thread. Do not wait the for the callback if calling this method during module initilization, otherwise a deadlock is expected</remarks>
    public static void RequestScriptCreation(Script script, Action<bool, Script> callback = null)
    {
        ScheduleCallback(Marshal.GetFunctionPointerForDelegate(() =>
        {
            try
            {
                if (!RegisterScriptFiber(CurrentModule,
                        (delegate* unmanaged<IntPtr, void>)Marshal.GetFunctionPointerForDelegate(script.ScriptEntry)))
                {
                    throw new ArgumentException(
                        $"An invalid module is supplied. Module: {CurrentModule}. Make sure you set SHVDN.Core.CurrentModule properly during module initialization");
                }

                lock (_scripts)
                {
                    _scripts.Add(script);
                }

                Logger.Info($"Script registered: {script}");
                callback?.Invoke(true, script);
            }
            catch (Exception ex)
            {
                callback?.Invoke(false, script);
                Logger.Error("Failed to request script creation: " + ex.ToString());
            }
        }));
    }

    public static void DoKeyEvent(Keys keys, bool status)
    {
        var e = new KeyEventArgs(keys);

        // Only update state of the primary key (without modifiers) here
        _keyboardState[(int)e.KeyCode] = status;

        if (_recordKeyboardEvents)
        {
            var eventinfo = new Tuple<bool, KeyEventArgs>(status, e);
            lock (_scripts)
            {
                foreach (Script script in _scripts)
                    script.KeyboardEvents.Enqueue(eventinfo);
            }
        }
    }
}