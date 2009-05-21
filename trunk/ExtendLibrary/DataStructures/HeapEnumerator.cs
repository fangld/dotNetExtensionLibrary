using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionLibrary.DataStructures
{
    internal class HeapEnumerator<T> : IEnumerator<T>
    {
        #region Fields

        private IEnumerator<T> enumerator;

        private int count;

        private int currentIndex;

        #endregion

        internal HeapEnumerator(IEnumerable<T> enumerable, int count)
        {
            enumerator = enumerable.GetEnumerator();
            this.count = count;
            currentIndex = 0;
        }

        #region IEnumerator<T> 成员

        public T Current
        {
            get
            {
                return enumerator.Current;
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
            currentIndex++;
            return (currentIndex < count);
        }

        public void Reset()
        {
            enumerator.Reset();
            currentIndex = 0;
        }

        #endregion
    }
}
