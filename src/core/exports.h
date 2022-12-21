#include "pch.h"
#include "AotLoader.h"
#pragma once
vector<AotLoader*> Modules = {};
mutex ModulesMutex;
HMODULE CurrentModule;
queue<VoidFunc> JobQueue;
mutex JobMutex;
LPVOID MainFiber;
#pragma region Internal

HMODULE LoadModuleInternal(LPCWSTR path) {
	try {
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

bool UnloadModuleInternal(LPCWSTR path) {
	wstring ws(path);
	string sPath(ws.begin(), ws.end());
	for (int i = 0; i < Modules.size(); i++) {
		if (Modules[i]->ModulePath.compare(path) == 0) {
			try {
				// terminate all threads, free FLS and unload the module
				Modules[i]->Unload();
				delete Modules[i];
				Modules.erase(next(Modules.begin(), i));
				return true;
			}
			catch (exception ex) {
				error("Failed to unload module {0}: {1}", sPath, ex.what());
				return false;
			}
		}
	}
	error("No script with such name was found");
	return false;
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

DllExport SIZE_T ListScripts(HMODULE pathBuffer[], SIZE_T maxSize) {
	LOCK(ModulesMutex);
	auto size = Modules.size();
	for (SIZE_T i = 0; i < maxSize && i < size; i++) {
		pathBuffer[i] = Modules[i]->Module;
	}
	return size;
}

DllExport bool UnloadAllModules() {
	LOCK(ModulesMutex);
	bool bResult = true;
	for (int i = 0; i < Modules.size(); i++) {
		try {
			// terminate all threads, free FLS and unload the module
			Modules[i]->Unload();
			delete Modules[i];
		}
		catch (exception ex) {
			string sPath(Modules[i]->ModulePath.begin(), Modules[i]->ModulePath.end());
			error("Failed to unload module {0}: {1}", sPath, ex.what());
			bResult = false;
		}
	}
	Modules.clear();
	AotLoader::FreeFls();
	return bResult;
}

DllExport bool RegisterScript(HMODULE module,ScriptEntry entry) {
	LOCK(ModulesMutex);
	for (auto pModule : Modules) {
		if (pModule->Module == module) {
			pModule->RegisterScript(entry);
			return true;
		}
	}
	return false;
}

DllExport void ScriptYield() {
	SwitchToFiber(MainFiber);
}

DllExport void ScheduleCallback(VoidFunc callback) {
	LOCK(JobMutex);
	JobQueue.push(callback);
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

#pragma endregion

#pragma region Logger

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

#pragma endregion



