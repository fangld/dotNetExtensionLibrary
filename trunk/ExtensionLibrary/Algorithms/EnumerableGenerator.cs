using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtensionLibrary.Common;

namespace ExtensionLibrary.Algorithms
{
    public static class EnumerableGenerator
    {
        #region GenerateMixedRadix

        public static IEnumerable<T[]> GetMixedRadixEnumerator<T>(IEnumerable<T> collection)
        {
            T[] originalArray = collection.ToArray();

            int count = originalArray.Length;
            T[] scanArray = new T[count];
            int[] index = new int[count];
            int[] maxIndex = new int[count];
            for (int i = 0; i < count; i++)
            {
                maxIndex[i] = count;
            }

            do
            {
                for (int i = 0; i < count; i++)
                {
                    scanArray[i] = originalArray[index[i]];
                }
                yield return scanArray;
                int j = count - 1;
                while (j != -1)
                {
                    if (index[j] == maxIndex[j] - 1)
                    {
                        index[j] = 0;
                        j--;
                        continue;
                    }
                    break;
                }
                if (j == -1)
                    yield break;
                index[j]++;
            } while (true);
        }
      
        #endregion

        #region GeneratePermutation

        public static IEnumerable<T[]> GetPermutationEnumerator<T>(IEnumerable<T> collection, IComparer<T> comparer)
        {
            return GetPermutationEnumerator(collection, comparer.Compare);
        }

        public static IEnumerable<T[]> GetPermutationEnumerator<T>(IEnumerable<T> collection)
        {
            return GetPermutationEnumerator(collection, NativeComparer<T>.Compare);
        }

        public static IEnumerable<T[]> GetPermutationEnumerator<T>(IEnumerable<T> collection, Comparison<T> comparison)
        {
            T[] array = collection.ToArray();
            Array.Sort(array, comparison);
            while (true)
            {
                yield return array;
                int count = array.Length;
                int j = count - 2;
                while (true)
                {
                    if (j == -1)
                        yield break;
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
    }
}
