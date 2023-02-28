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
        private static readonly HMODULE BaseScript = NativeLibrary.Load(BASE_SCRIPT_NAME);
        private static HashSet<Type> _registeredTypes = new();
        private static List<ConsoleCommand> _registeredCommands = new(); // Keep reference to registered commands lest it get GC'd
        public static readonly delegate* unmanaged<char*, void> ExecuteConsoleCommand = (delegate* unmanaged<char*, void>)Core.GetPtr("SHVDN.Console.ExecuteConsoleCommand");
        public static readonly delegate* unmanaged<IntPtr, char*, char*, char*, char*, void> RegisterConsoleCommand = (delegate* unmanaged<IntPtr, char*, char*, char*, char*, void>)Core.GetPtr("SHVDN.Console.RegisterConsoleCommand");

        /// <summary>
        /// Search and register all static method marked with <see cref="ConsoleCommand"/> attribute in this type
        /// </summary>
        /// <param name="type"></param>
        /// <remarks>Automatically called for the delclaring type of a registered <see cref="Script"/> object</remarks>
        public static void RegisterCommands([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] Type type)
        {
            lock (_registeredTypes)
            {
                if (_registeredTypes.Contains(type))
                {
                    return;
                }

                foreach (var method in type.GetMethods(BindingFlags.Static | BindingFlags.Public))
                {
                    try
                    {
                        foreach (var attribute in method.GetCustomAttributes<ConsoleCommand>(false))
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
                _registeredTypes.Add(type);
                Logger.Info($"Registered commands for type {type.FullName}");
            }

        }

        /// <summary>
        /// Search and register all instance methods marked with <see cref="ConsoleCommand"/> attribute for this object
        /// </summary>
        /// <param name="type"></param>
        /// <param name="target"></param>
        /// <remarks>Automatically called when registering a <see cref="Script"/> object</remarks>
        public static void RegisterCommands([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] Type type, object target)
        {
            foreach (var method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public))
            {
                try
                {
                    foreach (var attribute in method.GetCustomAttributes<ConsoleCommand>(false))
                    {
                        attribute.Method = method;
                        attribute.Target = target;
                        RegisterCommand(attribute);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error($"Failed to search for console commands in {type.FullName}.{method.Name}: {ex}");
                }
            }
        }
        public static void Print(uint level, ReadOnlySpan<char> msg, params object[] args)
        {
            if (args != null && args.Length > 0)
            {
                msg = string.Format(msg.ToString(), args);
            }

            // Will be forwarded to in-game console through registered log handlers
            switch (level)
            {
                case L_INF: Logger.Info(msg); break;
                case L_ERR: Logger.Error(msg); break;
                case L_WRN: Logger.Warn(msg); break;
            }
        }
        /// <summary>
        /// Writes an info message to the console.
        /// </summary>
        /// <param name="msg">The composite format string.</param>
        /// <param name="args">The formatting arguments.</param>
        public static void PrintInfo(ReadOnlySpan<char> msg, params object[] args) => Print(L_INF, msg, args);

        /// <summary>
        /// Writes an error message to the console.
        /// </summary>
        /// <param name="msg">The composite format string.</param>
        /// <param name="args">The formatting arguments.</param>
        public static void PrintError(ReadOnlySpan<char> msg, params object[] args) => Print(L_ERR, msg, args);

        /// <summary>
        /// Writes a warning message to the console.
        /// </summary>
        /// <param name="msg">The composite format string.</param>
        /// <param name="args">The formatting arguments.</param>
        public static void PrintWarning(ReadOnlySpan<char> msg, params object[] args) => Print(L_WRN, msg, args);

        static void RegisterCommand(ConsoleCommand command)
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
                catch (TargetInvocationException ex)
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
            lock (_registeredCommands)
            {
                _registeredCommands.Add(command);
            }
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

        internal static void OnUnload()
        {
            try
            {
                NativeLibrary.Free(BaseScript);
            }
            catch { }
            _registeredTypes = null;
            _registeredCommands = null;
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
