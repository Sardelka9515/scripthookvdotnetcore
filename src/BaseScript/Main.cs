﻿using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using SHVDN;
using GTA;
using System;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace SHVDN;
public static unsafe class Main
{


    [UnmanagedCallersOnly(EntryPoint = "OnInit")]
    public static void OnInit(HMODULE module)
    {
        try
        {
            Core.CurrentModule = module;
            Core.RequestScriptCreation(new BaseScript());
        }
        catch (Exception ex)
        {
            MessageBox(default, ex.ToString(), "Base script initialization error", MessageBoxOptions.MB_OK);
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
        for (int i=0; i < 20; i++)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }

    [UnmanagedCallersOnly(EntryPoint = "OnKeyboard")]
    public static void OnKeyboard(DWORD key, ushort repeats, bool scanCode, bool isExtended, bool isWithAlt, bool wasDownBefore, bool isUpNow)
    {
        keyboardMessage(
        key,
        !isUpNow,
        (GetAsyncKeyState(VK_CONTROL) & 0x8000) != 0,
        (GetAsyncKeyState(VK_SHIFT) & 0x8000) != 0,
        isWithAlt);

    }
    static void keyboardMessage(DWORD keycode, bool keydown, bool ctrl, bool shift, bool alt)
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
}