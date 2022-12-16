using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SHVDN;
public unsafe class Script
{
    public delegate void ScriptEntryDelegate(IntPtr lParam);
    internal readonly ScriptEntryDelegate ScriptEntry;
    public event Action Tick; 
    public Script(IntPtr module)
    {
        // Need to store it somewhere to prevent GC from messing with it.
        ScriptEntry = ScriptMain;
        Core.ScheduleCallback(Marshal.GetFunctionPointerForDelegate(() =>
        {
            Core.RegisterScript(module, (delegate* unmanaged<IntPtr, void>)System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(ScriptEntry));
            Logger.Info($"Script registered: {GetType()}");
        }));
    }

    private void ScriptMain(IntPtr lParam)
    {
        while (true)
        {
            try
            {
                Tick?.Invoke();
                Core.ScriptYield();
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
            }
        }
    }
}
