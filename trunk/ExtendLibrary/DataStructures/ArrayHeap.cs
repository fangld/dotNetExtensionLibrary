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
        /// the count of allocated
        /// </summary>
        private int capacity;

        /// <summary>
        /// the array of items
        /// </summary>
        private T[] itemArray;

        #endregion

        #region Properties

        protected override IEnumerator HeapEnumerator
        {
            get { return itemArray.GetEnumerator(); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public ArrayHeap() : this(4)
        {}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="capacity">the capacity of stored items</param>
        public ArrayHeap(int capacity): base(capacity)
        {
            this.capacity = capacity;
            itemArray = new T[capacity];
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">a itemArray that contains items</param>
        public ArrayHeap(IEnumerable<T> collection)
            : base(0)
        {
            BuildHeap(collection);
        }

        ///// <summary>
        ///// Constructor
        ///// </summary>
        ///// <param name="collection">a itemArray that contains items</param>
        ///// <param name="exchangeCallBack">exchange callback</param>
        //public ArrayHeap(IEnumerable<T> collection, ExchangeCallback exchangeCallBack)
        //    :base(0, new MultiComparer<T>(), exchangeCallBack)
        //{
        //    BuildHeap(collection);
        //}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="comparison">comparison that used to compare items</param>
        public ArrayHeap(Comparison<T> comparison)
            : this(4, comparison)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="capacity">the capacity of stored items</param>
        /// <param name="comparison">comparison that used to compare items</param>
        public ArrayHeap(int capacity, Comparison<T> comparison)
            : base(capacity, new MultiComparer<T>(comparison), null)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">a itemArray that contains items</param>
        /// <param name="comparison">comparison that used to compare items</param>        
        public ArrayHeap(IEnumerable<T> collection, Comparison<T> comparison)
            : base(collection, new MultiComparer<T>(comparison))
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="comparer">a comparer that implement IComparer that used to compare items</param>
        public ArrayHeap(IComparer<T> comparer)
            : this(4, comparer)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="capacity">the capacity of stored items</param>
        /// <param name="comparer">a comparer that implement IComparer that used to compare items</param>
        public ArrayHeap(int capacity, IComparer<T> comparer)
            : base(capacity, new MultiComparer<T>(comparer))
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">a itemArray that contains items</param>
        /// <param name="comparer">a comparer that implement IComparer that used to compare items</param>
        public ArrayHeap(IEnumerable<T> collection, IComparer<T> comparer)
            : base(collection, new MultiComparer<T>(comparer))
        {
        }

        #endregion

        #region Methods

        private int Compare(int xIndex, int yIndex)
        {
            T xItem = itemArray[xIndex];
            T yItem = itemArray[yIndex];
            return Comparer.Compare(xItem, yItem);
        }

        /// <summary>
        /// Exchange the item of xIndex and the item of yIndex
        /// </summary>
        /// <param name="xIndex">the index of first item</param>
        /// <param name="yIndex">the index of second item</param>
        protected override void Exchange(int xIndex, int yIndex)
        {
            base.Exchange(xIndex, yIndex);
            T exchange = itemArray[xIndex];
            itemArray[xIndex] = itemArray[yIndex];
            itemArray[yIndex] = exchange;
        }

        #endregion

        #region Heap<T> ≥…‘±

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
        }

        public override void Add(T item)
        {
            Count++;
            if (Count > capacity)
            {
                capacity <<= 1;
                Array.Resize(ref itemArray, capacity);
            }
            itemArray[Count - 1] = item;
        }

        public override T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Minheap is empty!");
            }
            int minIndex = 0;
            for (int i = 1; i < Count; i++)
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
            if (Count == 0)
            {
                throw new InvalidOperationException("Minheap is empty!");
            }
            int minIndex = 0;
            for (int i = 1; i < Count; i++)
            {
                if (Compare(minIndex, i) > 0)
                {
                    minIndex = i;
                }
            }

            Count--;

            for (int i = minIndex; i < Count; )
            {
                Exchange(i, ++i);
            }

            return itemArray[Count];
        }

        public override void DecreaseKey(int index, T value)
        {
            if (Comparer.Compare(itemArray[index], value) < 0)
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
