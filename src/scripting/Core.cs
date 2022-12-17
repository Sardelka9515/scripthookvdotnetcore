using GTA;
using System.Runtime.InteropServices;

namespace SHVDN;
public static unsafe class Core
{
    public static readonly IntPtr CoreModule = NativeLibrary.Load("ScriptHookVDotNetCore.asi");
    public static delegate* unmanaged<HMODULE, delegate* unmanaged<IntPtr,void>, bool> RegisterScript = (delegate* unmanaged<HMODULE, delegate* unmanaged<IntPtr,void>, bool>)Import("RegisterScript");
    public static delegate* unmanaged<void> ScriptYield = (delegate* unmanaged<void>)Import("ScriptYield");
    public static delegate* unmanaged<IntPtr, void> ScheduleCallback = (delegate* unmanaged<IntPtr, void>)Import("ScheduleCallback");
    private static bool[] keyboardState = new bool[256];
    private static bool recordKeyboardEvents = true;

    public static List<Script> Scripts = new();
    public static IntPtr Import(string entryPoint)
        => NativeLibrary.GetExport(CoreModule, entryPoint);

    public static void PauseKeyEvents(bool pause)
    {
        recordKeyboardEvents = !pause;
    }
    public static bool IsKeyPressed(Keys key)
    {
        return keyboardState[(int)key];
    }

    public static void DoKeyEvent(Keys keys, bool status)
    {
        var e = new KeyEventArgs(keys);

        // Only update state of the primary key (without modifiers) here
        keyboardState[(int)e.KeyCode] = status;

        if (recordKeyboardEvents)
        {
            var eventinfo = new Tuple<bool, KeyEventArgs>(status, e);

            foreach (Script script in Scripts)
                script.KeyboardEvents.Enqueue(eventinfo);
        }
    }
}
