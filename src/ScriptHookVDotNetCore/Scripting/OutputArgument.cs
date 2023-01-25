
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GTA.Native;

/// <summary>
/// An output argument passed to a script function.
/// </summary>
public unsafe class OutputArgument : IDisposable
{
    bool disposed = false;
    internal ulong* _storage = null;

    public OutputArgument()
    {
        _storage = (ulong*)Marshal.AllocCoTaskMem(24);
    }

    public OutputArgument(ulong value) : this()
    {
        *_storage = value;
    }

    public OutputArgument(object value) : this(ObjectToNative(value))
    {
    }


    /// <summary>
    /// Frees the unmanaged resources associated with this <see cref="OutputArgument"/>.
    /// </summary>
    ~OutputArgument()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
        {
            return;
        }

        Marshal.FreeCoTaskMem((IntPtr)_storage);
        disposed = true;
    }

    /// <summary>
    /// Gets the value of data stored in this <see cref="OutputArgument"/>.
    /// </summary>
    public TResult GetResult<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] TResult>() => ConvertFromNative<TResult>(_storage);

    public static implicit operator InputArgument(OutputArgument argument) => InputArgument.FromPtr(argument._storage);
}