namespace GTA.Native;
public static unsafe partial class Function
{
#region Call overloads without return value
    public static void Call(Hash hash)
    {
        if (Core.IsMainThread())
        {
            NativeInit((ulong)hash);
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, null, 0);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0)
    {
        if (Core.IsMainThread())
        {
            NativeInit((ulong)hash);
            NativePush64(arg0);
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 1);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1)
    {
        if (Core.IsMainThread())
        {
            NativeInit((ulong)hash);
            NativePush64(arg0);
            NativePush64(arg1);
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 2);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2)
    {
        if (Core.IsMainThread())
        {
            NativeInit((ulong)hash);
            NativePush64(arg0);
            NativePush64(arg1);
            NativePush64(arg2);
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 3);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3)
    {
        if (Core.IsMainThread())
        {
            NativeInit((ulong)hash);
            NativePush64(arg0);
            NativePush64(arg1);
            NativePush64(arg2);
            NativePush64(arg3);
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 4);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4)
    {
        if (Core.IsMainThread())
        {
            NativeInit((ulong)hash);
            NativePush64(arg0);
            NativePush64(arg1);
            NativePush64(arg2);
            NativePush64(arg3);
            NativePush64(arg4);
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 5);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5)
    {
        if (Core.IsMainThread())
        {
            NativeInit((ulong)hash);
            NativePush64(arg0);
            NativePush64(arg1);
            NativePush64(arg2);
            NativePush64(arg3);
            NativePush64(arg4);
            NativePush64(arg5);
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 6);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6)
    {
        if (Core.IsMainThread())
        {
            NativeInit((ulong)hash);
            NativePush64(arg0);
            NativePush64(arg1);
            NativePush64(arg2);
            NativePush64(arg3);
            NativePush64(arg4);
            NativePush64(arg5);
            NativePush64(arg6);
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 7);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 8);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 9);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 10);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 11);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 12);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 13);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 14);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 15);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 16);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 17);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 18);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 19);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 20);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 21);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 22);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 23);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 24);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 25);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 26);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 27);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 28);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 29);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 30);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 31);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 32);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 33);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 34);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 35);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 36);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 37);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36, InputArgument arg37)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 38);
            Core.DispatchTask(task);
        }
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36, InputArgument arg37, InputArgument arg38)
    {
        if (Core.IsMainThread())
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
            NativeCall();
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 39);
            Core.DispatchTask(task);
        }
    }

#endregion
#region Call overloads with return value
    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash)
    {
        if (Core.IsMainThread())
        {
            NativeInit((ulong)hash);
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, null, 0);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0)
    {
        if (Core.IsMainThread())
        {
            NativeInit((ulong)hash);
            NativePush64(arg0);
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 1);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1)
    {
        if (Core.IsMainThread())
        {
            NativeInit((ulong)hash);
            NativePush64(arg0);
            NativePush64(arg1);
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 2);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2)
    {
        if (Core.IsMainThread())
        {
            NativeInit((ulong)hash);
            NativePush64(arg0);
            NativePush64(arg1);
            NativePush64(arg2);
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 3);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3)
    {
        if (Core.IsMainThread())
        {
            NativeInit((ulong)hash);
            NativePush64(arg0);
            NativePush64(arg1);
            NativePush64(arg2);
            NativePush64(arg3);
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 4);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4)
    {
        if (Core.IsMainThread())
        {
            NativeInit((ulong)hash);
            NativePush64(arg0);
            NativePush64(arg1);
            NativePush64(arg2);
            NativePush64(arg3);
            NativePush64(arg4);
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 5);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5)
    {
        if (Core.IsMainThread())
        {
            NativeInit((ulong)hash);
            NativePush64(arg0);
            NativePush64(arg1);
            NativePush64(arg2);
            NativePush64(arg3);
            NativePush64(arg4);
            NativePush64(arg5);
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 6);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6)
    {
        if (Core.IsMainThread())
        {
            NativeInit((ulong)hash);
            NativePush64(arg0);
            NativePush64(arg1);
            NativePush64(arg2);
            NativePush64(arg3);
            NativePush64(arg4);
            NativePush64(arg5);
            NativePush64(arg6);
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 7);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 8);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 9);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 10);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 11);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 12);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 13);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 14);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 15);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 16);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 17);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 18);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 19);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 20);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 21);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 22);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 23);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 24);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 25);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 26);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 27);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 28);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 29);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 30);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 31);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 32);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 33);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 34);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 35);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 36);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 37);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36, InputArgument arg37)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 38);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36, InputArgument arg37, InputArgument arg38)
    {
        if (Core.IsMainThread())
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
            return ConvertFromNative<T>(NativeCall());
        }
        else
        {
            var task = new NativeCallTask((ulong)hash, &arg0, 39);
            Core.DispatchTask(task);
            return ConvertFromNative<T>(task.Result);
        }
    }
#endregion
}