using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.DataStructures
{
    internal class EdgeNode
    {
        #region Fields

        /// <summary>
        /// the source index of edge
        /// </summary>
        private int sourceIndex;

        /// <summary>
        /// the destination index of edge;
        /// </summary>
        private int destinationIndex;
        
        /// <summary>
        /// the length of vertex to source vertex
        /// </summary>
        private double length;

        #endregion

        #region Properties

        /// <summary>
        /// Get and set the source index of vertex
        /// </summary>
        public int SourceIndex
        {
            get { return sourceIndex; }
            set { sourceIndex = value; }
        }

        /// <summary>
        /// Get and set the destination index of vertex
        /// </summary>
        public int DestinationIndex
        {
            get { return destinationIndex; }
            set { destinationIndex = value; }
        }

        /// <summary>
        /// Get and set the length of vertex to source vertex
        /// </summary>
        public double Length
        {
            get { return length; }
            set { length = value; }
        }

        #endregion

        #region Constructor

        public EdgeNode(int sourceIndex, int destinationIndex, double length)
        {
            this.sourceIndex = sourceIndex;
            this.destinationIndex = destinationIndex;
            this.length = length;
        }

        #endregion

        #region IComparable<VertexNode> ≥…‘±

        public int CompareTo(EdgeNode other)
        {
            return length.CompareTo(other.length);
        }

        #endregion
    }
}
