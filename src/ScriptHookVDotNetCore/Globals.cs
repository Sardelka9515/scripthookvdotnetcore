global using System.Diagnostics.CodeAnalysis;
global using SHVDN;
global using GTA.Native;
global using static SHVDN.PInvoke;
global using static SHVDN.ScriptHookV;
global using DWORD = System.UInt32;
global using DWORD64 = System.UInt64;
global using HANDLE = System.IntPtr;
global using LPVOID = System.IntPtr;
global using PVOID = System.IntPtr;
global using BYTE = System.Byte;
global using HINSTANCE = System.IntPtr;
global using HMODULE = System.IntPtr;
global using static SHVDN.Globals;
global using static GTA.Native.Function;
global using static SHVDN.Marshaller;
global using NativeVector3 = GTA.Math.Vector3;

namespace SHVDN;

public class Globals
{
    public const int DLL_PROCESS_ATTACH = 1;
    public const int DLL_PROCESS_DETACH = 0;
    public const int DLL_THREAD_ATTACH = 2;
    public const int DLL_THREAD_DETACH = 3;


    public const int VK_CONTROL = 0x11;
    public const int VK_SHIFT = 0x10;

    public const uint MB_OK = 0x0;

    public const uint CF_UNICODETEXT = 13;

    public const string BASE_SCRIPT_NAME = "ScriptHookVDotNetCore.BaseScript.dll";
    public const string CONFIG_PATH = "ScriptHookVDotNetCore.ini";

    public const uint L_TRC = 0;
    public const uint L_DBG = 1;
    public const uint L_INF = 2;
    public const uint L_WRN = 3;
    public const uint L_ERR = 4;
    public const uint L_CRI = 5;
    public const uint L_OFF = 6;

    public const DWORD WAIT_ABANDONED = 0x00000080;
    public const DWORD WAIT_OBJECT_0 = 0x00000000;
    public const DWORD WAIT_TIMEOUT = 0x00000102;
    public const DWORD WAIT_FAILED = 0xFFFFFFFF;

    public const DWORD INFINITE = 0xFFFFFFFF;
}