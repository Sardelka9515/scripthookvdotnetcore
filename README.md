# ScriptHookV .NET Core
ScriptHookV for .NET Core using NativeAOT technology.

A screenshot from the [AirStrike example script](https://github.com/Sardelka9515/scripthookvdotnetcore/blob/master/examples/AirStrike/Main.cs)
![image](https://user-images.githubusercontent.com/106232474/208843982-d6ced835-d5ad-4d9e-9dde-f461a1ac2aed.png)

## Features
- Use latest .NET Core API (.NET 7 or higher)
- Can run alonside existing [ScriptHookVDotNet](https://github.com/crosire/scripthookvdotnet) based mods
- Easy [upgrade/migration from ScriptHookVDotNet](https://github.com/Sardelka9515/scripthookvdotnetcore/edit/master/README.md#upgrade--migration-guide)
- Reload scripts without restarting the game. Press **End** to unload all scripts, **Home** to reload
- Better performance

## How it works?
NativeAOT allow us to compile .NET code to native machine code, so it can be loaded like a regular Win32 module. Each module can have multiple scripts in it, just define a class that inherits from `GTA.Script` with default constructor. An instance will be automatically created.

Module loading\unloading is done by the C++ core with some tweaks to bypass unloading problems. But first, some entry points is required in the NativeAOT compiled assembly so the core can dispatch events to our module. This is done via the `UnmanagedCallersOnly` attribute, you can see how those are defined in the [BaseScript](https://github.com/Sardelka9515/scripthookvdotnetcore/blob/master/src/BaseScript/EntryPoint.cs).

Don't worry! You'll never have to write these yourself. The nuget package comes with a source generatoe that'll set up everything for you. If you want to define the entrypoints yourself, you just need to mark your methods with the attribute like those in the base script, the generator is smart enough to recognize and skip that part of code.

## Limitations
As the entire runtime is based on NativeAOT, all limitations apply.

- Limited use of reflection API
- No dynamic assembly loading and code execution, executing code on the fly with console is thus impossible
- Only scripts from the same module are visible to each other, see [cross-module comunication](https://github.com/Sardelka9515/scripthookvdotnetcore/edit/master/README.md#cross-module-communication)
- Longer compile time and larger binary size

## Cross-module communication
To call functions from other modules, you first need to export functions in the target module:
 ```
 using System.Runtime.InteropServices;
 UnnmanagedCallersOnly(EntryPoint="MyFancyFunction")
 public static void MyFancyFunction()
 {
   // Do some fancy stuff
 }
 ```
 Then you need to load the module with the `NativeLibrary` class
 ```
 using System.Runtime.InteropServices;
 public MyScript : GTA.Script
 {
 
 }
 ```
## Upgrade & migration guide

## Building the project
- Install .NET 7 SDK, C++ desktop development workload and build tools v143
- Clone the repo
- Install [vcpkg](https://vcpkg.io/) manually or using [scoop](https://scoop.sh).
- Install dependencies
```
vcpkg integrate install
vcpkg install minhook:x64-windows-static
vcpkg install boost:x64-windows-static
```
- Download and extract ScriptHookV SDK to **sdk** folder
- Build the solution with Visual Studio 2022

## Credits
[ScriptHoookVDotNet](https://github.com/crosire/scripthookvdotnet) and all of its contributors for the amazing work on the scripting API

## License & disclaimer
The C++ core and the AOT-specific runtime are written from scratch, while most parts of the scripting API are from [ScriptHookVDotNet](https://github.com/crosire/scripthookvdotnet). For simplicity, all codes are under the [same license](https://github.com/crosire/scripthookvdotnet#license).
