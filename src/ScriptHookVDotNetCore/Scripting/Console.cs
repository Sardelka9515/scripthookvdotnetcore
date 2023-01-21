using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GTA
{
    /// <summary>
    /// Expose access to the in-game console
    /// </summary>
    public static unsafe class Console
    {
        public static readonly HMODULE BaseScript = NativeLibrary.Load("ScriptHookVDotNetCore.BaseScript.dll");
        public static readonly delegate* unmanaged<char*, void> ExecuteConsoleCommand = (delegate* unmanaged<char*, void>)Import("ExecuteConsoleCommand");
        public static readonly delegate* unmanaged<IntPtr, char*, char*, char*, char*, void> RegisterConsoleCommand = (delegate* unmanaged<IntPtr, char*, char*, char*, char*, void>)Import("RegisterConsoleCommand");
        public static readonly delegate* unmanaged<char*, char*, void> PrintConsoleMessage = (delegate* unmanaged<char*, char*, void>)Import("PrintConsoleMessage");

        public static IntPtr Import(string name) => NativeLibrary.GetExport(BaseScript, name);
        
        public static void RegisterCommands([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] Type type)
        {
            foreach (var method in type.GetMethods(BindingFlags.Static | BindingFlags.Public))
            {
                try
                {
                    foreach (var attribute in method.GetCustomAttributes<ConsoleCommand>(true))
                    {
                        attribute.Method = method;
                        RegisterCommand(attribute);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error($"Failed to search for console commands in {type.FullName}.{method.Name}: {ex}");
                }
            }
        }
        
        public static void Print(string prefix, string msg, params object[] args)
        {
            msg = string.Format(msg, args);
            fixed (char* pp = prefix, pm = msg)
            {
                PrintConsoleMessage(pp, pm);
            }
        }
        
        /// <summary>
        /// Writes an info message to the console.
        /// </summary>
        /// <param name="msg">The composite format string.</param>
        /// <param name="args">The formatting arguments.</param>
        public static void PrintInfo(string msg, params object[] args) => Print("[~b~INFO~w~] ", msg, args);
        
        /// <summary>
        /// Writes an error message to the console.
        /// </summary>
        /// <param name="msg">The composite format string.</param>
        /// <param name="args">The formatting arguments.</param>
        public static void PrintError(string msg, params object[] args) => Print("[~r~ERROR~w~] ", msg, args);
        
        /// <summary>
        /// Writes a warning message to the console.
        /// </summary>
        /// <param name="msg">The composite format string.</param>
        /// <param name="args">The formatting arguments.</param>
        public static void PrintWarning(string msg, params object[] args) => Print("[~o~WARNING~w~] ", msg, args);
        
        public static void RegisterCommand(ConsoleCommand command)
        {
            var wrapper = (int argc, char** argv) =>
            {
                try
                {

                    var sArgs = GetArguments(argc, argv);
                    object[] args = new object[command.Params.Length];
                    for (int i = 0; i < argc && i < command.Params.Length; i++)
                    {
                        args[i] = Convert.ChangeType(sArgs[i], command.Params[i].Item1);
                    }
                    command.Method.Invoke(command.Target, args);
                }
                catch(TargetInvocationException ex)
                {
                    PrintError(ex.InnerException.ToString());
                }
                catch (Exception ex)
                {
                    PrintError(ex.ToString());
                }
                return IntPtr.Zero;
            };
            fixed (char* pName = command.Name, pParm = command.ParamsString, pHelp = command.Help, pAssm = command.Assembly)
            {
                RegisterConsoleCommand(Marshal.GetFunctionPointerForDelegate(wrapper), pName, pParm, pHelp, pAssm);
            }
            command._wrapper = wrapper;
        }
        
        public static List<string> GetArguments(int argc, char** argv)
        {
            List<string> args = new(argc);
            while (args.Count < argc)
            {
                args.Add(Marshal.PtrToStringUni((IntPtr)argv[args.Count]));
            }
            return args;
        }
    }
    public class ConsoleCommand : Attribute
    {
        public ConsoleCommand(string help) { Help = help; }
        public object Target { get; internal set; }
        public string Name { get; private set; }
        public string Help { get; private set; }
        public string Assembly { get; private set; }
        internal object _wrapper; // To prevent the wrapper from being GC'd
        public (Type, string)[] Params { get; private set; }
        public string ParamsString => string.Join(' ', Params.Select(x => $"~b~{x.Item2}:~g~{Type.GetTypeCode(x.Item1)}~s~"));
        private MethodInfo _method;
        public MethodInfo Method
        {
            get => _method;
            internal set
            {
                _method = value;
                Name = value.Name;
                Assembly = value.DeclaringType.Assembly.GetName().Name;
                Params = value.GetParameters().Select(x => (x.ParameterType, x.Name)).ToArray();
            }
        }
    }
}
