using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SHVDN
{
    /// <summary>
    /// Simple struct that holds information of an array allocated on the heap or given address
    /// </summary>
    /// <remarks>No bound checking will be performed when indexing.
    /// Attempting to create an instance for managed type may result in unexpected behaviour 
    /// as the object may be moved around by the GC</remarks>
    /// <typeparam name="T"></typeparam>
    public unsafe struct UnmanagedArray<T> : IEnumerable<T> where T : unmanaged
    {
        public readonly T* Address;
        public readonly Int32 Length;
        public readonly Int32 _canWrite = 1; // For memory alignment
        public bool CanWrite => _canWrite != 0;
        public UnmanagedArray(T* addr, int size, bool canWrite = true)
        {
            Address = addr;
            Length = size;
            _canWrite = canWrite ? 1 : 0;
        }

        public UnmanagedArray(int size, bool canWrite = true) : this((T*)Marshal.AllocHGlobal(size * sizeof(T)), size, canWrite)
        {
        }

        public T this[int i]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return Address[i]; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (CanWrite)
                {
                    Address[i] = value;
                }
                else
                {
                    throw new InvalidOperationException("Array does not support writing");
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T[] ToArray()
        {
            var arr = new T[Length];
            var toCopy = sizeof(T) * Length;
            fixed (T* pArr = arr)
            {
                Buffer.MemoryCopy(Address, pArr, toCopy, toCopy);
            }
            return arr;
        }

        /// <summary>
        /// Returns a resized copy of this instance
        /// </summary>
        /// <param name="newSize"></param>
        /// <returns></returns>
        public UnmanagedArray<T> MakeCopy(int newSize)
        {
            var result = new UnmanagedArray<T>(newSize, CanWrite);
            var toCopy = Math.Min(Length, newSize) * sizeof(T);
            Buffer.MemoryCopy(Address, result.Address, toCopy, toCopy);
            return result;
        }

        public void Free()
        {
            Marshal.FreeHGlobal((IntPtr)Address);
            ZeroStruct(ref this);
        }

        public IEnumerator<T> GetEnumerator() => new UnmanagedArrayEnumerator<T>(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void ZeroBlock() => ZeroMemory((IntPtr)Address, sizeof(T) * Length);
    }
    class UnmanagedArrayEnumerator<T> : IEnumerator<T> where T : unmanaged
    {
        public UnmanagedArrayEnumerator(UnmanagedArray<T> arr)
        {
            _arr = arr;
        }
        UnmanagedArray<T> _arr;
        int _i = -1;
        public T Current => _arr[_i];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_i < _arr.Length - 1)
            {
                _i++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _i = -1;
        }
    }
}
