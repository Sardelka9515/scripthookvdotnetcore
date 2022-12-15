global using static PInvoke.Kernel32;
global using static PInvoke.User32;
global using static SHVDNC.ScriptHookV;
global using DWORD = System.Int32;
global using DWORD64 = System.Int64;
global using HANDLE = System.IntPtr;
global using LPVOID = System.IntPtr;
global using HINSTANCE = System.IntPtr;
global using HMODULE = System.IntPtr;
global using static SHVDNC.Globals;
global using static SHVDNC.NativeFunc;
global using static SHVDNC.Marshaller;

namespace SHVDNC;
public class Globals
{
    public const int DLL_PROCESS_ATTACH = 1;
    public const int DLL_PROCESS_DETACH = 0;
    public const int DLL_THREAD_ATTACH = 2;
    public const int DLL_THREAD_DETACH = 3;


    public const int BASE_WIDTH = 1280;
    public const int BASE_HEIGHT = 720;
}