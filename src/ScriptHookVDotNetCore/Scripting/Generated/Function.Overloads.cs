namespace GTA.Native;
public static unsafe partial class Function
{
#region Call overloads without return value
    public static void Call(Hash hash)
    {
        NativeInit((ulong)hash);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        NativePush64(arg27);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        NativePush64(arg27);
        NativePush64(arg28);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        NativePush64(arg27);
        NativePush64(arg28);
        NativePush64(arg29);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        NativePush64(arg27);
        NativePush64(arg28);
        NativePush64(arg29);
        NativePush64(arg30);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        NativePush64(arg27);
        NativePush64(arg28);
        NativePush64(arg29);
        NativePush64(arg30);
        NativePush64(arg31);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        NativePush64(arg27);
        NativePush64(arg28);
        NativePush64(arg29);
        NativePush64(arg30);
        NativePush64(arg31);
        NativePush64(arg32);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        NativePush64(arg27);
        NativePush64(arg28);
        NativePush64(arg29);
        NativePush64(arg30);
        NativePush64(arg31);
        NativePush64(arg32);
        NativePush64(arg33);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        NativePush64(arg27);
        NativePush64(arg28);
        NativePush64(arg29);
        NativePush64(arg30);
        NativePush64(arg31);
        NativePush64(arg32);
        NativePush64(arg33);
        NativePush64(arg34);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        NativePush64(arg27);
        NativePush64(arg28);
        NativePush64(arg29);
        NativePush64(arg30);
        NativePush64(arg31);
        NativePush64(arg32);
        NativePush64(arg33);
        NativePush64(arg34);
        NativePush64(arg35);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        NativePush64(arg27);
        NativePush64(arg28);
        NativePush64(arg29);
        NativePush64(arg30);
        NativePush64(arg31);
        NativePush64(arg32);
        NativePush64(arg33);
        NativePush64(arg34);
        NativePush64(arg35);
        NativePush64(arg36);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36, InputArgument arg37)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        NativePush64(arg27);
        NativePush64(arg28);
        NativePush64(arg29);
        NativePush64(arg30);
        NativePush64(arg31);
        NativePush64(arg32);
        NativePush64(arg33);
        NativePush64(arg34);
        NativePush64(arg35);
        NativePush64(arg36);
        NativePush64(arg37);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36, InputArgument arg37, InputArgument arg38)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        NativePush64(arg27);
        NativePush64(arg28);
        NativePush64(arg29);
        NativePush64(arg30);
        NativePush64(arg31);
        NativePush64(arg32);
        NativePush64(arg33);
        NativePush64(arg34);
        NativePush64(arg35);
        NativePush64(arg36);
        NativePush64(arg37);
        NativePush64(arg38);
        Core.ExecuteTask(ref NativeCallTask.Default);
    }

#endregion
#region Call overloads with return value
    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash)
    {
        NativeInit((ulong)hash);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        NativePush64(arg27);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        NativePush64(arg27);
        NativePush64(arg28);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        NativePush64(arg27);
        NativePush64(arg28);
        NativePush64(arg29);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        NativePush64(arg27);
        NativePush64(arg28);
        NativePush64(arg29);
        NativePush64(arg30);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        NativePush64(arg27);
        NativePush64(arg28);
        NativePush64(arg29);
        NativePush64(arg30);
        NativePush64(arg31);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        NativePush64(arg27);
        NativePush64(arg28);
        NativePush64(arg29);
        NativePush64(arg30);
        NativePush64(arg31);
        NativePush64(arg32);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        NativePush64(arg27);
        NativePush64(arg28);
        NativePush64(arg29);
        NativePush64(arg30);
        NativePush64(arg31);
        NativePush64(arg32);
        NativePush64(arg33);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        NativePush64(arg27);
        NativePush64(arg28);
        NativePush64(arg29);
        NativePush64(arg30);
        NativePush64(arg31);
        NativePush64(arg32);
        NativePush64(arg33);
        NativePush64(arg34);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        NativePush64(arg27);
        NativePush64(arg28);
        NativePush64(arg29);
        NativePush64(arg30);
        NativePush64(arg31);
        NativePush64(arg32);
        NativePush64(arg33);
        NativePush64(arg34);
        NativePush64(arg35);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        NativePush64(arg27);
        NativePush64(arg28);
        NativePush64(arg29);
        NativePush64(arg30);
        NativePush64(arg31);
        NativePush64(arg32);
        NativePush64(arg33);
        NativePush64(arg34);
        NativePush64(arg35);
        NativePush64(arg36);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36, InputArgument arg37)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        NativePush64(arg27);
        NativePush64(arg28);
        NativePush64(arg29);
        NativePush64(arg30);
        NativePush64(arg31);
        NativePush64(arg32);
        NativePush64(arg33);
        NativePush64(arg34);
        NativePush64(arg35);
        NativePush64(arg36);
        NativePush64(arg37);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36, InputArgument arg37, InputArgument arg38)
    {
        NativeInit((ulong)hash);
        NativePush64(arg0);
        NativePush64(arg1);
        NativePush64(arg2);
        NativePush64(arg3);
        NativePush64(arg4);
        NativePush64(arg5);
        NativePush64(arg6);
        NativePush64(arg7);
        NativePush64(arg8);
        NativePush64(arg9);
        NativePush64(arg10);
        NativePush64(arg11);
        NativePush64(arg12);
        NativePush64(arg13);
        NativePush64(arg14);
        NativePush64(arg15);
        NativePush64(arg16);
        NativePush64(arg17);
        NativePush64(arg18);
        NativePush64(arg19);
        NativePush64(arg20);
        NativePush64(arg21);
        NativePush64(arg22);
        NativePush64(arg23);
        NativePush64(arg24);
        NativePush64(arg25);
        NativePush64(arg26);
        NativePush64(arg27);
        NativePush64(arg28);
        NativePush64(arg29);
        NativePush64(arg30);
        NativePush64(arg31);
        NativePush64(arg32);
        NativePush64(arg33);
        NativePush64(arg34);
        NativePush64(arg35);
        NativePush64(arg36);
        NativePush64(arg37);
        NativePush64(arg38);
        Core.ExecuteTask(ref NativeCallTask.Default);
        return ConvertFromNative<T>(NativeCallTask.Default.Result);
    }
#endregion
}