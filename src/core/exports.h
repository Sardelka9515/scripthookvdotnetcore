#include "pch.h"
#include "AotLoader.h"
#include "INIReader.h"
#include <winternl.h>
#include "Scripts.h"
#pragma once
typedef LPVOID(WINAPI* CallBackFunc)(LPVOID);
typedef VOID(WINAPI* LogHandler)(uint64_t time, uint32_t level, LPCSTR msg);
const LPCSTR KEY_PTRRELOADED = "SHVDNC.ASI.PtrReloaded";
const LPCSTR KEY_CORECLR_INITFUNC = "SHVDNC.CoreCLR.InitFuncAddr";
const LPCSTR KEY_CORECLR_TICKFUNC = "SHVDNC.CoreCLR.TickFuncAddr";
const LPCSTR KEY_CORECLR_KBHFUNC = "SHVDNC.CoreCLR.KeyboardFuncAddr";
const LPCSTR KEY_CORECLR_CONSOLE_EXEC_FUNC = "SHVDN.CoreCLR.ExecuteConsoleCommandFuncAddr";
const LPCSTR KEY_CORECLR_CONSOLE_REG_FUNC = "SHVDN.CoreCLR.RegisterConsoleCommandFuncAddr";
const LPCSTR KEY_CORECLR_CONSOLE_PRINT_FUNC = "SHVDN.CoreCLR.PrintConsoleMessageFuncAddr";
const LPCSTR KEY_CONFIGPTR = "SHVDN.ASI.PtrConfig";
inline WCHAR AsiPath[MAX_PATH];
inline vector<AotLoader*> Modules = {};
inline mutex ModulesMutex;
inline HMODULE CurrentModule;
inline queue<Job> JobQueue;
inline mutex JobMutex;
inline unordered_map<string, LPVOID> PtrMap;
inline mutex PtrMapMutex;
inline vector<LogHandler> LogHandlers = {};
inline mutex LogHandlersMutex;
inline wstring BaseDirectory;
#pragma region Internal

static inline HMODULE LoadModuleInternal(LPCWSTR path) {
	try {
		auto sPath = wstring(path);
		auto sName = sPath.substr(sPath.find_last_of(L"/\\") + 1);
		if (GetModuleHandleW(sName.c_str())) {
			throw runtime_error("Module with same name already loaded: " + WTS(sName));
		}
		auto script = new AotLoader(path);
		Modules.push_back(script);
		info("Loaded module {0}", string(script->ModulePath.begin(), script->ModulePath.end()));
		return script->Module;
	}
	catch (exception ex) {
		error(ex.what());
		return NULL;
	}
}
static inline void UnloadModuleInternal(AotLoader* loader) {

	// Unregister associated scripts
	auto script = Script::First;
	if (script) {
		do {
			if (script->Module == loader->Module)
				Script::Unregister(script);
			script = script->Next;
		} while (script);
	}

	// terminate all threads, free FLS and unload the module
	loader->Unload();
	delete loader;
}
static inline bool UnloadModuleInternal(LPCWSTR path) {
	wstring ws(path);
	string sPath(ws.begin(), ws.end());
	for (int i = 0; i < Modules.size(); i++) {
		if (Modules[i]->ModulePath.compare(path) == 0) {
			try {
				UnloadModuleInternal(Modules[i]);
				Modules.erase(next(Modules.begin(), i));
				return true;
			}
			catch (exception ex) {
				error("Failed to unload module {0}: {1}", sPath, ex.what());
				return false;
			}
		}
	}
	error("No module with such name was found");
	return false;
}
template<typename _func>
static inline bool TryInvoke(_func work, const char* msg) {
	try {
		work();
		return true;
	}
	catch (exception ex) {
		error(string(msg) + string(" failed: ") + ex.what());
		return false;
	}
}
#pragma endregion


DllExport HMODULE LoadModuleW(LPCWSTR path) {
	LOCK(ModulesMutex);
	return LoadModuleInternal(path);
}


DllExport bool UnloadModuleW(LPCWSTR path) {
	LOCK(ModulesMutex);
	return UnloadModuleInternal(path);
}
DllExport bool UnloadAllModules() {
	LOCK(ModulesMutex);
	bool bResult = true;
	try {

		for (int i = 0; i < Modules.size(); i++) {
			try {
				UnloadModuleInternal(Modules[i]);
			}
			catch (exception ex) {
				string sPath(Modules[i]->ModulePath.begin(), Modules[i]->ModulePath.end());
				error("Failed to unload module {0}: {1}", sPath, ex.what());
				bResult = false;
			}
		}
		Modules.clear();
	}
	catch (exception ex) {
		error("Error during module unload: {}", ex.what());
		bResult = false;
	}
	return bResult;
}
DllExport void ScheduleTask(Job job) {
	LOCK(JobMutex);
	JobQueue.push(job);
}
DllExport void ScheduleLoad(LPCWSTR path) {
	Job j = {};
	j.Type = J_LOAD;
	j.Parameter = (LPVOID)new wstring(path);
	ScheduleTask(j);
}
DllExport void ScheduleUnload(LPCWSTR path) {
	Job j = {};
	j.Type = J_UNLOAD;
	j.Parameter = (LPVOID)new wstring(path);
	ScheduleTask(j);
}
DllExport void ScheduleUnloadAll() {
	Job j = {};
	j.Type = J_UNLOAD_ALL;
	ScheduleTask(j);
}
// Obsolete
DllExport void ScheduleCallback(VoidFunc callback) {
	Job j = {};
	j.Type = J_CALLBACK;
	j.Parameter = (LPVOID)callback; // Works despite different signature
	ScheduleTask(j);
}

