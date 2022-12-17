using GTA.Math;
using System.Runtime.CompilerServices;

namespace GTA.Native;

public unsafe readonly ref struct InputArgument
{
    public readonly ulong Value;

    public InputArgument(ulong value)
    {
        Value = value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe InputArgument From<T>(T val) where T : unmanaged
    {
        InputArgument arg = default;
        *(T*)&arg.Value = val;
        return arg;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe InputArgument FromPtr<T>(T* val) where T : unmanaged
    {
        return From((IntPtr)val);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(bool val) => From(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(byte val) => From(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(sbyte val) => From(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(short val) => From(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(ushort val) => From(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(int val) => From(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(uint val) => From(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(long val) => From(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(ulong val) => From(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(float val) => From(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(bool* val) => FromPtr(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(byte* val) => FromPtr(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(sbyte* val) => FromPtr(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(short* val) => FromPtr(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(ushort* val) => FromPtr(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(int* val) => FromPtr(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(uint* val) => FromPtr(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(long* val) => FromPtr(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(ulong* val) => FromPtr(val);
    public static implicit operator InputArgument(float* val) => FromPtr(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(double* val) => FromPtr(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(nint* val) => FromPtr(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(nuint* val) => FromPtr(val);
    public static implicit operator InputArgument(NativeVector3* val) => FromPtr(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(DlcWeaponComponentData* val) => FromPtr(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(DlcWeaponData* val) => FromPtr(val);
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(Enum val) => From(Convert.ToUInt64(val));
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static implicit operator InputArgument(string val) => From(PinString(val));
}
