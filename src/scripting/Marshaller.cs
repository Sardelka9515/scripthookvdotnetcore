using System.Runtime.InteropServices;
using System.Text;
using static SHVDN.Logger;

namespace SHVDN;
/// <summary>
///     General marshalling helpers for calling natives
/// </summary>
public static unsafe class Marshaller
{


    private static readonly List<IntPtr> _pinnedStrings = new();
    public static IntPtr String => StringToCoTaskMemASCII("STRING");
    public static IntPtr NullString => StringToCoTaskMemASCII(string.Empty);
    public static IntPtr CellEmailBcon => StringToCoTaskMemASCII("CELL_EMAIL_BCON");


    /// <summary>
    ///     Free memory for all pinned strings.
    /// </summary>
    public static void CleanupStrings()
    {
        foreach (var handle in _pinnedStrings)
            Marshal.FreeCoTaskMem(handle);
        _pinnedStrings.Clear();
    }

    /// <summary>
    ///     Pins the memory of a string so that it can be used in native calls without worrying about the GC invalidating its
    ///     pointer.
    /// </summary>
    /// <param name="str">The string to pin to a fixed pointer.</param>
    /// <returns>A pointer to the pinned memory containing the string.</returns>
    /// <remarks>Memory will be freed after each tick, use <see cref="StringToCoTaskMemASCII"/> if you want to pin string in a persistent memory</remarks>
    public static IntPtr PinString(string str)
    {
        var handle = StringToCoTaskMemASCII(str);

        if (handle == IntPtr.Zero) return IntPtr.Zero;

        _pinnedStrings.Add(handle);
        return handle;
    }
    


    /// <summary>
    ///     Allocate a memory to store ASCII encoded string using <see cref="System.Runtime.InteropServices.Marshal.AllocCoTaskMem" />
    /// </summary>
    /// <param name="s"></param>
    /// <returns>Pointer to the allocated memory</returns>
    /// <exception cref="OutOfMemoryException"></exception>
    /// <remarks>
    ///     Users are responsible for cleaning up the allocated memory themselves, use <see cref="PinString" /> if you
    ///     want the memory be cleaned up automatically after each tick
    /// </remarks>
    public static IntPtr StringToCoTaskMemASCII(ReadOnlySpan<char> s)
    {
        if (s == null)
            return NullString;

        fixed (char* pChar = s)
        {
            var byteCount = Encoding.ASCII.GetByteCount(s);
            var buf = stackalloc byte[byteCount + 1];
            Encoding.ASCII.GetBytes(pChar, s.Length, buf, byteCount);
            var dest = Marshal.AllocCoTaskMem(byteCount + 1);

            if (dest == IntPtr.Zero)
                throw new OutOfMemoryException();

            Buffer.MemoryCopy(buf, (void*)dest, byteCount + 1, byteCount + 1);

            // Termination character
            ((byte*)dest)[byteCount] = 0;

            return dest;
        }
    }

    /// <summary>
    ///     Helper function that converts an array of primitive values to a native stack.
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static ulong[] ConvertPrimitiveArguments(object[] args)
    {
        var result = new ulong[args.Length];
        for (var i = 0; i < args.Length; ++i)
        {
            if (args[i] is bool valueBool)
            {
                result[i] = valueBool ? 1ul : 0ul;
                continue;
            }

            if (args[i] is byte valueByte)
            {
                result[i] = valueByte;
                continue;
            }

            if (args[i] is int valueInt32)
            {
                result[i] = (ulong)valueInt32;
                continue;
            }

            if (args[i] is ulong valueUInt64)
            {
                result[i] = valueUInt64;
                continue;
            }

            if (args[i] is float valueFloat)
            {
                result[i] = *(ulong*)&valueFloat;
                continue;
            }

            if (args[i] is IntPtr valueIntPtr)
            {
                result[i] = (ulong)valueIntPtr.ToInt64();
                continue;
            }

            if (args[i] is string valueString)
            {
                result[i] = (ulong)PinString(valueString);
                continue;
            }

            throw new ArgumentException("Unknown primitive type in native argument list", nameof(args));
        }

        return result;


        /*
        /// <summary>
        /// Copy string to a shared heap region, data will be overwritten on next tick
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static IntPtr PinTempString(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            var avalible = _tmpStrHeapSize - ((ulong)_ptrTmpStrCur - (ulong)_ptrTmpStrHeap);

            if ((ulong)bytes.Length > avalible + 1) // 1 byte for termination character '\0'
                throw new ArgumentOutOfRangeException(nameof(str), "String too bigggggg!");

            Marshal.Copy(bytes, 0, _ptrTmpStrCur, bytes.Length);
            *(char*)(_ptrTmpStrCur + bytes.Length) = '\0'; // null-terminated string
            var result = _ptrTmpStrCur;
            _ptrTmpStrCur = _ptrTmpStrCur + bytes.Length + 1;
            return result;
        }
        */
    }
}