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
// ScriptHookV
#include <main.h> 
// MinHook
#include<MinHook.h>
// spdlog
#include "spdlog/spdlog.h"
#include "spdlog/sinks/basic_file_sink.h"


using namespace std;
using namespace spdlog;
namespace fs = std::filesystem;

#define MAX_UNLOAD_RETRIES 256
#define BASE_SCRIPT_NAME "ScriptHookVDotNet.BaseScript.dll"
#define UNLOAD_KEY 35 // End
#define RELOAD_KEY 36 // Home


// Unicode/ANSI convertion macros
#define STW(s) wstring(s.begin(), s.end())
#define WTS(ws) string(ws.begin(), ws.end())

#define LOCK(mtx) std::scoped_lock lock(mtx)
