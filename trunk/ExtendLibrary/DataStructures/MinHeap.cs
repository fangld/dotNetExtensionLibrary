using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.DataStructures
{
    /// <summary>
    ///  Min heap data structure
    /// </summary>
    /// <typeparam name="T">the type of item</typeparam>
    public class MinHeap<T> : IEnumerable<T>
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
        private T[] array;

        /// <summary>
        /// comparsion
        /// </summary>
        private readonly Comparison<T> comparison;

        /// <summary>
        /// comparer
        /// </summary>
        private readonly IComparer<T> comparer;

        #endregion

        #region Properties

        /// <summary>
        /// Get the count of the items that minheap contains
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public MinHeap() : this(4) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="capacity">新最小堆最初可以存储的元素数</param>
        public MinHeap(int capacity)
        {
            count = 0;
            this.capacity = capacity;
            array = new T[capacity];
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">a collection that contains items</param>
        public MinHeap(IEnumerable<T> collection)
            :this(4)
        {
            foreach(T item in collection)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="comparison">比较元素时要使用的 Comparison</param>
        public MinHeap(Comparison<T> comparison)
            : this(4, comparison)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="capacity">新最小堆最初可以存储的元素数</param>
        /// <param name="comparison">比较元素时要使用的 Comparison</param>
        public MinHeap(int capacity, Comparison<T> comparison)
            :this(capacity)
        {
            this.comparison = comparison;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">一个集合，其元素被复制到新最小堆中</param>
        /// <param name="comparison">比较元素时要使用的 Comparison</param>        
        public MinHeap(IEnumerable<T> collection, Comparison<T> comparison)
            : this(collection)
        {
            this.comparison = comparison;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="comparer">比较元素时使用的 IComparer 泛型接口实现</param>
        public MinHeap(IComparer<T> comparer)
            : this(4, comparer)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="capacity">新最小堆最初可以存储的元素数</param>
        /// <param name="comparer">比较元素时使用的 IComparer 泛型接口实现</param>
        public MinHeap(int capacity, IComparer<T> comparer)
            : this(capacity)
        {
            this.comparer = comparer;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">一个集合，其元素被复制到新最小堆中</param>
        /// <param name="comparer">比较元素时使用的 IComparer 泛型接口实现</param>
        public MinHeap(IEnumerable<T> collection, IComparer<T> comparer)
            : this(collection)
        {
            this.comparer = comparer;
        }

        #endregion

        #region Methods

        /// <summary>
        /// build the heap
        /// </summary>
        public void BuildHeap()
        {
            int position;
            for (position = (count - 1) >> 1; position >= 0; position--)
            {
                MinHeapify(position);
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
                DoubleArray();
            }
            array[count - 1] = item;
            int position = count - 1;

            int parentPosition = ((position - 1) >> 1);

            while (position > 0 && Compare(parentPosition, position) > 0)
            {
                T swapValue = array[position];
                array[position] = array[parentPosition];
                array[parentPosition] = swapValue;
                position = parentPosition;
                parentPosition = ((position - 1) >> 1);
            }
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
        /// Double the array
        /// </summary>
        private void DoubleArray()
        {
            capacity <<= 1;
            T[] newArray = new T[capacity];
            CopyArray(array, newArray);
            array = newArray;
        }

        /// <summary>
        /// Copy array
        /// </summary>
        /// <param name="source">source array</param>
        /// <param name="destination">destination</param>
        private static void CopyArray(T[] source, T[] destination)
        {
            int index;
            for (index = 0; index < source.Length; index++)
            {
                destination[index] = source[index];
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

            return array[0];
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
                string message = string.Format("Minheap contains no more than {0} items!", count);
                throw new InvalidOperationException(message);
            }
            IList<T> result = new List<T>();
            for (int i = 0; i < count; i++)
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
            T result = array[0];
            array[0] = array[count - 1];
            count--;
            MinHeapify(0);
            return result;
        }

        private int Compare(int xIndex, int yIndex)
        {
            T xItem = array[xIndex];
            T yItem = array[yIndex];
            if (xItem is IComparable<T>)
            {
                return ((IComparable<T>)xItem).CompareTo(yItem);
            }

            if (xItem is IComparable)
            {
                return ((IComparable)xItem).CompareTo(yItem);
            }

            if (comparison != null)
            {
                return comparison(xItem, yItem);
            }

            if (comparer != null)
            {
                return comparer.Compare(xItem, yItem);
            }

            throw new InvalidOperationException("未能比较容器中的两个元素。");
        }

        /// <summary>
        /// 调整堆
        /// </summary>
        /// <param name="position">调整的位置</param>
        private void MinHeapify(int position)
        {
            do
            {
                int left = ((position << 1) + 1);
                int right = left + 1;
                int minPosition;

                if (left < count && Compare(left, position) < 0)
                {
                    minPosition = left;
                }
                else
                {
                    minPosition = position;
                }

                if (right < count && Compare(right, minPosition) < 0)
                {
                    minPosition = right;
                }

                if (minPosition != position)
                {
                    T swapValue = array[position];
                    array[position] = array[minPosition];
                    array[minPosition] = swapValue;
                    position = minPosition;
                }

                else
                {
                    return;
                }

            } while (true);
        }

        #endregion

        #region IEnumerable<T> 成员

        public IEnumerator<T> GetEnumerator()
        {
            return new MinHeapEnumerator<T>(array, count);
        }

        #endregion

        #region IEnumerable 成员

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
