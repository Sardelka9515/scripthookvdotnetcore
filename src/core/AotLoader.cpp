#include "pch.h"
#include "AotLoader.h"
#pragma region Stuff

#define STATUS_SUCCESS    ((NTSTATUS)0x00000000L)
#define ThreadQuerySetWin32StartAddress 9

typedef NTSTATUS(WINAPI* pNtQIT)(HANDLE, LONG, PVOID, ULONG, PULONG);
typedef BOOL(WINAPI* GETMODULEHANDLEEXW)(DWORD, LPCWSTR, HMODULE*);
typedef DWORD(WINAPI* FLSALLOC)(PFLS_CALLBACK_FUNCTION);
typedef PVOID(WINAPI* ADDVECEXHAND)(ULONG First, PVECTORED_EXCEPTION_HANDLER Handler);
LPVOID WINAPI GetThreadStartAddress(HANDLE hThread);
BOOL ListProcessThreads(DWORD dwOwnerPID, DWORD results[] = NULL, LPCWSTR terminateIfMatch = NULL);
BOOL GetModuleHandleExWHook(DWORD   dwFlags, LPCWSTR  lpModuleName, HMODULE* phModule);
DWORD FlsAllocHook(PFLS_CALLBACK_FUNCTION lpCallback);
PVOID AddVectoredExceptionHandlerHook(ULONG First, PVECTORED_EXCEPTION_HANDLER Handler);
mutex FlsMutex;
DWORD FlsIndecies[256] = { 0 };
mutex VehMutex;
map<PVOID, PVECTORED_EXCEPTION_HANDLER> VectoredExceptionHandlers;
int FlsCount = 0;
GETMODULEHANDLEEXW GetModuleHandleExWOrg = NULL;
FLSALLOC FlsAllocOrg = NULL;
ADDVECEXHAND AddVecExHandOrg = NULL;
#pragma endregion
#pragma region Static

void AotLoader::Shutdown() {
	// MH_Check(MH_DisableHook(&FlsAlloc));
	MH_Check(MH_DisableHook(&GetModuleHandleExW));
	MH_Check(MH_RemoveHook(&GetModuleHandleExW));
	MH_Check(MH_RemoveHook(&FlsAlloc));
	MH_Check(MH_Uninitialize());
	FreeFls();
}

void AotLoader::Init() {
	MH_Check(MH_Initialize());
	MH_Check(MH_CreateHook(&GetModuleHandleExW, &GetModuleHandleExWHook, (LPVOID*)&GetModuleHandleExWOrg));
	MH_Check(MH_CreateHook(&FlsAlloc, &FlsAllocHook, (LPVOID*)&FlsAllocOrg));
	MH_Check(MH_EnableHook(&GetModuleHandleExW));
	// MH_Check(MH_EnableHook(&FlsAlloc));
	MH_Check(MH_CreateHook(&AddVectoredExceptionHandler, &AddVectoredExceptionHandlerHook, (LPVOID*)&AddVecExHandOrg));
	MH_Check(MH_EnableHook(&AddVectoredExceptionHandler));
}
void AotLoader::FreeFls() {
	// Release all FLS created by .NET
	LOCK(FlsMutex);
	while (FlsCount--) {
		debug("Freeing Fls {0} : {1}", FlsIndecies[FlsCount], FlsFree(FlsIndecies[FlsCount]) ? "Success" : "Fail");
	}
	FlsCount = 0;
}

#pragma endregion

