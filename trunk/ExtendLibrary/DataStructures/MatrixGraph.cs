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

        #region Properties

        /// <summary>
        /// the index of matrix grpah
        /// </summary>
        /// <param name="sourceIndex"></param>
        /// <returns></returns>
        public double[] this[int sourceIndex]
        {
            get { return matrix[sourceIndex]; }
        }

        /// <summary>
        /// return the max distance of this grpah
        /// </summary>
        public double MaxDistance
        {
            get { return maxDistance; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="count">the number of vertexs</param>
        /// <param name="maxDistance">the max distance of this grpah</param>
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

        internal MatrixGraph(double[][] matrix, double maxDistance)
        {
            this.matrix = matrix;
            this.maxDistance = maxDistance;
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
            GraphBinaryHeap heap = new GraphBinaryHeap(count);
            for (int i  = 0; i < count; i++)
            {
                VertexNode vertexNode = new VertexNode(i, maxDistance);
                heap.Add(vertexNode);
            }
            heap.ModifyVertexNode(sourceIndex, 0);
            while (heap.Count != 0)
            {
                VertexNode minNode = heap.ExtractFirst();
                if (minNode.Length == maxDistance)
                {
                    break;
                }
                for (int i = 0; i < count; i++)
                {
                    if (matrix[minNode.Index][i] < maxDistance)
                    {
                        double newLength = minNode.Length + matrix[minNode.Index][i];
                        if (newLength < result[i])
                        {
                            result[i] = newLength;
                            heap.ModifyVertexNode(i, newLength);
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
                Array.Copy(matrix[i], result[i], count);
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
        /// Kruskal algorithm
        /// </summary>
        /// <returns>return the min span tree for this grpah</returns>
        public MatrixGraph Kruskal()
        {
            double[][] result = GetNonEdgeGraph();
            List<EdgeNode> edgeNodes = new List<EdgeNode>(count);

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    double length = matrix[i][j];
                    if (length != maxDistance)
                    {
                        EdgeNode edgeNode = new EdgeNode(i, j, length);
                        edgeNodes.Add(edgeNode);
                    }
                }
            }

            edgeNodes.Sort();

            int addEdgeNumber = 0;
            DisjointSet set = new DisjointSet(count);
            for (int i= 0; i < edgeNodes.Count; i++)
            {
                int sourceIndex = edgeNodes[i].SourceIndex;
                int destinationIndex = edgeNodes[i].DestinationIndex;
                if (!set.IsInSameSet(sourceIndex, destinationIndex))
                {
                    result[sourceIndex][destinationIndex] = edgeNodes[i].Length;
                    set.Union(sourceIndex, destinationIndex);
                    addEdgeNumber++;
                }
                if (addEdgeNumber == count)
                {
                    break;
                }
            }
            if (addEdgeNumber != count)
            {
                throw new InvalidOperationException("The graph isn't connected!");
            }
            return new MatrixGraph(result, maxDistance);
        }

        /// <summary>
        /// Prim algorithm
        /// </summary>
        /// <returns>return the min span tree for this grpah</returns>
        public MatrixGraph Prim()
        {
            double[][] result = GetNonEdgeGraph();
            bool[] isConnected = new bool[count];
            int[] sourceArray = new int[count];
            double[] weight = new double[count];
            isConnected[0] = true;
            for (int i = 1; i < count; i++)
            {
                weight[i] = matrix[0][i];
                sourceArray[i] = 0;
            }
            for (int i = 1; i < count; i++)
            {
                int destinationIndex = 0;
                double minDistance = maxDistance;
                for (int j = 1; j < count; j++)
                {
                    if (!isConnected[j] && weight[j] < minDistance)
                    {
                        destinationIndex = j;
                        minDistance = weight[j];
                    }
                }
                if (destinationIndex == 0)
                {
                    throw new InvalidOperationException("The graph isn't connected!");
                }
                result[sourceArray[destinationIndex]][destinationIndex] = weight[destinationIndex];
                isConnected[destinationIndex] = true;
                for (int j = 1; j < count; j++)
                {
                    if (!isConnected[j] && matrix[destinationIndex][j] < weight[j])
                    {
                        weight[j] = matrix[destinationIndex][j];
                        sourceArray[j] = destinationIndex;
                    }
                }
            }
            return new MatrixGraph(result, maxDistance);
        }

        private double[][] GetNonEdgeGraph()
        {
            double[][] result = new double[count][];
            for (int i = 0; i < count; i++)
            {
                result[i] = new double[count];
                for (int j = 0; j < count; j++)
                {
                    result[i][j] = maxDistance;
                }
                result[i][i] = 0;
            }
            return result;
        }

        /// <summary>
        /// Set unidirectional edge
        /// </summary>
        /// <param name="srcIndex">the source index of vertex</param>
        /// <param name="destIndex">the destination index of vertex</param>
        /// <param name="value">the value of the edge</param>
        public void SetUniEdge(int srcIndex, int destIndex, double value)
        {
            if (value > maxDistance)
            {
                throw new InvalidOperationException("The value can't be greater than the maxDistantce");
            }
            matrix[srcIndex][destIndex] = value;
        }

        /// <summary>
        /// Set bidirectional edge
        /// </summary>
        /// <param name="srcIndex">the source index of vertex</param>
        /// <param name="destIndex">the destination index of vertex</param>
        /// <param name="value">the value of the edge</param>
        public void SetBidEdge(int srcIndex, int destIndex, double value)
        {
            if (value > maxDistance)
            {
                throw new InvalidOperationException("The value can't be greater than the maxDistantce");
            }
            matrix[srcIndex][destIndex] = value;
            matrix[destIndex][srcIndex] = value;
        }

        #endregion
    }
}
