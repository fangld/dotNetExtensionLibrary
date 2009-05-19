using System;
using System.Collections.Generic;
using System.Text;
using ExtendLibrary.Common;

namespace ExtendLibrary.Algorithms
{
    public static class EnumerableGenerator
    {
        public static T[] GetArray<T>(IEnumerable<T> collection)
        {
            int count = 0;
            foreach (T item in collection)
            {
                count++;
            }
            T[] result = new T[count];
            int index = 0;
            foreach (T item in result)
            {
                result[index++] = item;
            }
            return result;
        }

        #region GetMixedRadix

        public static void GetMixedRadix<T>(IEnumerable<T> collection, Action<T[]> action)
        {
            throw new NotImplementedException();
        }

        public static void GetMixedRadix<T>(IEnumerable<T> collection, Action<T[]> action, IComparer<T> comparer)
        {
            throw new NotImplementedException();
        }

        public static void GetMixedRadix<T>(IEnumerable<T> collection, Action<T[]> action, Comparison<T> comparison)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region GetPermutation

        public static void GetPermutation<T>(IEnumerable<T> collection, Action<T[]> action)
        {
            GetPermutation(collection, action, MultiComparison<T>.Compare);
        }

        public static void GetPermutation<T>(IEnumerable<T> collection, Action<T[]> action, IComparer<T> comparer)
        {
            GetPermutation(collection, action, comparer.Compare);            
        }

        public static void GetPermutation<T>(IEnumerable<T> collection, Action<T[]> action, Comparison<T> comparison)
        {
            T[] array = GetArray(collection);
            Array.Sort(array);
            while (true)
            {
                action(array);
                int count = array.Length;
                int j = count - 2;
                while (true)
                {
                    if (j == -1)
                        return;
                    if (comparison(array[j], array[j + 1]) >= 0)
                    {
                        j--;
                    }
                    else
                        break;
                }

                int l = count - 1;
                while (comparison(array[j], array[l]) >= 0)
                {
                    l--;
                }
                T exchange = array[j];
                array[j] = array[l];
                array[l] = exchange;

                int k = j + 1;
                l = count - 1;
                while (k < l)
                {
                    exchange = array[k];
                    array[k] = array[l];
                    array[l] = exchange;
                    k++;
                    l--;
                }
            }
        }

        #endregion

        #region GetCombination

        public static void GetCombination<T>(IEnumerable<T> collection, Action<T[]> action)
        {
            throw new NotImplementedException();
        }

        public static void GetCombination<T>(IEnumerable<T> collection, Action<T[]> action, IComparer<T> comparer)
        {
            throw new NotImplementedException();
        }

        public static void GetCombination<T>(IEnumerable<T> collection, Action<T[]> action, Comparison<T> comparison)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}