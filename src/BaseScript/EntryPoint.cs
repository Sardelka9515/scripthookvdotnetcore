using System.Runtime.InteropServices;
using System;

namespace SHVDN;

/// <summary>
/// Template for generating AOT entrypoints
/// </summary>
public static unsafe partial class EntryPoint
{

    [UnmanagedCallersOnly(EntryPoint = "OnInit")]
    public static void OnInit(HMODULE module)
    {
        try
        {
            ModuleSetup();
            Core.CurrentModule = module;
        }
        catch (Exception ex)
        {
            MessageBoxA(default, ex.ToString(), "Module initialization error", MB_OK);
            throw; // Crash the process
        }
    }

    /// <summary>
    /// Called prior to module unload
    /// </summary>
    /// <param name="module"></param>
    [UnmanagedCallersOnly(EntryPoint = "OnUnload")]
    public static void OnUnload(HMODULE module)
    {
        Core.CurrentModule = module;
        Core.DisposeScripts();
        for (int i = 0; i < 20; i++)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }

    [UnmanagedCallersOnly(EntryPoint = "OnKeyboard")]
    public static void OnKeyboard(DWORD key, ushort repeats, bool scanCode, bool isExtended, bool isWithAlt,
        bool wasDownBefore, bool isUpNow)
    {
        _keyboardMessage(
            key,
            !isUpNow,
            (GetAsyncKeyState(VK_CONTROL) & 0x8000) != 0,
            (GetAsyncKeyState(VK_SHIFT) & 0x8000) != 0,
            isWithAlt);
    }

    static void _keyboardMessage(DWORD keycode, bool keydown, bool ctrl, bool shift, bool alt)
    {
        // Filter out invalid key codes
        if (keycode <= 0 || keycode >= 256)
            return;

        // Convert message into a key event
        var keys = (Keys)keycode;
        if (ctrl) keys |= Keys.Control;
        if (shift) keys |= Keys.Shift;
        if (alt) keys |= Keys.Alt;
        Core.DoKeyEvent(keys, keydown);
    }

    [UnmanagedCallersOnly(EntryPoint = "OnTick")]
    public static void OnTick(LPVOID currentFiber)
    {
        Core.DoTick(currentFiber);
    }
}