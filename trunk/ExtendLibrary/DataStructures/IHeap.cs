using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.DataStructures
{
    public interface IHeap<T>
    {
        /// <summary>
        /// build the heap
        /// </summary>
        void BuildHeap();

        /// <summary>
        /// Add item
        /// </summary>
        /// <param name="item">a item that is ready to add</param>
        void Add(T item);

        /// <summary>
        /// Add items
        /// </summary>
        /// <param name="collection">a colletion that contaions items</param>
        void Add(IEnumerable<T> collection);

        /// <summary>
        /// Return the first item
        /// </summary>
        /// <returns>Return the first item</returns>
        T Peek();

        /// <summary>
        /// Extract the top n items
        /// </summary>
        /// <param name="number">the number of items that is extracted</param>
        /// <returns>return a list that contains the top n items</returns>
        IList<T> ExtractList(int number);

        /// <summary>
        /// Extract the first item
        /// </summary>
        /// <returns>Return the first iem</returns>
        T ExtractFirst();
    }
}
