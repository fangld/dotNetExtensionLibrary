using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.DataStructures
{
    internal class HeapEnumerator<T> : IEnumerator<T>
    {
        #region Fields

        private IEnumerator<T> enumerator;

        #endregion

        internal HeapEnumerator(IEnumerable<T> enumerable)
        {
            enumerator = enumerable.GetEnumerator();
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
            return enumerator.MoveNext();
        }

        public void Reset()
        {
            enumerator.Reset();
        }

        #endregion
    }
}
