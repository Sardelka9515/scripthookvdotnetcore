global using SHVDN;
global using GTA.Native;
global using static SHVDN.PInvoke;
global using static SHVDN.ScriptHookV;
global using DWORD = System.Int32;
global using DWORD64 = System.Int64;
global using HANDLE = System.IntPtr;
global using LPVOID = System.IntPtr;
global using HINSTANCE = System.IntPtr;
global using HMODULE = System.IntPtr;
global using static SHVDN.Globals;
global using static GTA.Native.Function;
global using static SHVDN.Marshaller;

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
}