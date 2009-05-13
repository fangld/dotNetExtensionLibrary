using System;
using System.Collections.Generic;
using System.Text;
using ExtendLibrary.Common;

namespace ExtendLibrary.DataStructures
{
    /// <summary>
    ///  Min heap data structure
    /// </summary>
    /// <typeparam name="T">the type of item</typeparam>
    public class BinaryHeap<T> : IEnumerable<T>
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
        /// <param name="capacity">����С��������Դ洢��Ԫ����</param>
        public BinaryHeap(int capacity)
        {
            count = 0;
            this.capacity = capacity;
            array = new T[capacity];
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">a collection that contains items</param>
        public BinaryHeap(IEnumerable<T> collection)
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
        /// <param name="comparison">�Ƚ�Ԫ��ʱҪʹ�õ� Comparison</param>
        public BinaryHeap(Comparison<T> comparison)
            : this(4, comparison)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="capacity">����С��������Դ洢��Ԫ����</param>
        /// <param name="comparison">�Ƚ�Ԫ��ʱҪʹ�õ� Comparison</param>
        public BinaryHeap(int capacity, Comparison<T> comparison)
            :this(capacity)
        {
            comparer = new MultiComparer<T>(comparison);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">һ�����ϣ���Ԫ�ر����Ƶ�����С����</param>
        /// <param name="comparison">�Ƚ�Ԫ��ʱҪʹ�õ� Comparison</param>        
        public BinaryHeap(IEnumerable<T> collection, Comparison<T> comparison)
            : this(collection)
        {
            comparer = new MultiComparer<T>(comparison);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="comparer">�Ƚ�Ԫ��ʱʹ�õ� IComparer ���ͽӿ�ʵ��</param>
        public BinaryHeap(IComparer<T> comparer)
            : this(4, comparer)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="capacity">����С��������Դ洢��Ԫ����</param>
        /// <param name="comparer">�Ƚ�Ԫ��ʱʹ�õ� IComparer ���ͽӿ�ʵ��</param>
        public BinaryHeap(int capacity, IComparer<T> comparer)
            : this(capacity)
        {
            this.comparer = new MultiComparer<T>(comparer);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="collection">һ�����ϣ���Ԫ�ر����Ƶ�����С����</param>
        /// <param name="comparer">�Ƚ�Ԫ��ʱʹ�õ� IComparer ���ͽӿ�ʵ��</param>
        public BinaryHeap(IEnumerable<T> collection, IComparer<T> comparer)
            : this(collection)
        {
            this.comparer = new MultiComparer<T>(comparer);
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
                Heapify(position);
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
                Array.Resize(ref array, capacity);
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
            T result = array[0];
            array[0] = array[count - 1];
            count--;
            Heapify(0);
            return result;
        }

        private int Compare(int xIndex, int yIndex)
        {
            T xItem = array[xIndex];
            T yItem = array[yIndex];
            return comparer.Compare(xItem, yItem);
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="position">������λ��</param>
        private void Heapify(int position)
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

        #region IEnumerable<T> ��Ա

        public IEnumerator<T> GetEnumerator()
        {
            return new HeapEnumerator<T>(array);
        }

        #endregion

        #region IEnumerable ��Ա

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return array.GetEnumerator();
        }

        #endregion
    }
}
