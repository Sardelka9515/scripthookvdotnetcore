namespace GTA.Native;
public static unsafe partial class Function
{
#region Call overloads without return value
    public static void Call(Hash hash)
    {
        NativeInit((ulong)hash);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativePush64(arg27.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativePush64(arg27.Value);
        NativePush64(arg28.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativePush64(arg27.Value);
        NativePush64(arg28.Value);
        NativePush64(arg29.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativePush64(arg27.Value);
        NativePush64(arg28.Value);
        NativePush64(arg29.Value);
        NativePush64(arg30.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativePush64(arg27.Value);
        NativePush64(arg28.Value);
        NativePush64(arg29.Value);
        NativePush64(arg30.Value);
        NativePush64(arg31.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativePush64(arg27.Value);
        NativePush64(arg28.Value);
        NativePush64(arg29.Value);
        NativePush64(arg30.Value);
        NativePush64(arg31.Value);
        NativePush64(arg32.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativePush64(arg27.Value);
        NativePush64(arg28.Value);
        NativePush64(arg29.Value);
        NativePush64(arg30.Value);
        NativePush64(arg31.Value);
        NativePush64(arg32.Value);
        NativePush64(arg33.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativePush64(arg27.Value);
        NativePush64(arg28.Value);
        NativePush64(arg29.Value);
        NativePush64(arg30.Value);
        NativePush64(arg31.Value);
        NativePush64(arg32.Value);
        NativePush64(arg33.Value);
        NativePush64(arg34.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativePush64(arg27.Value);
        NativePush64(arg28.Value);
        NativePush64(arg29.Value);
        NativePush64(arg30.Value);
        NativePush64(arg31.Value);
        NativePush64(arg32.Value);
        NativePush64(arg33.Value);
        NativePush64(arg34.Value);
        NativePush64(arg35.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativePush64(arg27.Value);
        NativePush64(arg28.Value);
        NativePush64(arg29.Value);
        NativePush64(arg30.Value);
        NativePush64(arg31.Value);
        NativePush64(arg32.Value);
        NativePush64(arg33.Value);
        NativePush64(arg34.Value);
        NativePush64(arg35.Value);
        NativePush64(arg36.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36, InputArgument arg37)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativePush64(arg27.Value);
        NativePush64(arg28.Value);
        NativePush64(arg29.Value);
        NativePush64(arg30.Value);
        NativePush64(arg31.Value);
        NativePush64(arg32.Value);
        NativePush64(arg33.Value);
        NativePush64(arg34.Value);
        NativePush64(arg35.Value);
        NativePush64(arg36.Value);
        NativePush64(arg37.Value);
        NativeCall();
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36, InputArgument arg37, InputArgument arg38)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativePush64(arg27.Value);
        NativePush64(arg28.Value);
        NativePush64(arg29.Value);
        NativePush64(arg30.Value);
        NativePush64(arg31.Value);
        NativePush64(arg32.Value);
        NativePush64(arg33.Value);
        NativePush64(arg34.Value);
        NativePush64(arg35.Value);
        NativePush64(arg36.Value);
        NativePush64(arg37.Value);
        NativePush64(arg38.Value);
        NativeCall();
    }

#endregion
#region Call overloads with return value
    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash)
    {
        NativeInit((ulong)hash);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativePush64(arg27.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativePush64(arg27.Value);
        NativePush64(arg28.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativePush64(arg27.Value);
        NativePush64(arg28.Value);
        NativePush64(arg29.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativePush64(arg27.Value);
        NativePush64(arg28.Value);
        NativePush64(arg29.Value);
        NativePush64(arg30.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativePush64(arg27.Value);
        NativePush64(arg28.Value);
        NativePush64(arg29.Value);
        NativePush64(arg30.Value);
        NativePush64(arg31.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativePush64(arg27.Value);
        NativePush64(arg28.Value);
        NativePush64(arg29.Value);
        NativePush64(arg30.Value);
        NativePush64(arg31.Value);
        NativePush64(arg32.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativePush64(arg27.Value);
        NativePush64(arg28.Value);
        NativePush64(arg29.Value);
        NativePush64(arg30.Value);
        NativePush64(arg31.Value);
        NativePush64(arg32.Value);
        NativePush64(arg33.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativePush64(arg27.Value);
        NativePush64(arg28.Value);
        NativePush64(arg29.Value);
        NativePush64(arg30.Value);
        NativePush64(arg31.Value);
        NativePush64(arg32.Value);
        NativePush64(arg33.Value);
        NativePush64(arg34.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativePush64(arg27.Value);
        NativePush64(arg28.Value);
        NativePush64(arg29.Value);
        NativePush64(arg30.Value);
        NativePush64(arg31.Value);
        NativePush64(arg32.Value);
        NativePush64(arg33.Value);
        NativePush64(arg34.Value);
        NativePush64(arg35.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativePush64(arg27.Value);
        NativePush64(arg28.Value);
        NativePush64(arg29.Value);
        NativePush64(arg30.Value);
        NativePush64(arg31.Value);
        NativePush64(arg32.Value);
        NativePush64(arg33.Value);
        NativePush64(arg34.Value);
        NativePush64(arg35.Value);
        NativePush64(arg36.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36, InputArgument arg37)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativePush64(arg27.Value);
        NativePush64(arg28.Value);
        NativePush64(arg29.Value);
        NativePush64(arg30.Value);
        NativePush64(arg31.Value);
        NativePush64(arg32.Value);
        NativePush64(arg33.Value);
        NativePush64(arg34.Value);
        NativePush64(arg35.Value);
        NativePush64(arg36.Value);
        NativePush64(arg37.Value);
        return ConvertFromNative<T>(NativeCall());
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36, InputArgument arg37, InputArgument arg38)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0.Value);
        NativePush64(arg1.Value);
        NativePush64(arg2.Value);
        NativePush64(arg3.Value);
        NativePush64(arg4.Value);
        NativePush64(arg5.Value);
        NativePush64(arg6.Value);
        NativePush64(arg7.Value);
        NativePush64(arg8.Value);
        NativePush64(arg9.Value);
        NativePush64(arg10.Value);
        NativePush64(arg11.Value);
        NativePush64(arg12.Value);
        NativePush64(arg13.Value);
        NativePush64(arg14.Value);
        NativePush64(arg15.Value);
        NativePush64(arg16.Value);
        NativePush64(arg17.Value);
        NativePush64(arg18.Value);
        NativePush64(arg19.Value);
        NativePush64(arg20.Value);
        NativePush64(arg21.Value);
        NativePush64(arg22.Value);
        NativePush64(arg23.Value);
        NativePush64(arg24.Value);
        NativePush64(arg25.Value);
        NativePush64(arg26.Value);
        NativePush64(arg27.Value);
        NativePush64(arg28.Value);
        NativePush64(arg29.Value);
        NativePush64(arg30.Value);
        NativePush64(arg31.Value);
        NativePush64(arg32.Value);
        NativePush64(arg33.Value);
        NativePush64(arg34.Value);
        NativePush64(arg35.Value);
        NativePush64(arg36.Value);
        NativePush64(arg37.Value);
        NativePush64(arg38.Value);
        return ConvertFromNative<T>(NativeCall());
    }
#endregion
}