using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ExtendLibrary.Common;

namespace ExtendLibrary.DataStructures
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
        private readonly MultiComparer<T> comparer;

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

        protected abstract IEnumerator HeapEnumerator
        {
            get;
        }

        protected MultiComparer<T> Comparer
        {
            get { return comparer; }
        }

        public ExchangeCallback ExchangeCallBack
        {
            get { return exchangeCallback; }
            set { exchangeCallback = value; }
        }

        #endregion

        #region Delegates

        public delegate void ExchangeCallback(int xIndex, int yIndex);

        public delegate IEnumerator<T> GetEnumerable(IEnumerable<T> enumerable);

        #endregion

        #region Constructors

        protected Heap()
            : this(0)
        {
        }

        protected Heap(int count)
            : this(count, new MultiComparer<T>(), null)
        {
        }

        //protected Heap(ExchangeCallback exchangeCallback):
        //    this(0, new MultiComparer<T>(), exchangeCallback)
        //{
        //}

        protected Heap(int count, MultiComparer<T> comparer):
            this(count, comparer, null)
        {
            
        }

        protected Heap(int count, MultiComparer<T> comparer, ExchangeCallback exchangeCallback)
        {
            this.count = count;
            this.comparer = comparer;
            this.exchangeCallback = exchangeCallback;
        }

        protected Heap(IEnumerable<T> collection, MultiComparer<T> comparer)
            :this(0, comparer, null)
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
        protected virtual void Exchange(int xIndex, int yIndex)
        {
            if (exchangeCallback != null)
            {
                exchangeCallback(xIndex, yIndex);
            }
        }

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

        #endregion


        #region IEnumerable<T> 成员

        public abstract IEnumerator<T> GetEnumerator();

        #endregion

        #region IEnumerable 成员

        IEnumerator IEnumerable.GetEnumerator()
        {
            return HeapEnumerator;
        }

        #endregion
    }
}
