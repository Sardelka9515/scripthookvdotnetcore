namespace GTA.Native;
public static unsafe partial class Function
{
#region Call overloads without return value
    public static void Call(Hash hash)
    {
        var task = new NativeCallTask((ulong)hash, null, 0);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 1);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 2);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 3);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 4);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 5);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 6);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 7);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 8);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 9);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 10);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 11);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 12);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 13);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 14);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 15);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 16);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 17);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 18);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 19);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 20);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 21);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 22);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 23);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 24);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 25);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 26);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 27);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 28);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 29);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 30);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 31);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 32);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 33);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 34);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 35);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 36);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 37);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36, InputArgument arg37)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 38);
        Core.ExecuteTask(ref task);
    }

    public static void Call(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36, InputArgument arg37, InputArgument arg38)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 39);
        Core.ExecuteTask(ref task);
    }

#endregion
#region Call overloads with return value
    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash)
    {
        var task = new NativeCallTask((ulong)hash, null, 0);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 1);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 2);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 3);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 4);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 5);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 6);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 7);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 8);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 9);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 10);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 11);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 12);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 13);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 14);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 15);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 16);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 17);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 18);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 19);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 20);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 21);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 22);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 23);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 24);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 25);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 26);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 27);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 28);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 29);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 30);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 31);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 32);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 33);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 34);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 35);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 36);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 37);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36, InputArgument arg37)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 38);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }

    public static T Call<
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)]
    T>(Hash hash, InputArgument arg0, InputArgument arg1, InputArgument arg2, InputArgument arg3, InputArgument arg4, InputArgument arg5, InputArgument arg6, InputArgument arg7, InputArgument arg8, InputArgument arg9, InputArgument arg10, InputArgument arg11, InputArgument arg12, InputArgument arg13, InputArgument arg14, InputArgument arg15, InputArgument arg16, InputArgument arg17, InputArgument arg18, InputArgument arg19, InputArgument arg20, InputArgument arg21, InputArgument arg22, InputArgument arg23, InputArgument arg24, InputArgument arg25, InputArgument arg26, InputArgument arg27, InputArgument arg28, InputArgument arg29, InputArgument arg30, InputArgument arg31, InputArgument arg32, InputArgument arg33, InputArgument arg34, InputArgument arg35, InputArgument arg36, InputArgument arg37, InputArgument arg38)
    {
        var task = new NativeCallTask((ulong)hash, &arg0, 39);
        Core.ExecuteTask(ref task);
        return ConvertFromNative<T>(task.Result);
    }
#endregion
}