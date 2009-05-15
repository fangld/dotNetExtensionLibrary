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
            for (int i = 0; i < capacity; i++)
            {
                indexArray[i] = i;
            }
        }

        #endregion

        #region Methods

        protected override void Exchange(int xIndex, int yIndex)
        {
            indexArray[ItemArray[xIndex].Index] = yIndex;
            indexArray[ItemArray[yIndex].Index] = xIndex;
            base.Exchange(xIndex, yIndex);
        }

        public void ModifyVertexNode(int index, double length)
        {
            int collectionIndex = indexArray[index];
            VertexNode vertexNode = ItemArray[collectionIndex];
            vertexNode.Length = length;
            DecreaseKey(collectionIndex, vertexNode);
        }

        #endregion
    }
}
