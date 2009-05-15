using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ExtendLibrary.Common;

namespace ExtendLibrary.DataStructures
{
    public class ArrayHeap<T> : Heap<T>
    {
        #region Fields

        /// <summary>
        /// the count of the items that minheap contains
        /// </summary>
        private int count;

        /// <summary>
        /// the count of allocated
        /// </summary>
        private int capacity;

        /// <summary>
        /// the array of items
        /// </summary>
        private T[] itemArray;

        /// <summary>
        /// comparer
        /// </summary>
        private readonly MultiComparer<T> comparer;

        #endregion

        #region Properties

        protected override IEnumerator HeapEnumerator
        {
            get { return itemArray.GetEnumerator(); }
        }

        #endregion

        #region Methods

        private int Compare(int xIndex, int yIndex)
        {
            T xItem = itemArray[xIndex];
            T yItem = itemArray[yIndex];
            return comparer.Compare(xItem, yItem);
        }

        /// <summary>
        /// Exchange the item of xIndex and the item of yIndex
        /// </summary>
        /// <param name="xIndex">the index of first item</param>
        /// <param name="yIndex">the index of second item</param>
        protected override void Exchange(int xIndex, int yIndex)
        {
            T exchange = itemArray[xIndex];
            itemArray[xIndex] = itemArray[yIndex];
            itemArray[yIndex] = exchange;
            base.Exchange(xIndex, yIndex);
        }

        #endregion

        #region Heap<T> ≥…‘±

        public override void BuildHeap(IEnumerable<T> collection)
        {
            count = 0;
            foreach (T item in collection)
            {
                count++;
            }
            capacity = count;
            itemArray = new T[count];

            int index = 0;
            foreach (T item in collection)
            {
                itemArray[index] = item;
                index++;
            }
        }

        public override void Add(T item)
        {
            count++;
            if (count > capacity)
            {
                capacity <<= 1;
                Array.Resize(ref itemArray, capacity);
            }
            itemArray[count - 1] = item;
        }

        public override T Peek()
        {
            int minIndex = 0;
            for (int i = 1; i < count; i++)
            {
                if (Compare(minIndex, i) > 0)
                {
                    minIndex = i;
                }
            }

            return itemArray[minIndex];
        }

        public override T ExtractMin()
        {
            int minIndex = 0;
            for (int i = 1; i < count; i++)
            {
                if (Compare(minIndex, i) > 0)
                {
                    minIndex = i;
                }
            }

            count--;

            for (int i = minIndex; i < count; )
            {
                Exchange(i, ++i);
            }

            return itemArray[minIndex];
        }

        public override void DecreaseKey(int index, T value)
        {
            if (comparer.Compare(itemArray[index], value) < 0)
            {
                string message = string.Format("Value {0} is greater than array[{1}]", value, index);
                throw new InvalidOperationException(message);
            }
            itemArray[index] = value;
        }

        public override T GetIndex(int index)
        {
            return itemArray[index];
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return new HeapEnumerator<T>(itemArray);
        }

        #endregion
    }
}
