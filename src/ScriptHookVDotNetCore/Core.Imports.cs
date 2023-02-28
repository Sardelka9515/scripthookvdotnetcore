using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using GTA;

namespace SHVDN
{
    struct ConfigStruct
    {
        public ushort UnloadKey;
        public ushort ReloadKey;
        public ushort MaxUnloadRetries;
        public ushort ConsoleKey;
    }

    public static unsafe partial class Core
    {

        public static readonly HMODULE AsiModule = NativeLibrary.Load("ScriptHookVDotNetCore.asi");
        public static readonly Version AsiVersion = Version.Parse(FileVersionInfo.GetVersionInfo("ScriptHookVDotNetCore.asi").FileVersion ?? "0.0.0.0");
        public static readonly Version ScriptingApiVersion = typeof(Core).Assembly.GetName().Version;
        public static readonly delegate* unmanaged<char*, void> ScheduleLoad = (delegate* unmanaged<char*, void>)Import("ScheduleLoad");
        public static readonly delegate* unmanaged<char*, void> ScheduleUnload = (delegate* unmanaged<char*, void>)Import("ScheduleUnload");
        public static readonly delegate* unmanaged<void> ScheduleUnoadAll = (delegate* unmanaged<void>)Import("ScheduleUnloadAll");
        public static readonly delegate* unmanaged<HMODULE*, int, int> ListModules = (delegate* unmanaged<HMODULE*, int, int>)Import("ListModules");
        public static readonly delegate* unmanaged<string, ulong> GetPtr = (delegate* unmanaged<string, ulong>)Import("GetPtr");
        public static readonly delegate* unmanaged<string, ulong, void> SetPtr = (delegate* unmanaged<string, ulong, void>)Import("SetPtr");
        internal static readonly delegate* unmanaged[SuppressGCTransition]<LPVOID> GetTls = (delegate* unmanaged[SuppressGCTransition]<LPVOID>)Import("GetTls");
        internal static readonly delegate* unmanaged[SuppressGCTransition]<LPVOID, void> SetTls = (delegate* unmanaged[SuppressGCTransition]<LPVOID, void>)Import("SetTls");
        internal static readonly delegate* unmanaged<LPVOID, HMODULE, LPVOID> ScriptRegister = (delegate* unmanaged<LPVOID, HMODULE, LPVOID>)Import("ScriptRegister");
        internal static readonly delegate* unmanaged<LPVOID, void> ScriptUnregister = (delegate* unmanaged<LPVOID, void>)Import("ScriptUnregister");
        internal static readonly delegate* unmanaged<DWORD64, void> ScriptWait = (delegate* unmanaged<DWORD64, void>)Import("ScriptWait");
        internal static readonly delegate* unmanaged<IntPtr, void> KeyboardHandlerRegister = (delegate* unmanaged<IntPtr, void>)Import("KeyboardHandlerRegister");
        internal static delegate* unmanaged<void> ReloadCoreConfig = (delegate* unmanaged<void>)Import("ReloadCoreConfig");
        internal static delegate* unmanaged<delegate* unmanaged<ulong, uint, IntPtr, void>, void> AddLogHandler = (delegate* unmanaged<delegate* unmanaged<ulong, uint, IntPtr, void>, void>)Import("AddLogHandler");
        internal static delegate* unmanaged<delegate* unmanaged<ulong, uint, IntPtr, void>, void> RemoveLogHandler = (delegate* unmanaged<delegate* unmanaged<ulong, uint, IntPtr, void>, void>)Import("RemoveLogHandler");

        public static IntPtr Import(string entryPoint)
            => NativeLibrary.GetExport(AsiModule, entryPoint);

        internal static readonly ConfigStruct* Config = (ConfigStruct*)GetPtr("Config");
    }
}
