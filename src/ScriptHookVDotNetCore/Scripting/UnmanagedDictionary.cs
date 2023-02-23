using GTA;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SHVDN
{
    /// <summary>
    /// Unmanaged implmentation of <see cref="Dictionary{TKey, TValue}"/>
    /// </summary>
    public unsafe struct UnmanagedDictionary<TKey, TValue> : IEnumerable<(TKey, TValue)> where TKey : unmanaged where TValue : unmanaged
    {
        const float LoadFactor = 0.6f;
        private UnmanagedList<(TKey, TValue)>* _buckets = null;
        private int _numBuckets = 0;
        private int _numBucketsUsed = 0;
        public int Count { get; private set; }
        public UnmanagedDictionary(int numBuckets = 128)
        {
            Initialise(numBuckets);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void Initialise(int numBuckets)
        {
            _numBucketsUsed = 0;
            _numBuckets = numBuckets;
            _buckets = (UnmanagedList<(TKey, TValue)>*)Marshal.AllocHGlobal((IntPtr)_numBuckets * sizeof(UnmanagedList<(TKey, TValue)>));
            for (int i = 0; i < _numBuckets; i++)
            {
                _buckets[i] = new(8);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ContainsKey(TKey key)
        {
            var pBucket = GetBucket(key);
            for (int i = 0; i < pBucket->Count; i++)
            {
                if ((*pBucket)[i].Item1.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(TKey key, TValue val)
        {
            // Resize
            if (Count % 128 == 0 && (float)_numBucketsUsed / _numBuckets > LoadFactor)
            {
                var tmp = this;
                Initialise((int)(_numBuckets * (1 / LoadFactor)));
                foreach (var pair in tmp)
                {
                    Add(pair.Item1, pair.Item2);
                }
                tmp.Free();
            }

            var pBucket = GetBucket(key);
            for (int i = 0; i < pBucket->Count; i++)
            {
                if ((*pBucket)[i].Item1.Equals(key))
                {
                    throw new ArgumentException(key.ToString());
                }
            }
            if (pBucket->Count == 0)
            {
                _numBucketsUsed++;
            }
            (*pBucket).Add((key, val));
            Count++;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Remove(TKey key)
        {
            var pBucket = GetBucket(key);
            for (int i = 0; i < pBucket->Count; i++)
            {
                var pair = (*pBucket)[i];
                if (pair.Item1.Equals(key))
                {
                    if (i != pBucket->Count - 1)
                    {
                        (*pBucket)[i] = (*pBucket)[pBucket->Count - 1]; // Move last element to current one
                    }
                    (*pBucket).Trim(pBucket->Count - 1); // Discard last element
                    if (pBucket->Count == 0)
                        _numBucketsUsed--;
                    return;
                }
            }
            throw new KeyNotFoundException();
        }

        public TValue this[TKey key]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                var pBucket = GetBucket(key);
                for (int i = 0; i < pBucket->Count; i++)
                {
                    if ((*pBucket)[i].Item1.Equals(key))
                    {
                        return (*pBucket)[i].Item2;
                    }
                }
                throw new KeyNotFoundException();
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                var pBucket = GetBucket(key);
                for (int i = 0; i < pBucket->Count; i++)
                {
                    if ((*pBucket)[i].Item1.Equals(key))
                    {
                        (*pBucket)[i] = (key, value);
                        return;
                    }
                }
                throw new KeyNotFoundException();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private UnmanagedList<(TKey, TValue)>* GetBucket(TKey key)
        {
            return _buckets + (key.GetHashCode() % _numBuckets);
        }

        public void Free()
        {
            for (int i = 0; i < _numBuckets; i++)
            {
                _buckets[i].Free();
            }
            Marshal.FreeHGlobal((IntPtr)_buckets);
            ZeroStruct(ref this);
        }

        public IEnumerator<(TKey, TValue)> GetEnumerator()
        {
            return new UnmanagedDictionaryEnumerator<TKey, TValue>(ref this);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        class UnmanagedDictionaryEnumerator<eTKey, eTValue> : IEnumerator<(eTKey, eTValue)> where eTKey : unmanaged where eTValue : unmanaged
        {
            public UnmanagedDictionaryEnumerator(ref UnmanagedDictionary<eTKey, eTValue> dict)
            {
                _dict = dict;
            }
            public (eTKey, eTValue) Current => _dict._buckets[_iBucket][_iElement - 1];

            object IEnumerator.Current => Current;

            UnmanagedDictionary<eTKey, eTValue> _dict;
            int _iBucket;
            int _iElement;
            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                for (; _iBucket < _dict._numBuckets; _iBucket++)
                {
                    if (_dict._buckets[_iBucket].Count > _iElement++)
                    {
                        return true;
                    }
                    _iElement = 0;
                }
                return false;
            }

            public void Reset()
            {
                _iBucket = 0;
                _iElement = -1;
            }
        }
    }
}
