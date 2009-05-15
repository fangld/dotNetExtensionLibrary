using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.DataStructures
{
    public class VertexNode : IComparable<VertexNode>
    {
        #region Fields

        /// <summary>
        /// the index of vertex
        /// </summary>
        private int index;
        
        /// <summary>
        /// the length of vertex to source vertex
        /// </summary>
        private double length;

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
        public double Length
        {
            get { return length; }
            set { length = value; }
        }

        #endregion

        #region Constructor

        public VertexNode(int index, double length)
        {
            this.index = index;
            this.length = length;
        }

        #endregion

        #region IComparable<VertexNode> ≥…‘±

        public int CompareTo(VertexNode other)
        {
            return length.CompareTo(other.length);
        }

        #endregion
    }
}
