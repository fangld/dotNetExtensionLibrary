using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.DataStructures
{
    internal class GraphPriorityQueue
    {
        #region Fields

        private int[] indexArray;

        private Heap<VertexNode> heap;

        #endregion

        #region Properties

        public int Count
        {
            get { return heap.Count; }
        }

        #endregion

        #region Constructors

        public GraphPriorityQueue(int capacity, Heap<VertexNode> heap)
        {
            indexArray = new int[capacity];
            for (int i = 0; i < capacity; i++)
            {
                indexArray[i] = i;
            }

            this.heap = heap;
            this.heap.ExchangeCallBack = Exchange;
        }

        #endregion

        #region Methods

        private void Exchange(int xIndex, int yIndex)
        {
            indexArray[heap.GetIndex(xIndex).Index] = yIndex;
            indexArray[heap.GetIndex(yIndex).Index] = xIndex;
        }

        public void BuildHeap(IEnumerable<VertexNode> enumerable)
        {
            heap.BuildHeap(enumerable);
        }

        public VertexNode ExtractMin()
        {
            return heap.ExtractMin();
        }

        public void ModifyVertexNode(int index, double length)
        {
            int collectionIndex = indexArray[index];
            VertexNode vertexNode = heap.GetIndex(collectionIndex);
            vertexNode.Length = length;
            heap.DecreaseKey(collectionIndex, vertexNode);
        }

        #endregion
    }
}
