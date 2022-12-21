using System.Runtime.InteropServices;
using GTA;

namespace SHVDN;

public static unsafe class Core
{
    public static HMODULE CurrentModule { get; set; }
    public static readonly HMODULE CoreModule = NativeLibrary.Load("ScriptHookVDotNetCore.asi");

    internal static readonly delegate* unmanaged<void> ScriptYield = (delegate* unmanaged<void>)Import("ScriptYield");
    internal static readonly delegate* unmanaged<string, HMODULE> LoadModuleA = (delegate* unmanaged<string, HMODULE>)Import("LoadModuleA");
    private static readonly delegate* unmanaged<HMODULE, delegate* unmanaged<IntPtr, void>, bool> RegisterScriptFiber = (delegate* unmanaged<HMODULE, delegate* unmanaged<IntPtr, void>, bool>)Import("RegisterScript");
    private static readonly delegate* unmanaged<IntPtr, void> ScheduleCallback = (delegate* unmanaged<IntPtr, void>)Import("ScheduleCallback");

    private static readonly bool[] KeyboardState = new bool[256];
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
        return KeyboardState[(int)key];
    }

    /// <summary>
    /// Request a script fiber creation from the C++ core
    /// </summary>
    /// <param name="script">The script instance to create</param>
    /// <param name="callback">The callback to invoke when the script is registered or the request have failed</param>
    /// <remarks>The script is registered from a worker thread. Do not wait the for the callback if calling this method during module initilization, otherwise a deadlock is expected</remarks>
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
                Logger.Error("Failed to request script creation: " + ex);
                callback?.Invoke(false, script);
            }
        }));
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
}