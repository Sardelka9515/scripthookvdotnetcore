## Warning: As tested, NativeAOT is not very stable and can sometimes cause random crashes. Debugging is not easy, considering using the CoreCLR mode instead.

To enable NativeAOT mode, add this item to your project property
```
<UseNativeAOT>true</UseNativeAOT>
```

## Troubleshooting
- Since NativeAOT does not run under the normal .NET runtime, fatal crash is usally harder to debug. Normal CLR exceptions in script thread should be handled by the runtime, but a fatal error such as access violation or memory/GC corruption due to the use of unsafe code will result in a violent crash with few clues to debug. In that case, you should wait for the game and SHVDNC to fininsh loading, attach to the process with Visual Studio's debugger, then load your module through the in-game console, it isn't perfect, but at least gives you some insight of what might be causing the trouble.
- All threads should be properly stopped during a module/script unload, override `Script.OnAborted()` or subscribe to `Aborted` event and check the `IsUnloading` property to perform corresponding cleaup procedure.

## How it works?

NativeAOT allow us to compile .NET code to native machine code, so it can be loaded like a regular Win32 module. Each module can have multiple scripts in it, just define a class that inherits from `GTA.Script` with default constructor. An instance will be automatically created.

Module loading/unloading is done by the C++ core with some tweaks to bypass unloading problems. But first, some entry points is required in the NativeAOT compiled assembly so the core can dispatch events to our module. This is done via the `UnmanagedCallersOnly` attribute, you can see how those are defined in the [BaseScript](https://github.com/Sardelka9515/scripthookvdotnetcore/blob/master/src/BaseScript/EntryPoint.cs).

Don't worry! You'll never have to write these yourself. The nuget package comes with a source generator that'll set up everything for you. If you want to define the entrypoints yourself, just mark your methods with the attribute like those in the base script, the generator is smart enough to recognize and skip that part of code.


## Limitations
As the entire runtime is based on NativeAOT, all limitations apply.

- Limited use of reflection API
- No dynamic assembly loading and code execution, executing code on the fly with console is thus impossible
- Only scripts from the same module are visible to each other, see [cross-module comunication](https://github.com/Sardelka9515/scripthookvdotnetcore/master/README.md#cross-module-communication)
- Significantly longer compile time and larger binary size
- C# is the only language the source generator supports as for now, support for VB might be added in the future? (no)

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
 
