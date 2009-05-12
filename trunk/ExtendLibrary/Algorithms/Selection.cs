using System;
using System.Collections.Generic;
using System.Text;
using ExtendLibrary.Common;

namespace ExtendLibrary.Algorithms
{
    public static class Selection<T>
    {
        private static int Patition(T[] array, int left, int right, int pivotIndex, MultiComparer<T> comparer)
        {
            T pivotValue = array[pivotIndex];
            T exchange = array[pivotIndex];
            array[pivotIndex] = array[right];
            array[right] = exchange;
            int storeIndex = left;
            for (int i = left; i < right; i++)
            {
                if (comparer.Compare(array[i], pivotValue) < 0)
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

        public static T NthSelect(T[] array, int n, Comparison<T> comparison)
        {
            MultiComparer<T> multiComparer = new MultiComparer<T>(comparison);
            return NthSelect(array, n, multiComparer);
        }

        public static T NthSelect(T[] array, int n, IComparer<T> comparer)
        {
            MultiComparer<T> multiComparer = new MultiComparer<T>(comparer);
            return NthSelect(array, n, multiComparer);
        }

        public static T NthSelect(T[] array, int n, MultiComparer<T> comparer)
        {
            return NthSelect(array, comparer, 0, array.Length - 1, n);
        }

        public static T NthSelect(T[] array, int n)
        {
            MultiComparer<T> multiComparer = new MultiComparer<T>();
            return NthSelect(array, n, multiComparer);
        }

        public static T NthSelect(T[] array, int offset, int length, int n, Comparison<T> comparison)
        {
            MultiComparer<T> multiComparer = new MultiComparer<T>(comparison);
            return NthSelect(array, multiComparer, offset, offset + length - 1, n);
        }

        public static T NthSelect(T[] array, int offset, int length, int n, IComparer<T> comparer)
        {
            MultiComparer<T> multiComparer = new MultiComparer<T>(comparer);
            return NthSelect(array, multiComparer, offset, offset + length - 1, n);
        }

        public static T NthSelect(T[] array, int offset, int length, int n, MultiComparer<T> comparer)
        {
            return NthSelect(array, comparer, offset, offset + length - 1, n);
        }

        public static T NthSelect(T[] array, int offset, int length, int n)
        {
            MultiComparer<T> multiComparer = new MultiComparer<T>();
            return NthSelect(array, multiComparer, offset, offset + length - 1, n);
        }

        private static T NthSelect(T[] array, MultiComparer<T> comparer, int left, int right, int n)
        {
            do
            {
                int pivotIndex = (left + right) >> 1;
                int pivotNewIndex = Patition(array, left, right, pivotIndex, comparer);
                if (n == pivotNewIndex)
                    return array[n];
                if (n < pivotNewIndex)
                    right = pivotNewIndex - 1;
                else
                    left = pivotNewIndex + 1;
            } while (true);
        }
    }
}