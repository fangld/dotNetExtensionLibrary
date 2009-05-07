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
        private int count;

        /// <summary>
        /// the array of items
        /// </summary>
        private T[] array;

        /// <summary>
        /// the current position of the array
        /// </summary>
        private int currentPosition;

        #endregion

        internal MinHeapEnumerator(T[] array, int count)
        {
            currentPosition = 0;
            this.array = array;
            this.count = count;
        }

        #region IEnumerator<T> 成员

        public T Current
        {
            get { return array[currentPosition]; }
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
            currentPosition = 0;
        }

        #endregion
    }
}
