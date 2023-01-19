//
// Copyright (C) 2015 crosire & contributors
// License: https://github.com/crosire/scripthookvdotnet#license
//

using GTA.Native;
using GTA;
using static GTA.Native.Function;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace SHVDN
{
    internal static unsafe partial class Console
    {
        static int _cursorPos = 0;
        static int _commandPos = -1;
        static int _currentPage = 1;
        static bool _isOpen = false;
        static string _input = string.Empty;
        static List<string> _lineHistory = new();
        static List<string> _commandHistory = new(); // This must be set via CommandHistory property
        static ConcurrentQueue<string[]> _outputQueue = new();
        static Dictionary<string, ConsoleCommand> _commands = new();
        static DateTime _lastClosed;
        const int BASE_WIDTH = 1280;
        const int BASE_HEIGHT = 720;
        const int CONSOLE_WIDTH = BASE_WIDTH;
        const int CONSOLE_HEIGHT = BASE_HEIGHT / 3;
        const int INPUT_HEIGHT = 20;
        const int LINES_PER_PAGE = 16;

        static readonly Color InputColor = Color.White;
        static readonly Color InputColorBusy = Color.DarkGray;
        static readonly Color OutputColor = Color.White;
        static readonly Color PrefixColor = Color.FromArgb(255, 52, 152, 219);
        static readonly Color BackgroundColor = Color.FromArgb(200, Color.Black);
        static readonly Color AltBackgroundColor = Color.FromArgb(200, 52, 73, 94);

        [DllImport("user32.dll")]
        static extern int ToUnicode(
            uint virtualKeyCode, uint scanCode, byte[] keyboardState,
            [Out, MarshalAs(UnmanagedType.LPWStr, SizeConst = 64)] StringBuilder receivingBuffer, int bufferSize, uint flags);

        /// <summary>
        /// Gets or sets whether the console is open.
        /// </summary>
        public static bool IsOpen
        {
            get => _isOpen;
            set
            {
                _isOpen = value;
                DisableControlsThisFrame();
                if (!_isOpen)
                    _lastClosed = DateTime.UtcNow.AddMilliseconds(200); // Hack so the input gets blocked long enough
            }
        }

        /// <summary>
        /// Gets or sets the command history. This is used to avoid losing the command history on SHVDN reloading.
        /// </summary>
        public static List<string> CommandHistory
        {
            get => _commandHistory;
            set => _commandHistory = value;
        }

        /// <summary>
        /// Register the specified method as a console command.
        /// </summary>
        /// <param name="command">The command attribute of the method.</param>
        /// <param name="methodInfo">The method information.</param>
        public static void RegisterCommand(delegate* unmanaged<int, char**, IntPtr> func, ReadOnlySpan<char> name, ReadOnlySpan<char> param, ReadOnlySpan<char> help, ReadOnlySpan<char> assembly)
        {
            var command = new ConsoleCommand((IntPtr)func, name, param, help, assembly);
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

        [UnmanagedCallersOnly(EntryPoint = "RegisterConsoleCommand")]
        public static void RegisterCommand(delegate* unmanaged<int, char**, IntPtr> func, char* name, char* param, char* help, char* assembly)
            => RegisterCommand(func, PtrToSpanUni(name), PtrToSpanUni(param), PtrToSpanUni(help), PtrToSpanUni(assembly));

        /// <summary>
        /// Unregister all methods with a <see cref="ConsoleCommand"/> attribute that were previously registered.
        /// </summary>
        /// <param name="type">The type to search for console command methods.</param>
        public static void UnregisterCommand(string name)
        {
            lock (_commands)
            {
                if (_commands.ContainsKey(name)) { _commands.Remove(name); }
            }
        }

        /// <summary>
        /// Add text lines to the console. This call is thread-safe.
        /// </summary>
        /// <param name="prefix">The prefix for each line.</param>
        /// <param name="messages">The lines to add to the console.</param>

        /// <summary>
        /// Add text lines to the console. This call is thread-safe.
        /// </summary>
        /// <param name="prefix">The prefix for each line.</param>
        /// <param name="messages">The lines to add to the console.</param>
        static void AddLines(string prefix, string[] messages)
        {
            AddLines(prefix, messages, "~w~");
        }
        /// <summary>
        /// Add colored text lines to the console. This call is thread-safe.
        /// </summary>
        /// <param name="prefix">The prefix for each line.</param>
        /// <param name="messages">The lines to add to the console.</param>
        /// <param name="color">The color of those lines.</param>
        static void AddLines(string prefix, string[] messages, string color)
        {
            for (int i = 0; i < messages.Length; i++) // Add proper styling
                messages[i] = $"~c~[{DateTime.Now.ToString("HH:mm:ss")}] ~w~{prefix} {color}{messages[i]}";

            _outputQueue.Enqueue(messages);
        }
        /// <summary>
        /// Add text to the console input line.
        /// </summary>
        /// <param name="text">The text to add.</param>
        static void AddToInput(ReadOnlySpan<char> text)
        {
            var t = text.ToString();
            if (string.IsNullOrEmpty(t))
                return;

            _input = _input.Insert(_cursorPos, t);
            _cursorPos += text.Length;
        }
        /// <summary>
        /// Paste clipboard content into the console input line.
        /// </summary>
        static void AddClipboardContent()
        {
            string text = GetClipboardText().ToString();
            text = text.Replace("\n", string.Empty); // TODO Keep this?

            AddToInput(text);
        }


        /// <summary>
        /// Clear the console input line.
        /// </summary>
        static void ClearInput()
        {
            _input = string.Empty;
            _cursorPos = 0;
        }
        /// <summary>
        /// Clears the console output.
        /// </summary>
        public static void Clear()
        {
            _lineHistory.Clear();
            _currentPage = 1;
        }

        /// <summary>
        /// Writes an info message to the console.
        /// </summary>
        /// <param name="msg">The composite format string.</param>
        /// <param name="args">The formatting arguments.</param>
        public static void PrintInfo(string msg, params object[] args)
        {
            if (args.Length > 0)
                msg = String.Format(msg, args);
            AddLines("[~b~INFO~w~] ", msg.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries));
        }
        /// <summary>
        /// Writes an error message to the console.
        /// </summary>
        /// <param name="msg">The composite format string.</param>
        /// <param name="args">The formatting arguments.</param>
        public static void PrintError(string msg, params object[] args)
        {
            if (args.Length > 0)
                msg = String.Format(msg, args);
            AddLines("[~r~ERROR~w~] ", msg.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries));
        }
        /// <summary>
        /// Writes a warning message to the console.
        /// </summary>
        /// <param name="msg">The composite format string.</param>
        /// <param name="args">The formatting arguments.</param>
        public static void PrintWarning(string msg, params object[] args)
        {
            if (args.Length > 0)
                msg = String.Format(msg, args);
            AddLines("[~o~WARNING~w~] ", msg.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries));
        }

        /// <summary>
        /// Writes the help text for all commands to the console.
        /// </summary>
        internal static void PrintHelpText()
        {
            lock (_commands)
            {
                StringBuilder help = new StringBuilder();
                var commands = _commands.Values.OrderBy(x => x.Assembly);
                if (!commands.Any()) return;
                string assm = null;
                foreach (var command in commands)
                {
                    if (assm != command.Assembly)
                    {
                        assm = command.Assembly;
                        help.AppendLine($"[{assm}]");
                    }
                    help.AppendLine($"    ~h~{command.Name}({command.Parameters})~h~ : {command.Help}");
                }

                PrintInfo(help.ToString());
            }
        }
        /// <summary>
        /// Writes the help text for the specified command to the console.
        /// </summary>
        /// <param name="commandName">The command name to check.</param>
        internal static void PrintHelpText(string commandName)
        {
            if (_commands.TryGetValue(commandName, out var command))
            {
                PrintInfo($"~h~{command.Name}({command.Parameters})~h~: {command.Help}");
                return;
            }
        }

        /// <summary>
        /// Main execution logic of the console.
        /// </summary>
		/// <summary>
		/// Main execution logic of the console.
		/// </summary>
		internal static void DoTick()
        {
            DateTime now = DateTime.UtcNow;
            // Add lines from concurrent queue to history
            if (_outputQueue.TryDequeue(out string[] lines))
                foreach (string line in lines)
                    _lineHistory.Add(line);

            if (!IsOpen)
            {
                // Hack so the input gets blocked long enough
                if (_lastClosed > now)
                    DisableControlsThisFrame();
                return; // Nothing more to do here when the console is not open
            }

            // Disable controls while the console is open
            DisableControlsThisFrame();

            // Draw background
            DrawRect(0, 0, CONSOLE_WIDTH, CONSOLE_HEIGHT, BackgroundColor);
            // Draw input field
            DrawRect(0, CONSOLE_HEIGHT, CONSOLE_WIDTH, INPUT_HEIGHT, AltBackgroundColor);
            DrawRect(0, CONSOLE_HEIGHT + INPUT_HEIGHT, 80, INPUT_HEIGHT, AltBackgroundColor);
            // Draw input prefix
            DrawText(0, CONSOLE_HEIGHT, "$>", PrefixColor);
            // Draw input text
            DrawText(25, CONSOLE_HEIGHT, _input, InputColor);
            // Draw page information
            DrawText(5, CONSOLE_HEIGHT + INPUT_HEIGHT, "Page " + _currentPage + "/" + System.Math.Max(1, ((_lineHistory.Count + (LINES_PER_PAGE - 1)) / LINES_PER_PAGE)), InputColor);

            // Draw blinking cursor
            if (now.Millisecond < 500)
            {
                float length = GetStringWidth(_input.Substring(0, _cursorPos));

                DrawRect(25 + (length * CONSOLE_WIDTH) - 5, CONSOLE_HEIGHT + 3, 3, INPUT_HEIGHT - 6, Color.White);
            }

            // Draw console history text
            int historyOffset = _lineHistory.Count - (LINES_PER_PAGE * _currentPage);
            int historyLength = historyOffset + LINES_PER_PAGE;
            for (int i = System.Math.Max(0, historyOffset); i < historyLength; ++i)
            {
                DrawText(2, (float)((i - historyOffset) * 14), _lineHistory[i], OutputColor);
            }
        }
        internal static void DoKeyEvent(Keys keys, bool status)
        {
            if (!status || !IsOpen)
                return; // Only interested in key down events and do not need to handle events when the console is not open

            var e = new KeyEventArgs(keys);

            if (e.KeyCode == Keys.PageUp)
            {
                PageUp();
                return;
            }
            if (e.KeyCode == Keys.PageDown)
            {
                PageDown();
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Back:
                    RemoveCharLeft();
                    break;
                case Keys.Delete:
                    RemoveCharRight();
                    break;
                case Keys.Left:
                    if (e.Control)
                        BackwardWord();
                    else
                        MoveCursorLeft();
                    break;
                case Keys.Right:
                    if (e.Control)
                        ForwardWord();
                    else
                        MoveCursorRight();
                    break;
                case Keys.Home:
                    MoveCursorToBegOfLine();
                    break;
                case Keys.End:
                    MoveCursorToEndOfLine();
                    break;
                case Keys.Up:
                    GoUpCommandList();
                    break;
                case Keys.Down:
                    GoDownCommandList();
                    break;
                case Keys.Enter:
                    Execute();
                    break;
                case Keys.Escape:
                    IsOpen = false;
                    break;
                case Keys.B:
                    if (e.Control)
                        MoveCursorLeft();
                    else if (e.Alt)
                        BackwardWord();
                    else
                        goto default;
                    break;
                case Keys.D:
                    if (e.Control)
                        RemoveCharRight();
                    else
                        goto default;
                    break;
                case Keys.F:
                    if (e.Control)
                        MoveCursorRight();
                    else if (e.Alt)
                        ForwardWord();
                    else
                        goto default;
                    break;
                case Keys.H:
                    if (e.Control)
                        RemoveCharLeft();
                    else
                        goto default;
                    break;
                case Keys.A:
                    if (e.Control)
                        MoveCursorToBegOfLine();
                    else
                        goto default;
                    break;
                case Keys.E:
                    if (e.Control)
                        MoveCursorToEndOfLine();
                    else
                        goto default;
                    break;
                case Keys.P:
                    if (e.Control)
                        GoUpCommandList();
                    else
                        goto default;
                    break;
                case Keys.K:
                    if (e.Control)
                        RemoveAllCharsRight();
                    else
                        goto default;
                    break;
                case Keys.N:
                    if (e.Control)
                        GoDownCommandList();
                    else
                        goto default;
                    break;
                case Keys.L:
                    if (e.Control)
                        Clear();
                    else
                        goto default;
                    break;
                case Keys.T:
                    if (e.Control)
                        TransposeTwoChars();
                    else
                        goto default;
                    break;
                case Keys.U:
                    if (e.Control)
                        RemoveAllCharsLeft();
                    else
                        goto default;
                    break;
                case Keys.V:
                    if (e.Control)
                        AddClipboardContent();
                    else
                        goto default;
                    break;
                default:
                    var buf = new StringBuilder(256);
                    var keyboardState = new byte[256];
                    keyboardState[(int)Keys.Menu] = e.Alt ? (byte)0xff : (byte)0;
                    keyboardState[(int)Keys.ShiftKey] = e.Shift ? (byte)0xff : (byte)0;
                    keyboardState[(int)Keys.ControlKey] = e.Control ? (byte)0xff : (byte)0;

                    // Translate key event to character for text input
                    ToUnicode((uint)e.KeyCode, 0, keyboardState, buf, 256, 0);
                    AddToInput(buf.ToString());
                    break;
            }
        }
        static void Execute()
        {
            if (string.IsNullOrEmpty(_input))
            {
                ClearInput();
                return;
            }

            _commandPos = -1;
            if (_commandHistory.LastOrDefault() != _input)
                _commandHistory.Add(_input);

            var command = _input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];

            lock (_commands)
            {
                if (_commands.TryGetValue(command, out var cmdObj))
                {
                    var result = default(string);
                    if (_input.Replace(" ", "").Length > command.Length)
                    {
                        var argv = CommandLineToArgvW(_input.Substring(command.Length), out var argc);
                        result = Marshal.PtrToStringUni(cmdObj.FuncPtr(argc, argv));
                        Marshal.FreeHGlobal((IntPtr)argv);
                    }
                    else
                    {
                        result = Marshal.PtrToStringUni(cmdObj.FuncPtr(0, null));
                    }
                    if (result != null)
                    {
                        PrintInfo(result);
                    }
                }
                else
                {
                    PrintError("Command not found: " + command);
                }
            }
            ClearInput();
        }
        static void PageUp()
        {
            if (_currentPage < ((_lineHistory.Count + LINES_PER_PAGE - 1) / LINES_PER_PAGE))
                _currentPage++;
        }
        static void PageDown()
        {
            if (_currentPage > 1)
                _currentPage--;
        }
        static void GoUpCommandList()
        {
            if (_commandHistory.Count == 0 || _commandPos >= _commandHistory.Count - 1)
                return;

            _commandPos++;
            _input = _commandHistory[_commandHistory.Count - _commandPos - 1];
            // Reset cursor position to end of input text
            _cursorPos = _input.Length;
        }
        static void GoDownCommandList()
        {
            if (_commandHistory.Count == 0 || _commandPos <= 0)
                return;

            _commandPos--;
            _input = _commandHistory[_commandHistory.Count - _commandPos - 1];
            _cursorPos = _input.Length;
        }

        static void ForwardWord()
        {
            var regex = new Regex(@"[^\W_]+");
            Match match = regex.Match(_input, _cursorPos);
            _cursorPos = match.Success ? match.Index + match.Length : _input.Length;
        }
        static void BackwardWord()
        {
            var regex = new Regex(@"[^\W_]+");
            MatchCollection matches = regex.Matches(_input);
            _cursorPos = matches.Cast<Match>().Where(x => x.Index < _cursorPos).Select(x => x.Index).LastOrDefault();
        }
        static void RemoveCharLeft()
        {
            if (_input.Length > 0 && _cursorPos > 0)
            {
                _input = _input.Remove(_cursorPos - 1, 1);
                _cursorPos--;
            }
        }
        static void RemoveCharRight()
        {
            if (_input.Length > 0 && _cursorPos < _input.Length)
            {
                _input = _input.Remove(_cursorPos, 1);
            }
        }
        static void RemoveAllCharsLeft()
        {
            if (_input.Length > 0 && _cursorPos > 0)
            {
                _input = _input.Remove(0, _cursorPos);
                _cursorPos = 0;
            }
        }
        static void RemoveAllCharsRight()
        {
            if (_input.Length > 0 && _cursorPos < _input.Length)
            {
                _input = _input.Remove(_cursorPos, _input.Length - _cursorPos);
            }
        }
        static void TransposeTwoChars()
        {
            var inputLength = _input.Length;
            if (inputLength < 2)
            {
                return;
            }

            if (_cursorPos == 0)
            {
                SwapTwoCharacters(_input, 0);
                _cursorPos = 2;
            }
            else if (_cursorPos < inputLength)
            {
                SwapTwoCharacters(_input, _cursorPos - 1);
                _cursorPos += 1;
            }
            else
            {
                SwapTwoCharacters(_input, _cursorPos - 2);
            }

            void SwapTwoCharacters(string str, int index)
            {
                unsafe
                {
                    fixed (char* stringPtr = str)
                    {
                        char tmp = stringPtr[index];
                        stringPtr[index] = stringPtr[index + 1];
                        stringPtr[index + 1] = tmp;
                    }
                }
            }
        }
        static void MoveCursorLeft()
        {
            if (_cursorPos > 0)
                _cursorPos--;
        }
        static void MoveCursorRight()
        {
            if (_cursorPos < _input.Length)
                _cursorPos++;
        }
        static void MoveCursorToBegOfLine()
        {
            _cursorPos = 0;
        }
        static void MoveCursorToEndOfLine()
        {
            _cursorPos = _input.Length;
        }

        static unsafe void DrawRect(float x, float y, int width, int height, Color color)
        {
            float w = (float)(width) / BASE_WIDTH;
            float h = (float)(height) / BASE_HEIGHT;

            Call(Hash.DRAW_RECT,
                (x / BASE_WIDTH) + w * 0.5f,
                (y / BASE_HEIGHT) + h * 0.5f,
                w, h,
                color.R, color.G, color.B, color.A);
        }
        static unsafe void DrawText(float x, float y, string text, Color color)
        {
            Call(Hash.SET_TEXT_FONT, 0); // Chalet London :>
            Call(Hash.SET_TEXT_SCALE, 0.35f, 0.35f);
            Call(Hash.SET_TEXT_COLOUR, color.R, color.G, color.B, color.A);
            Call(Hash.BEGIN_TEXT_COMMAND_DISPLAY_TEXT, SHVDN.NativeMemory.CellEmailBcon);
            PushLongString(text);
            Call(Hash.END_TEXT_COMMAND_DISPLAY_TEXT /*END_TEXT_COMMAND_DISPLAY_TEXT*/, (x / BASE_WIDTH), (y / BASE_HEIGHT));
        }

        static unsafe void DisableControlsThisFrame()
        {
            Function.Call(Hash.DISABLE_ALL_CONTROL_ACTIONS, 0);

            // LookLeftRight .. LookRightOnly
            for (ulong i = 1; i <= 6; i++)
                Function.Call(Hash.ENABLE_CONTROL_ACTION, 0, i, 0);
        }

        static unsafe float GetStringWidth(ReadOnlySpan<char> text, float scale = 0.35f, int font = 0)
        {
            Call(Hash.SET_TEXT_FONT, font);
            Call(Hash.SET_TEXT_SCALE, scale, scale);
            Call(Hash.BEGIN_TEXT_COMMAND_GET_SCREEN_WIDTH_OF_DISPLAY_TEXT, NativeMemory.CellEmailBcon);
            PushLongString(text);
            return Call<float>(Hash.END_TEXT_COMMAND_GET_SCREEN_WIDTH_OF_DISPLAY_TEXT, true);
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
        [DllImport("shell32.dll", SetLastError = true)]
        static extern char** CommandLineToArgvW([MarshalAs(UnmanagedType.LPWStr)] string lpCmdLine, out int pNumArgs);
    }

    public unsafe class ConsoleCommand
    {
        public ConsoleCommand(IntPtr func, ReadOnlySpan<char> name, ReadOnlySpan<char> param, ReadOnlySpan<char> help, ReadOnlySpan<char> assembly)
        {
            Name = name.ToString();
            Parameters = param.ToString();
            Help = help.ToString();
            Assembly = assembly.ToString();
            FuncPtr = (delegate* unmanaged<int, char**, IntPtr>)func;
        }
        public delegate* unmanaged<int, char**, IntPtr> FuncPtr; // argc,argv,result
        public string Help { get; }

        internal string Name { get; }
        internal string Parameters { get; }
        internal string Assembly { get; }
    }
}
