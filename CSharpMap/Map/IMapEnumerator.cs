using System.Collections;

namespace CSharpMap.Map
{
    /// <summary>
    /// IMapEnumerator interface
    /// </summary>
    public interface IMapEnumerator : IEnumerable
    {
        /// <summary>
        /// Key field
        /// </summary>
        object Key
        {
            get;
        }

        /// <summary>
        /// Value field
        /// </summary>
        object Value
        {
            get;
        }

        /// <summary>
        /// MapEntry Field
        /// </summary>
        MapEntry MapEntry
        {
            get;
        }
    }
}
