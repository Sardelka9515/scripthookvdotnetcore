// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#include "pch.h"
#include "exports.h"
// Provided by the AppHost NuGet package and installed as an SDK pack
#include "nethost.h"

// Header files copied from https://github.com/dotnet/core-setup
#include "coreclr_delegates.h"
#include <hostfxr.h>

#include "nativehost.h"


namespace
{
	// Globals to hold hostfxr exports
	hostfxr_initialize_for_runtime_config_fn init_fptr;
	hostfxr_get_runtime_delegate_fn get_delegate_fptr;
	hostfxr_close_fn close_fptr;

	// Forward declarations
	bool load_hostfxr();
	load_assembly_and_get_function_pointer_fn get_dotnet_load_assembly(const char_t* assembly);
}
wstring dotnet_root;
int CoreCLRInit(HMODULE asiModule)
{

	wstring root_path = filesystem::current_path().wstring() + L"\\";
	//
	// STEP 1: Load HostFxr and get exported hosting functions
	//
	if (!load_hostfxr())
	{
		assert(false && "Failure: load_hostfxr()");
		return EXIT_FAILURE;
	}


	//
	// STEP 2: Initialize and start the .NET Core runtime
	//
	const wstring config_path = root_path + L"ScriptHookVDotNetCore.runtimeconfig.json";
	load_assembly_and_get_function_pointer_fn load_assembly_and_get_function_pointer = nullptr;
	load_assembly_and_get_function_pointer = get_dotnet_load_assembly(config_path.c_str());
	assert(load_assembly_and_get_function_pointer != nullptr && "Failure: get_dotnet_load_assembly()");

	//
	// STEP 3: Load managed assembly and get function pointer to a managed method
	//
	const wstring dotnetlib_path = root_path + L"ScriptHookVDotNetCore.dll";
	const char_t* dotnet_type = L"SHVDN.Core, ScriptHookVDotNetCore";
	const char_t* dotnet_type_method = L"CLR_EntryPoint";
	// <SnippetLoadAndGet>
	// Function pointer to managed delegate
	component_entry_point_fn clrEntryFunc = nullptr;
	int rc = load_assembly_and_get_function_pointer(
		dotnetlib_path.c_str(),
		dotnet_type,
		dotnet_type_method,
		nullptr /*delegate_type_name*/,
		nullptr,
		(void**)&clrEntryFunc);
	// </SnippetLoadAndGet>
	assert(rc == 0 && clrEntryFunc != nullptr && "Failure: load_assembly_and_get_function_pointer()");

	//
	// STEP 4: Run managed code
	//
	clrEntryFunc(asiModule, sizeof(HMODULE));

	assert(CoreCLR_DoInit = (VoidFunc)GetPtr(KEY_CORECLR_INITFUNC));
	assert(CoreCLR_DoTick = (VoidFunc)GetPtr(KEY_CORECLR_TICKFUNC));
	assert(CoreCLR_DoKeyboard = (KeyboardFunc)GetPtr(KEY_CORECLR_KBHFUNC));

	return EXIT_SUCCESS;
}

/******************************************	**************************************************
 * Function used to load and activate .NET Core
 ********************************************************************************************/

namespace
{
	// Forward declarations
	void* load_library(const char_t*);
	void* get_export(void*, const char*);

	void* load_library(const char_t* path)
	{
		HMODULE h = ::LoadLibraryW(path);
		assert(h != nullptr);
		return (void*)h;
	}
	void* get_export(void* h, const char* name)
	{
		void* f = ::GetProcAddress((HMODULE)h, name);
		assert(f != nullptr);
		return f;
	}

	// <SnippetLoadHostFxr>
	// Using the nethost library, discover the location of hostfxr and get exports
	bool load_hostfxr()
	{
		// Pre-allocate a large buffer for the path to hostfxr
		char_t buffer[MAX_PATH];
		size_t buffer_size = sizeof(buffer) / sizeof(char_t);
		int rc = get_hostfxr_path(buffer, &buffer_size, nullptr);
		if (rc != 0)
			return false;

		// Load hostfxr and get desired exports
		void* lib = load_library(buffer);
		init_fptr = (hostfxr_initialize_for_runtime_config_fn)get_export(lib, "hostfxr_initialize_for_runtime_config");
		get_delegate_fptr = (hostfxr_get_runtime_delegate_fn)get_export(lib, "hostfxr_get_runtime_delegate");
		close_fptr = (hostfxr_close_fn)get_export(lib, "hostfxr_close");

		return (init_fptr && get_delegate_fptr && close_fptr);
	}
	// </SnippetLoadHostFxr>

	// <SnippetInitialize>
	// Load and initialize .NET Core and get desired function pointer for scenario
	load_assembly_and_get_function_pointer_fn get_dotnet_load_assembly(const char_t* config_path)
	{
		// Load .NET Core
		void* load_assembly_and_get_function_pointer = nullptr;
		hostfxr_handle cxt = nullptr;

		TCHAR szExePath[MAX_PATH];
		GetModuleFileName(NULL, szExePath, MAX_PATH);
		hostfxr_initialize_parameters params = { 0 };
		params.size = sizeof(hostfxr_initialize_parameters);
		params.host_path = szExePath;

		int rc = init_fptr(config_path, &params, &cxt);
		if (rc != 0 || cxt == nullptr)
		{
			std::cerr << "Init failed: " << std::hex << std::showbase << rc << std::endl;
			close_fptr(cxt);
			return nullptr;
		}

		// Get the load assembly function pointer
		rc = get_delegate_fptr(
			cxt,
			hdt_load_assembly_and_get_function_pointer,
			&load_assembly_and_get_function_pointer);
		if (rc != 0 || load_assembly_and_get_function_pointer == nullptr)
			std::cerr << "Get delegate failed: " << std::hex << std::showbase << rc << std::endl;

		close_fptr(cxt);
		return (load_assembly_and_get_function_pointer_fn)load_assembly_and_get_function_pointer;
	}
	// </SnippetInitialize>
}
