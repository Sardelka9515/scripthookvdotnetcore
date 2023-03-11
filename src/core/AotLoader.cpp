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
map<DWORD, PFLS_CALLBACK_FUNCTION> RegisterFls;
mutex VehMutex;
map<PVOID, PVECTORED_EXCEPTION_HANDLER> RegisteredVeh;
GETMODULEHANDLEEXW GetModuleHandleExWOrg = NULL;
FLSALLOC FlsAllocOrg = NULL;
ADDVECEXHAND AddVecExHandOrg = NULL;
#pragma endregion
#pragma region Static
vector<LPVOID> Hooks;
void CreateHook(LPVOID pTarget, LPVOID pDetour, LPVOID* ppTrampoline) {
	MH_Check(MH_CreateHook(pTarget, pDetour, ppTrampoline));
	MH_Check(MH_EnableHook(pTarget));
	Hooks.push_back(pTarget);
}
void AotLoader::Shutdown() {
	if (Hooks.size() == 0)
		return;

	for (const auto& pTarget : Hooks) {
		MH_Check(MH_DisableHook(pTarget));
		MH_Check(MH_RemoveHook(pTarget));
	}
	Hooks.clear();
	MH_Check(MH_Uninitialize());
}

void AotLoader::Init() {
	MH_Check(MH_Initialize());
	CreateHook(&GetModuleHandleExW, &GetModuleHandleExWHook, (LPVOID*)&GetModuleHandleExWOrg);
	CreateHook(&FlsAlloc, &FlsAllocHook, (LPVOID*)&FlsAllocOrg);
	CreateHook(&AddVectoredExceptionHandler, &AddVectoredExceptionHandlerHook, (LPVOID*)&AddVecExHandOrg);
}
void AotLoader::FreeFls() {
	auto predicate = [this](pair<DWORD, PFLS_CALLBACK_FUNCTION> fls) {
		HMODULE flsModule;
		GetModuleHandleEx(GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS | GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT, (LPCWSTR)fls.second, &flsModule);
		if (flsModule == Module) {
			if (FlsFree(fls.first)) {
				debug("FlsFree success: {}", fls.first);
			}
			else {
				debug("FlsFree failed: {}", fls.first);
				error("Error code: {}", GetLastError());
			}
			return true;
		}
		return false;
	};
	LOCK(FlsMutex);
	erase_if(RegisterFls, predicate);
}
void AotLoader::FreeVeh() {
	auto predicate = [this](pair<PVOID, PVECTORED_EXCEPTION_HANDLER> veh) {
		HMODULE vehModule;
		GetModuleHandleEx(GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS | GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT, (LPCWSTR)veh.second, &vehModule);
		if (vehModule == Module) {
			if (RemoveVectoredExceptionHandler(veh.first)) {
				debug("Removed veh: {}, handle: {}", (uint64_t)veh.second, (uint64_t)veh.first);
			}
			else {
				error("Failed to remove veh: {}, handle: {}", (uint64_t)veh.second, (uint64_t)veh.first);
				error("Error code: {}", GetLastError());
			}
			return true;
		}
		return false;
	};
	LOCK(VehMutex);
	erase_if(RegisteredVeh, predicate);
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

	FreeFls();
	FreeVeh();

	// Actual unload (FreeLibrary)
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

	auto index = FlsAllocOrg(lpCallback);
	if (index != FLS_OUT_OF_INDEXES) {

		debug("FLS created: {0}", index);
		LOCK(FlsMutex);
		RegisterFls[index] = lpCallback;
	}

	return index;
}

PVOID AddVectoredExceptionHandlerHook(ULONG First, PVECTORED_EXCEPTION_HANDLER Handler)
{
	auto hHandler = AddVecExHandOrg(First, Handler);
	debug("VEH registered: {}, handle: {}", (uint64_t)Handler, (uint64_t)hHandler);
	{
		LOCK(VehMutex);
		RegisteredVeh[hHandler] = Handler;
	}
	return hHandler;
}

LPVOID WINAPI GetThreadStartAddress(HANDLE hThread)
{
	NTSTATUS ntStatus;
	HANDLE hDupHandle;
	LPVOID dwStartAddress;

	auto hmNtdll = GetModuleHandle(L"ntdll.dll");
	if (!hmNtdll)
		return NULL;

	pNtQIT NtQueryInformationThread = (pNtQIT)GetProcAddress(hmNtdll, "NtQueryInformationThread");

	if (NtQueryInformationThread == NULL)
		return NULL;

	HANDLE hCurrentProcess = GetCurrentProcess();
	if (!DuplicateHandle(hCurrentProcess, hThread, hCurrentProcess, &hDupHandle, THREAD_QUERY_INFORMATION, FALSE, 0)) {
		SetLastError(ERROR_ACCESS_DENIED);

		return NULL;
	}

	ntStatus = NtQueryInformationThread(hDupHandle, ThreadQuerySetWin32StartAddress, &dwStartAddress, sizeof(LPVOID), NULL);
	CloseHandle(hDupHandle);
	if (ntStatus != STATUS_SUCCESS)
		return NULL;

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

