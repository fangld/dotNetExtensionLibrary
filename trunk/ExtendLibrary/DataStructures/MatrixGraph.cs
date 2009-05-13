using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.DataStructures
{
    /// <summary>
    /// Matrix graph data structure
    /// </summary>
    public class MatrixGraph
    {
        #region Fields

        private int count;

        private double maxDistance;

        private double[][] matrix;

        #endregion

        #region Constructor

        public MatrixGraph(int count, double maxDistance)
        {
            this.count = count;
            this.maxDistance = maxDistance;
            matrix = new double[count][];
            for (int i = 0; i < count; i++)
            {
                matrix[i] = new double[count];
                for (int j = 0; j < count; j++)
                {
                    matrix[i][j] = maxDistance;
                }
                matrix[i][i] = 0;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Dijkstra algorithm
        /// </summary>
        /// <param name="sourceIndex">the source index of vertex</param>
        /// <returns>return the array that contains the minimal length from the source to all vertex</returns>
        public double[] Dijkstra(int sourceIndex)
        {
            double[] result = new double[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = maxDistance;
            }
            result[sourceIndex] = 0;
            BinaryHeap<VertexNode> heap = new BinaryHeap<VertexNode>();
            VertexNode sourceNode = new VertexNode(sourceIndex, 0);
            heap.Add(sourceNode);
            while (heap.Count != 0)
            {
                VertexNode minNode = heap.ExtractFirst();
                for (int i = 0; i < count; i++)
                {
                    if (matrix[minNode.Index][i] < maxDistance)
                    {
                        double newLength = minNode.Length + matrix[minNode.Index][i];
                        if (newLength < result[i])
                        {
                            result[i] = newLength;
                            VertexNode addNode = new VertexNode(i, newLength);
                            heap.Add(addNode);
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Floyd algorithm
        /// </summary>
        /// <returns>return the matrix that contains the minimal length of all pair vertex</returns>
        public double[][] Floyd()
        {
            double[][] result = new double[count][];
            for (int i = 0; i < count; i++)
            {
                result[i] = new double[count];
                Buffer.BlockCopy(matrix[i], 0, result[i], 0, count);
            }

            for (int midIndex = 0; midIndex < count; midIndex++)
            {
                for (int srcIndex = 0; srcIndex < count; srcIndex++)
                {
                    for (int destIndex = 0; destIndex < count; destIndex++)
                    {
                        double newLength = result[srcIndex][midIndex] + result[midIndex][destIndex];
                        if (newLength < result[srcIndex][destIndex])
                        {
                            result[srcIndex][destIndex] = newLength;
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Set unidirectional edge
        /// </summary>
        /// <param name="source">the source index of vertex</param>
        /// <param name="destination">the destination index of vertex</param>
        /// <param name="value">the value of the edge</param>
        public void SetUniEdge(int source, int destination, double value)
        {
            if (value > maxDistance)
            {
                throw new InvalidOperationException("The value can't be greater than the maxDistantce");
            }
            matrix[source][destination] = value;
        }

        /// <summary>
        /// Set bidirectional edge
        /// </summary>
        /// <param name="source">the source index of vertex</param>
        /// <param name="destination">the destination index of vertex</param>
        /// <param name="value">the value of the edge</param>
        public void SetBidEdge(int source, int destination, double value)
        {
            if (value > maxDistance)
            {
                throw new InvalidOperationException("The value can't be greater than the maxDistantce");
            }
            matrix[source][destination] = value;
            matrix[destination][source] = value;
        }

        #endregion
    }
}
