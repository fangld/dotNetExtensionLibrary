using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ExtensionLibrary.Common;

namespace ExtensionLibrary.DataStructures
{
    public abstract class Heap<T> : IEnumerable<T>
    {
        #region Fields

        /// <summary>
        /// the count of the items that minheap contains
        /// </summary>
        private int count;

        /// <summary>
        /// comparer
        /// </summary>
        private readonly Comparison<T> comparison;

        private ExchangeCallback exchangeCallback;

        #endregion

        #region Properties

        /// <summary>
        /// Get the count of the items that minheap contains
        /// </summary>
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        protected Comparison<T> Comparison
        {
            get { return comparison; }
        }

        #endregion

        #region Delegates

        public event ExchangeCallback BeforeExchange;

        public event ExchangeCallback AfterExchange;

        public delegate void ExchangeCallback(int xIndex, int yIndex);

        public delegate IEnumerator<T> GetEnumerable(IEnumerable<T> enumerable);

        #endregion

        #region Constructors

        protected Heap()
            : this(0)
        {
        }

        protected Heap(int count)
            : this(count, NativeComparer<T>.Compare, null)
        {
        }

        protected Heap(int count, Comparison<T> comparison)
            : this(count, comparison, null)
        {
        }

        protected Heap(int count, Comparison<T> comparison, ExchangeCallback exchangeCallback)
        {
            this.count = count;
            this.comparison = comparison;
            this.exchangeCallback = exchangeCallback;
        }

        protected Heap(IEnumerable<T> collection, Comparison<T> comparison)
            : this(0, comparison, null)
        {
            BuildHeap(collection);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Exchange the item of xIndex and the item of yIndex
        /// </summary>
        /// <param name="xIndex">the index of first item</param>
        /// <param name="yIndex">the index of second item</param>
        protected void Exchange(int xIndex, int yIndex)
        {
            if (BeforeExchange != null)
            {
                BeforeExchange(xIndex, yIndex);
            }

            ExchangeIndex(xIndex, yIndex);

            if (AfterExchange != null)
            {
                AfterExchange(xIndex, yIndex);
            }
        }

        protected abstract void ExchangeIndex(int xIndex, int yIndex);

        /// <summary>
        /// build the heap
        /// </summary>
        public abstract void BuildHeap(IEnumerable<T> collection);

        /// <summary>
        /// Add item
        /// </summary>
        /// <param name="item">a item that is ready to add</param>
        public abstract void Add(T item);

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
        public abstract T Peek();

        /// <summary>
        /// Extract the top n items
        /// </summary>
        /// <param name="number">the number of items that is extracted</param>
        /// <returns>return a list that contains the top n items</returns>
        public IList<T> ExtractList(int number)
        {
            if (Count < number)
            {
                string message = string.Format("Heap contains less than {0} items!", number);
                throw new InvalidOperationException(message);
            }
            IList<T> result = new List<T>(number);
            for (int i = 0; i < number; i++)
            {
                T item = ExtractMin();
                result.Add(item);
            }
            return result;
        }

        /// <summary>
        /// Extract the first item
        /// </summary>
        /// <returns>Return the first iem</returns>
        public abstract T ExtractMin();

        public abstract void DecreaseKey(int i, T value);

        public abstract T GetIndex(int index);

        protected void BeforeExchangeCallback(int xIndex, int yIndex)
        {
            if (BeforeExchange != null)
                BeforeExchange(xIndex, yIndex);
        }

        protected void AfterExchangeCallback(int xIndex, int yIndex)
        {
            if (AfterExchange != null)
                AfterExchange(xIndex, yIndex);
        }

        #endregion


        #region IEnumerable<T> 成员

        public abstract IEnumerator<T> GetEnumerator();

        #endregion

        #region IEnumerable 成员

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
