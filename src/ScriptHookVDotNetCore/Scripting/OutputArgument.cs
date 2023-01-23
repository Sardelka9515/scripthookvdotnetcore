namespace GTA.Native;

public unsafe readonly ref struct OutputArgument
{
    public readonly IntPtr Ptr;

    public OutputArgument(ulong* result)
    {
        Ptr = (IntPtr)result;
    }

    /// <summary>
    /// Cast the returned native value to specified unmanaged type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T To<T>() where T : unmanaged
    {
        T result = default;
        *&result = *(T*)Ptr;
        return result;
    }
}