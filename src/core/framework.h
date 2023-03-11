#pragma once

#define DllExport extern "C" __declspec( dllexport ) inline
#define WIN32_LEAN_AND_MEAN             // Exclude rarely-used stuff from Windows headers
// Windows Header Files
#include <windows.h>
#include <tlhelp32.h>
#include <tchar.h>
#include <winternl.h>
#include <Psapi.h>
// std
#include <iostream>
#include <string> 
#include <vector>
#include <filesystem>
#include <mutex>
#include <queue>
#include <fstream>
#include <map>
// ScriptHookV
#include <main.h> 
// MinHook
#include <MinHook.h>
// spdlog
#include "spdlog/spdlog.h"
#include "spdlog/sinks/stdout_color_sinks.h"
#include "spdlog/sinks/basic_file_sink.h"
#include "callback_sink.h"

using namespace std;
using namespace spdlog;
namespace fs = std::filesystem;

typedef VOID(WINAPI* ModuleEntry)(HMODULE);

typedef VOID(WINAPI* VoidFunc)(VOID);
typedef VOID(WINAPI* TickEntry)(PVOID currentFiber);

#pragma pack(push, 1)

struct RuntimeConfig
{
	LPVOID TickPtr;
	LPVOID Reserved[31];
};

struct Job {
	uint16_t Type;
	LPVOID Parameter;
	LPVOID ParameterEx;
};
struct ConfigStruct {
	// Parsed by base script
	uint16_t UnloadKey = 35;
	uint16_t ReloadKey = 36;
	uint16_t MaxUnloadRetries = 256;
	uint16_t ConsoleKey = 0; 
	uint16_t Reserved[28] = { 0 };
	// core only
#ifdef DEBUG
	uint16_t AllocDebugConsole = TRUE;
#else
	uint16_t AllocDebugConsole = FALSE;
#endif // DEBUG
	uint16_t SkipLegalScreen = TRUE;
	uint16_t Reserved2[32] = { 0 };
};
#pragma pack(pop)

static ConfigStruct Config = ConfigStruct();

#define J_UNLOAD 0
#define J_LOAD 1
#define J_UNLOAD_ALL 2
#define J_CALLBACK 10

#define MAX_UNLOAD_RETRIES Config.MaxUnloadRetries
#define BASE_SCRIPT_NAME L"ScriptHookVDotNetCore.BaseScript.dll"
#define CONFIG_PATH "ScriptHookVDotNetCore.ini"
#define UNLOAD_KEY Config.UnloadKey // End
#define RELOAD_KEY Config.ReloadKey // Home

#define LOCK(mtx) std::scoped_lock lock(mtx)

// Convert Unicode string to ANSI string
static string WTS(wstring ws) {
	return string(ws.begin(), ws.end());
}

// Convert ANSI string to Unicode string
static wstring STW(string s) {
	return wstring(s.begin(), s.end());
}

#define MH_Check(code) assert(code == MH_OK)

template< typename ContainerT, typename PredicateT >
static void erase_if(ContainerT& items, const PredicateT& predicate) {
	for (auto it = items.begin(); it != items.end(); ) {
		if (predicate(*it)) it = items.erase(it);
		else ++it;
	}
}

#define PWTS(lpcwstr) WTS(wstring(lpcwstr)).c_str()
#define PSTW(lpcstr) STW(string(lpcstr)).c_str()

