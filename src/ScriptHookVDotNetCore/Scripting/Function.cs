using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;

namespace GTA.Native;

public interface INativeValue
{
    ulong NativeValue { get; set; }
}

public unsafe struct NativeCallTask : IScriptTask
{
    public NativeCallTask(ulong hash, InputArgument* ptrArgs, int argCount)
    {
        Hash = hash;
        PtrArgs = ptrArgs;
        ArgsCount = argCount;
    }
    public ulong Hash;
    public InputArgument* PtrArgs;
    public int ArgsCount;
    public ulong* Result;
    public void Run()
    {
        NativeInit(Hash);
        for (int i = 0; i < ArgsCount; i++)
        {
            NativePush64(PtrArgs[i]);
        }
        Result = NativeCall();
    }
    public override string ToString()
    {
        return $"{(Hash)Hash},{(ulong)PtrArgs},{ArgsCount},{(ulong)Result}";
    }
}

/// <summary>
/// Push arguments that are placed in reverse order. <see cref="PtrArgLast"/> points to the last argument 
/// </summary>
/// <remarks>Example memory layout: [arg2][arg1][arg0], <see cref="PtrArgLast"/> points to arg2</remarks>
public unsafe class ReversedNativeCallTask : IScriptTask
{
    public ReversedNativeCallTask(ulong hash, InputArgument* ptrArgLast, int argCount)
    {
        Hash = hash;
        PtrArgLast = ptrArgLast;
        ArgsCount = argCount;
    }
    public ulong Hash;
    public InputArgument* PtrArgLast;
    public int ArgsCount;
    public ulong* Result;
    public void Run()
    {
        NativeInit(Hash);
        while (ArgsCount > 0) { NativePush64(PtrArgLast[--ArgsCount]); }
        Result = NativeCall();
    }
    public override string ToString()
    {
        return $"{(Hash)Hash},{(ulong)PtrArgLast},{ArgsCount},{(ulong)Result}";
    }
}

public static unsafe partial class Function
{
    #region Push string

    public delegate void PushCallBack(ReadOnlySpan<char> str);


    /// <summary>
    ///     Pushes a single string component on the text stack.
    /// </summary>
    /// <param name="str">The string to push.</param>
    public static void PushString(ReadOnlySpan<char> str)
    {
        var len = Encoding.UTF8.GetByteCount(str);
        var buf = stackalloc byte[len + 1];
        Encoding.UTF8.GetBytes(str, new Span<byte>(buf, len));
        buf[len] = 0; // '\0'
        Call(Hash.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME, (ulong)buf, 1);
    }

    /// <summary>
    ///     Splits up a spring into manageable components and pushes them on the text stack.
    /// </summary>
    /// <param name="str">The string to split up.</param>
    public static void PushLongString(ReadOnlySpan<char> str)
    {
        PushLongString(str, PushString);
    }

    /// <summary>
    ///     Splits up a string into manageable components and performs an <paramref name="action" /> on them.
    /// </summary>
    /// <param name="str">The string to split up.</param>
    /// <param name="action">The action to perform on the component.</param>
    public static void PushLongString(ReadOnlySpan<char> str, PushCallBack action)
    {
        const int maxLengthUtf8 = 99;

        if (str == null || Encoding.UTF8.GetByteCount(str) <= maxLengthUtf8)
        {
            action(str);
            return;
        }

        var startPos = 0;
        var currentPos = 0;
        var currentUtf8StrLength = 0;

        while (currentPos < str.Length)
        {
            var codePointSize = 0;

            // Calculate the UTF-8 code point size of the current character
            var chr = str[currentPos];
            if (chr < 0x80)
            {
                codePointSize = 1;
            }
            else if (chr < 0x800)
            {
                codePointSize = 2;
            }
            else if (chr < 0x10000)
            {
                codePointSize = 3;
            }
            else
            {
                #region Surrogate check

                const int LowSurrogateStart = 0xD800;
                const int HighSurrogateStart = 0xD800;

                var temp1 = chr - HighSurrogateStart;
                if (temp1 >= 0 && temp1 <= 0x7ff)
                    // Found a high surrogate
                    if (currentPos < str.Length - 1)
                    {
                        var temp2 = str[currentPos + 1] - LowSurrogateStart;
                        if (temp2 >= 0 && temp2 <= 0x3ff)
                            // Found a low surrogate
                            codePointSize = 4;
                    }

                #endregion
            }

            if (currentUtf8StrLength + codePointSize > maxLengthUtf8)
            {
                action(str.Slice(startPos, currentPos - startPos));

                startPos = currentPos;
                currentUtf8StrLength = 0;
            }
            else
            {
                currentPos++;
                currentUtf8StrLength += codePointSize;
            }

            // Additional increment is needed for surrogate
            if (codePointSize == 4) currentPos++;
        }

        if (startPos == 0)
            action(str);
        else
            action(str.Slice(startPos, str.Length - startPos));
    }

    #endregion

    #region call with params

    /// <remarks>When calling with this overload, arguments are subjected to heap allocation, which may cause GC pressure when used frequently.</remarks>
    public static void Call(Hash hash, params InputArgument[] args)
    {
        fixed (InputArgument* pArgs = args)
        {
            var task = new NativeCallTask((ulong)hash, pArgs, args.Length);
            Core.ExecuteTask(ref task);
        }
    }

    /// <remarks>When calling with this overload, arguments are subjected to heap allocation, which may cause GC pressure when used frequently.</remarks>
    public static T Call<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(Hash hash, params InputArgument[] args)
    {
        fixed (InputArgument* pArgs = args)
        {
            var task = new NativeCallTask((ulong)hash, pArgs, args.Length);
            Core.ExecuteTask(ref task);
            return ConvertFromNative<T>(task.Result);
        }
    }
    #endregion

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T ConvertFromNative<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(ulong* pNative)
    {
        var type = typeof(T);
        if (type.IsValueType)
        {
            if (type == typeof(double))
            {
                // Additional conversion required since double is invalid in native functions
                var tmp = (double)Unsafe.As<ulong, float>(ref *pNative);
                return Unsafe.As<double, T>(ref tmp); // Bypass type checking
            }

            return Unsafe.As<ulong, T>(ref *pNative);
        }

        if (type == typeof(string))
        {
            var obj = (T)(object)NativeMemory.PtrToStringUTF8((IntPtr)(*pNative));
            return obj;
        }

        if (type.IsAssignableTo(typeof(Entity)))
        {
            Entity val = null;
            if (type == typeof(Ped)) { val = new Ped((int)*pNative); }
            else if (type == typeof(Vehicle)) { val = new Vehicle((int)*pNative); }
            else if (type == typeof(Prop)) { val = new Vehicle((int)*pNative); }
            else if (type == typeof(Projectile)) { val = new Vehicle((int)*pNative); }
            return val == null ? default : Unsafe.As<Entity, T>(ref val);
        }

        if (type.IsAssignableTo(typeof(INativeValue)))
        {
            // Edge case. Warning: Requires classes implementing 'INativeValue' to repeat all constructor work in the setter of 'NativeValue'
            var result = (INativeValue)FormatterServices.GetUninitializedObject(type);
            result.NativeValue = *pNative;
            return (T)result;
        }

        throw new NotSupportedException($"Converting from native to {type.FullName} is not supported");
    }

}