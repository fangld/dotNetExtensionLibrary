using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.DataStructures
{
    internal class MinHeapEnumerator<T> : IEnumerator<T>
    {
        #region Fields

        /// <summary>
        /// the count of the items that minheap contains
        /// </summary>
        private readonly int count;

        /// <summary>
        /// the array of items
        /// </summary>
        private readonly T[] array;

        /// <summary>
        /// the current position of the array
        /// </summary>
        private int currentPosition;

        #endregion

        internal MinHeapEnumerator(T[] array, int count)
        {
            currentPosition = -1;
            this.array = array;
            this.count = count;
        }

        #region IEnumerator<T> 成员

        public T Current
        {
            get
            {
                try
                {
                    return array[currentPosition];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
        }

        #endregion

        #region IEnumerator 成员

        object System.Collections.IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            currentPosition++;
            return currentPosition < count;
        }

        public void Reset()
        {
            currentPosition = -1;
        }

        #endregion
    }
}
