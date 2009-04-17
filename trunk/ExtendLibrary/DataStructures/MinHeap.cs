using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.DataStructures
{
    /// <summary>
    ///  最小堆
    /// </summary>
    /// <typeparam name="T">最小堆中元素的类型</typeparam>
    public class MinHeap<T>
    {
        #region Fields

        /// <summary>
        /// 该堆包含的元素数量
        /// </summary>
        private int count;

        /// <summary>
        /// 已分配的元素数量
        /// </summary>
        private int capacity;

        /// <summary>
        /// 用来交换的元素
        /// </summary>
        private T swapValue;

        /// <summary>
        /// 保存所有元素
        /// </summary>
        private T[] array;

        private readonly Comparison<T> comparison;

        private readonly IComparer<T> comparer;

        #endregion

        #region Properties

        /// <summary>
        /// 访问该堆包含的元素个数
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// 构造函数
        /// </summary>
        public MinHeap() : this(4) { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="capacity">新最小堆最初可以存储的元素数</param>
        public MinHeap(int capacity)
        {
            count = 0;
            this.capacity = capacity;
            array = new T[capacity];
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="collection">一个集合，其元素被复制到新最小堆中</param>
        public MinHeap(IEnumerable<T> collection)
            :this(4)
        {
            foreach(T item in collection)
            {
                Add(item);
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="comparison">比较元素时要使用的 Comparison</param>
        public MinHeap(Comparison<T> comparison)
            : this(4, comparison)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="capacity">新最小堆最初可以存储的元素数</param>
        /// <param name="comparison">比较元素时要使用的 Comparison</param>
        public MinHeap(int capacity, Comparison<T> comparison)
            :this(capacity)
        {
            this.comparison = comparison;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="collection">一个集合，其元素被复制到新最小堆中</param>
        /// <param name="comparison">比较元素时要使用的 Comparison</param>        
        public MinHeap(IEnumerable<T> collection, Comparison<T> comparison)
            : this(collection)
        {
            this.comparison = comparison;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="comparer">比较元素时使用的 IComparer 泛型接口实现</param>
        public MinHeap(IComparer<T> comparer)
            : this(4, comparer)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="capacity">新最小堆最初可以存储的元素数</param>
        /// <param name="comparer">比较元素时使用的 IComparer 泛型接口实现</param>
        public MinHeap(int capacity, IComparer<T> comparer)
            : this(capacity)
        {
            this.comparer = comparer;
        }

        /// <summary>
        /// 构造函数
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
        /// 建立堆
        /// </summary>
        public void BuildHead()
        {
            int position;
            for (position = (count - 1) >> 1; position >= 0; position--)
            {
                MinHeapify(position);
            }
        }

        /// <summary>
        /// 增加元素
        /// </summary>
        /// <param name="item">待增加的元素</param>
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
                swapValue = array[position];
                array[position] = array[parentPosition];
                array[parentPosition] = swapValue;
                position = parentPosition;
                parentPosition = ((position - 1) >> 1);
            }
        }

        /// <summary>
        /// 使保存的元素的数量翻倍。
        /// </summary>
        private void DoubleArray()
        {
            capacity <<= 1;
            T[] newArray = new T[capacity];
            CopyArray(array, newArray);
            array = newArray;
        }

        /// <summary>
        /// 复制数组
        /// </summary>
        /// <param name="source">待复制的数组</param>
        /// <param name="destion">复制去的数组</param>
        private static void CopyArray(T[] source, T[] destion)
        {
            int index;
            for (index = 0; index < source.Length; index++)
            {
                destion[index] = source[index];
            }
        }

        /// <summary>
        /// 返回第一个元素,但是没有删除它
        /// </summary>
        /// <returns>返回第一个元素,但是没有删除它</returns>
        public T Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("堆为空。");
            }

            return array[0];
        }

        /// <summary>
        /// 返回第一个元素,并删除它
        /// </summary>
        /// <returns>返回第一个元素,并删除它</returns>
        public T ExtractFirst()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("堆为空。");
            }
            T result = array[0];
            array[0] = array[count - 1];
            count--;
            MinHeapify(0);
            return result;
        }

        private int Compare(int xIndex, int yIndex)
        {
            if (comparison != null)
            {
                return comparison(array[xIndex], array[yIndex]);
            }

            if (comparer != null)
            {
                return comparer.Compare(array[xIndex], array[yIndex]);
            }

            if (swapValue is IComparable<T>)
            {
                return ((IComparable<T>) array[xIndex]).CompareTo(array[yIndex]);
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
                //左孩子的位置
                int left = ((position << 1) + 1);

                //右孩子的位置
                int right = left + 1;
                int minPosition;

                //如果左孩子的位置小于元素个数并且左孩子节点比父亲节点大，最小元素的位置为左孩子
                if (left < count && Compare(left, position) < 0)
                {
                    minPosition = left;
                }

                //否则最大元素的位置为父亲
                else
                {
                    minPosition = position;
                }

                //如果右孩子的位置小于元素个数并且右孩子节点比父亲节点大，最小元素的位置为右孩子
                if (right < count && Compare(right, minPosition) < 0)
                {
                    minPosition = right;
                }

                //如果最大元素的位置不是父亲节点，则调整下一棵子树
                if (minPosition != position)
                {
                    T temp = array[position];
                    array[position] = array[minPosition];
                    array[minPosition] = temp;
                    position = minPosition;
                }

                else
                {
                    return;
                }

            } while (true);
        }

        #endregion
    }
}
