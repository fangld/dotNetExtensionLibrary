using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.Algorithms
{
    public class PermutationEnumerable<T> : IEnumerable<T[]>
    {
        #region Fields

        private T[] array;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">the collection contains the items that visited</param>
        public PermutationEnumerable(IEnumerable<T> collection)
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

        #region IEnumerable<T[]> 成员

        public IEnumerator<T[]> GetEnumerator()
        {
            return new MixedRadixEnumerator<T>(array);
        }

        #endregion

        #region IEnumerable 成员

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
