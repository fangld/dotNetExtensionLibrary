using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ExtensionLibrary.Common;

namespace ExtensionLibrary.Algorithms
{
    public static class EnumerableScanner
    {
        #region ScanMixedRadix

        public static void ScanMixedRadix<T>(IEnumerable<T> collection, Action<T[]> action)
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
                action(scanArray);
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
                    return;
                index[j]++;
            } while (true);

        }

        #endregion

        #region ScanPermutation

        public static void ScanPermutation<T>(IEnumerable<T> collection, Action<T[]> action)
        {
            ScanPermutation(collection, action, NativeComparer<T>.Compare);
        }

        public static void ScanPermutation<T>(IEnumerable<T> collection, Action<T[]> action, IComparer<T> comparer)
        {
            ScanPermutation(collection, action, comparer.Compare);            
        }

        public static void ScanPermutation<T>(IEnumerable<T> collection, Action<T[]> action, Comparison<T> comparison)
        {
            T[] array = collection.ToArray();
            Array.Sort(array, comparison);
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

        #region ScanCombination

        public static void ScanCombination<T>(IEnumerable<T> collection, int combinationNumber, Action<T[]> action)
        {
            ScanCombination(collection, combinationNumber, action, NativeComparer<T>.Compare);
        }

        public static void ScanCombination<T>(IEnumerable<T> collection, int combinationNumber, Action<T[]> action, IComparer<T> comparer)
        {
            ScanCombination(collection, combinationNumber, action, comparer.Compare);
        }

        public static void ScanCombination<T>(IEnumerable<T> collection, int t, Action<T[]> action, Comparison<T> comparison)
        {
            T[] originalArray = collection.ToArray();
            T[] scanArray = new T[t];
            if (originalArray.Length < t)
            {
                throw new InvalidOperationException("The number of items that collection contains is no more than t!");
            }

            int[] c = new int[t + 3];
            for (int i = 1; i <= t; i++)
            {
                c[i] = i - 1;
            }
            c[t + 1] = originalArray.Length;
            c[t + 2] = 0;
            do
            {
                for (int i = 1; i <= t; i++)
                {
                    if (c[i] < 0)
                    {
                        Console.WriteLine("i:{0} value:{1}", i, c[i]);
                    }
                    scanArray[i - 1] = originalArray[c[i]];
                }
                action(scanArray);
                int j = 1;
                while (c[j] + 1 == c[j + 1])
                {
                    c[j] = j - 1;
                    j++;
                }

                if (j > t)
                    break;
                c[j]++;

            } while (true);
        }

        public static void GetCombination2<T>(IEnumerable<T> collection, int t, Action<T[]> action, Comparison<T> comparison)
        {
            T[] originalArray = collection.ToArray();
            T[] scanArray = new T[t];
            if (originalArray.Length < t)
            {
                throw new InvalidOperationException("The number of items that collection contains is no more than t!");
            }

            int[] c = new int[t + 3];
            for (int i = 1; i <= t; i++)
            {
                c[i] = i - 1;
            }
            c[t + 1] = originalArray.Length;
            c[t + 2] = 0;
            int j = t;
            do
            {
                for (int i = 1; i <= t; i++)
                {
                    if (c[i] < 0)
                    {
                        Console.WriteLine("i:{0} value:{1}", i, c[i]);
                    }
                    scanArray[i - 1] = originalArray[c[i]];
                }
                action(scanArray);
                int x;

                if (j > 0)
                {
                    x = j;
                    c[j] = x;
                    j--;
                    continue;
                }

                if (c[1] + 1 < c[2])
                {
                    c[1]++;
                    continue;
                }

                j = 2;
                c[j - 1] = j - 2;
                x = c[j] + 1;
                while (x == c[j + 1])
                {
                    j++;
                }

                if (j > t)
                {
                    return;
                }

                c[j] = x;
                j--;

            } while (true);
        }


        #endregion
    }
}