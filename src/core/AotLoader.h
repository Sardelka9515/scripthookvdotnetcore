#include "pch.h"
#pragma once
typedef VOID(WINAPI* ModuleEntry)(HMODULE);

typedef VOID(WINAPI* VoidFunc)(VOID);
typedef VOID(WINAPI* ScriptEntry)(LPVOID lparam);
using namespace std;


class AotLoader
{

private:
	ModuleEntry InitFunc;
	ModuleEntry UnloadFunc;
	vector<LPVOID> ScriptFibers = {};
public:
	KeyboardHandler KeyboardFunc;
	PresentCallback PresentFunc;
	AotLoader(LPCWSTR path);
	HMODULE Module;
	wstring ModulePath;
	void DoTick();
	void Unload();
	void RegisterScript(ScriptEntry entry);
	static void Init();
	static void Shutdown();
	static void FreeFls();
};
