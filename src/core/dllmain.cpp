#include "pch.h"
#include "exports.h"
#include "resource.h"
static bool Initialized = false;
static void FATAL(string msg) {
	msg = string("Fatal error ocurred: ") + msg;
	spdlog::error(msg);
	MessageBoxA(NULL, msg.c_str(), "FATAL!", MB_OK);
	throw exception(msg.c_str());
}

LPVOID DoJob(Job* pj) {
	switch (pj->Type) {
	case J_UNLOAD: {
		auto result = (LPVOID)UnloadModuleW(((wstring*)pj->Parameter)->c_str());
		delete (wstring*)pj->Parameter;
		return result;
	}
	case J_LOAD: {
		auto result = (LPVOID)LoadModuleW(((wstring*)pj->Parameter)->c_str());
		delete (wstring*)pj->Parameter;
		return result;
	}
	case J_UNLOAD_ALL:
		return (LPVOID)UnloadAllModules();
	case J_RELOAD:
		return (LPVOID)(UnloadAllModules() && LoadModuleW(BASE_SCRIPT_NAME));
	case J_CALLBACK:
		return ((CallBackFunc)pj->Parameter)(pj->ParameterEx);
	}
	return NULL;
}
shared_ptr<spdlog::logger> Logger;
LPVOID PtrBaseScript;
SIZE_T BaseScriptSize;

static void OnPresent(void* swapChain) {
	LOCK(ModulesMutex);
	for (const auto pScript : Modules) {
		if (pScript->PresentFunc) {
			try {
				pScript->PresentFunc(swapChain);
			}
			catch (exception ex) {
				auto scriptName = pScript->ModulePath.substr(pScript->ModulePath.find_last_of(L"/\\") + 1);
				error("Present[{0}]: {1}", WTS(scriptName), ex.what());
			}
		}
	}
}

static void KeyboardMessage(unsigned long keycode, bool keydown, bool ctrl, bool shift, bool alt) {
	if (!keydown) {
		if (keycode == UNLOAD_KEY) {
			ScheduleUnloadAll();
		}
		if (keycode == RELOAD_KEY) {
			ScheduleReload();
		}
	}
}

static void OnKeyboard(DWORD key, WORD repeats, BYTE scanCode, BOOL isExtended, BOOL isWithAlt, BOOL wasDownBefore, BOOL isUpNow)
{
	KeyboardMessage(
		key,
		!isUpNow,
		(GetAsyncKeyState(VK_CONTROL) & 0x8000) != 0,
		(GetAsyncKeyState(VK_SHIFT) & 0x8000) != 0,
		isWithAlt != FALSE);

	LOCK(ModulesMutex);
	for (const auto pScript : Modules) {
		if (pScript->KeyboardFunc) {
			try {
				pScript->KeyboardFunc(key, repeats, scanCode, isExtended, isWithAlt, wasDownBefore, isUpNow);
			}
			catch (exception ex) {
				auto scriptName = pScript->ModulePath.substr(pScript->ModulePath.find_last_of(L"/\\") + 1);
				error("KeyboardHandler[{0}]: {1}", WTS(scriptName), ex.what());
			}
		}
	}
}


static void Init() {
	if (Initialized) return; // Gets called evertime after game loaded
	AotLoader::Init();
	info("API hook created");
	auto hInfo = FindResource(CurrentModule, MAKEINTRESOURCE(BASE_SCRIPT_RES), MAKEINTRESOURCE(BASE_SCRIPT_RES));
	if (!hInfo) {
		FATAL("Failed to find base script in current module");
		return;
	}
	auto hBS = LoadResource(CurrentModule, hInfo);
	if (!hBS) {
		FATAL("Failed to load base script resource");
		return;
	}

	info("Loading base script module");
	PtrBaseScript = LockResource(hBS);
	BaseScriptSize = SizeofResource(CurrentModule, hInfo);
	if (!fs::is_symlink(BASE_SCRIPT_NAME)) {
		info("Writing resource");
		try {
			ofstream fout;
			fout.open(BASE_SCRIPT_NAME, ios::binary | ios::out | ios::trunc);
			fout.write((char*)PtrBaseScript, BaseScriptSize);
			fout.close();
		}
		catch (exception ex) {
			error(ex.what());
			if (!fs::exists(BASE_SCRIPT_NAME))
				FATAL(string("Failure writing base script: ") + string(ex.what()));
		}
	}
	else {
		info("Symlink detected, base script will not be overwritten");
	}

#if DEBUG
#else
	ScheduleLoad(BASE_SCRIPT_NAME);
#endif

	Initialized = true;
	return;
}
void ScriptMain() {
	Init();
	while (true) {

		// execute scheduled jobs
		try
		{
			Job job = {};
		doWork:
			bool hasJob = false;
			// Only lock the mutex in this scope so we can schedule another job inside the current one
			{
				LOCK(JobMutex);
				if (!JobQueue.empty()) { job = JobQueue.front(); JobQueue.pop(); hasJob = true; }
			}
			if (hasJob) {
				DoJob(&job);
				goto doWork;
			}
		}
		catch (exception ex) {
			error(format("Failed to execute queued job: {}", ex.what()));
		}

		// Tick
		{
			LOCK(ModulesMutex);
			for (auto pM : Modules) {
				if (pM->TickFunc != NULL) {
					pM->TickFunc(GetCurrentFiber());
				}
			}
		}
		scriptWait(0);
	}
}
BOOL APIENTRY DllMain(HMODULE hModule,
	DWORD  ul_reason_for_call,
	LPVOID lpReserved
)
{
	CurrentModule = hModule;
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH: {
		SetPtr("Config", (uint64_t)&Config);
		auto callback_sink = std::make_shared<sinks::callback_sink_mt>([](const details::log_msg& msg) {
			LOCK(LogHandlersMutex);
			auto time = (uint64_t)msg.time.time_since_epoch().count();
			auto level = (uint32_t)msg.level;
			auto payload = string(msg.payload.begin(), msg.payload.end()).c_str();
			for (auto lh : LogHandlers) {
				lh(time, level, payload);
			}
		});

		auto file_sink = std::make_shared<sinks::basic_file_sink_mt>("ScriptHookVDotNetCore.log", true);
		Logger = shared_ptr<logger>(new logger("Core", { callback_sink, file_sink }));
		Logger->set_level(level::trace);
		Logger->flush_on(level::info);
		Logger->set_pattern("[%H:%M:%S] [%^%l%$] %v");
		set_default_logger(Logger);
		flush_every(chrono::seconds(3));
		info("Logging system initilized");
		presentCallbackRegister(OnPresent);
		keyboardHandlerRegister(OnKeyboard);
		scriptRegister(hModule, ScriptMain);
		break;
	}
	case DLL_PROCESS_DETACH:
		// Not supported currently, game will crash once we unloaded another script
		info("Shutting down");
		Logger->flush();
		presentCallbackUnregister(OnPresent);
		keyboardHandlerUnregister(OnKeyboard);
		scriptUnregister(hModule);
		AotLoader::Shutdown();
		spdlog::shutdown();
		break;
	case DLL_THREAD_ATTACH:
	case DLL_THREAD_DETACH:
		break;
	}
	return TRUE;
}