AotLoader::AotLoader(LPCWSTR path) {

	LPCWSTR relativePath = path;
	TCHAR fullPath[MAX_PATH];
	GetFullPathName(relativePath, MAX_PATH, fullPath, nullptr);
	ModulePath = wstring(fullPath);

	info("Loading module {0}", WTS(ModulePath));

	// Load the library and find the entry points we want
	Module = LoadLibraryW(path);
	if (Module == NULL) {
		throw runtime_error(string("Invalid module: ") + WTS(ModulePath));
	}
	InitFunc = (ModuleEntry)GetProcAddress(Module, "OnInit");
	UnloadFunc = (ModuleEntry)GetProcAddress(Module, "OnUnload");

	// Optional entry points
	KeyboardFunc = (KeyboardHandler)GetProcAddress(Module, "OnKeyboard");
	PresentFunc = (PresentCallback)GetProcAddress(Module, "OnPresent");
	TickFunc = (TickEntry)GetProcAddress(Module, "OnTick");

	if (!(InitFunc && UnloadFunc)) {
		FreeLibrary(Module);
		throw runtime_error("Some required entry points were not found in this module");
	}

	// First call to the dll will spin up the .NET runtime, which creates FLS and the GC thread
	InitFunc(Module);
}

void AotLoader::Unload() {
	info("Unloading module {0}", WTS(ModulePath));

	// Call the pre-unload function
	UnloadFunc(Module);

	// Terminate all threads that orginated from this module
	ListProcessThreads(GetCurrentProcessId(), NULL, ModulePath.c_str());


	// Search for handlers to unregister
	vector<pair<PVOID, PVECTORED_EXCEPTION_HANDLER>> toUnregister;
	{
		LOCK(VehMutex);
		for (const auto& handler : VectoredExceptionHandlers) {
			HMODULE module;
			GetModuleHandleEx(GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS | GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT, (LPCWSTR)handler.second, &module);
			if (module == Module) {
				toUnregister.push_back(pair<PVOID, PVECTORED_EXCEPTION_HANDLER>(handler.first, handler.second));
			}
		}
	}

	int retries = MAX_UNLOAD_RETRIES;
	auto path = ModulePath.c_str();
	while ((Module = GetModuleHandleW(path)) && retries--) {
		if (!FreeLibrary(Module)) {
			stringstream s;
			s << "FreeLibrary error: " << GetLastError();
			throw runtime_error(s.str());
			break;
		}
	}
	if (retries < 0) {
		stringstream s;
		s << "Module not unloaded after " << MAX_UNLOAD_RETRIES << " retries";
		throw runtime_error(s.str());
	}

	// Remove vectored exception handlers
	for (const auto& hand : toUnregister) {
		bool fSuccess = RemoveVectoredExceptionHandler(hand.first);
		if (fSuccess) {
			debug("Removed exception handler: {}, handle: {}", (uint64_t)hand.second, (uint64_t)hand.first);
		}
		else {
			error("Failed to remove exception handler: {}, handle: {}", (uint64_t)hand.second, (uint64_t)hand.first);
			error("Error code: {}", GetLastError());
		}
		{
			LOCK(VehMutex);
			VectoredExceptionHandlers.erase(hand.first);
		}
	}

	info("Unloaded module {0}", WTS(ModulePath));
}

BOOL GetModuleHandleExWHook(DWORD   dwFlags, LPCWSTR  lpModuleName, HMODULE* phModule) {
	// Shift out the flag that pins .NET modules in memory
	if (dwFlags & GET_MODULE_HANDLE_EX_FLAG_PIN) {
		dwFlags &= ~(GET_MODULE_HANDLE_EX_FLAG_PIN);
		dwFlags |= GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT;
		stringstream s;
		s << "GetModuleHandleEx flag modified for module " << (DWORD64)lpModuleName;
		debug(s.str());
	}
	return GetModuleHandleExWOrg(dwFlags, lpModuleName, phModule);
}

DWORD FlsAllocHook(PFLS_CALLBACK_FUNCTION lpCallback) {

	// TODO: find assembly by the callback address and store it in the corresponding loader
	return FlsAllocOrg(lpCallback);

	LOCK(FlsMutex);
	auto index = FlsIndecies[FlsCount++] = FlsAllocOrg(lpCallback);
	debug("FLS created: {0}", index);
	return index;
}

PVOID AddVectoredExceptionHandlerHook(ULONG First, PVECTORED_EXCEPTION_HANDLER Handler)
{
	HMODULE module;
	GetModuleHandleEx(GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS | GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT, (LPCWSTR)Handler, &module);
	auto hHandler = AddVecExHandOrg(First, Handler);
	debug("Exception handler registered: {}, module: {}, handle: {}", (uint64_t)Handler, (uint64_t)module, (uint64_t)hHandler);
	{
		LOCK(VehMutex);
		VectoredExceptionHandlers[hHandler] = Handler;
	}
	return hHandler;
}

