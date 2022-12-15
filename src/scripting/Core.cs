using System.Runtime.InteropServices;

namespace SHVDNC;
internal static unsafe class Core
{
    public static readonly IntPtr CoreModule = NativeLibrary.Load("ScriptHookVDotNetCore.asi");
    public static delegate* unmanaged<HMODULE, delegate* unmanaged<IntPtr,void>, bool> RegisterScript = (delegate* unmanaged<HMODULE, delegate* unmanaged<IntPtr,void>, bool>)Import("RegisterScript");
    public static delegate* unmanaged<void> ScriptYield = (delegate* unmanaged<void>)Import("ScriptYield");
    public static delegate* unmanaged<IntPtr, void> ScheduleCallback = (delegate* unmanaged<IntPtr, void>)Import("ScheduleCallback");
    public static IntPtr Import(string entryPoint)
        => NativeLibrary.GetExport(CoreModule, entryPoint);
}
