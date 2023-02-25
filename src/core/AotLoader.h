#include "pch.h"
#pragma once
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
	void FreeFls();
	void FreeVeh();
	static void Init();
	static void Shutdown();
};
