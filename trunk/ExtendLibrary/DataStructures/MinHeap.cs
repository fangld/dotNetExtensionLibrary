using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.DataStructures
{
    /// <summary>
    ///  ��С��
    /// </summary>
    /// <typeparam name="T">��С����Ԫ�ص�����</typeparam>
    public class MinHeap<T>
    {
        #region Fields

        /// <summary>
        /// �öѰ�����Ԫ������
        /// </summary>
        private int count;

        /// <summary>
        /// �ѷ����Ԫ������
        /// </summary>
        private int capacity;

        /// <summary>
        /// ����������Ԫ��
        /// </summary>
        private T swapValue;

        /// <summary>
        /// ��������Ԫ��
        /// </summary>
        private T[] array;

        private readonly Comparison<T> comparison;

        private readonly IComparer<T> comparer;

        #endregion

        #region Properties

        /// <summary>
        /// ���ʸöѰ�����Ԫ�ظ���
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// ���캯��
        /// </summary>
        public MinHeap() : this(4) { }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="capacity">����С��������Դ洢��Ԫ����</param>
        public MinHeap(int capacity)
        {
            count = 0;
            this.capacity = capacity;
            array = new T[capacity];
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="collection">һ�����ϣ���Ԫ�ر����Ƶ�����С����</param>
        public MinHeap(IEnumerable<T> collection)
            :this(4)
        {
            foreach(T item in collection)
            {
                Add(item);
            }
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="comparison">�Ƚ�Ԫ��ʱҪʹ�õ� Comparison</param>
        public MinHeap(Comparison<T> comparison)
            : this(4, comparison)
        {

        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="capacity">����С��������Դ洢��Ԫ����</param>
        /// <param name="comparison">�Ƚ�Ԫ��ʱҪʹ�õ� Comparison</param>
        public MinHeap(int capacity, Comparison<T> comparison)
            :this(capacity)
        {
            this.comparison = comparison;
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="collection">һ�����ϣ���Ԫ�ر����Ƶ�����С����</param>
        /// <param name="comparison">�Ƚ�Ԫ��ʱҪʹ�õ� Comparison</param>        
        public MinHeap(IEnumerable<T> collection, Comparison<T> comparison)
            : this(collection)
        {
            this.comparison = comparison;
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="comparer">�Ƚ�Ԫ��ʱʹ�õ� IComparer ���ͽӿ�ʵ��</param>
        public MinHeap(IComparer<T> comparer)
            : this(4, comparer)
        {
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="capacity">����С��������Դ洢��Ԫ����</param>
        /// <param name="comparer">�Ƚ�Ԫ��ʱʹ�õ� IComparer ���ͽӿ�ʵ��</param>
        public MinHeap(int capacity, IComparer<T> comparer)
            : this(capacity)
        {
            this.comparer = comparer;
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="collection">һ�����ϣ���Ԫ�ر����Ƶ�����С����</param>
        /// <param name="comparer">�Ƚ�Ԫ��ʱʹ�õ� IComparer ���ͽӿ�ʵ��</param>
        public MinHeap(IEnumerable<T> collection, IComparer<T> comparer)
            : this(collection)
        {
            this.comparer = comparer;
        }

        #endregion

        #region Methods

        /// <summary>
        /// ������
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
        /// ����Ԫ��
        /// </summary>
        /// <param name="item">�����ӵ�Ԫ��</param>
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
        /// ʹ�����Ԫ�ص�����������
        /// </summary>
        private void DoubleArray()
        {
            capacity <<= 1;
            T[] newArray = new T[capacity];
            CopyArray(array, newArray);
            array = newArray;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="source">�����Ƶ�����</param>
        /// <param name="destion">����ȥ������</param>
        private static void CopyArray(T[] source, T[] destion)
        {
            int index;
            for (index = 0; index < source.Length; index++)
            {
                destion[index] = source[index];
            }
        }

        /// <summary>
        /// ���ص�һ��Ԫ��,����û��ɾ����
        /// </summary>
        /// <returns>���ص�һ��Ԫ��,����û��ɾ����</returns>
        public T Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("��Ϊ�ա�");
            }

            return array[0];
        }

        /// <summary>
        /// ���ص�һ��Ԫ��,��ɾ����
        /// </summary>
        /// <returns>���ص�һ��Ԫ��,��ɾ����</returns>
        public T ExtractFirst()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("��Ϊ�ա�");
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

            throw new InvalidOperationException("δ�ܱȽ������е�����Ԫ�ء�");
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="position">������λ��</param>
        private void MinHeapify(int position)
        {
            do
            {
                //���ӵ�λ��
                int left = ((position << 1) + 1);

                //�Һ��ӵ�λ��
                int right = left + 1;
                int minPosition;

                //������ӵ�λ��С��Ԫ�ظ����������ӽڵ�ȸ��׽ڵ����СԪ�ص�λ��Ϊ����
                if (left < count && Compare(left, position) < 0)
                {
                    minPosition = left;
                }

                //�������Ԫ�ص�λ��Ϊ����
                else
                {
                    minPosition = position;
                }

                //����Һ��ӵ�λ��С��Ԫ�ظ��������Һ��ӽڵ�ȸ��׽ڵ����СԪ�ص�λ��Ϊ�Һ���
                if (right < count && Compare(right, minPosition) < 0)
                {
                    minPosition = right;
                }

                //������Ԫ�ص�λ�ò��Ǹ��׽ڵ㣬�������һ������
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
