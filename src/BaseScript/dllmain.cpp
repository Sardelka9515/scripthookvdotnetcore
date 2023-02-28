// This project is only used for backward-compatability with scripts compiled in the NativeAOT era
#include "pch.h"
#include "assert.h"
#define DllExport extern "C" __declspec( dllexport ) inline
typedef LPVOID(WINAPI* CommandHandler)(uint32_t argc, wchar_t** argv);
typedef void(WINAPI* regcom_func)(CommandHandler handler, wchar_t* name, wchar_t* param, wchar_t* help, wchar_t* assembly);
typedef void(WINAPI* prcom_func)(wchar_t* prefix, wchar_t* msg);
typedef void(WINAPI* execcom_func)(wchar_t* command);

LPVOID RegisterConsoleCommand_ptr;
LPVOID PrintConsoleMessage_ptr;
LPVOID ExecuteConsoleCommand_ptr;
DllExport void RegisterConsoleCommand(CommandHandler handler, wchar_t* name, wchar_t* param, wchar_t* help, wchar_t* assembly) {
	assert(RegisterConsoleCommand_ptr);
	((regcom_func)RegisterConsoleCommand_ptr)(handler, name, param, help, assembly);
}
DllExport void PrintConsoleMessage(wchar_t* prefix, wchar_t* msg) {
	assert(PrintConsoleMessage_ptr);
	((prcom_func)PrintConsoleMessage_ptr)(prefix, msg);
}
DllExport void ExecuteConsoleCommand(wchar_t* command) {
	assert(ExecuteConsoleCommand_ptr);
	((execcom_func)ExecuteConsoleCommand_ptr)(command);
}
typedef uint64_t(WINAPI* getptr_func)(LPCSTR key);
typedef void(WINAPI* setptr_func)(LPCSTR key, uint64_t value);
DWORD Setup(LPVOID lparam) {
	HMODULE asi = LoadLibrary(L"ScriptHookVDotNetCore.asi");
	assert(asi);
	auto GetPtr = (getptr_func)GetProcAddress(asi, "GetPtr");
	assert(GetPtr);
	auto SetPtr = (setptr_func)GetProcAddress(asi, "SetPtr");
	assert(SetPtr);
	RegisterConsoleCommand_ptr = (LPVOID)GetPtr("SHVDN.Console.RegisterConsoleCommand");
	PrintConsoleMessage_ptr = (LPVOID)GetPtr("SHVDN.Console.PrintConsoleMessage");
	ExecuteConsoleCommand_ptr = (LPVOID)GetPtr("SHVDN.Console.ExecuteConsoleCommand");
	assert(RegisterConsoleCommand_ptr && PrintConsoleMessage_ptr && ExecuteConsoleCommand_ptr);
	return 0;
}

BOOL APIENTRY DllMain(HMODULE hModule,
	DWORD  ul_reason_for_call,
	LPVOID lpReserved
)
{
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
		Setup(NULL);
	case DLL_THREAD_ATTACH:
	case DLL_THREAD_DETACH:
	case DLL_PROCESS_DETACH:
		break;
	}
	return TRUE;
}

