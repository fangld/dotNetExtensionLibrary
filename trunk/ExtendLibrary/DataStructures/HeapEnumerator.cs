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

        #region IEnumerator<T> ��Ա

        public T Current
        {
            get
            {
                return enumerator.Current;
            }
        }

        #endregion

        #region IDisposable ��Ա

        public void Dispose()
        {
        }

        #endregion

        #region IEnumerator ��Ա

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
