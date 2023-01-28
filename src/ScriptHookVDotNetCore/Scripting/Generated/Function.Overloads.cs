namespace GTA.Native;
public static unsafe partial class Function
{
#region Call overloads without return value
    public static void Call(Hash hash)
    {
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = null, ArgsCount = 0, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0)
    {
        var pArgs = stackalloc InputArgument[1];
        pArgs[0] = arg0;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 1, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1)
    {
        var pArgs = stackalloc InputArgument[2];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 2, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2)
    {
        var pArgs = stackalloc InputArgument[3];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 3, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3)
    {
        var pArgs = stackalloc InputArgument[4];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 4, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4)
    {
        var pArgs = stackalloc InputArgument[5];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 5, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5)
    {
        var pArgs = stackalloc InputArgument[6];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 6, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6)
    {
        var pArgs = stackalloc InputArgument[7];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 7, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7)
    {
        var pArgs = stackalloc InputArgument[8];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 8, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8)
    {
        var pArgs = stackalloc InputArgument[9];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 9, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9)
    {
        var pArgs = stackalloc InputArgument[10];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 10, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10)
    {
        var pArgs = stackalloc InputArgument[11];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 11, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11)
    {
        var pArgs = stackalloc InputArgument[12];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 12, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12)
    {
        var pArgs = stackalloc InputArgument[13];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 13, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13)
    {
        var pArgs = stackalloc InputArgument[14];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 14, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14)
    {
        var pArgs = stackalloc InputArgument[15];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 15, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15)
    {
        var pArgs = stackalloc InputArgument[16];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 16, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16)
    {
        var pArgs = stackalloc InputArgument[17];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 17, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17)
    {
        var pArgs = stackalloc InputArgument[18];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 18, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18)
    {
        var pArgs = stackalloc InputArgument[19];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 19, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19)
    {
        var pArgs = stackalloc InputArgument[20];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 20, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20)
    {
        var pArgs = stackalloc InputArgument[21];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 21, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21)
    {
        var pArgs = stackalloc InputArgument[22];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 22, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22)
    {
        var pArgs = stackalloc InputArgument[23];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 23, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23)
    {
        var pArgs = stackalloc InputArgument[24];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 24, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24)
    {
        var pArgs = stackalloc InputArgument[25];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 25, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25)
    {
        var pArgs = stackalloc InputArgument[26];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 26, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26)
    {
        var pArgs = stackalloc InputArgument[27];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 27, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27)
    {
        var pArgs = stackalloc InputArgument[28];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        pArgs[27] = arg27;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 28, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28)
    {
        var pArgs = stackalloc InputArgument[29];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        pArgs[27] = arg27;
        pArgs[28] = arg28;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 29, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29)
    {
        var pArgs = stackalloc InputArgument[30];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        pArgs[27] = arg27;
        pArgs[28] = arg28;
        pArgs[29] = arg29;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 30, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30)
    {
        var pArgs = stackalloc InputArgument[31];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        pArgs[27] = arg27;
        pArgs[28] = arg28;
        pArgs[29] = arg29;
        pArgs[30] = arg30;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 31, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31)
    {
        var pArgs = stackalloc InputArgument[32];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        pArgs[27] = arg27;
        pArgs[28] = arg28;
        pArgs[29] = arg29;
        pArgs[30] = arg30;
        pArgs[31] = arg31;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 32, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32)
    {
        var pArgs = stackalloc InputArgument[33];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        pArgs[27] = arg27;
        pArgs[28] = arg28;
        pArgs[29] = arg29;
        pArgs[30] = arg30;
        pArgs[31] = arg31;
        pArgs[32] = arg32;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 33, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33)
    {
        var pArgs = stackalloc InputArgument[34];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        pArgs[27] = arg27;
        pArgs[28] = arg28;
        pArgs[29] = arg29;
        pArgs[30] = arg30;
        pArgs[31] = arg31;
        pArgs[32] = arg32;
        pArgs[33] = arg33;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 34, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34)
    {
        var pArgs = stackalloc InputArgument[35];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        pArgs[27] = arg27;
        pArgs[28] = arg28;
        pArgs[29] = arg29;
        pArgs[30] = arg30;
        pArgs[31] = arg31;
        pArgs[32] = arg32;
        pArgs[33] = arg33;
        pArgs[34] = arg34;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 35, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35)
    {
        var pArgs = stackalloc InputArgument[36];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        pArgs[27] = arg27;
        pArgs[28] = arg28;
        pArgs[29] = arg29;
        pArgs[30] = arg30;
        pArgs[31] = arg31;
        pArgs[32] = arg32;
        pArgs[33] = arg33;
        pArgs[34] = arg34;
        pArgs[35] = arg35;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 36, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36)
    {
        var pArgs = stackalloc InputArgument[37];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        pArgs[27] = arg27;
        pArgs[28] = arg28;
        pArgs[29] = arg29;
        pArgs[30] = arg30;
        pArgs[31] = arg31;
        pArgs[32] = arg32;
        pArgs[33] = arg33;
        pArgs[34] = arg34;
        pArgs[35] = arg35;
        pArgs[36] = arg36;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 37, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36, InputArgument arg37)
    {
        var pArgs = stackalloc InputArgument[38];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        pArgs[27] = arg27;
        pArgs[28] = arg28;
        pArgs[29] = arg29;
        pArgs[30] = arg30;
        pArgs[31] = arg31;
        pArgs[32] = arg32;
        pArgs[33] = arg33;
        pArgs[34] = arg34;
        pArgs[35] = arg35;
        pArgs[36] = arg36;
        pArgs[37] = arg37;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 38, };
        Core.ExecuteTask(task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36, InputArgument arg37, InputArgument arg38)
    {
        var pArgs = stackalloc InputArgument[39];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        pArgs[27] = arg27;
        pArgs[28] = arg28;
        pArgs[29] = arg29;
        pArgs[30] = arg30;
        pArgs[31] = arg31;
        pArgs[32] = arg32;
        pArgs[33] = arg33;
        pArgs[34] = arg34;
        pArgs[35] = arg35;
        pArgs[36] = arg36;
        pArgs[37] = arg37;
        pArgs[38] = arg38;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 39, };
        Core.ExecuteTask(task);
    }

