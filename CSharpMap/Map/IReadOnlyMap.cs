using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMap.Map
{
    public interface IReadOnlyMap<TKey, TValue> : IReadOnlyCollection<KeyValuePair<TKey, TValue>>
    {
        bool ContainsKey(TKey key);

        bool TryGetValue(TKey key, out TValue value);

        bool TryGetKey(TValue value, out TKey key);

        IEnumerable<TKey> Keys { get; }

        IEnumerable<TValue> Values { get; }
    }
}
