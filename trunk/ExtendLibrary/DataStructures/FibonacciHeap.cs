#if FibonacciHeap
using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.DataStructures
{
    public class FibonacciHeap<T> : IHeap<T>
    {
        #region IHeap<T> ≥…‘±

        public void BuildHeap()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Add(T item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Add(IEnumerable<T> collection)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public T Peek()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public IList<T> ExtractList(int number)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public T ExtractFirst()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
#endif