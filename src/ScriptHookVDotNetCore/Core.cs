using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using GTA;
using GTA.UI;

namespace SHVDN;
#region API bridge

public class ScriptDomain
{
    public static readonly ScriptDomain CurrentDomain = new();
    public bool IsKeyPressed(Keys k) => Core.IsKeyPressed(k);
    public void PauseKeyEvents(bool pause) => Core.PauseKeyEvents(pause);
    public IntPtr PinString(ReadOnlySpan<char> str) => Marshaller.PinString(str);

    public void ExecuteTask<T>(ref T task) where T : IScriptTask => Core.ExecuteTask(ref task);
}
public static class NativeFunc
{
    public static void PushLongString(ReadOnlySpan<char> str, PushCallBack cb) => Function.PushLongString(str, cb);
    public static void PushLongString(ReadOnlySpan<char> str) => Function.PushLongString(str);
}
public interface IScriptTask
{
    public void Run();
}

#endregion

/// <summary>
/// Signify that this member will be indirectly invoked
/// through runtime reflection and should remian backward-compatible
/// </summary>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false)]
class ReflectionEntryAttribute : Attribute
{
    public Version Introduced { get; set; }
    public EntryPlace Place { get; set; }
}

enum EntryPlace
{
    /// <summary>
    /// Indicates that this member lives in the main assembly 
    /// and can be accessed by script assemblies through reflection
    /// </summary>
    MainAssembly,

    /// <summary>
    /// Indicates that this member lives in the api assembly of the loaded context 
    /// and can be accessed by main assembly through reflection
    /// </summary>
    ScriptAssemblies
}

public static unsafe partial class Core
{
#if NATIVEAOT
    public static HMODULE CurrentModule { get; private set; }
#endif
    private static bool[] KeyboardState = new bool[256];
    private static bool _recordKeyboardEvents = true;

    private static List<Script> _scripts = new();
    private static DWORD _mainThread;

    private static IScriptTask _toExecute;
    internal static LPVOID GameTls;

    /// <summary>
    /// List all scripts in this module
    /// </summary>
    /// <returns>A copy of all registered <see cref="Script"/> instances.</returns>
    [ReflectionEntry(Place = EntryPlace.ScriptAssemblies)]
    public static Script[] ListScripts()
    {
        lock (_scripts)
        {
            return _scripts.ToArray();
        }
    }

    public static Script ExecutingScript { get; private set; }

    public static void PauseKeyEvents(bool pause)
    {
        _recordKeyboardEvents = !pause;
    }

    public static bool IsKeyPressed(Keys key)
    {
        return KeyboardState[(int)key];
    }

    /// <summary>
    /// Abort alls scripts and delete associated fibers
    /// </summary>
    internal static void DisposeScripts()
    {
        lock (_scripts)
        {
            foreach (Script script in _scripts)
            {
                try
                {
                    script.Abort(new AbortedEventArgs() { IsUnloading = true });
                }
                catch (Exception ex)
                {
                    Logger.Error($"Error disposing script: {ex}");
                }
            }
            _scripts.Clear();
        }
    }

    /// <summary>
    /// Register a script instance, create associated fiber, register commands and begin the execution once the script thread has been launched
    /// </summary>
    /// <param name="script">The script instance to register</param>
    public static void RegisterScript(Script script)
    {
        // We don't use enumerator to iterate through scripts, so it's safe to add script in the same thread.
        lock (_scripts)
        {
            var type = script.Name;
            var attri = script.Attributes;
            if (attri.SingleInstance && _scripts.Any(x => x.Name == type))
                throw new InvalidOperationException($"A script with the same type has already been registered");

            if (_scripts.Any(x => ReferenceEquals(x, script)))
                throw new InvalidOperationException($"Same script object has already been registered");

            _scripts.Add(script);
            script.Start(!attri.NoScriptThread);
        }
    }

    /// <summary>
    /// Don't use
    /// </summary>
    public static void DoTick(LPVOID currentFiber)
    {
        _mainThread = GetCurrentThreadId();
        GameTls = GetTls();
        lock (_scripts)
        {
            // Execute running scripts
            for (int i = 0; i < _scripts.Count; i++)
            {

                var script = _scripts[i];

                if (script.Continue > GetTickCount64() || script.IsAborted)
                    continue;

                _toExecute = null;
                ExecutingScript = script;

                try
                {
                    if (script.IsUsingThread)
                    {
                        bool finishedInTime;
                    nextTask:
                        finishedInTime = SignalAndWait(script.ContinueEvent, script.WaitEvent, 5000);

                        if (!finishedInTime && !Debugger.IsAttached)
                        {
                            throw new TimeoutException("Script execution has timed out after 5 seconds.");
                        }
                        if (!script.IsAborted)
                        {
                            if (_toExecute != null)
                            {
                                _toExecute.Run();
                                goto nextTask;
                            }
                        }
                        else
                        {
                            var error = script.Error;
                            Notification.Show($"~r~Unhandled exception~s~ in script \"~h~{script.Name}~h~\"!~n~~n~~r~" + error.GetType().Name + "~s~ " + error.StackTrace.Split('\n').FirstOrDefault().Trim());
                        }
                        _toExecute = null;
                    }
                    else
                    {
                        script.DoTick();
                    }
                    ExecutingScript = null;
                }
                catch (Exception ex)
                {
                    ExecutingScript = null;
                    script.HandleException(ex);
                }

            }

            CleanupStrings();
        }
    }

