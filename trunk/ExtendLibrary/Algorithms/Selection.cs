using System;
using System.Collections.Generic;
using System.Text;
using ExtendLibrary.Common;

namespace ExtendLibrary.Algorithms
{
    public static class Selection<T>
    {
        internal static int Patition(T[] array, int left, int right, int pivotIndex, Comparison<T> comparison)
        {
            T pivotValue = array[pivotIndex];
            T exchange = array[pivotIndex];
            array[pivotIndex] = array[right];
            array[right] = exchange;
            int storeIndex = left;
            for (int i = left; i < right; i++)
            {
                if (comparison(array[i], pivotValue) < 0)
                {
                    exchange = array[i];
                    array[i] = array[storeIndex];
                    array[storeIndex] = exchange;
                    storeIndex++;
                }
            }
            exchange = array[storeIndex];
            array[storeIndex] = array[right];
            array[right] = exchange;
            return storeIndex;
        }

        #region Select Kth item

        private static T SelectKth(T[] array, Comparison<T> comparison, int left, int right, int k)
        {
            do
            {
                int pivotIndex = (left + right) >> 1;
                int pivotNewIndex = Patition(array, left, right, pivotIndex, comparison);
                if (k == pivotNewIndex)
                    return array[k];
                if (k < pivotNewIndex)
                    right = pivotNewIndex - 1;
                else
                    left = pivotNewIndex + 1;
            } while (true);
        }

        public static T SelectKth(T[] array, int k, Comparison<T> comparison)
        {
            return SelectKth(array, comparison, 0, k - 1, k);
        }

        public static T SelectKth(T[] array, int k, IComparer<T> comparer)
        {
            return SelectKth(array, k, comparer.Compare);
        }

        public static T SelectKth(T[] array, int k)
        {
            return SelectKth(array, k, NativeComparer<T>.Compare);
        }

        public static T SelectKth(T[] array, int index, int length, int k, Comparison<T> comparison)
        {
            return SelectKth(array, comparison, index, index + length - 1, k);
        }

        public static T SelectKth(T[] array, int index, int length, int k, IComparer<T> comparer)
        {
            return SelectKth(array, comparer.Compare, index, index + length - 1, k);
        }

        public static T SelectKth(T[] array, int index, int length, int k)
        {
            return SelectKth(array, NativeComparer<T>.Compare, index, index + length - 1, k);
        }

        #endregion

        #region Get first kth item

        private static void GetFirstKth(T[]array, Comparison<T> comparison, int left, int right, int k)
        {
            if (right > left)
            {
                int pivotIndex = (left + right) >> 1;
                int pivotNewIndex = Patition(array, left, right, pivotIndex, comparison);
                if (pivotNewIndex > k)
                    GetFirstKth(array, comparison, left, pivotNewIndex - 1, k);
                else if (pivotNewIndex < k)
                    GetFirstKth(array, comparison, pivotNewIndex + 1, right, k);
            }
        }

        public static T[] GetFirstKth(T[] array, int k)
        {
            return GetFirstKth(array, 0, array.Length, k);
        }

        public static T[] GetFirstKth(T[] array, int k, IComparer<T> comparer)
        {
            return GetFirstKth(array, 0, array.Length, k, comparer);
        }

        public static T[] GetFirstKth(T[] array, int k, Comparison<T> comparison)
        {
            return GetFirstKth(array, 0, array.Length, k, comparison);
        }

        public static T[] GetFirstKth(T[] array, int index, int length, int k)
        {
            return GetFirstKth(array, index, length, k, NativeComparer<T>.Compare);
        }

        public static T[] GetFirstKth(T[] array, int index, int length, int k, IComparer<T> comparer)
        {
            return GetFirstKth(array, index, length, k, comparer.Compare);
        }

        public static T[] GetFirstKth(T[] array, int index, int length, int k, Comparison<T> comparison)
        {
            T[] result = new T[length - index];
            Array.Copy(array, index, result, 0, length);
            GetFirstKth(result, comparison, 0, length - 1, k);
            return result;
        }

        #endregion
    }
}