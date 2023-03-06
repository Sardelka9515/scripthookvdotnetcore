using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using GTA;
using System.Runtime.CompilerServices;

namespace SHVDN
{
    struct ConfigStruct
    {
        public ushort UnloadKey;
        public ushort ReloadKey;
        public ushort MaxUnloadRetries;
        public ushort ConsoleKey;
    }

    /// <summary>
    /// 32-bit bool for interop
    /// </summary>
    public struct BOOL
    {
        int value;
        public static implicit operator bool(BOOL b) => b.value != 0;
        public static implicit operator BOOL(bool b) => new() { value = b ? 1 : 0 };
    }
    public static unsafe partial class Core
    {
        public const string KEY_PTRRELOADED = "SHVDNC.ASI.PtrReloaded";
        public const string KEY_CORECLR_INITFUNC = "SHVDNC.CoreCLR.InitFuncAddr";
        public const string KEY_CORECLR_TICKFUNC = "SHVDNC.CoreCLR.TickFuncAddr";
        public const string KEY_CORECLR_KBHFUNC = "SHVDNC.CoreCLR.KeyboardFuncAddr";
        public const string KEY_CORECLR_CONSOLE_EXEC_FUNC = "SHVDN.CoreCLR.ExecuteConsoleCommandFuncAddr";
        public const string KEY_CORECLR_CONSOLE_REG_FUNC = "SHVDN.CoreCLR.RegisterConsoleCommandFuncAddr";
        public const string KEY_CORECLR_CONSOLE_PRINT_FUNC = "SHVDN.CoreCLR.PrintConsoleMessageFuncAddr";
        public const string KEY_CONFIGPTR = "SHVDN.ASI.PtrConfig";
        public static HMODULE AsiModule;
        public static Version AsiVersion { get; private set; }
        public static Version ScriptingApiVersion = typeof(Core).Assembly.GetName().Version;
        public static delegate* unmanaged<char*, void> ScheduleLoad { get; private set; }
        public static delegate* unmanaged<char*, void> ScheduleUnload { get; private set; }
        public static delegate* unmanaged<void> ScheduleUnoadAll { get; private set; }
        public static delegate* unmanaged<HMODULE*, int, int> ListModules { get; private set; }
        public static delegate* unmanaged<string, IntPtr> GetPtr { get; private set; }
        public static delegate* unmanaged<string, IntPtr, void> SetPtr { get; private set; }
        internal static delegate* unmanaged[SuppressGCTransition]<LPVOID> GetTls { get; private set; }
        internal static delegate* unmanaged[SuppressGCTransition]<LPVOID, void> SetTls { get; private set; }
        internal static delegate* unmanaged<LPVOID, HMODULE, LPVOID> ScriptRegister { get; private set; }
        internal static delegate* unmanaged<LPVOID, void> ScriptUnregister { get; private set; }
        internal static delegate* unmanaged<DWORD64, void> ScriptWait { get; private set; }
        internal static delegate* unmanaged<void> ReloadCoreConfig { get; private set; }
        internal static delegate* unmanaged<delegate* unmanaged<ulong, uint, IntPtr, void>, void> AddLogHandler { get; private set; }
        internal static delegate* unmanaged<delegate* unmanaged<ulong, uint, IntPtr, void>, void> RemoveLogHandler { get; private set; }
        internal static ConfigStruct* Config { get; private set; }

        public static IntPtr Import(string entryPoint)
            => NativeLibrary.GetExport(AsiModule, entryPoint);


        static void DoImport(HMODULE asiModule)
        {
            AsiModule = asiModule;
            AsiVersion = Version.Parse(FileVersionInfo.GetVersionInfo("ScriptHookVDotNetCore.asi").FileVersion ?? "0.0.0.0");
            ScheduleLoad = (delegate* unmanaged<char*, void>)Import("ScheduleLoad");
            ScheduleUnload = (delegate* unmanaged<char*, void>)Import("ScheduleUnload");
            ScheduleUnoadAll = (delegate* unmanaged<void>)Import("ScheduleUnloadAll");
            ListModules = (delegate* unmanaged<HMODULE*, int, int>)Import("ListModules");
            GetPtr = (delegate* unmanaged<string, IntPtr>)Import("GetPtr");
            SetPtr = (delegate* unmanaged<string, IntPtr, void>)Import("SetPtr");
            GetTls = (delegate* unmanaged[SuppressGCTransition]<LPVOID>)Import("GetTls");
            SetTls = (delegate* unmanaged[SuppressGCTransition]<LPVOID, void>)Import("SetTls");
            ScriptRegister = (delegate* unmanaged<LPVOID, HMODULE, LPVOID>)Import("ScriptRegister");
            ScriptUnregister = (delegate* unmanaged<LPVOID, void>)Import("ScriptUnregister");
            ScriptWait = (delegate* unmanaged<DWORD64, void>)Import("ScriptWait");
            ReloadCoreConfig = (delegate* unmanaged<void>)Import("ReloadCoreConfig");
            AddLogHandler = (delegate* unmanaged<delegate* unmanaged<ulong, uint, IntPtr, void>, void>)Import("AddLogHandler");
            RemoveLogHandler = (delegate* unmanaged<delegate* unmanaged<ulong, uint, IntPtr, void>, void>)Import("RemoveLogHandler");
            Config = (ConfigStruct*)GetPtr(KEY_CONFIGPTR);
            RuntimeHelpers.RunClassConstructor(typeof(Logger).TypeHandle);
        }
    }
}
