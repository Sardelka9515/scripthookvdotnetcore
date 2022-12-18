using System.Runtime.InteropServices;
using System.Text;

namespace GTA.Native;

/// <summary>
/// A value class which handles access to global script variables.
/// </summary>
public unsafe readonly struct GlobalVariable
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GlobalVariable"/> class with a variable address.
    /// </summary>
    /// <param name="address">The memory address of the global variable.</param>
    private GlobalVariable(IntPtr address) : this()
    {
        MemoryAddress = address;
    }

    /// <summary>
    /// Gets the global variable at the specified index.
    /// </summary>
    /// <param name="index">The index of the global variable.</param>
    /// <returns>A <see cref="GlobalVariable"/> instance representing the global variable.</returns>
    public static GlobalVariable Get(int index)
    {
        IntPtr address = GetGlobalPtr(index);

        if (address == IntPtr.Zero)
        {
            throw new IndexOutOfRangeException(
                $"The index {index} does not correspond to an existing global variable.");
        }

        return new GlobalVariable(address);
    }

    /// <summary>
    /// Gets the native memory address of the <see cref="GlobalVariable"/>.
    /// </summary>
    public IntPtr MemoryAddress { get; }

    /// <summary>
    /// Gets the value stored in the <see cref="GlobalVariable"/>.
    /// </summary>
    public T Read<T>()
    {
        return ConvertFromNative<T>((ulong*)MemoryAddress);
    }

    /// <summary>
    /// Set the value stored in the <see cref="GlobalVariable"/>.
    /// </summary>
    /// <param name="value">The new value to assign to the <see cref="GlobalVariable"/>.</param>
    public void Write<T>(T value) where T : unmanaged
    {
        *(T*)MemoryAddress = value;
    }

    /// <summary>
    /// Set the value stored in the <see cref="GlobalVariable"/> to a string.
    /// </summary>
    /// <param name="value">The string to set the <see cref="GlobalVariable"/> to.</param>
    /// <param name="maxSize">The maximum size of the string. Can be found for a given global variable by checking the decompiled scripts from the game.</param>
    public void WriteString(string value, int maxSize)
    {
        if (maxSize % 8 != 0 || maxSize <= 0 || maxSize > 64)
        {
            throw new ArgumentException("The string maximum size should be one of 8, 16, 24, 32 or 64.", "maxSize");
        }

        // Null-terminate string
        value += '\0';

        // Write UTF-8 string to memory
        var size = Encoding.UTF8.GetByteCount(value);

        if (size >= maxSize)
        {
            size = maxSize - 1;
        }

        Marshal.Copy(Encoding.UTF8.GetBytes(value), 0, MemoryAddress, size);
    }

    /// <summary>
    /// Set the value of a specific bit of the <see cref="GlobalVariable"/> to true.
    /// </summary>
    /// <param name="index">The zero indexed bit of the <see cref="GlobalVariable"/> to set.</param>
    public unsafe void SetBit(int index)
    {
        if (index < 0 || index > 63)
        {
            throw new IndexOutOfRangeException("The bit index has to be between 0 and 63");
        }

        *(ulong*)(MemoryAddress.ToPointer()) |= (1u << index);
    }

    /// <summary>
    /// Set the value of a specific bit of the <see cref="GlobalVariable"/> to false.
    /// </summary>
    /// <param name="index">The zero indexed bit of the <see cref="GlobalVariable"/> to clear.</param>
    public unsafe void ClearBit(int index)
    {
        if (index < 0 || index > 63)
        {
            throw new IndexOutOfRangeException("The bit index has to be between 0 and 63");
        }

        *(ulong*)(MemoryAddress.ToPointer()) &= ~(1u << index);
    }

    /// <summary>
    /// Gets a value indicating whether a specific bit of the <see cref="GlobalVariable"/> is set.
    /// </summary>
    /// <param name="index">The zero indexed bit of the <see cref="GlobalVariable"/> to check.</param>
    public unsafe bool IsBitSet(int index)
    {
        if (index < 0 || index > 63)
        {
            throw new IndexOutOfRangeException("The bit index has to be between 0 and 63");
        }

        return ((*(ulong*)(MemoryAddress.ToPointer()) >> index) & 1) != 0;
    }

    /// <summary>
    /// Gets the <see cref="GlobalVariable"/> stored at a given offset in a global structure.
    /// </summary>
    /// <param name="index">The index the <see cref="GlobalVariable"/> is stored in the structure. For example the Y component of a Vector3 is at index 1.</param>
    /// <returns>The <see cref="GlobalVariable"/> at the index given.</returns>
    public unsafe GlobalVariable GetStructField(int index)
    {
        if (index < 0)
        {
            throw new IndexOutOfRangeException("The structure item index cannot be negative.");
        }

        return new GlobalVariable(MemoryAddress + (8 * index));
    }

    /// <summary>
    /// Returns an array of all <see cref="GlobalVariable"/>s in a global array.
    /// </summary>
    /// <param name="itemSize">The number of items stored in each array index. For example an array of Vector3s takes up 3 items.</param>
    /// <returns>The array of <see cref="GlobalVariable"/>s.</returns>
    public unsafe GlobalVariable[] GetArray(int itemSize)
    {
        if (itemSize <= 0)
        {
            throw new ArgumentOutOfRangeException("itemSize", "The item size for an array must be positive.");
        }

        int count = Read<int>();

        // Globals are stored in pages that hold a maximum of 65536 items
        if (count < 1 || count >= 65536 / itemSize)
        {
            throw new InvalidOperationException("The variable does not seem to be an array.");
        }

        var result = new GlobalVariable[count];

        for (int i = 0; i < count; i++)
        {
            result[i] = new GlobalVariable(MemoryAddress + 8 + (8 * itemSize * i));
        }

        return result;
    }

    /// <summary>
    /// Gets the <see cref="GlobalVariable"/> stored at a specific index in a global array.
    /// </summary>
    /// <param name="index">The array index.</param>
    /// <param name="itemSize">The number of items stored in each array index. For example an array of Vector3s takes up 3 items.</param>
    /// <returns>The <see cref="GlobalVariable"/> at the index given.</returns>
    public unsafe GlobalVariable GetArrayItem(int index, int itemSize)
    {
        if (itemSize <= 0)
        {
            throw new ArgumentOutOfRangeException("itemSize", "The item size for an array must be positive.");
        }

        int count = Read<int>();

        // Globals are stored in pages that hold a maximum of 65536 items
        if (count < 1 || count >= 65536 / itemSize)
        {
            throw new InvalidOperationException("The variable does not seem to be an array.");
        }

        if (index < 0 || index >= count)
        {
            throw new IndexOutOfRangeException($"The index {index} was outside the array bounds.");
        }

        return new GlobalVariable(MemoryAddress + 8 + (8 * itemSize * index));
    }
}