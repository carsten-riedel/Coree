using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Coree.Extensions.List
{
    public static partial class ExtensionsList
    {
        /// <summary>
        /// Adds an object to the end of the System.Collections.Generic.List`1.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <param name="item">The object to add to the System.Collections.Generic.List`1. The value can be null for reference types</param>
        /// <exception cref="NullReferenceException"></exception>
        public static void Enqueue<T>(this List<T> values, T item) where T : class
        {
            if (values != null)
            {
                values.Add(item);
            }
            else
            {
                throw new NullReferenceException();
            }
        }


        /// <summary>
        /// Removes and returns the object at the beginning of the System.Collections.Generic.List`1.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns>The object that is removed from the beginning of the System.Collections.List.List`1.</returns>
        /// <exception cref="InvalidOperationException">The System.Collections.Generic.List`1 is empty</exception>
        /// <exception cref="NullReferenceException"></exception>
        public static T Dequeue<T>(this List<T> values) where T : class
        {
            T? retval = null;
            if (values != null && values.Count >= 1)
            {
                retval = values[0];
                values.RemoveAt(0);
            }
            else if (values != null && values.Count == 0)
            {
                throw new InvalidOperationException("Queue empty.");

            }
            else if (values == null)
            {
                throw new NullReferenceException();
            }

            return retval;
        }

    }
}
