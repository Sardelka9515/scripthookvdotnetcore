global using static ScriptHookVDotNetCore.Generator.Debug;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ScriptHookVDotNetCore.Generator
{
    internal static class Debug
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type = default);

    }
}
