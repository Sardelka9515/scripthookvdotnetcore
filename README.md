# ScriptHookV .NET Core
ScriptHookV for .NET Core using NativeAOT technology.

## Installation
Download **ScriptHookVDotNetCore.zip** from [release page](https://github.com/Sardelka9515/scripthookvdotnetcore/releases) and extract ScriptHookVDotNetCore.asi to your game root.

A screenshot from the [AirStrike example script](https://github.com/Sardelka9515/scripthookvdotnetcore/blob/master/examples/AirStrike/Main.cs)
![image](https://user-images.githubusercontent.com/106232474/208843982-d6ced835-d5ad-4d9e-9dde-f461a1ac2aed.png)

## Features
- Use latest .NET Core API (.NET 7 or higher)
- Can run alonside existing [ScriptHookVDotNet](https://github.com/crosire/scripthookvdotnet) based mods
- Easy [upgrade/migration from ScriptHookVDotNet](https://github.com/Sardelka9515/scripthookvdotnetcore#upgrade--migration-guide)
- Reload scripts without restarting the game. Press **End** to unload all scripts, **Home** to reload
- Better performance

## Troubleshooting
- [Issue running with ScriptHookVDotNet](https://github.com/Sardelka9515/scripthookvdotnetcore/issues/3)
- Since NativeAOT does not run under the normal .NET runtime, fatal crash is usally harder to debug. Normal CLR exceptions in script thread should be handled by the runtime, but a fatal error such as access violation or memory/GC corruption due to the use of unsafe code will result in a violent crash with few clues to debug. In that case, you should wait for the game and SHVDNC to fininsh loading, attach to the process with Visual Studio's debugger, then load your module through the in-game console, it isn't perfect, but at least gives you some insight of what might be causing the trouble.

## How it works?
NativeAOT allow us to compile .NET code to native machine code, so it can be loaded like a regular Win32 module. Each module can have multiple scripts in it, just define a class that inherits from `GTA.Script` with default constructor. An instance will be automatically created.

Module loading/unloading is done by the C++ core with some tweaks to bypass unloading problems. But first, some entry points is required in the NativeAOT compiled assembly so the core can dispatch events to our module. This is done via the `UnmanagedCallersOnly` attribute, you can see how those are defined in the [BaseScript](https://github.com/Sardelka9515/scripthookvdotnetcore/blob/master/src/BaseScript/EntryPoint.cs).

Don't worry! You'll never have to write these yourself. The nuget package comes with a source generator that'll set up everything for you. If you want to define the entrypoints yourself, just mark your methods with the attribute like those in the base script, the generator is smart enough to recognize and skip that part of code.

## Getting started
- Make sure you have .NET 7 SDK installed
- Create a project targeting .NET 7
- Install the [nuget package](https://www.nuget.org/packages/ScriptHookVDotNetCore/1.0.0)
```
dotnet add package ScriptHookVDotNetCore
```
- Define a class that inherits from `GTA.Script`
- Subscribe to events like you would in ScriptHookVDotNet, or override `OnStart`,`OnTick` and other methods as you need
- Build the project and copy the dll in `native` folder of the output directory to GTAV\CoreScripts
- Voila! Start the game and you'll see your script running.
- Take a look at the examples to see how you can use the scripting API.

## Limitations
As the entire runtime is based on NativeAOT, all limitations apply.

- Limited use of reflection API
- No dynamic assembly loading and code execution, executing code on the fly with console is thus impossible
- Only scripts from the same module are visible to each other, see [cross-module comunication](https://github.com/Sardelka9515/scripthookvdotnetcore/master/README.md#cross-module-communication)
- Longer compile time and larger binary size
- ~~No fail-safe script abortion, the game will hang if you block the main thread~~ starting with 1.1, dedicated script thread was reintroduced
- C# is the only language the source generator supports as for now, support for VB might be added in the future

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
 Then load the module with the `NativeLibrary` class
 ```
 using System.Runtime.InteropServices;
 public unsafe class MyScript : GTA.Script
 {
  protected override void OnStart()
  {
    base.OnStart();
    IntPtr myModu = NativeLibrary.Load("MyModule.dll");
    var func = (delegate* unmanaged<void>)NativeLibrary.GetExport("MyFancyFunction");
    func();
  }
 }
 ```
 
## Upgrade & migration guide
The code is written in such way that should make the migration from ScriptHookVDotNet pretty easy. 
- Remove the reference from SHVDN
- Upgrade project TFM to .NET 7
- Remove WinForms reference as it's not supported by NativeAOT (yet). `Keys` and `KeyEvent` are now defined in the `GTA` namespace.
- Install the nuget package, then you should be good to go.
- Some internal APIs were removed, such as `SHVDN.ScriptDomain` and `SHVDN.Console`. A new static class `GTA.Console` was introduced in 1.1, which expose access to the in-game console.
- If you use the reflection api(or serialization library such as Newtonsoft.json), you'll probaly need to configure [trimming options](https://learn.microsoft.com/en-us/dotnet/core/deploying/trimming/trimming-options?pivots=dotnet-7-0), using the [descriptor format](https://github.com/dotnet/linker/blob/main/docs/data-formats.md#descriptor-format) xml file is recommended.

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
