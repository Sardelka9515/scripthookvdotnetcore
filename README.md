# ScriptHookVDotNetCore
ScriptHookV for .NET Core using NativeAOT technology.

WIP, not ready yet!

# Building the project
- Install .NET 7 SDK, C++ desktop development workload and build tools v143
- Clone the repo
- Install [scoop](https://scoop.sh)
- Install vcpkg:
```
scoop install vcpkg
```
- Install dependencies
```
vcpkg install minhook:x64-windows-static
vcpkg install boost:x64-windows-static
```
- Download and extract ScriptHookV SDK to **sdk** folder
- Build the solution with Visual Studio 2022