LPVOID WINAPI GetThreadStartAddress(HANDLE hThread)
{
	NTSTATUS ntStatus;
	HANDLE hDupHandle;
	LPVOID dwStartAddress;

	pNtQIT NtQueryInformationThread = (pNtQIT)GetProcAddress(GetModuleHandle(L"ntdll.dll"), "NtQueryInformationThread");

	if (NtQueryInformationThread == NULL)
		return 0;

	HANDLE hCurrentProcess = GetCurrentProcess();
	if (!DuplicateHandle(hCurrentProcess, hThread, hCurrentProcess, &hDupHandle, THREAD_QUERY_INFORMATION, FALSE, 0)) {
		SetLastError(ERROR_ACCESS_DENIED);

		return 0;
	}

	ntStatus = NtQueryInformationThread(hDupHandle, ThreadQuerySetWin32StartAddress, &dwStartAddress, sizeof(LPVOID), NULL);
	CloseHandle(hDupHandle);
	if (ntStatus != STATUS_SUCCESS)
		return 0;

	return dwStartAddress;

}


BOOL ListProcessThreads(DWORD dwOwnerPID, DWORD results[], LPCWSTR terminateIfMatch)
{
	HANDLE hThreadSnap = INVALID_HANDLE_VALUE;
	THREADENTRY32 te32;

	// Take a snapshot of all running threads  
	hThreadSnap = CreateToolhelp32Snapshot(TH32CS_SNAPTHREAD, 0);
	if (hThreadSnap == INVALID_HANDLE_VALUE)
		return(FALSE);

	// Fill in the size of the structure before using it. 
	te32.dwSize = sizeof(THREADENTRY32);

	// Retrieve information about the first thread,
	// and exit if unsuccessful
	if (!Thread32First(hThreadSnap, &te32))
	{
		_tprintf(TEXT("Thread32First failed"));  // Show cause of failure
		CloseHandle(hThreadSnap);     // Must clean up the snapshot object!
		return(FALSE);
	}
	int threadCount = 0;
	do
	{
		if (te32.th32OwnerProcessID == dwOwnerPID)
		{
			if (results) {
				results[threadCount] = te32.th32ThreadID;
			}
			HANDLE hThread = OpenThread(THREAD_ALL_ACCESS, 0, te32.th32ThreadID);
			if (hThread == NULL) throw new exception("Failed to open thread");
			auto startAddr = GetThreadStartAddress(hThread);
			HMODULE threadModule;
			GetModuleHandleEx(GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS,
				(LPCWSTR)startAddr,
				&threadModule);

			TCHAR modulePath[256] = { 0 };
			GetModuleFileName(threadModule, modulePath, sizeof(modulePath) / sizeof(TCHAR));
			auto sModulePath = wstring(modulePath);
			// debug("Thread {0} found in module {1}", te32.th32ThreadID, WTS(sModulePath));
			auto moduleName = sModulePath.substr(sModulePath.find_last_of(L"/\\") + 1);
			if (terminateIfMatch && (moduleName.compare(terminateIfMatch) == 0 || sModulePath.compare(terminateIfMatch) == 0)) {
				if (TerminateThread(hThread, 0)) {
					debug("Thread terminated: {0}", te32.th32ThreadID);
				}
				else {
					error("Failed to terminate thread {0}", te32.th32ThreadID);
				}
			}
			if (DWORD lastError = GetLastError()) {
				error("List thread error: {0}", lastError);
				SetLastError(0);
			}
			CloseHandle(hThread);
			threadCount++;
		}
	} while (Thread32Next(hThreadSnap, &te32));

	_tprintf(TEXT("\n"));

	//  Don't forget to clean up the snapshot object.
	CloseHandle(hThreadSnap);
	return(TRUE);
}

