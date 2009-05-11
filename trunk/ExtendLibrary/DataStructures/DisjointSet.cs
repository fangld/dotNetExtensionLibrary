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
            return GetFather(xIndex) == GetFather(yIndex);
        }

        public int GetFather(int index)
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

        public void Union(int xIndex, int yIndex)
        {
            int xFather = GetFather(xIndex);
            int yFather = GetFather(yIndex);
            if (xFather != yFather)
            {
                if (rank[xFather] > rank[yFather])
                {
                    father[yFather] = xFather;

                }
                else
                {
                    father[xFather] = yFather;
                    if (rank[xFather] == rank[yFather])
                    {
                        rank[yFather]++;
                    }
                }
            }
        }

        #endregion
    }
}