#include "pch.h"
#include "Scripts.h"
#include "exports.h"
void DestroyScript(Script* script) {
	Job cleanupJob = { 0 };
	cleanupJob.Type = J_CALLBACK;
	cleanupJob.Parameter = (LPVOID)DeleteFiber;
	cleanupJob.ParameterEx = script->ScriptFiber;
	// ScheduleTask(cleanupJob);
	delete script;
	debug("Script unregistered: {}", (uint64_t)script);
}
void Script::Unregister(Script* script) {
	if (!First) {
		error("Illegal call to UnregisterScript, no script is running");
		return;
	}
	Script* prev = First;
	if (prev == script) {
		DestroyScript(First);
		First = script->Next;
		return;
	}

	// Walk the list and remove matching script
	Script* cur = NULL;
	while (cur = prev->Next) {
		if (cur == script) {
			prev->Next = cur->Next;
			DestroyScript(cur);
			return;
		}
		prev = cur;
	}
	error("Script not found");
}
Script* Script::GetCurrent() {
	return (Script*)FlsGetValue(FlsIndex);
}
void Script::SwitchTo(Script* nextScript) {
	if (!nextScript) {
		SwitchToFiber(MainFiber);
		return;
	}

	auto time = GetTickCount64();
	while (nextScript->Continue > time) {
		if (!(nextScript = nextScript->Next)) {
			SwitchToFiber(MainFiber); // End reached
			return;
		}
	}

	SwitchToFiber(nextScript->ScriptFiber);
}
void ScriptFiberProc(LPVOID thisScript) {
	FlsSetValue(Script::FlsIndex, thisScript);
	auto cur = (Script*)thisScript;
	cur->ScriptEntry();
	Script::Unregister(cur);
	Script::SwitchTo(cur->Next);
}
Script* Script::Register(VoidFunc scriptEntry, HMODULE module) {
	if (!FlsIndex)
		FlsIndex = FlsAlloc(NULL);

	auto newScript = new Script();
	ZeroMemory(newScript, sizeof(Script));
	newScript->ScriptEntry = scriptEntry;
	newScript->Next = First;
	newScript->ScriptFiber = CreateFiber(NULL, ScriptFiberProc, newScript);
	GetModuleHandleEx(GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS | GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT, (LPCWSTR)scriptEntry, &newScript->Module);
	debug("Script registered: {}, module: {}", (uint64_t)newScript, (uint64_t)newScript->Module);
	return First = newScript;
}
void Script::Wait(DWORD64 milliSeconds) {
	auto current = GetCurrent();
	if (!current) {
		error("Illegal call to ScriptWait, no script is running");
		return;
	}
	if (milliSeconds) {
		auto time = GetTickCount64();
		current->Continue = time + milliSeconds;
	}
	SwitchTo(current->Next);
}