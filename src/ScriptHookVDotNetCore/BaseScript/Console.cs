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
using GTA.UI;
using System.Xml.Linq;
using System;

namespace SHVDN
{
    /// <summary>
    /// SHVDN.Console implementations
    /// </summary>
    internal static unsafe partial class Console
    {
        const string INFO_PREFIX = "[~b~INFO~w~] ";
        const string ERROR_PREFIX = "[~r~ERROR~w~] ";
        const string WARNING_PREFIX = "[~o~WARNING~w~] ";
        static int _cursorPos = 0;
        static int _commandPos = -1;
        static int _currentPage = 1;
        static bool _isOpen = false;
        static string _input = string.Empty;
        static List<string> _lineHistory = new();
        static List<string> _commandHistory = new(); // This must be set via CommandHistory property
        static ConcurrentQueue<string> _outputQueue = new();
        static Dictionary<string, Command> _commands = new();
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
        static void AddLine(ReadOnlySpan<char> prefix, ReadOnlySpan<char> msg, string color)
        {
            _outputQueue.Enqueue($"~c~[{DateTime.Now.ToString("HH:mm:ss")}] ~w~{prefix} {color}{msg}");
        }
        static float GetTextLength(ReadOnlySpan<char> str)
        {
            fixed (char* p = str)
            {
                return GetTextLength(p, str.Length, GetMarginLength());
            }
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
        public static void PrintInfo(string msg, params object[] args) => Print(INFO_PREFIX, msg, args);
        /// <summary>
        /// Writes an error message to the console.
        /// </summary>
        /// <param name="msg">The composite format string.</param>
        /// <param name="args">The formatting arguments.</param>
        public static void PrintError(string msg, params object[] args) => Print(ERROR_PREFIX, msg, args);
        /// <summary>
        /// Writes a warning message to the console.
        /// </summary>
        /// <param name="msg">The composite format string.</param>
        /// <param name="args">The formatting arguments.</param>
        public static void PrintWarning(string msg, params object[] args) => Print(WARNING_PREFIX, msg, args);
        public static void Print(string prefix, string msg, params object[] args)
        {
            if (args.Length > 0)
                msg = String.Format(msg, args);
            foreach (var s in msg.Split('\n', StringSplitOptions.RemoveEmptyEntries))
            {
                AddLine(prefix, s, "~s~");
            }
        }

        /// <summary>
        /// Writes the help text for all commands to the console.
        /// </summary>
        internal static void PrintHelpText()
        {
            lock (_commands)
            {
                StringBuilder help = new();
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
                    help.AppendLine($"    ~h~{command.Name}({command.ParametersStr})~h~ ~s~ => {command.Help}");
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
                PrintInfo($"~h~{command.Name}({command.ParametersStr})~h~ ~s~ => {command.Help}");
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

            // Execute compiled input line script
            if (_compilerTask != null && _compilerTask.IsCompleted)
            {
                if (_compilerTask.Result != null)
                {
                    try
                    {
                        ExecuteAndUnload(_compilerTask.Result, out _);
                    }
                    catch (TargetInvocationException ex)
                    {
                        Logger.Error($"[Exception]: {ex.InnerException}");
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(ex.ToString());
                    }
                    finally
                    {
                        _compilerTask.Result.Dispose();
                    }
                }

                ClearInput();

                // Reset compiler task
                _compilerTask = null;
            }

            // Add lines from concurrent queue to history
            while (_outputQueue.TryDequeue(out var line))
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
            DrawText(25, CONSOLE_HEIGHT, _input, _compilerTask == null ? InputColor : InputColorBusy);
            // Draw page information
            DrawText(5, CONSOLE_HEIGHT + INPUT_HEIGHT, "Page " + _currentPage + "/" + Math.Max(1, (_lineHistory.Count + (LINES_PER_PAGE - 1)) / LINES_PER_PAGE), InputColor);

            // Draw blinking cursor
            if (now.Millisecond < 500)
            {
                var input = _input.Substring(0, _cursorPos);
                float length = GetTextLength(input);
                DrawRect(25 + (length * CONSOLE_WIDTH) - 5, CONSOLE_HEIGHT + 3, 3, INPUT_HEIGHT - 6, Color.White);
            }

            // Draw console history text
            int historyOffset = _lineHistory.Count - (LINES_PER_PAGE * _currentPage);
            int historyLength = historyOffset + LINES_PER_PAGE;
            for (int i = Math.Max(0, historyOffset); i < historyLength; ++i)
            {
                DrawText(2, (i - historyOffset) * 14f, _lineHistory[i], OutputColor);
            }
        }
        internal static void DoKeyDown(KeyEventArgs e)
        {
            if (_compilerTask?.IsCompleted == false || !IsOpen)
                return;

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
                    BeginCompilation();
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

        static Task<MemoryStream> _compilerTask;
        static void BeginCompilation()
        {
            if (string.IsNullOrEmpty(_input) || _compilerTask != null)
                return;

            _commandPos = -1;
            if (_commandHistory.LastOrDefault() != _input)
                _commandHistory.Add(_input);

            _compilerTask = Task.Run(() =>
            {
                try
                {
                    return CompileInput(_input);
                }
                catch (Exception ex)
                {
                    PrintError("Failed to compile expression: " + ex);
                    return null;
                }
            });
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
        static unsafe float GetTextLength(char* str, int count, float marginLength)
        {
            if (str == null) return 0;
            var calculated = count;
            if (calculated > 50) { calculated = 50; }
            while (Encoding.UTF8.GetByteCount(str, calculated) > 50) { calculated--; };
            Call((Hash)0x66E0276CC5F6B9DA /*SET_TEXT_FONT*/, 0);
            Call((Hash)0x07C837F9A01C34C9 /*SET_TEXT_SCALE*/, 0.35f, 0.35f);
            Call((Hash)0x54CE8AC98E120CAB /*_BEGIN_TEXT_COMMAND_GET_WIDTH*/, NativeMemory.CellEmailBcon);
            PushString(new ReadOnlySpan<char>(str, calculated));
            var len = Call<float>((Hash)0x85F061DA64ED2F67 /*_END_TEXT_COMMAND_GET_WIDTH*/, true);
            if (calculated < count)
            {
                len += GetTextLength(str + calculated, count - calculated, marginLength) - marginLength;
            }
            return len;
        }
        static unsafe float GetMarginLength()
        {
            char* pC = stackalloc char[3] { 'A', '\0', '\0' };
            var len1 = GetTextLength(pC, 1, 0);
            pC[1] = 'A';
            var len2 = GetTextLength(pC, 2, 0);
            return len1 - (len2 - len1); // [Margin][A] - [A] = [Margin]
        }

        #region Exports

        public static void RegisterConsoleCommand(delegate* unmanaged<int, char**, IntPtr> func, char* name, char* param, char* help, char* assembly)
            => RegisterCommand(func, PtrToSpanUni(name), PtrToSpanUni(param), PtrToSpanUni(help), PtrToSpanUni(assembly));

        public static void PrintConsoleMessage(char* preFix, char* msg) => Print(new string(preFix), new string(msg));

        public static void ExecuteConsoleCommand(char* command)
        {
            _input = new(command);
            BeginCompilation();
        }

        static Console()
        {
            // Setup function pointer and store it in core
            Core.SetPtr(Core.KEY_CORECLR_CONSOLE_REG_FUNC, Marshal.GetFunctionPointerForDelegate(RegisterConsoleCommand));
            Core.SetPtr(Core.KEY_CORECLR_CONSOLE_PRINT_FUNC, Marshal.GetFunctionPointerForDelegate(PrintConsoleMessage));
            Core.SetPtr(Core.KEY_CORECLR_CONSOLE_EXEC_FUNC, Marshal.GetFunctionPointerForDelegate(ExecuteConsoleCommand));

            // Set up function bridge
            NativeLibrary.Load("ScriptHookVDotNetCore.BaseScript.dll");
        }

        #endregion

    }

}
