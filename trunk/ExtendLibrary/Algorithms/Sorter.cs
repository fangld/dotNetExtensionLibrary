using System;
using System.Collections.Generic;
using System.Text;
using ExtendLibrary.Common;

namespace ExtendLibrary.Algorithms
{
    public static class Sortor<T>
    {
        #region Sort first kth item

        private static void SortFirstKth(T[] array, Comparison<T> comparison, int left, int right, int k)
        {
            if (array.Length <= 20)
            {
                BubbleSortKth(array, comparison, left, right, k);
            }
            else
            {
                QuickSortFirstKth(array, comparison, left, right, k);
            }
        }

        private static void BubbleSortKth(T[] array, Comparison<T> comparison, int left, int right, int k)
        {
            for (int i = 0; i < k; i++)
            {
                for (int j = left; j <= right - i; j++)
                {
                    if (comparison(array[j], array[j + 1]) > 0)
                    {
                        T exchange = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = exchange;
                    }
                }
            }
        }

        private static void QuickSortFirstKth(T[] array, Comparison<T> comparison, int left, int right, int k)
        {
            if (right > left)
            {
                int pivotIndex = (left + right) >> 1;
                int pivotNewIndex = Selection<T>.Patition(array, left, right, pivotIndex, comparison);
                QuickSortFirstKth(array, comparison, left, pivotNewIndex - 1, k);
                if (pivotNewIndex < k)
                    QuickSortFirstKth(array, comparison, pivotNewIndex + 1, right, k);
            }
        }

        public static void SortFirstKth(T[] array, int k)
        {
            SortFirstKth(array, 0, array.Length, k);
        }

        public static void SortFirstKth(T[] array, int k, IComparer<T> comparer)
        {
            SortFirstKth(array, 0, array.Length, k, comparer);
        }

        public static void SortFirstKth(T[] array, int k, Comparison<T> comparison)
        {
            SortFirstKth(array, 0, array.Length, k, comparison);
        }

        public static void SortFirstKth(T[] array, int index, int length, int k)
        {
            SortFirstKth(array, index, index + length - 1, k, NativeComparer<T>.Compare);
        }

        public static void SortFirstKth(T[] array, int index, int length, int k, IComparer<T> comparer)
        {
            SortFirstKth(array, index, index + length - 1, k, comparer.Compare);
        }

        public static void SortFirstKth(T[] array, int index, int length, int k, Comparison<T> comparison)
        {
            SortFirstKth(array, comparison, index, index + length - 1, k);
        }

        #endregion
    }
}
