#include "pch.h"
#pragma once
class Script {
public:
	LPVOID ScriptFiber;
	VoidFunc ScriptEntry;
	DWORD64 Continue;
	HMODULE Module;
	Script* Next;


	static inline DWORD FlsIndex;
	static inline Script* First;
	static inline LPVOID MainFiber;
	static void SwitchTo(Script* nextScript);
	static Script* Register(VoidFunc scriptEntry, HMODULE module = NULL);
	static void Unregister(Script* script);
	static void Wait(DWORD64 milliSeconds);
	static Script* GetCurrent();
	static inline void TickAll() {
		if (!Script::First)
			return;

		Script::MainFiber = GetCurrentFiber();
		Script::SwitchTo(Script::First);
	}
};
