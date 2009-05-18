using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.Algorithms
{
    /// <summary>
    /// Mixed radix enumerable
    /// </summary>
    /// <typeparam name="T">the type of item</typeparam>
    public class MixedRadixEnumerable<T> : IEnumerable<T[]>
    {
        #region Fields

        private T[] array;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">the collection contains the items that visited</param>
        public MixedRadixEnumerable(IEnumerable<T> collection)
        {
            int count = 0;
            foreach (T item in collection)
            {
                count++;
            }

            array = new T[count];
            int index = 0;
            foreach (T item in collection)
            {
                array[index++] = item;
            }
        }

        #endregion

        #region IEnumerable<T[]> ��Ա

        public IEnumerator<T[]> GetEnumerator()
        {
            return new MixedRadixEnumerator<T>(array);
        }

        #endregion

        #region IEnumerable ��Ա

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
