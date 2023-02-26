using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace SHVDN;

/// <summary>
/// Some imports of required WINAPI
/// </summary>
public static unsafe partial class PInvoke
{
    public static readonly HMODULE User32 = NativeLibrary.Load("User32.dll");
    public static readonly HMODULE Kernel32 = NativeLibrary.Load("Kernel32.dll");
    public static delegate* unmanaged[SuppressGCTransition]<ulong> GetTickCount64 = (delegate* unmanaged[SuppressGCTransition]<ulong>)NativeLibrary.GetExport(Kernel32, "GetTickCount64");
    public static delegate* unmanaged[SuppressGCTransition]<DWORD> GetCurrentThreadId = (delegate* unmanaged[SuppressGCTransition]<DWORD>)NativeLibrary.GetExport(Kernel32, "GetCurrentThreadId");
    public static delegate* unmanaged<HANDLE, string, string, uint, int> MessageBoxA = (delegate* unmanaged<HANDLE, string, string, uint, int>)NativeLibrary.GetExport(User32, "MessageBoxA");
    public static delegate* unmanaged<int, short> GetAsyncKeyState = (delegate* unmanaged<int, short>)NativeLibrary.GetExport(User32, "GetAsyncKeyState");
    public static string GetClipboardText()
    {
        if (!OpenClipboard(default)) throw new Win32Exception();
        var pChar = (char*)GetClipboardData(CF_UNICODETEXT);
        var text = new string(pChar);
        CloseClipboard();
        return text;
    }


    public static delegate* unmanaged<uint, IntPtr> GetClipboardData = (delegate* unmanaged<uint, IntPtr>)NativeLibrary.GetExport(User32, "GetClipboardData");

    public static delegate* unmanaged<IntPtr, bool> OpenClipboard = (delegate* unmanaged<IntPtr, bool>)NativeLibrary.GetExport(User32, "OpenClipboard");

    public static delegate* unmanaged<bool> CloseClipboard = (delegate* unmanaged<bool>)NativeLibrary.GetExport(User32, "CloseClipboard");

    [LibraryImport("kernel32.dll", SetLastError = true)]
    [PreserveSig]
    public static partial uint GetModuleFileNameW(HMODULE hModule, char* buf, uint nSize);

    [LibraryImport("kernel32.dll")]
    public static partial HANDLE GetConsoleWindow();


    [LibraryImport("kernel32.dll", EntryPoint = "RtlZeroMemory", SetLastError = false)]
    public static partial void ZeroMemory(HANDLE dest, HANDLE size);

    [LibraryImport("kernel32.dll", SetLastError = true)]
    public static partial uint CreateThread(LPVOID lpThreadAttributes,
        DWORD dwStackSize, HANDLE lpStartAddress,
        DWORD* lpParameter, DWORD dwCreationFlags, out DWORD lpThreadId);

    [LibraryImport("kernel32.dll", SetLastError = true)]
    public static partial DWORD WaitForSingleObject(HANDLE hHandle, DWORD dwMilliseconds);

    [LibraryImport("kernel32.dll", SetLastError = true)]
    public static partial HANDLE OpenThread(DWORD dwDesiredAccess, DWORD bInheritHandle, DWORD dwThreadId);


    [LibraryImport("kernel32.dll", SetLastError = true)]
    public static partial DWORD CloseHandle(HANDLE hObject);

    [LibraryImport("kernel32.dll", SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    public static partial HANDLE CreateEventW(IntPtr lpEventAttributes, [MarshalAs(UnmanagedType.Bool)] bool bManualReset, [MarshalAs(UnmanagedType.Bool)] bool bInitialState, string name);


    [LibraryImport("kernel32.dll", SetLastError = true)]
    public static partial BOOL SetEvent(HANDLE hObject);
}
