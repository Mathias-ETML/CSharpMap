using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMap.Map
{
    /// <summary>
    /// Map entry class
    /// </summary>
    public class MapEntry
    {
        /// <summary>
        /// key entry
        /// </summary>
        private object _key;

        /// <summary>
        /// value entry
        /// </summary>
        private object _value;

        /// <summary>
        /// Value field
        /// </summary>
        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>
        /// Key field
        /// </summary>
        public object Key
        {
            get { return _key; }
            set { _key = value; }
        }

        /// <summary>
        /// Custom constructor
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        public MapEntry(object key, object value)
        {
            this._key = key;
            this._value = value;
        }
    }
}
