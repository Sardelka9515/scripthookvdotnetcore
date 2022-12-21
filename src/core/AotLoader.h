#include "pch.h"
#pragma once
typedef VOID(WINAPI* ModuleEntry)(HMODULE);

typedef VOID(WINAPI* VoidFunc)(VOID);
typedef VOID(WINAPI* TickEntry)(PVOID currentFiber);
using namespace std;


class AotLoader
{

private:
	ModuleEntry InitFunc;
	ModuleEntry UnloadFunc;
public:
	KeyboardHandler KeyboardFunc;
	PresentCallback PresentFunc;
	TickEntry TickFunc;
	AotLoader(LPCWSTR path);
	HMODULE Module;
	wstring ModulePath;
	void Unload();
	static void Init();
	static void Shutdown();
	static void FreeFls();
};
