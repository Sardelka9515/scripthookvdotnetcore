using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SHVDNC;
public unsafe class Script
{
    public delegate void ScriptEntryDelegate(IntPtr lParam);
    internal readonly ScriptEntryDelegate ScriptEntry;
    public event Action Tick; 
    public Script()
    {
        // Need to store it somewhere to prevent GC from messing with it.
        ScriptEntry = ScriptMain;
        Core.ScheduleCallback(Marshal.GetFunctionPointerForDelegate(() =>
        {
            Core.RegisterScript(Main.CurrentModule, (delegate* unmanaged<IntPtr, void>)Marshal.GetFunctionPointerForDelegate(ScriptEntry));
            Logger.Info($"Script registered: {this.GetType()}");
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
