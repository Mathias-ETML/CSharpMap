#define CS70
#define TEST_MODE

using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpMap.SimpleMap
{
    public class SimpleMap<TKey, TValue> : ISimpleMap<TKey, TValue>
    {
        /// <summary>
        /// attributs
        /// </summary>
        private List<TKey> _keys;
        private List<TValue> _values;

        /// <summary>
        /// properties
        /// </summary>
        public ICollection<TKey> Keys => _keys;

        public ICollection<TValue> Values => _values;

        public int Count => _keys.Count;

        public bool IsReadOnly => false;

        /// <summary>
        /// Default constructor
        /// </summary>
        public SimpleMap()
        {
            this._keys = new List<TKey>();
            this._values = new List<TValue>();
        }

        /// <summary>
        /// Add key
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        public void Add(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key) + " cannot be null", "key");
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value) + " cannot be null", "value");
            }

            if (FindIndex(key) != - 1)
            {
                throw new ArgumentException(nameof(key) + " allready exist in the map", "key");
            }

            if (FindIndex(value) != -1)
            {
                throw new ArgumentException(nameof(value) + " allready exist in the map", "value");
            }

            this._keys.Add(key);
            this._values.Add(value);
        }

        /// <summary>
        /// remove key
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>if key and value where removed</returns>
        public bool Remove(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key) + " cannot be null", "key");
            }

            int i = FindIndex(key);

            if (i >= 0)
            {
                this._keys.RemoveAt(i);
                this._values.RemoveAt(i);
                return true;
            }

            return false;
        }

        /// <summary>
        /// remove value
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>if value and key where removed</returns>
        public bool Remove(TValue value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value) + " cannot be null", "value");
            }

            int i = FindIndex(value);

            if (i >= 0)
            {
                this._values.RemoveAt(i);
                this._keys.RemoveAt(i);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Get Value
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>value, or default value is not existing</returns>
        public TValue GetValue(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key) + " cannot be null", "key");
            }

            int i = FindIndex(key);

            // check if key exist
            if (i == -1)
            {
                throw new ArgumentException(nameof(key) + " does not exist in the map", "key");
            }

            return _values[i];
        }

        /// <summary>
        /// Get Value
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>key, or default key is not existing</returns>
        public TKey GetKey(TValue value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value) + " cannot be null", "value");
            }

            int i = FindIndex(value);

            // check if key exist
            if (i == -1)
            {
                throw new ArgumentException(nameof(value) + " does not exist in the map", "value");
            }

            return _keys[i];
        }

        /// <summary>
        /// Try get key
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">out value</param>
        /// <returns>if value find</returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key) + " cannot be null", "key");
            }

            int i = FindIndex(key);

            // check if key is existing
            if (i >= 0)
            {
                value = _values[i];
                return true;
            }

#if TEST_MODE
            value = default(TValue);
#else

#if CS70
            value = default(TValue);
#else
            value = default;
#endif
#endif
            return false;
        }

        /// <summary>
        /// Try get key
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="key">out key</param>
        /// <returns>if key find</returns>
        public bool TryGetKey(TValue value, out TKey key)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value) + " cannot be null", "value");
            }

            int i = FindIndex(value);

            // check if value is existing
            if (i >= 0)
            {
                key = _keys[i];
                return true;
            }

#if TEST_MODE
            key = default(TKey);
#else

#if CS70
            key = default(TKey);
#else
            key = default;
#endif
#endif
            return false;
        }

        /// <summary>
        /// find index
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>index, or -1 if not found</returns>
        private int FindIndex(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key) + " cannot be null", "key");
            }

            // this is not optimised
            // we need to do a hash table of the keys, or hash table of an entry struct
            // because we are checking with the Equals function, which takes time
            for (int i = 0; i < _keys.Count; i++)
            {
                if (object.Equals(_keys[i], key))
                {
                    return i;
                }
            }

            return -1;
        }


        /// <summary>
        /// find index
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>index, or -1 if not found</returns>
        private int FindIndex(TValue value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value) + " cannot be null", "key");
            }

            // this is not optimised, see above
            for (int i = 0; i < _values.Count; i++)
            {
                if (object.Equals(_values[i], value))
                {
                    return i;
                }
            }

            return -1;
        }


        #region ISimpleMap interface implementation
        /// <summary>
        /// Check if a key exist in the map
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>if a key exist</returns>
        public bool ContainsKey(TKey key)
        {
            return FindIndex(key) != -1;
        }

        /// <summary>
        /// Add key value pair into the map
        /// </summary>
        /// <param name="item">key value pair</param>
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            _keys.Add(item.Key);
            _values.Add(item.Value);
        }

        /// <summary>
        /// Clair the map
        /// </summary>
        public void Clear()
        {
            _keys.Clear();
            _values.Clear();
        }

        /// <summary>
        /// Check if key value pair are in the map
        /// </summary>
        /// <param name="item">key value pair</param>
        /// <returns>if key value pair are in the map</returns>
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            int i = FindIndex(item.Key);
            int y = FindIndex(item.Value);

            // check if items exist and they are in the same place in the list
            return i != -1 && y != -1 && i == y;
        }

        /// <summary>
        /// Copyto function
        /// </summary>
        /// <param name="array">array</param>
        /// <param name="arrayIndex">where to start</param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array) + " cannot be null", "array");
            }

            if (arrayIndex < 0 || arrayIndex > array.Length)
            {
                throw new ArgumentException(nameof(arrayIndex) + " is too small or too big", "arrayIndex");
            }

            if (array.Length - arrayIndex < Keys.Count)
            {
                throw new ArgumentException(nameof(array) + " is too small", "array");
            }

            for (int i = 0; i < Keys.Count; i++, arrayIndex++)
            {
                array[arrayIndex] = new KeyValuePair<TKey, TValue>(_keys[i], _values[i]);
            }
        }

        /// <summary>
        /// Remove key value pair from the map
        /// </summary>
        /// <param name="item">key value pair</param>
        /// <returns>if key value pair was removed</returns>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            int i = FindIndex(item.Key);
            int y = FindIndex(item.Value);

            if (i != y || i == -1 || y == -1)
            {
                return false;
            }

            _keys.RemoveAt(i);
            _values.RemoveAt(i);

            return true;
        }

        /// <summary>
        /// IEnumerator implementation
        /// </summary>
        /// <returns>yield key value pair</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < _keys.Count; i++)
            {
                yield return new KeyValuePair<TKey, TValue>(_keys[i], _values[i]);
            }
        }

        /// <summary>
        /// IEnumerator implementation
        /// </summary>
        /// <returns>yield key value pair</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < _keys.Count; i++)
            {
                yield return new KeyValuePair<TKey, TValue>(_keys[i], _values[i]);
            }
        }
#endregion ISimpleMap interface implementation
    }

    /// <summary>
    /// ISimpleMap interface
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public interface ISimpleMap<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>>
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

        bool Remove(TValue value);

        bool TryGetValue(TKey key, out TValue value);

        bool TryGetKey(TValue value, out TKey key);
    }
}
