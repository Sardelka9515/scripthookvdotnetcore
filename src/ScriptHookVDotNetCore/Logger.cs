﻿namespace SHVDN
{
    public unsafe class Logger
    {
        static Logger()
        {
            Debug = (delegate* unmanaged<string, void>)Core.Import("LogDebug");
            Info = (delegate* unmanaged<string, void>)Core.Import("LogInfo");
            Warn = (delegate* unmanaged<string, void>)Core.Import("LogWarn");
            Error = (delegate* unmanaged<string, void>)Core.Import("LogError");
        }

        public static delegate* unmanaged<string, void> Debug;
        public static delegate* unmanaged<string, void> Info;
        public static delegate* unmanaged<string, void> Warn;
        public static delegate* unmanaged<string, void> Error;
    }
}