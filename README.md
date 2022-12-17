# ScriptHookV .NET Core
ScriptHookV for .NET Core using NativeAOT technology.
![image](https://user-images.githubusercontent.com/106232474/208249914-7fbccc41-48ac-420b-b532-561963dd5c46.png)

WIP, not ready yet!

## Building the project
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
