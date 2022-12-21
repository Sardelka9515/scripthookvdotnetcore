using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SHVDN;

/// <summary>
/// Some imports of required WINAPI
/// </summary>
public static unsafe class PInvoke
{
    public static readonly HMODULE User32 = NativeLibrary.Load("User32.dll");
    public static readonly HMODULE Kernel32 = NativeLibrary.Load("Kernel32.dll");
    public static delegate* unmanaged<ulong> GetTickCount64 = (delegate* unmanaged<ulong>)NativeLibrary.GetExport(Kernel32, "GetTickCount64");
    public static delegate* unmanaged<HANDLE,string,string,uint,int> MessageBoxA = (delegate* unmanaged<HANDLE, string, string, uint, int>)NativeLibrary.GetExport(User32, "MessageBoxA");
    public static delegate* unmanaged<int, short> GetAsyncKeyState = (delegate* unmanaged<int, short>)NativeLibrary.GetExport(User32, "GetAsyncKeyState");
}
