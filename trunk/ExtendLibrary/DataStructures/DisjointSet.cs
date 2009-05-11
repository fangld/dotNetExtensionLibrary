using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.DataStructures
{
    /// <summary>
    /// Disjoint set
    /// </summary>
    public class DisjointSet
    {
        #region Fields

        /// <summary>
        /// father pointer array
        /// </summary>
        private readonly int[] father;

        /// <summary>
        /// rank array
        /// </summary>
        private readonly int[] rank;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="count">the number of items</param>
        public DisjointSet(int count)
        {
            father = new int[count];
            rank = new int[count];
            for (int i = 0; i < father.Length; i++)
            {
                father[i] = i;
                rank[i] = 0;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determine there is in the same set
        /// </summary>
        /// <param name="xIndex">the first index of item</param>
        /// <param name="yIndex">the second index </param>
        /// <returns></returns>
        public bool IsSame(int xIndex, int yIndex)
        {
            return FindSet(xIndex) == FindSet(yIndex);
        }

        /// <summary>
        /// Find set with path compress 
        /// </summary>
        /// <param name="index">the index of item</param>
        /// <returns>return which set contains the item</returns>
        public int FindSet(int index)
        {
            int fatherIndex = index;
            while (father[fatherIndex] != fatherIndex)
            {
                fatherIndex = father[fatherIndex];
            }
            while (index != fatherIndex)
            {
                int exchange = father[index];
                father[index] = fatherIndex;
                index = exchange;
            }
            return index;
        }

        /// <summary>
        /// Union two set that contains xIndex and yIndex sperately
        /// </summary>
        /// <param name="xIndex">the index of first item</param>
        /// <param name="yIndex">the index of second item</param>
        public void Union(int xIndex, int yIndex)
        {
            int xFather = FindSet(xIndex);
            int yFather = FindSet(yIndex);
            if (xFather != yFather)
            {
                if (rank[xFather] >= rank[yFather])
                {
                    father[yFather] = xFather;
                    if (rank[xFather] == rank[yFather])
                    {
                        rank[xFather]++;
                    }
                }
                else
                {
                    father[xFather] = yFather;
                }
            }
        }

        #endregion
    }
}