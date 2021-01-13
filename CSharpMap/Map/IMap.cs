using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace CSharpMap.Map
{
    /// <summary>
    /// IMap interface
    /// </summary>
    public interface IMap : ICollection
    {
        ICollection Key
        {
            get;
        }

        ICollection Values
        {
            get;
        }

        bool IsReadOnly
        {
            get;
        }

        bool IsFixedSize
        {
            get;
        }
        
        bool Contains(object key);

        void Add(object key, object value);

        void Clear();

        void Remove(object key);

        new IMapEnumerator GetEnumerator();

        // todo : contracts
    }

    /// <summary>
    /// IMap with key values
    /// </summary>
    /// <typeparam name="TKey">key</typeparam>
    /// <typeparam name="TValue">value</typeparam>
    public interface IMap<TKey, TValue> 
    {
        ICollection<TKey> Keys
        {
            get;
        }

        ICollection<TValue> Values
        {
            get;
        }

        bool ContainsKey(TKey key);

        void Add(TKey key, TValue value);

        bool Remove(TKey key);

        bool TryGetValue(TKey key, out TValue value);

        bool TryGetKey(TValue value, out TKey key);
    }
}
