using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionLibrary.DataStructures
{
    public class AdjEdgeNode
    {
        #region Fields

        private int index;

        private double length;

        private AdjEdgeNode next;

        #endregion

        #region Properties

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public double Length
        {
            get { return length; }
            set { length = value; }
        }

        public AdjEdgeNode Next
        {
            get { return next; }
            set { next = value; }
        }

        #endregion

        #region Constructors

        public AdjEdgeNode(int index, double length, AdjEdgeNode next)
        {
            this.index = index;
            this.length = length;
            this.next = next;
        }

        public AdjEdgeNode(int index, double length)
            : this(index, length, null)
        {
        }

        #endregion
    }
}
