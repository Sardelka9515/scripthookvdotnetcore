using System.Runtime.InteropServices;

namespace SHVDN;

public static unsafe class ScriptHookV
{
    public static readonly IntPtr ShvModule = NativeLibrary.Load("ScriptHookV.dll");

    public static IntPtr Import(string entryPoint)
        => NativeLibrary.GetExport(ShvModule, entryPoint);

    static ScriptHookV()
    {
        ScriptWait = (delegate* unmanaged[SuppressGCTransition]<ulong, void>)Import("?scriptWait@@YAXK@Z");
        NativeInit = (delegate* unmanaged[SuppressGCTransition]<ulong, void>)Import("?nativeInit@@YAX_K@Z");
        NativePush64 = (delegate* unmanaged[SuppressGCTransition]<InputArgument, void>)Import("?nativePush64@@YAX_K@Z");
        NativeCall = (delegate* unmanaged[SuppressGCTransition]<ulong*>)Import("?nativeCall@@YAPEA_KXZ");
        GetGlobalPtr = (delegate* unmanaged[SuppressGCTransition]<int, IntPtr>)Import("?getGlobalPtr@@YAPEA_KH@Z");
    }

    public static delegate* unmanaged[SuppressGCTransition]<ulong, void> ScriptWait;

    public static delegate* unmanaged[SuppressGCTransition]<ulong, void> NativeInit;
    public static delegate* unmanaged[SuppressGCTransition]<InputArgument, void> NativePush64;
    public static delegate* unmanaged[SuppressGCTransition]<ulong*> NativeCall;

    public static delegate* unmanaged[SuppressGCTransition]<int, IntPtr> GetGlobalPtr;

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