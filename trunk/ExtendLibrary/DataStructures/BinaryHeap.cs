using System;
using System.Collections.Generic;
using System.Text;
using ExtendLibrary.Common;

namespace ExtendLibrary.DataStructures
{
    /// <summary>
    ///  Binary heap data structure
    /// </summary>
    /// <typeparam name="T">the type of item</typeparam>
    public class BinaryHeap<T> : IEnumerable<T>, IHeap<T>
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

        /// <summary>
        /// Get the count of the items that minheap contains
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        protected internal T[] ItemArray
        {
            get { return itemArray; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public BinaryHeap() : this(4)
        {
            comparer = new MultiComparer<T>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="capacity">the capacity of stored items</param>
        public BinaryHeap(int capacity)
        {
            count = 0;
            this.capacity = capacity;
            itemArray = new T[capacity];
            comparer = new MultiComparer<T>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">a itemArray that contains items</param>
        public BinaryHeap(IEnumerable<T> collection)
        {
            BuildHeap(collection);
            comparer = new MultiComparer<T>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="comparison">comparison that used to compare items</param>
        public BinaryHeap(Comparison<T> comparison)
            : this(4, comparison)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="capacity">the capacity of stored items</param>
        /// <param name="comparison">comparison that used to compare items</param>
        public BinaryHeap(int capacity, Comparison<T> comparison)
            :this(capacity)
        {
            comparer = new MultiComparer<T>(comparison);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">a itemArray that contains items</param>
        /// <param name="comparison">comparison that used to compare items</param>        
        public BinaryHeap(IEnumerable<T> collection, Comparison<T> comparison)
            : this(collection)
        {
            comparer = new MultiComparer<T>(comparison);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="comparer">a comparer that implement IComparer that used to compare items</param>
        public BinaryHeap(IComparer<T> comparer)
            : this(4, comparer)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="capacity">the capacity of stored items</param>
        /// <param name="comparer">a comparer that implement IComparer that used to compare items</param>
        public BinaryHeap(int capacity, IComparer<T> comparer)
            : this(capacity)
        {
            this.comparer = new MultiComparer<T>(comparer);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">a itemArray that contains items</param>
        /// <param name="comparer">a comparer that implement IComparer that used to compare items</param>
        public BinaryHeap(IEnumerable<T> collection, IComparer<T> comparer)
            : this(collection)
        {
            this.comparer = new MultiComparer<T>(comparer);
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
        /// 调整堆
        /// </summary>
        /// <param name="index">调整的位置</param>
        private void Heapify(int index)
        {
            do
            {
                int leftIndex = ((index << 1) + 1);
                int rightIndex = leftIndex + 1;
                int minIndex = (leftIndex < count && Compare(leftIndex, index) < 0) ? leftIndex : index;

                if (rightIndex < count && Compare(rightIndex, minIndex) < 0)
                {
                    minIndex = rightIndex;
                }

                if (minIndex != index)
                {
                    Exchange(index, minIndex);
                    index = minIndex;
                }

                else
                {
                    return;
                }

            } while (true);
        }

        private void ShiftUp(int index)
        {
            int parentPosition = ((index - 1) >> 1);

            while (index > 0 && Compare(parentPosition, index) > 0)
            {
                Exchange(index, parentPosition);
                index = parentPosition;
                parentPosition = ((index - 1) >> 1);
            }
        }

        /// <summary>
        /// Exchange the item of xIndex and the item of yIndex
        /// </summary>
        /// <param name="xIndex">the index of first item</param>
        /// <param name="yIndex">the index of second item</param>
        protected virtual void Exchange(int xIndex, int yIndex)
        {
            T exchange = itemArray[xIndex];
            itemArray[xIndex] = itemArray[yIndex];
            itemArray[yIndex] = exchange;
        }

        #endregion

        #region IEnumerable<T> 成员

        public IEnumerator<T> GetEnumerator()
        {
            return new HeapEnumerator<T>(itemArray);
        }

        #endregion

        #region IHeap<T> 成员

        /// <summary>
        /// build the heap
        /// </summary>
        public void BuildHeap(IEnumerable<T> collection)
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

            for (index = (count - 1) >> 1; index >= 0; index--)
            {
                Heapify(index);
            }
        }

        /// <summary>
        /// Add item
        /// </summary>
        /// <param name="item">a item that is ready to add</param>
        public void Add(T item)
        {
            count++;
            if (count > capacity)
            {
                capacity <<= 1;
                Array.Resize(ref itemArray, capacity);
            }
            itemArray[count - 1] = item;
            ShiftUp(count - 1);
        }

        /// <summary>
        /// Add items
        /// </summary>
        /// <param name="collection">a colletion that contaions items</param>
        public void Add(IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Return the first item
        /// </summary>
        /// <returns>Return the first item</returns>
        public T Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Minheap is empty!");
            }

            return itemArray[0];
        }

        /// <summary>
        /// Extract the top n items
        /// </summary>
        /// <param name="number">the number of items that is extracted</param>
        /// <returns>return a list that contains the top n items</returns>
        public IList<T> ExtractList(int number)
        {
            if (count < number)
            {
                string message = string.Format("Minheap contains less than {0} items!", number);
                throw new InvalidOperationException(message);
            }
            IList<T> result = new List<T>(number);
            for (int i = 0; i < number; i++)
            {
                T item = ExtractFirst();
                result.Add(item);
            }
            return result;
        }

        /// <summary>
        /// Extract the first item
        /// </summary>
        /// <returns>Return the first iem</returns>
        public T ExtractFirst()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Minheap is empty!");
            }
            T result = itemArray[0];
            itemArray[0] = itemArray[count - 1];
            count--;
            Heapify(0);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        public void DecreaseKey(int index, T value)
        {
            if (comparer.Compare(itemArray[index], value) < 0)
            {
                string message = string.Format("Value {0} is greater than array[{1}]", value, index);
                throw new InvalidOperationException(message);
            }
            itemArray[index] = value;
            ShiftUp(index);
        }

        #endregion

        #region IEnumerable 成员

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return itemArray.GetEnumerator();
        }

        #endregion
    }
}
