using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SHVDN
{
    public struct UnmanagedList<T> : IEnumerable<T> where T : unmanaged
    {
        const int DefaultCapacity = 128;
        const int AllocBlockSize = 32;
        private UnmanagedArray<T> _buffer;
        public int Count { get; private set; }
#pragma warning disable CS0169
        private readonly int _pad;
#pragma warning restore CS0169
        public UnmanagedList(int capacity = DefaultCapacity)
        {
            _buffer = new UnmanagedArray<T>(capacity);
            _buffer.ZeroBlock();
        }
        public T this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (index >= Count) throw new IndexOutOfRangeException();
                return _buffer[index];
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (index >= Count) throw new IndexOutOfRangeException();
                _buffer[index] = value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(T item)
        {
            if (Count >= _buffer.Length)
            {
                var resized = _buffer.MakeCopy(_buffer.Length + AllocBlockSize);
                _buffer.Free();
                _buffer = resized;
                _buffer.ZeroBlock();
            }
            _buffer[Count++] = item;
        }
        public void ExpandToCapacity()
        {
            Count = _buffer.Length;
        }
        public void Clear() => Count = 0;
        public void Free()
        {
            _buffer.Free();
            ZeroStruct(ref this);
        }
        public IEnumerator<T> GetEnumerator() => new UnmanagedListEnumerator<T>(this);
        public void Trim(int newSize)
        {
            if (newSize >= Count)
                throw new ArgumentOutOfRangeException();

            Count = newSize;
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    class UnmanagedListEnumerator<T> : IEnumerator<T> where T : unmanaged
    {
        public UnmanagedListEnumerator(UnmanagedList<T> arr)
        {
            _arr = arr;
        }
        UnmanagedList<T> _arr;
        int _i = -1;
        public T Current => _arr[_i];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_i < _arr.Count - 1)
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
