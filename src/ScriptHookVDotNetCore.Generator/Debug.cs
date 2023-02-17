global using static ScriptHookVDotNetCore.Generator.Debug;
using Microsoft.CodeAnalysis;
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

        public static bool IsSubClassOf(this INamedTypeSymbol ns,string name)
        {
            if (ns == null)
                return false;

            return ns.BaseType?.ToString() == name || ns.BaseType.IsSubClassOf(name);
        }
    }
}
