using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SHVDN
{

#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type

    /// <summary>
    /// Simple struct that holds information of an array allocated on the heap or given address
    /// </summary>
    /// <remarks>No bound checking will be performed when indexing.
    /// Attempting to create an instance for managed type may result in unexpected behaviour 
    /// as the object may be moved around by the GC</remarks>
    /// <typeparam name="T"></typeparam>
    public unsafe readonly struct HeapArray<T> : IEnumerable<T>
    {
        public readonly T* Address;
        public readonly Int32 Length;
        public readonly Int32 _canWrite; // For memory alignment
        public bool CanWrite => _canWrite != 0;
        public HeapArray(T* addr, int len, bool canWrite = true)
        {
            Address = addr;
            Length = len;
            _canWrite = canWrite ? 1 : 0;
        }

        public HeapArray(int len, bool canWrite = true) : this((T*)Marshal.AllocHGlobal(len), len, canWrite)
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
            Buffer.MemoryCopy(Address, &arr, Length, Length);
            return arr;
        }

        public IEnumerator<T> GetEnumerator() => new HeapArrayEnumerator<T>(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class HeapArrayEnumerator<T> : IEnumerator<T>
    {
        public HeapArrayEnumerator(HeapArray<T> arr)
        {
            _arr = arr;
        }
        HeapArray<T> _arr;
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
