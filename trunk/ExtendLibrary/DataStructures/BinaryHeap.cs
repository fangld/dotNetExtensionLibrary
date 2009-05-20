using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ExtendLibrary.Common;

namespace ExtendLibrary.DataStructures
{
    /// <summary>
    ///  Binary heap data structure
    /// </summary>
    /// <typeparam name="T">the type of item</typeparam>
    public class BinaryHeap<T> : Heap<T>
    {
        #region Fields

        /// <summary>
        /// the array of items
        /// </summary>
        private T[] itemArray;

        /// <summary>
        /// the count of allocated
        /// </summary>
        private int capacity;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public BinaryHeap() : this(4)
        {}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="capacity">the capacity of stored items</param>
        public BinaryHeap(int capacity): base(capacity)
        {
            this.capacity = capacity;
            itemArray = new T[capacity];
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">a itemArray that contains items</param>
        public BinaryHeap(IEnumerable<T> collection)
            : base(0)
        {
            BuildHeap(collection);
        }

        ///// <summary>
        ///// Constructor
        ///// </summary>
        ///// <param name="collection">a itemArray that contains items</param>
        ///// <param name="exchangeCallBack">exchange callback</param>
        //public BinaryHeap(IEnumerable<T> collection, ExchangeCallback exchangeCallBack)
        //    :base(0, new MultiComparer<T>(), exchangeCallBack)
        //{
        //    BuildHeap(collection);
        //}

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
            : base(capacity, comparison, null)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">a itemArray that contains items</param>
        /// <param name="comparison">comparison that used to compare items</param>        
        public BinaryHeap(IEnumerable<T> collection, Comparison<T> comparison)
            : base(collection, comparison)
        {
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
            : base(capacity, comparer.Compare)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">a itemArray that contains items</param>
        /// <param name="comparer">a comparer that implement IComparer that used to compare items</param>
        public BinaryHeap(IEnumerable<T> collection, IComparer<T> comparer)
            : base(collection, comparer.Compare)
        {
        }

        #endregion

        #region Methods

        private int Compare(int xIndex, int yIndex)
        {
            T xItem = itemArray[xIndex];
            T yItem = itemArray[yIndex];
            return Comparison(xItem, yItem);
        }

        /// <summary>
        /// 调整堆
        /// </summary>
        /// <param name="index">调整的位置</param>
        private void ShiftDown(int index)
        {
            do
            {
                int leftIndex = ((index << 1) + 1);
                int rightIndex = leftIndex + 1;
                int minIndex = (leftIndex < Count && Compare(leftIndex, index) < 0) ? leftIndex : index;

                if (rightIndex < Count && Compare(rightIndex, minIndex) < 0)
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
        protected override void ExchangeIndex(int xIndex, int yIndex)
        {
            T exchange = itemArray[xIndex];
            itemArray[xIndex] = itemArray[yIndex];
            itemArray[yIndex] = exchange;
        }

        #endregion

        #region Heap<T> 成员

        /// <summary>
        /// build the heap
        /// </summary>
        public override void BuildHeap(IEnumerable<T> collection)
        {
            Count = 0;
            foreach (T item in collection)
            {
                Count++;
            }
            capacity = Count;
            itemArray = new T[Count];

            int index = 0;
            foreach (T item in collection)
            {
                itemArray[index] = item;
                index++;
            }

            for (index = (Count - 1) >> 1; index >= 0; index--)
            {
                ShiftDown(index);
            }
        }

        /// <summary>
        /// Add item
        /// </summary>
        /// <param name="item">a item that is ready to add</param>
        public override void Add(T item)
        {
            Count++;
            if (Count > capacity)
            {
                capacity <<= 1;
                Array.Resize(ref itemArray, capacity);
            }
            itemArray[--Count] = item;
            ShiftUp(Count);
        }

        /// <summary>
        /// Return the first item
        /// </summary>
        /// <returns>Return the first item</returns>
        public override T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Minheap is empty!");
            }

            return itemArray[0];
        }

        /// <summary>
        /// Extract the first item
        /// </summary>
        /// <returns>Return the first iem</returns>
        public override T ExtractMin()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Minheap is empty!");
            }
            T result = itemArray[0];
            itemArray[0] = itemArray[--Count];
            ShiftDown(0);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void DecreaseKey(int index, T value)
        {
            if (Comparison(itemArray[index], value) < 0)
            {
                string message = string.Format("Value {0} is greater than array[{1}]", value, index);
                throw new InvalidOperationException(message);
            }
            itemArray[index] = value;
            ShiftUp(index);
        }

        public override T GetIndex(int index)
        {
            return itemArray[index];
        }

        #endregion

        #region IEnumerable<T> 成员

        public override IEnumerator<T> GetEnumerator()
        {
            return new HeapEnumerator<T>(itemArray, Count);
        }

        #endregion
    }
}
