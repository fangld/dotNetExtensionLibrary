using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
