namespace SHVDN
{
    public unsafe class Logger
    {
        static Logger()
        {
            _trace = (delegate* unmanaged<char*, void>)Core.Import("LogTraceW");
            _debug = (delegate* unmanaged<char*, void>)Core.Import("LogDebugW");
            _info = (delegate* unmanaged<char*, void>)Core.Import("LogInfoW");
            _warn = (delegate* unmanaged<char*, void>)Core.Import("LogWarnW");
            _error = (delegate* unmanaged<char*, void>)Core.Import("LogErrorW");
            _critical = (delegate* unmanaged<char*, void>)Core.Import("LogCriticalW");
        }
        public static void Debug(ReadOnlySpan<char> msg) => Write(msg, L_DBG);
        public static void Info(ReadOnlySpan<char> msg) => Write(msg, L_INF);
        public static void Warn(ReadOnlySpan<char> msg) => Write(msg, L_WRN);
        public static void Error(ReadOnlySpan<char> msg) => Write(msg, L_ERR);
        public static void Write(ReadOnlySpan<char> msg, uint lev)
        {
            delegate* unmanaged<char*, void> func =
            lev switch
            {
                L_TRC => _trace,
                L_DBG => _debug,
                L_INF => _info,
                L_WRN => _warn,
                L_ERR => _error,
                L_CRI => _critical,
                _ => throw new ArgumentException("Invalid level", nameof(lev))
            };
            fixed (char* ptr = msg)
            {
                func(ptr);
            }
        }

        private static readonly delegate* unmanaged<char*, void> _trace;
        private static readonly delegate* unmanaged<char*, void> _debug;
        private static readonly delegate* unmanaged<char*, void> _info;
        private static readonly delegate* unmanaged<char*, void> _warn;
        private static readonly delegate* unmanaged<char*, void> _error;
        private static readonly delegate* unmanaged<char*, void> _critical;
    }
}