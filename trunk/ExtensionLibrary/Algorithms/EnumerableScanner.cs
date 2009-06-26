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
            T[] array = collection.ToArray();
            int length = array.Length;
            int[] c = new int[length];
            int[] o = new int[length];
            for (int i = 0; i < length; i++)
            {
                o[i] = 1;
            }

            do
            {
                action(array);
                int j = length - 1;
                int s = 0;
                int q;
                do
                {
                    q = c[j] + o[j];
                    if (q < 0)
                    {
                        o[j] = -o[j];
                        j--;
                        continue;
                    }
                    if (q == j + 1)
                    {
                        if (j == 0)
                        {
                            return;
                        }
                        s++;
                        o[j] = -o[j];
                        j--;
                        continue;
                    }
                    break;
                } while (true);

                int exchangIndex1 = j - c[j] + s;
                int exchangIndex2 = j - q + s;
                T exchange = array[exchangIndex1];
                array[exchangIndex1] = array[exchangIndex2];
                array[exchangIndex2] = exchange;
                c[j] = q;
            } while (true);
        }

        #endregion

        #region ScanCombination

        public static void ScanCombination<T>(IEnumerable<T> collection, int combinationNumber, Action<T[]> action)
        {
            T[] originalArray = collection.ToArray();
            T[] scanArray = new T[combinationNumber];
            if (originalArray.Length < combinationNumber)
            {
                throw new InvalidOperationException("The number of items that collection contains is no more than combinationNumber!");
            }

            if (originalArray.Length == combinationNumber)
            {
                action(originalArray);
                return;
            }

            int[] c = new int[combinationNumber + 2];
            for (int i = 0; i < combinationNumber; i++)
            {
                c[i] = i;
            }
            c[combinationNumber] = originalArray.Length;
            c[combinationNumber + 1] = 0;
            int j = combinationNumber - 1;
            do
            {
                for (int i = 0; i < combinationNumber; i++)
                {
                    scanArray[i] = originalArray[c[i]];
                }
                action(scanArray);
                int x;

                if (j >= 0)
                {
                    x = j;
                    c[j] = x + 1;
                    j--;
                    continue;
                }

                if (c[0] + 1 < c[1])
                {
                    c[0]++;
                    continue;
                }

                j = 1;
                do
                {
                    c[j - 1] = j - 1;
                    x = c[j] + 1;
                    if (x == c[j + 1])
                    {
                        j++;
                    }
                    else break;
                } while (true);

                if (j >= combinationNumber)
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