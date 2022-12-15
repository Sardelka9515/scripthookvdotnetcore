using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SHVDNC;
public static unsafe class Main
{
    public static HMODULE CurrentModule;
    public static List<Script> Scripts = new();
    // public static readonly Type[] ScriptTypes = { typeof(BaseScript) };


    [UnmanagedCallersOnly(EntryPoint = "OnInit")]
    public static void OnInit(HMODULE module)
    {
        CurrentModule = module;
        try
        {
            Scripts.Add(new BaseScript());
            /*
             * 
            foreach (var t in ScriptTypes)
            {
                if (t.IsAssignableTo(typeof(Script)) && !t.IsAbstract)
                {
                    Logger.Info($"Starting script: {t.Name}");
                    try
                    {
                        Scripts.Add(t.GetConstructor(
                            BindingFlags.Instance | BindingFlags.Public, null,
                            CallingConventions.HasThis, Type.EmptyTypes, null).Invoke(new object[] { }) as Script);

                    }
                    catch (Exception ex)
                    {
                        Logger.Error($"Failed to instantiate script {t.Name}:\n{ex}");
                    }
                }
            }
             */
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