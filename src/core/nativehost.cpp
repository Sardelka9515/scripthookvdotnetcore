// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#include "pch.h"

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

int StartNetHost()
{

	wstring root_path = filesystem::current_path().wstring() + L"\\";
	debug(".NET root is {}", WTS(root_path));

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
	const wstring config_path = root_path + L"DotNetLib.runtimeconfig.json";
	load_assembly_and_get_function_pointer_fn load_assembly_and_get_function_pointer = nullptr;
	load_assembly_and_get_function_pointer = get_dotnet_load_assembly(config_path.c_str());
	assert(load_assembly_and_get_function_pointer != nullptr && "Failure: get_dotnet_load_assembly()");

	//
	// STEP 3: Load managed assembly and get function pointer to a managed method
	//
	const wstring dotnetlib_path = root_path + L"DotNetLib.dll";
	const char_t* dotnet_type = L"DotNetLib.Lib, DotNetLib";
	const char_t* dotnet_type_method = L"Hello";
	// <SnippetLoadAndGet>
	// Function pointer to managed delegate
	component_entry_point_fn hello = nullptr;
	int rc = load_assembly_and_get_function_pointer(
		dotnetlib_path.c_str(),
		dotnet_type,
		dotnet_type_method,
		nullptr /*delegate_type_name*/,
		nullptr,
		(void**)&hello);
	// </SnippetLoadAndGet>
	assert(rc == 0 && hello != nullptr && "Failure: load_assembly_and_get_function_pointer()");

	//
	// STEP 4: Run managed code
	//
	struct lib_args
	{
		const char_t* message;
		int number;
	};
	for (int i = 0; i < 3; ++i)
	{
		// <SnippetCallManaged>
		lib_args args
		{
			L"from host!",
			i
		};

		hello(&args, sizeof(args));
		// </SnippetCallManaged>
	}

#ifdef NET5_0
	// Function pointer to managed delegate with non-default signature
	typedef void (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(lib_args args);
	custom_entry_point_fn custom = nullptr;
	rc = load_assembly_and_get_function_pointer(
		dotnetlib_path.c_str(),
		dotnet_type,
		STR("CustomEntryPointUnmanaged") /*method_name*/,
		UNMANAGEDCALLERSONLY_METHOD,
		nullptr,
		(void**)&custom);
	assert(rc == 0 && custom != nullptr && "Failure: load_assembly_and_get_function_pointer()");
#else
	// Function pointer to managed delegate with non-default signature
	typedef void (CORECLR_DELEGATE_CALLTYPE* custom_entry_point_fn)(lib_args args);
	custom_entry_point_fn custom = nullptr;
	rc = load_assembly_and_get_function_pointer(
		dotnetlib_path.c_str(),
		dotnet_type,
		L"CustomEntryPoint" /*method_name*/,
		L"DotNetLib.Lib+CustomEntryPointDelegate, DotNetLib" /*delegate_type_name*/,
		nullptr,
		(void**)&custom);
	assert(rc == 0 && custom != nullptr && "Failure: load_assembly_and_get_function_pointer()");
#endif

	lib_args args
	{
		L"from host!",
		-1
	};
	custom(args);

	return EXIT_SUCCESS;
}

/********************************************************************************************
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
		int rc = init_fptr(config_path, nullptr, &cxt);
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
