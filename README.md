# ScriptHookV .NET Core
ScriptHookV for .NET Core, supports two modes, NativeAOT and CoreCLR (JIT)

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

### Note: content below is mostly about running scripts under CoreCLR runtime, for NativeAOT related information, refer to [this document](https://github.com/Sardelka9515/scripthookvdotnetcore/blob/master/NativeAOT.md)

## Getting started
- Make sure you have .NET 7 SDK installed
- Create a project targeting .NET 7
- Install the [nuget package](https://www.nuget.org/packages/ScriptHookVDotNetCore)
```
dotnet add package ScriptHookVDotNetCore
```
- Define a class that inherits from `GTA.Script`
- Subscribe to events like you would in ScriptHookVDotNet, or override `OnStart`,`OnTick` and other methods as you need
- Build the project and copy the dll in `native` folder of the output directory to GTAV\CoreScripts
- Voila! Start the game and you'll see your script running.
- Take a look at the examples to see how you can use the scripting API.

## Upgrade & migration guide
The code is written in such way that should make the migration from ScriptHookVDotNet pretty easy. 
- Remove the reference from SHVDN
- Upgrade project TFM to .NET 7
- Remove WinForms reference as it's not supported by NativeAOT (yet). `Keys` and `KeyEvent` are now defined in the `GTA` namespace.
- Install the nuget package, then you should be good to go.
- Some internal APIs were removed, such as `SHVDN.ScriptDomain` and `SHVDN.Console`. A new static class `GTA.Console` was introduced in 1.1, which expose access to the in-game console.
- If you use the reflection api(or serialization library such as Newtonsoft.json) in NativeAOT mode, you'll probaly need to configure [trimming options](https://learn.microsoft.com/en-us/dotnet/core/deploying/trimming/trimming-options?pivots=dotnet-7-0), using the [descriptor format](https://github.com/dotnet/linker/blob/main/docs/data-formats.md#descriptor-format) xml file is recommended.

## Building the project
- Install .NET 7 SDK, C++ desktop development workload and build tools v143
- Clone the repo
- Install [vcpkg](https://vcpkg.io/) manually or using [scoop](https://scoop.sh).
- Install dependencies
```
vcpkg integrate install
vcpkg install minhook:x64-windows-static
vcpkg install spdlog:x64-windows-static
vcpkg install nethost:x64-windows-static
vcpkg install inih:x64-windows-static
```
- Download and extract ScriptHookV SDK to **sdk** folder
- Build the solution with Visual Studio 2022

## Credits
[ScriptHoookVDotNet](https://github.com/crosire/scripthookvdotnet) and all of its contributors for the amazing work on the scripting API
[DotNetCorePlugins](https://github.com/natemcmaster/DotNetCorePlugins), which powers the dynamic assembly loading/unloading

## License & disclaimer
The C++ core and the AOT/CoreCLR-specific runtime are written from scratch, while most parts of the scripting API are from [ScriptHookVDotNet](https://github.com/crosire/scripthookvdotnet). See [LICENSE](https://github.com/Sardelka9515/scripthookvdotnetcore/blob/master/LICENSE)
