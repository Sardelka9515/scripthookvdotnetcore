using System.Runtime.InteropServices;
using System;
using GTA;

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
            Core.CurrentModule = module;
            ModuleSetup();
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
        Core.OnUnload();
    }

    [UnmanagedCallersOnly(EntryPoint = "OnKeyboard")]
    public static void OnKeyboard(DWORD key, ushort repeats, bool scanCode, bool isExtended, bool isWithAlt,
        bool wasDownBefore, bool isUpNow)
    {
        Core.DoKeyEvent(
            key,
            !isUpNow,
            (GetAsyncKeyState(VK_CONTROL) & 0x8000) != 0,
            (GetAsyncKeyState(VK_SHIFT) & 0x8000) != 0,
            isWithAlt);
    }

    [UnmanagedCallersOnly(EntryPoint = "OnTick")]
    public static void OnTick(LPVOID currentFiber)
    {
        Core.DoTick(currentFiber);
    }
}