    /// <summary>
    /// Don't use
    /// </summary>
    public static void DoKeyEvent(DWORD key, bool down, bool ctrl, bool shift, bool alt)
    {
        if (key <= 0 || key >= 256)
            return;

        // Convert message into a key event
        var keys = (Keys)key;
        if (ctrl) keys |= Keys.Control;
        if (shift) keys |= Keys.Shift;
        if (alt) keys |= Keys.Alt;

        KeyboardState[key] = down;

        if (_recordKeyboardEvents)
        {
            var te = new Tuple<bool, KeyEventArgs>(down, new KeyEventArgs(keys));
            lock (_scripts)
            {
                foreach (Script script in _scripts)
                    script.KeyboardEvents.Enqueue(te);
            }
        }
    }

    public static void OnInit(IntPtr lparams)
    {
#if NATIVEAOT
        CurrentModule = lparams;
        DoImport(NativeLibrary.Load(Environment.GetEnvironmentVariable("SHVDNC_ASI_PATH") ?? "ScriptHookVDotNetCore.asi"));
#else
        var asiModule = lparams;
        if (asiModule != default)
        {
            DoImport(asiModule);
        }
#endif

        _mainThread = GetCurrentThreadId();
        GameTls = GetTls();
        if (AsiVersion < ScriptingApiVersion)
        {
            MessageBoxA(default, $"Current ScriptHookVDotNetCore version is {AsiVersion}, while {ScriptingApiVersion} or higher is required. Update ScriptHookVDotNetCore if you experience random crashes", "Warning", default);
        }
#if !NATIVEAOT
        if (MainAssembly != null)
            FindAndRegisterAllScripts();
#endif
        // Initialize NativeMemory
        RuntimeHelpers.RunClassConstructor(typeof(NativeMemory).TypeHandle);
    }

    /// <summary>
    /// Don't use
    /// </summary>
    public static void OnUnload(HMODULE currentModule)
    {
#if NATIVEAOT
        CurrentModule = currentModule;
#endif
        DisposeScripts();
        _scripts = null;
        KeyboardState = null;
        GTA.Console.OnUnload();
        Marshaller.OnUnload();
        NativeLibrary.Free(AsiModule);
        for (int i = 0; i < 20; i++)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }

    /// <summary>
    /// Determine if the current thread is the main script thread
    /// </summary>
    public static bool IsMainThread() => GetCurrentThreadId() == _mainThread;

    internal static void EnsureMainThread()
    {
        if (!IsMainThread())
            throw new InvalidOperationException("This function can only be called from main thread.");
    }

    /// <summary>
    /// Dispatch the task to main thread and wait for it to finish if the script is running in a dedicated thread, otherwise, execute it directly
    /// </summary>
    /// <param name="task"></param>
    /// <exception cref="InvalidOperationException"></exception>
    public static void ExecuteTask<T>(ref T task) where T : IScriptTask
    {
        if (GetTls() == GameTls)
        {
            task?.Run();
            return;
        }

        var script = ExecutingScript;
        if (script?.ScriptThread != Thread.CurrentThread)
            throw new InvalidOperationException("Cannot execute task from non-script thread");

        _toExecute = task;
        SignalAndWait(script.WaitEvent, script.ContinueEvent);
        task = (T)_toExecute;
        _toExecute = null;
    }

    static void SignalAndWait(SemaphoreSlim toSignal, SemaphoreSlim toWaitOn)
    {
        toSignal.Release();
        toWaitOn.Wait();
    }
    static bool SignalAndWait(SemaphoreSlim toSignal, SemaphoreSlim toWaitOn, int timeout)
    {
        toSignal.Release();
        return toWaitOn.Wait(timeout);
    }

    public static void TryBreakToDebugger()
    {
        if (Debugger.IsAttached)
            Debugger.Break();
    }



    /// <summary>
    /// Helper method to determine whether a file is a managed assembly
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    internal static bool IsManagedAssembly(string fileName)
    {
        try
        {

            using Stream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            using BinaryReader binaryReader = new(fileStream);
            if (fileStream.Length < 64)
            {
                return false;
            }

            //PE Header starts @ 0x3C (60). Its a 4 byte header.
            fileStream.Position = 0x3C;
            uint peHeaderPointer = binaryReader.ReadUInt32();
            if (peHeaderPointer == 0)
            {
                peHeaderPointer = 0x80;
            }

            // Ensure there is at least enough room for the following structures:
            //     24 byte PE Signature & Header
            //     28 byte Standard Fields         (24 bytes for PE32+)
            //     68 byte NT Fields               (88 bytes for PE32+)
            // >= 128 byte Data Dictionary Table
            if (peHeaderPointer > fileStream.Length - 256)
            {
                return false;
            }

            // Check the PE signature.  Should equal 'PE\0\0'.
            fileStream.Position = peHeaderPointer;
            uint peHeaderSignature = binaryReader.ReadUInt32();
            if (peHeaderSignature != 0x00004550)
            {
                return false;
            }

            // skip over the PEHeader fields
            fileStream.Position += 20;

            const ushort PE32 = 0x10b;
            const ushort PE32Plus = 0x20b;

            // Read PE magic number from Standard Fields to determine format.
            var peFormat = binaryReader.ReadUInt16();
            if (peFormat != PE32 && peFormat != PE32Plus)
            {
                return false;
            }

            // Read the 15th Data Dictionary RVA field which contains the CLI header RVA.
            // When this is non-zero then the file contains CLI data otherwise not.
            ushort dataDictionaryStart = (ushort)(peHeaderPointer + (peFormat == PE32 ? 232 : 248));
            fileStream.Position = dataDictionaryStart;

            uint cliHeaderRva = binaryReader.ReadUInt32();
            if (cliHeaderRva == 0)
            {
                return false;
            }

            return true;
        }
        catch
        {
            return false;
        }
    }
}