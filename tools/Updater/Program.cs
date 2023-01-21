using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static System.IO.Path;
namespace Updater
{
    internal unsafe class Program
    {
        static HashSet<string> SrcExlude = new HashSet<string>
        {
            "Native.cs",
            "Script.cs",
            "Vector3.cs",
            "ScriptAttributes.cs"
        };
        static Dictionary<string, string> SrcUpstream = new();
        static List<ISourceUpdater> Updaters = typeof(ISourceUpdater).Assembly.GetTypes().Where(x => x.IsAssignableTo(typeof(ISourceUpdater)) && !x.IsAbstract && !x.IsInterface).Select(x =>
        {
            Console.WriteLine($"Adding updater {x}");
            return (ISourceUpdater)Activator.CreateInstance(x);
        }).ToList();

        public static int StrLenUni(char* pChar)
        {
            int len = 0;
            while (pChar[len] != 0) { len++; }
            return len;
        }
        [Flags]
        enum ParseState
        {
            Gap = 0,
            Read = 1,
            ReadEscape = 2,
            InQuotes = 4
        }
        static List<string> Parse(char* input)
        {
            ParseState state = ParseState.Gap;
            var results = new List<string>();
            char* currentCommandBuf = stackalloc char[StrLenUni(input)];
            char thisChar;
            int inputIndex = 0;
            int curCmdIndex = 0;
            while ((thisChar = input[inputIndex]) != 0)
            {
                Console.WriteLine("Reading char: " + thisChar);
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
                Console.WriteLine("State: " + state);
            }
            if (state.HasFlag(ParseState.Read))
            {
                currentCommandBuf[curCmdIndex] = '\0';
                results.Add(new(currentCommandBuf));
            }

            void throwEs()
            {
                throw new Exception($"Unrecognized esacape sequence: '\\{thisChar}'");
            }
            return results;
        }
        public static List<string> Parse(string input)
        {
            fixed (char* pI = input)
            {
                return Parse(pI);
            }
        }
        static unsafe void Main(string[] args)
        {
            void Add(string src)
            {
                var t = File.ReadAllText(src);
                var u = Updaters.Where(x => x.TargetFile == GetFileName(src) || x.TargetFile == null);
                if (u.Any())
                {
                    foreach (var ur in u)
                    {
                        if (ur.TargetFile != null)
                        {
                            Console.WriteLine($"Running updater {ur.GetType()}");
                        }
                        t = ur.Update(t);
                    }
                }
                SrcUpstream.Add(src, t);
            }
            Directory.SetCurrentDirectory(@"..\..\");
            Console.WriteLine($"Working directory is {Directory.GetCurrentDirectory()}");
            Console.WriteLine("Reading upstream source");
            Add(Combine("shvdn", "source", "core", "NativeMemory.cs"));
            foreach (var dir in Directory.GetDirectories(Combine("shvdn", "source", "scripting_v3"), "GTA*", SearchOption.TopDirectoryOnly))
            {
                foreach (var sc in Directory.GetFiles(dir, "*.cs", SearchOption.AllDirectories))
                {
                    if (!SrcExlude.Contains(GetFileName(sc)))
                    {
                        Add(sc);
                        // Console.WriteLine("added source " + sc);
                    }
                }
            }

            var dest = Combine("src", "ScriptHookVDotNetCore", "CodeDom");
            if (Directory.Exists(dest))
            {
                try
                {

                    Directory.Delete(dest, true);
                }
                catch (Exception) { }
            }
            Directory.CreateDirectory(dest);
            foreach (var s in SrcUpstream)
            {
                File.WriteAllText(Combine(dest, GetFileName(s.Key)), s.Value);
            }
        }
    }
}