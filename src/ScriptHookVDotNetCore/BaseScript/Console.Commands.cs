using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SHVDN
{
    internal static unsafe partial class Console
    {
        #region Argument parsing
        [Flags]
        enum ParseState
        {
            Gap = 0,
            Read = 1,
            ReadEscape = 2,
            InQuotes = 4
        }

        static char** Parse(char* input, out int argc)
        {
            ParseState state = ParseState.Gap;
            var results = new List<string>();
            char* currentCommandBuf = stackalloc char[StrLenUni(input)];
            char thisChar;
            int inputIndex = 0;
            int curCmdIndex = 0;
            while ((thisChar = input[inputIndex]) != 0)
            {
                char thisRead = '\0';
                var previouReading = state.HasFlag(ParseState.Read);
                switch (thisChar)
                {
                    case '\\':
                        {
                            if (state.HasFlag(ParseState.ReadEscape))
                            {
                                state &= ~ParseState.ReadEscape;
                                thisRead = thisChar;
                            }
                            else
                            {
                                state |= ParseState.ReadEscape;
                                state |= ParseState.Read;
                            }
                            break;
                        }
                    case '\"':
                        if (state.HasFlag(ParseState.ReadEscape))
                        {
                            thisRead = thisChar;
                            state &= ~ParseState.ReadEscape;
                        }
                        else if (state.HasFlag(ParseState.InQuotes))
                        {
                            state &= ~ParseState.InQuotes;
                        }
                        else
                        {
                            state |= ParseState.InQuotes;
                            state |= ParseState.Read;
                        }
                        break;
                    case ' ':
                        if (state.HasFlag(ParseState.ReadEscape))
                        {
                            throwEs();
                        }
                        else if (state.HasFlag(ParseState.InQuotes))
                        {
                            thisRead = thisChar;
                        }
                        else
                        {
                            state &= ~ParseState.Read;
                        }
                        break;
                    default:
                        if (state.HasFlag(ParseState.ReadEscape))
                        {
                            switch (thisChar)
                            {
                                case 'a': thisRead = '\a'; break;
                                case 'b': thisRead = '\b'; break;
                                case 'f': thisRead = '\f'; break;
                                case 'n': thisRead = '\n'; break;
                                case 'r': thisRead = '\r'; break;
                                case 't': thisRead = '\t'; break;
                                case 'v': thisRead = '\v'; break;
                                default: throwEs(); break;
                            }
                        }
                        else
                        {
                            thisRead = thisChar;
                        }
                        break;
                }
                if (thisRead != '\0')
                {
                    state |= ParseState.Read;
                    currentCommandBuf[curCmdIndex++] = thisRead;
                }
                if (previouReading && !state.HasFlag(ParseState.Read))
                {
                    currentCommandBuf[curCmdIndex + 1] = '\0';
                    results.Add(new(currentCommandBuf));
                    input += inputIndex;
                    inputIndex = curCmdIndex = 0;
                }
                else
                {
                    inputIndex++;
                }
            }
            if (state.HasFlag(ParseState.Read))
            {
                currentCommandBuf[curCmdIndex] = '\0';
                results.Add(new(currentCommandBuf));
            }

            void throwEs()
            {
                throw new Exception($"Unrecognized escape sequence: '\\{thisChar}'");
            }

            return StringArrayToMemory(results.ToArray(), out argc);
        }

        internal static char** StringArrayToMemory(string[] args, out int argc)
        {
            // Copy arguments to a sequential block of memory
            var bufPtrsSize = args.Length * sizeof(IntPtr);
            var bufArgsSize = args.Sum(x => x == null ? 0 : x.Length + 1) * sizeof(char);
            char** argv = (char**)Marshal.AllocHGlobal(bufPtrsSize + bufArgsSize);
            char* pCurArg = (char*)(argv + args.Length);
            for (int i = 0; i < args.Length; i++)
            {
                var thisArg = args[i];
                if (thisArg == null)
                {
                    argv[i] = default;
                    continue;
                }
                argv[i] = pCurArg;
                var cChars = thisArg.Length + 1;
                var cbThisArg = cChars * sizeof(char);
                fixed (char* pStr = thisArg)
                {
                    Buffer.MemoryCopy(pStr, pCurArg, cbThisArg, cbThisArg);
                }
                pCurArg += cChars;
            }
            argc = args.Length;
            return argv;
        }

        #endregion

        internal static Command GetCommandObject(string command)
        {
            if (_commands.TryGetValue(command, out var c))
            {
                return c;
            }
            return null;
        }


        /// <summary>
        /// Register the specified method as a console command.
        /// </summary>
        /// <param name="func"></param>
        /// <param name="name"></param>
        /// <param name="param"></param>
        /// <param name="help"></param>
        /// <param name="assembly"></param>
        public static void RegisterCommand(delegate* unmanaged<int, char**, IntPtr> func, ReadOnlySpan<char> name, ReadOnlySpan<char> param, ReadOnlySpan<char> help, ReadOnlySpan<char> assembly)
        {
            var command = new Command((IntPtr)func, name, param, help, assembly);
            var sName = name.ToString();
            Logger.Debug("Registering command: " + sName);
            lock (_commands)
            {
                if (_commands.ContainsKey(sName))
                {
                    _commands[sName] = command;
                }
                else
                {
                    _commands.Add(sName, command);
                }
            }
        }

        /// <summary>
        /// Register a managed console command
        /// </summary>
        /// <param name="help"></param>
        /// <param name="method"></param>
        /// <param name="target"></param>
        [ReflectionEntry(Place = EntryPlace.MainAssembly)]
        public static void RegisterCommandManaged(string help, MethodInfo method, object target = null)
        {
            var command = new Command(help, method, target);
            var name = method.Name;
            Logger.Debug("Registering command: " + name);
            lock (_commands)
            {
                if (_commands.TryGetValue(name, out var existing))
                {
                    Logger.Warn($"Command \"{name}\" has already been registered from assembly \"{existing.Assembly}\"" +
                        $", replacing with the one from \"{command.Assembly}\"");
                    _commands[name] = command;
                }
                else
                {
                    _commands.Add(name, command);
                }
            }
        }

        /// <summary>
        /// Unregister all methods with a <see cref="Command"/> attribute that were previously registered.
        /// </summary>
        [ReflectionEntry(Place = EntryPlace.MainAssembly)]
        public static void UnregisterCommand(string name)
        {
            lock (_commands)
            {
                if (!_commands.Remove(name))
                    Logger.Warn($"Attempted to unregister a non-existent command: \"{name}\"");
            }
        }
        internal unsafe partial class Command
        {
            public Command(IntPtr func, ReadOnlySpan<char> name, ReadOnlySpan<char> param, ReadOnlySpan<char> help, ReadOnlySpan<char> assembly)
            {
                List<(string, string)> parameters = new();
                foreach (var m in ParametersRegex.Matches(param.ToString()).Cast<Match>())
                {
                    parameters.Add((m.Groups["type"].Value, m.Groups["name"].Value));
                }

                Name = name.ToString();
                Help = help.ToString();
                Assembly = assembly.ToString();
                ParametersStr = string.Join(", ", parameters.Select(x => x.Item1 + " " + x.Item2));
                UnmanagedHandler = (delegate* unmanaged<int, char**, IntPtr>)func;
                var toPass = string.Join(", ", parameters.Select(x => x.Item2 + "?.ToString()"));
                Code = @$"
    public static void {name}({ParametersStr})
    {{
		var argv = SHVDN.Console.StringArrayToMemory(new string[] {{{toPass}}}, out var argc);
        SHVDN.Console.GetCommandObject(""{name}"").UnmanagedHandler(argc, argv);
    }}";

            }
            public Command(string help, MethodInfo method, object target = null)
            {
                Name = method.Name;
                Help = help;
                ManagedHandler = method;
                ManagedTarget = target;
                Assembly = method.DeclaringType.Assembly.GetName().Name;
                var parameters = method.GetParameters();
                ParametersStr = string.Join(", ", parameters.Select(x =>
                {
                    if (x.HasDefaultValue)
                    {
                        var defaultVal =
                        (x.ParameterType == typeof(string) && x.DefaultValue != null) ?
                        $"\"{x.DefaultValue}\"" : (x.DefaultValue?.ToString() ?? "null");
                        return $"{x.ParameterType.FullName} {x.Name} = {defaultVal}";
                    }
                    return $"{x.ParameterType.FullName} {x.Name}";
                }));
                var toPass = string.Join(", ", parameters.Select(x => x.Name));
                Code = @$"
    public static void {Name}({ParametersStr})
    {{
        var cmd = SHVDN.Console.GetCommandObject(""{Name}"");
		var result = cmd.ManagedHandler.Invoke(cmd.ManagedTarget, new object[] {{{toPass}}});
        if(result != null)
            SHVDN.Console.PrintInfo($""[Return Value]: {{result}}"");
    }}";

            }
            public readonly string Code;
            public readonly delegate* unmanaged<int, char**, IntPtr> UnmanagedHandler;
            public readonly MethodInfo ManagedHandler;
            public readonly object ManagedTarget;
            public readonly string Help;
            internal readonly string Name;
            internal readonly string ParametersStr;
            internal readonly string Assembly;

            private static readonly Regex ParametersRegex = new(@"~b~(?<name>\w+):~g~(?<type>\w+)~s~");
        }
    }
}
