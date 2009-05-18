using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.Algorithms
{
    public class MixedRadixEnumerator<T> : IEnumerator<T[]>
    {
        #region Fields

        private T[] originalArray;

        private T[] currentArray;

        private int[] currentIndexes;

        private int addIndex;

        private int[] maxIndexes;

        private int count;

        #endregion

        #region Constructors

        public MixedRadixEnumerator(T[] array)
        {
            count = array.Length;
            addIndex = count - 1;
            currentIndexes = new int[count];
            maxIndexes = new int[count];
            currentArray = new T[count];
            originalArray = new T[count];
            Array.Copy(array, originalArray, count);
            Array.Copy(array, currentArray, count);
            for (int i = 0; i < count; i++)
            {
                maxIndexes[i] = count - 1;
            }
            currentIndexes[count - 1] = -1;
        }

        #endregion

        #region IEnumerator<T> 成员

        public T[] Current
        {
            get
            {
                for (int i = 0; i < count; i++)
                {
                    currentArray[i] = originalArray[currentIndexes[i]];
                }
                return currentArray;
            }
        }

        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
        }

        #endregion

        #region IEnumerator 成员

        object System.Collections.IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            addIndex = count - 1;
            while (true)
            {
                if (addIndex != -1 && currentIndexes[addIndex] == maxIndexes[addIndex])
                {
                    currentIndexes[addIndex] = 0;
                    addIndex--;
                }
                else
                {
                    break;
                }
            }

            if (addIndex == -1)
            {
                return false;
            }

            currentIndexes[addIndex]++;
            return true;
        }

        public void Reset()
        {
            currentIndexes[count - 1] = -1;
            Array.Clear(currentIndexes, 0, count);
        }

        #endregion
    }
}
