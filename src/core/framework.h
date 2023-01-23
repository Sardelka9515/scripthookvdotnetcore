#pragma once

#define DllExport extern "C" __declspec( dllexport )
#define WIN32_LEAN_AND_MEAN             // Exclude rarely-used stuff from Windows headers
// Windows Header Files
#include <windows.h>
#include <tlhelp32.h>
#include <tchar.h>
#include <winternl.h>
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
#include "spdlog/sinks/basic_file_sink.h"
#include "callback_sink.h"

using namespace std;
using namespace spdlog;
namespace fs = std::filesystem;

#pragma pack(push, 1)
struct Job {
	uint16_t Type;
	LPVOID Parameter;
	LPVOID ParameterEx;
};
struct ConfigStruct {
	uint16_t UnloadKey = 35;
	uint16_t ReloadKey = 36;
	uint16_t MaxUnloadRetries = 256;
	uint16_t Reserved[13];
};
#pragma pack(pop)

static ConfigStruct Config = ConfigStruct();

#define J_UNLOAD 0
#define J_LOAD 1
#define J_UNLOAD_ALL 2
#define J_RELOAD 3
#define J_CALLBACK 10

#define MAX_UNLOAD_RETRIES Config.MaxUnloadRetries
#define BASE_SCRIPT_NAME L"ScriptHookVDotNetCore.BaseScript.dll"
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
#define PWTS(lpcwstr) WTS(wstring(lpcwstr)).c_str()
#define PSTW(lpcstr) STW(string(lpcstr)).c_str()

