//
// Copyright (C) 2015 crosire & contributors
// License: https://github.com/crosire/scripthookvdotnet#license
//
using System.Text;

namespace SHVDN;
/// <summary>
///     Class responsible for executing script functions.
/// </summary>
public static unsafe class NativeFunc
{
    public delegate void PushCallBack(ReadOnlySpan<char> str);


    /// <summary>
    ///     Pushes a single string component on the text stack.
    /// </summary>
    /// <param name="str">The string to push.</param>
    private static void PushString(ReadOnlySpan<char> str)
    {
        var len = Encoding.UTF8.GetByteCount(str);
        var buf = stackalloc byte[len + 1];
        Encoding.UTF8.GetBytes(str, new Span<byte>(buf, len));
        buf[len] = 0; // '\0'
        Invoke(0x6C188BE134E074AA /*ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME*/, (ulong)buf, 1);
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


    /// <summary>
    ///     Executes a script function immediately. This may only be called from the main script domain thread.
    /// </summary>
    /// <param name="hash">The function has to call.</param>
    /// <param name="argPtr">A pointer of function arguments.</param>
    /// <param name="argCount">The length of <paramref name="argPtr" />.</param>
    /// <returns>A pointer to the return value of the call.</returns>
    public static ulong* Invoke(ulong hash, ulong* argPtr, int argCount)
    {
        NativeInit(hash);
        for (var i = 0; i < argCount; i++)
            NativePush64(argPtr[i]);
        return NativeCall();
    }

    /// <summary>
    ///     Executes a script function immediately. This may only be called from the main script domain thread.
    /// </summary>
    /// <param name="hash">The function has to call.</param>
    /// <param name="args">A list of function arguments.</param>
    /// <returns>A pointer to the return value of the call.</returns>
    public static ulong* Invoke(ulong hash, params ulong[] args)
    {
        NativeInit(hash);
        foreach (var arg in args)
            NativePush64(arg);
        return NativeCall();
    }

    public static ulong* Invoke(ulong hash, params object[] args)
    {
        return Invoke(hash, ConvertPrimitiveArguments(args));
    }
}