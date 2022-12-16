using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using SHVDN;

namespace BaseScript;
public static unsafe class Main
{
    public static HMODULE CurrentModule;
    public static List<Script> Scripts = new();
    public static readonly Type[] ScriptTypes = { typeof(BaseScript) };


    [UnmanagedCallersOnly(EntryPoint = "OnInit")]
    public static void OnInit(HMODULE module)
    {
        CurrentModule = module;
        try
        {
            Scripts.Add(new BaseScript(module));
        }
        catch (Exception ex)
        {
            MessageBox(default, ex.ToString(), "Base script initialization error", MessageBoxOptions.MB_OK);
            throw; // Crash the process
        }
    }

    /// <summary>
    /// Called prior to module unload
    /// </summary>
    /// <param name="module"></param>
    [UnmanagedCallersOnly(EntryPoint = "OnUnload")]
    public static void OnUnload(HMODULE module)
    {
        CurrentModule = module;
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}