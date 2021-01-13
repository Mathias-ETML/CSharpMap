using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace CSharpMap.Map
{
    // i am watching microsoft source code for all of this, and they did a very smart move : 
    // moving the Ienumerator into an public struct, which simplify the code ( which is allready enough hard do read )
    public class Map<TKey, TValue> : IMap<TKey, TValue>, IMap, IReadOnlyMap<TKey, TValue>, ISerializable, IDeserializationCallback
    {
        public ICollection<TKey> Keys => throw new NotImplementedException();

        public ICollection<TValue> Values => throw new NotImplementedException();

        public ICollection Key => throw new NotImplementedException();

        ICollection IMap.Values => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public bool IsFixedSize => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        IEnumerable<TKey> IReadOnlyMap<TKey, TValue>.Keys => throw new NotImplementedException();

        IEnumerable<TValue> IReadOnlyMap<TKey, TValue>.Values => throw new NotImplementedException();

        private struct Entry
        {
            TKey _key;
            TValue _value;
            int _hash;
            int _next;
        }

        public Map()
        {

        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public void Add(TKey key, TValue value)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        public bool TryGetKey(TValue value, out TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Contains(object key)
        {
            throw new NotImplementedException();
        }

        public void Add(object key, object value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Remove(object key)
        {
            throw new NotImplementedException();
        }

        public IMapEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public void OnDeserialization(object sender)
        {
            throw new NotImplementedException();
        }
    }
}
