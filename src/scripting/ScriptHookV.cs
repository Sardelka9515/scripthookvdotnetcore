using System.Runtime.InteropServices;
namespace SHVDNC;
public static unsafe class ScriptHookV
{
    public static readonly IntPtr ShvModule = NativeLibrary.Load("ScriptHookV.dll");

    public static IntPtr Import(string entryPoint)
        => NativeLibrary.GetExport(ShvModule, entryPoint);
    static ScriptHookV()
    {
        ScriptWait = (delegate* unmanaged<ulong, void>)Import("?scriptWait@@YAXK@Z");
        ScriptRegister = (delegate* unmanaged<nint, delegate* unmanaged<void>, void>)Import("?scriptRegister@@YAXPEAUHINSTANCE__@@P6AXXZ@Z");
        ScriptUnregisterProc = (delegate* unmanaged<delegate* unmanaged<void>, void>)Import("?scriptUnregister@@YAXP6AXXZ@Z");
        ScriptUnregister = (delegate* unmanaged<HINSTANCE, void>)Import("?scriptUnregister@@YAXPEAUHINSTANCE__@@@Z");
        NativeInit = (delegate* unmanaged<ulong, void>)Import("?nativeInit@@YAX_K@Z");
        NativePush64 = (delegate* unmanaged<ulong, void>)Import("?nativePush64@@YAX_K@Z");
        NativeCall = (delegate* unmanaged<ulong*>)Import("?nativeCall@@YAPEA_KXZ");
    }
    public static delegate* unmanaged<ulong, void> ScriptWait;
    public static delegate* unmanaged<nint, delegate* unmanaged<void>, void> ScriptRegister;
    public static delegate* unmanaged<delegate* unmanaged<void>, void> ScriptUnregisterProc;
    public static delegate* unmanaged<HINSTANCE, void> ScriptUnregister;

    public static delegate* unmanaged<ulong, void> NativeInit;
    public static delegate* unmanaged<ulong, void> NativePush64;
    public static delegate* unmanaged<ulong*> NativeCall;

    #region Unused imports

    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?createTexture@@YAHPEBD@Z")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?drawTexture@@YAXHHHHMMMMMMMMMMMM@Z")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?getGameVersion@@YA?AW4eGameVersion@@XZ")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?getGlobalPtr@@YAPEA_KH@Z")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?getScriptHandleBaseAddress@@YAPEAEH@Z")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?keyboardHandlerRegister@@YAXP6AXKGEHHHH@Z@Z")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?keyboardHandlerUnregister@@YAXP6AXKGEHHHH@Z@Z")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?presentCallbackRegister@@YAXP6AXPEAX@Z@Z")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?presentCallbackUnregister@@YAXP6AXPEAX@Z@Z")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?worldGetAllObjects@@YAHPEAHH@Z")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?worldGetAllPeds@@YAHPEAHH@Z")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?worldGetAllPickups@@YAHPEAHH@Z")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?worldGetAllVehicles@@YAHPEAHH@Z")]
    // [DllImport("ScriptHookV.dll", ExactSpelling = true, EntryPoint = "?scriptRegisterAdditionalThread@@YAXPEAUHINSTANCE__@@P6AXXZ@Z")]

    #endregion
}