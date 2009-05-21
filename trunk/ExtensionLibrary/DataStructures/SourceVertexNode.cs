using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionLibrary.DataStructures
{
    public class SourceVertexNode
    {
       #region Fields

        /// <summary>
        /// the index of vertex
        /// </summary>
        private int index;

        /// <summary>
        /// the length of vertex to source vertex
        /// </summary>
        private AdjEdgeNode firstEdge;

        #endregion

        #region Properties

        /// <summary>
        /// Get and set the index of vertex
        /// </summary>
        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        /// <summary>
        /// Get and set the length of vertex to source vertex
        /// </summary>
        public AdjEdgeNode FirstEdge
        {
            get { return firstEdge; }
            set { firstEdge = value; }
        }

        #endregion

        #region Constructor

        public SourceVertexNode(int index, AdjEdgeNode firstEdge)
        {
            this.index = index;
            this.firstEdge = firstEdge;
        }

        public SourceVertexNode(int index)
            : this(index, null)
        {
        }

        #endregion

        #region Methods

        public void AddEdge(int destIndex, double value)
        {
            AdjEdgeNode newEdgeNode = new AdjEdgeNode(destIndex, value);
            if (firstEdge == null)
            {
                firstEdge = newEdgeNode;
            }
            else
            {
                AdjEdgeNode edgeNode = firstEdge;
                while (edgeNode.Next != null)
                {
                    edgeNode = edgeNode.Next;
                }
                edgeNode.Next = newEdgeNode;
            }
        }

        #endregion
    }
}