#endregion
#region Call overloads with return value
    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash)
    {
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = null, ArgsCount = 0, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0)
    {
        var pArgs = stackalloc InputArgument[1];
        pArgs[0] = arg0;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 1, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1)
    {
        var pArgs = stackalloc InputArgument[2];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 2, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2)
    {
        var pArgs = stackalloc InputArgument[3];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 3, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3)
    {
        var pArgs = stackalloc InputArgument[4];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 4, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4)
    {
        var pArgs = stackalloc InputArgument[5];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 5, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5)
    {
        var pArgs = stackalloc InputArgument[6];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 6, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6)
    {
        var pArgs = stackalloc InputArgument[7];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 7, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7)
    {
        var pArgs = stackalloc InputArgument[8];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 8, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8)
    {
        var pArgs = stackalloc InputArgument[9];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 9, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9)
    {
        var pArgs = stackalloc InputArgument[10];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 10, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10)
    {
        var pArgs = stackalloc InputArgument[11];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 11, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11)
    {
        var pArgs = stackalloc InputArgument[12];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 12, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12)
    {
        var pArgs = stackalloc InputArgument[13];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 13, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13)
    {
        var pArgs = stackalloc InputArgument[14];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 14, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14)
    {
        var pArgs = stackalloc InputArgument[15];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 15, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15)
    {
        var pArgs = stackalloc InputArgument[16];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 16, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16)
    {
        var pArgs = stackalloc InputArgument[17];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 17, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17)
    {
        var pArgs = stackalloc InputArgument[18];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 18, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18)
    {
        var pArgs = stackalloc InputArgument[19];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 19, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19)
    {
        var pArgs = stackalloc InputArgument[20];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 20, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20)
    {
        var pArgs = stackalloc InputArgument[21];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 21, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21)
    {
        var pArgs = stackalloc InputArgument[22];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 22, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22)
    {
        var pArgs = stackalloc InputArgument[23];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 23, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23)
    {
        var pArgs = stackalloc InputArgument[24];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 24, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24)
    {
        var pArgs = stackalloc InputArgument[25];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 25, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25)
    {
        var pArgs = stackalloc InputArgument[26];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 26, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26)
    {
        var pArgs = stackalloc InputArgument[27];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 27, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27)
    {
        var pArgs = stackalloc InputArgument[28];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        pArgs[27] = arg27;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 28, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28)
    {
        var pArgs = stackalloc InputArgument[29];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        pArgs[27] = arg27;
        pArgs[28] = arg28;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 29, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29)
    {
        var pArgs = stackalloc InputArgument[30];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        pArgs[27] = arg27;
        pArgs[28] = arg28;
        pArgs[29] = arg29;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 30, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30)
    {
        var pArgs = stackalloc InputArgument[31];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        pArgs[27] = arg27;
        pArgs[28] = arg28;
        pArgs[29] = arg29;
        pArgs[30] = arg30;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 31, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31)
    {
        var pArgs = stackalloc InputArgument[32];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        pArgs[27] = arg27;
        pArgs[28] = arg28;
        pArgs[29] = arg29;
        pArgs[30] = arg30;
        pArgs[31] = arg31;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 32, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32)
    {
        var pArgs = stackalloc InputArgument[33];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        pArgs[27] = arg27;
        pArgs[28] = arg28;
        pArgs[29] = arg29;
        pArgs[30] = arg30;
        pArgs[31] = arg31;
        pArgs[32] = arg32;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 33, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33)
    {
        var pArgs = stackalloc InputArgument[34];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        pArgs[27] = arg27;
        pArgs[28] = arg28;
        pArgs[29] = arg29;
        pArgs[30] = arg30;
        pArgs[31] = arg31;
        pArgs[32] = arg32;
        pArgs[33] = arg33;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 34, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34)
    {
        var pArgs = stackalloc InputArgument[35];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        pArgs[27] = arg27;
        pArgs[28] = arg28;
        pArgs[29] = arg29;
        pArgs[30] = arg30;
        pArgs[31] = arg31;
        pArgs[32] = arg32;
        pArgs[33] = arg33;
        pArgs[34] = arg34;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 35, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35)
    {
        var pArgs = stackalloc InputArgument[36];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        pArgs[27] = arg27;
        pArgs[28] = arg28;
        pArgs[29] = arg29;
        pArgs[30] = arg30;
        pArgs[31] = arg31;
        pArgs[32] = arg32;
        pArgs[33] = arg33;
        pArgs[34] = arg34;
        pArgs[35] = arg35;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 36, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36)
    {
        var pArgs = stackalloc InputArgument[37];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        pArgs[27] = arg27;
        pArgs[28] = arg28;
        pArgs[29] = arg29;
        pArgs[30] = arg30;
        pArgs[31] = arg31;
        pArgs[32] = arg32;
        pArgs[33] = arg33;
        pArgs[34] = arg34;
        pArgs[35] = arg35;
        pArgs[36] = arg36;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 37, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36, InputArgument arg37)
    {
        var pArgs = stackalloc InputArgument[38];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        pArgs[27] = arg27;
        pArgs[28] = arg28;
        pArgs[29] = arg29;
        pArgs[30] = arg30;
        pArgs[31] = arg31;
        pArgs[32] = arg32;
        pArgs[33] = arg33;
        pArgs[34] = arg34;
        pArgs[35] = arg35;
        pArgs[36] = arg36;
        pArgs[37] = arg37;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 38, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36, InputArgument arg37, InputArgument arg38)
    {
        var pArgs = stackalloc InputArgument[39];
        pArgs[0] = arg0;
        pArgs[1] = arg1;
        pArgs[2] = arg2;
        pArgs[3] = arg3;
        pArgs[4] = arg4;
        pArgs[5] = arg5;
        pArgs[6] = arg6;
        pArgs[7] = arg7;
        pArgs[8] = arg8;
        pArgs[9] = arg9;
        pArgs[10] = arg10;
        pArgs[11] = arg11;
        pArgs[12] = arg12;
        pArgs[13] = arg13;
        pArgs[14] = arg14;
        pArgs[15] = arg15;
        pArgs[16] = arg16;
        pArgs[17] = arg17;
        pArgs[18] = arg18;
        pArgs[19] = arg19;
        pArgs[20] = arg20;
        pArgs[21] = arg21;
        pArgs[22] = arg22;
        pArgs[23] = arg23;
        pArgs[24] = arg24;
        pArgs[25] = arg25;
        pArgs[26] = arg26;
        pArgs[27] = arg27;
        pArgs[28] = arg28;
        pArgs[29] = arg29;
        pArgs[30] = arg30;
        pArgs[31] = arg31;
        pArgs[32] = arg32;
        pArgs[33] = arg33;
        pArgs[34] = arg34;
        pArgs[35] = arg35;
        pArgs[36] = arg36;
        pArgs[37] = arg37;
        pArgs[38] = arg38;
        var task = new NativeCallTask()
        {Hash = (ulong)hash, PtrArgs = (ulong*)pArgs, ArgsCount = 39, };
        Core.ExecuteTask(task);
        return ConvertFromNative<T>(task.Result);
    }
#endregion
}