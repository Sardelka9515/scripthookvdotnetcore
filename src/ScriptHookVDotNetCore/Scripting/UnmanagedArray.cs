using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public unsafe readonly struct UnmanagedArray<T> : IEnumerable<T> where T : unmanaged
    {
        public readonly T* Address;
        public readonly Int32 Length;
        public readonly Int32 _canWrite; // For memory alignment
        public bool CanWrite => _canWrite != 0;
        public UnmanagedArray(T* addr, int len, bool canWrite = true)
        {
            Address = addr;
            Length = len;
            _canWrite = canWrite ? 1 : 0;
        }

        public UnmanagedArray(int len, bool canWrite = true) : this((T*)Marshal.AllocHGlobal(len), len, canWrite)
        {
        }
        public T this[int i]
        {
            get { return Address[i]; }
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
        public T[] ToArray()
        {
            var arr = new T[Length];
            fixed(T* pArr = arr)
            {
                Buffer.MemoryCopy(Address, pArr, Length, Length);
            }
            return arr;
        }

        public IEnumerator<T> GetEnumerator() => new UnmanagedArrayEnumerator<T>(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class UnmanagedArrayEnumerator<T> : IEnumerator<T> where T : unmanaged
    {
        public UnmanagedArrayEnumerator(UnmanagedArray<T> arr)
        {
            _arr = arr;
        }
        UnmanagedArray<T> _arr;
        int _i = 0;
        public T Current => _arr[_i];

        object IEnumerator.Current => throw new NotImplementedException();

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
            _i = 0;
        }
    }
}
