using System;
using System.Collections.Generic;
using System.Text;
using ExtendLibrary.Common;

namespace ExtendLibrary.Algorithms
{
    public static class Selection<T>
    {
        private static int Patition(T[] array, int left, int right, int pivotIndex, Comparison<T> comparison)
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

        private static T NthSelect(T[] array, Comparison<T> comparison, int left, int right, int n)
        {
            do
            {
                int pivotIndex = (left + right) >> 1;
                int pivotNewIndex = Patition(array, left, right, pivotIndex, comparison);
                if (n == pivotNewIndex)
                    return array[n];
                if (n < pivotNewIndex)
                    right = pivotNewIndex - 1;
                else
                    left = pivotNewIndex + 1;
            } while (true);
        }


        public static T NthSelect(T[] array, int n, Comparison<T> comparison)
        {
            return NthSelect(array, comparison, 0, n - 1, n);
        }

        public static T NthSelect(T[] array, int n, IComparer<T> comparer)
        {
            return NthSelect(array, n, comparer.Compare);
        }

        public static T NthSelect(T[] array, int n)
        {
            return NthSelect(array, n, MultiComparison<T>.Compare);
        }

        public static T NthSelect(T[] array, int offset, int length, int n, Comparison<T> comparison)
        {
            return NthSelect(array, comparison, offset, offset + length - 1, n);
        }

        public static T NthSelect(T[] array, int offset, int length, int n, IComparer<T> comparer)
        {
            return NthSelect(array, comparer.Compare, offset, offset + length - 1, n);
        }

        public static T NthSelect(T[] array, int offset, int length, int n)
        {
            return NthSelect(array, MultiComparison<T>.Compare, offset, offset + length - 1, n);
        }

    }
}