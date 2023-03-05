
#include "pch.h"
#pragma once
typedef void(WINAPI* KeyboardFunc)(DWORD keycode, BOOL keydown, BOOL ctrl, BOOL shift, BOOL alt);

int CoreCLRInit(HMODULE asiModule);
inline VoidFunc CoreCLR_DoInit;
inline VoidFunc CoreCLR_DoTick;
inline KeyboardFunc CoreCLR_DoKeyboard;