#pragma region ANSI

DllExport HMODULE LoadModuleA(LPCSTR path) {
	auto sPath = string(path);
	return LoadModuleW(STW(sPath).c_str());
}

DllExport bool UnloadModuleA(LPCSTR path) {
	auto sPath = string(path);
	return UnloadModuleW(STW(sPath).c_str());
}

DllExport int32_t ListModules(HMODULE* buf, int32_t bufSize) {
	try {
		int i = 0;
		for (auto pMod : Modules) {
			buf[i++] = pMod->Module;
			if (i >= bufSize) { break; }
		}
		return i;
	}
	catch (exception ex) {
		error("Failed to list modules {}", ex.what());
		return false;
	}
}
#pragma endregion

#pragma region Logger

DllExport void LogTrace(LPCSTR msg) {
	trace(msg);
}

DllExport void LogDebug(LPCSTR msg) {
	debug(msg);
}


DllExport void LogInfo(LPCSTR msg) {
	info(msg);
}

DllExport void LogWarn(LPCSTR msg) {
	warn(msg);
}

DllExport void LogError(LPCSTR msg) {
	error(msg);
}

DllExport void LogCritical(LPCSTR msg) {
	critical(msg);
}


DllExport void LogTraceW(LPCWSTR msg) {
	trace(PWTS(msg));
}

DllExport void LogDebugW(LPCWSTR msg) {
	debug(PWTS(msg));
}


DllExport void LogInfoW(LPCWSTR msg) {
	info(PWTS(msg));
}

DllExport void LogWarnW(LPCWSTR msg) {
	warn(PWTS(msg));
}

DllExport void LogErrorW(LPCWSTR msg) {
	error(PWTS(msg));
}

DllExport void LogCriticalW(LPCWSTR msg) {
	critical(PWTS(msg));
}

#pragma endregion

// Internal function, called when the game loads a save
static void PtrMapProcessReload() {
	LOCK(PtrMapMutex);
	erase_if(PtrMap, [](pair<string, LPVOID> ptrPair) {
		return ptrPair.first.rfind("SHVDN.", 0) == 0;
		});
}


DllExport LPVOID GetPtr(LPCSTR key) {
	LOCK(PtrMapMutex);
	auto i_ptr = PtrMap.find(string(key));
	return i_ptr == PtrMap.end() ? NULL : i_ptr->second;
}
DllExport void SetPtr(LPCSTR key, LPVOID value) {
	LOCK(PtrMapMutex);
	PtrMap[key] = value;
}
DllExport void ClearAllPtr() {
	LOCK(PtrMapMutex);
	PtrMap.clear();
}
DllExport void RemovePtr(LPCSTR key) {
	LOCK(PtrMapMutex);
	auto i = PtrMap.find(string(key));
	if (i != PtrMap.end()) {
		PtrMap.erase(i);
	}
}
DllExport void AddLogHandler(LogHandler lh) {
	try {
		LOCK(LogHandlersMutex);
		LogHandlers.push_back(lh);
	}
	catch (exception ex) {
		error(ex.what());
	}
}
DllExport void RemoveLogHandler(LogHandler lh) {
	try {
		LOCK(LogHandlersMutex);
		LogHandlers.erase(remove_if(LogHandlers.begin(), LogHandlers.end(), [lh](LogHandler toCheck) {return toCheck == lh; }));
	}
	catch (exception ex) {
		error(ex.what());
	}
}
DllExport void ReloadCoreConfig() {
	INIReader reader(CONFIG_PATH);
	Config.AllocDebugConsole = reader.GetBoolean("", "AllocDebugConsole", Config.AllocDebugConsole);
	Config.SkipLegalScreen = reader.GetBoolean("", "SkipLegalScreen", Config.SkipLegalScreen);
}
DllExport void SetTls(LPVOID tls) {
	__writegsqword(0x58, (DWORD64)tls);
}
DllExport LPVOID GetTls() {
	return (LPVOID)__readgsqword(0x58);
}
DllExport Script* ScriptRegister(VoidFunc scriptEntry, HMODULE module) {
	return Script::Register(scriptEntry, module);
}
DllExport Script* GetCurrentScript() {
	return Script::GetCurrent();
}
DllExport void ScriptUnregister(Script* script) {
	Script::Unregister(script);
}
DllExport void ScriptWait(DWORD64 milliSeconds) {
	Script::Wait(milliSeconds);
}