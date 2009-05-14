using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.DataStructures
{
    internal class GraphBinaryHeap : BinaryHeap<VertexNode>
    {
        #region Fields

        private int[] indexArray;

        #endregion

        #region Constructors

        public GraphBinaryHeap(int capacity)
        {
            indexArray = new int[capacity];
        }

        #endregion

        #region Methods

        public void Add(VertexNode item)
        {
            indexArray[Count] = Count;
            base.Add(item);
        }

        protected override void Exchange(int xIndex, int yIndex)
        {
            indexArray[Collection[xIndex].Index] = yIndex;
            indexArray[Collection[yIndex].Index] = xIndex;
            base.Exchange(xIndex, yIndex);
        }

        public void ModifyVertexNode(int index, double length)
        {
            int collectionIndex = indexArray[index];
            VertexNode vertexNode = Collection[collectionIndex];
            vertexNode.Length = length;
            DecreaseKey(collectionIndex, vertexNode);
        }

        #endregion
    }
}
