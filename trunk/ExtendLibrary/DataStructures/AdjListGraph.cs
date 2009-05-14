using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.DataStructures
{
    public class AdjListGraph
    {
        #region Fields

        private SourceVertexNode[] nodes;

        private int count;

        private double maxDistance;

        #endregion

        #region Properties

        #endregion

        #region Constructors

        public AdjListGraph(int count, double maxDistance)
        {
            nodes = new SourceVertexNode[count];
            for (int i = 0; i < count; i++)
            {
                nodes[i] = new SourceVertexNode(i);
            }
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
            BinaryHeap<VertexNode> heap = new BinaryHeap<VertexNode>();
            VertexNode sourceNode = new VertexNode(sourceIndex, 0);
            heap.Add(sourceNode);
            while (heap.Count != 0)
            {
                VertexNode minNode = heap.ExtractFirst();
                if (minNode.Length > result[minNode.Index])
                {
                    continue;
                }

                AdjEdgeNode edgeNode = nodes[minNode.Index].FirstEdge;
                while (edgeNode != null)
                {
                    if (edgeNode.Length < maxDistance)
                    {
                        double newLength = minNode.Length + edgeNode.Length;
                        if (newLength < result[edgeNode.Index])
                        {
                            result[edgeNode.Index] = newLength;
                            VertexNode addNode = new VertexNode(edgeNode.Index, newLength);
                            heap.Add(addNode);
                        }
                    }
                }
            }
            return result;
        }

        ///// <summary>
        ///// Floyd algorithm
        ///// </summary>
        ///// <returns>return the matrix that contains the minimal length of all pair vertex</returns>
        //public double[][] Floyd()
        //{
        //    double[][] result = new double[count][];
        //    for (int i = 0; i < count; i++)
        //    {
        //        result[i] = new double[count];
        //        Array.Copy(matrix[i], result[i], count);
        //    }

        //    for (int midIndex = 0; midIndex < count; midIndex++)
        //    {
        //        for (int srcIndex = 0; srcIndex < count; srcIndex++)
        //        {
        //            for (int destIndex = 0; destIndex < count; destIndex++)
        //            {
        //                double newLength = result[srcIndex][midIndex] + result[midIndex][destIndex];
        //                if (newLength < result[srcIndex][destIndex])
        //                {
        //                    result[srcIndex][destIndex] = newLength;
        //                }
        //            }
        //        }
        //    }

        //    return result;
        //}

        ///// <summary>
        ///// Kruskal algorithm
        ///// </summary>
        ///// <returns>return the min span tree for this grpah</returns>
        //public MatrixGraph Kruskal()
        //{
        //    double[][] result = GetNonEdgeGraph();
        //    List<EdgeNode> edgeNodes = new List<EdgeNode>(count);

        //    for (int i = 0; i < count; i++)
        //    {
        //        for (int j = 0; j < count; j++)
        //        {
        //            double length = matrix[i][j];
        //            if (length != maxDistance)
        //            {
        //                EdgeNode edgeNode = new EdgeNode(i, j, length);
        //                edgeNodes.Add(edgeNode);
        //            }
        //        }
        //    }

        //    edgeNodes.Sort();

        //    int addEdgeNumber = 0;
        //    DisjointSet set = new DisjointSet(count);
        //    for (int i = 0; i < edgeNodes.Count; i++)
        //    {
        //        int sourceIndex = edgeNodes[i].SourceIndex;
        //        int destinationIndex = edgeNodes[i].DestinationIndex;
        //        if (!set.IsInSameSet(sourceIndex, destinationIndex))
        //        {
        //            result[sourceIndex][destinationIndex] = edgeNodes[i].Length;
        //            set.Union(sourceIndex, destinationIndex);
        //            addEdgeNumber++;
        //        }
        //        if (addEdgeNumber == count)
        //        {
        //            break;
        //        }
        //    }
        //    if (addEdgeNumber != count)
        //    {
        //        throw new InvalidOperationException("The graph isn't connected!");
        //    }
        //    return new MatrixGraph(result, maxDistance);
        //}

        ///// <summary>
        ///// Prim algorithm
        ///// </summary>
        ///// <returns>return the min span tree for this grpah</returns>
        //public MatrixGraph Prim()
        //{
        //    double[] minDistance = new double[count];
        //    for (int i = 0; i < count; i++)
        //    {
        //        minDistance[i] = maxDistance;
        //    }
        //    int[] parent = new int[count];
        //    bool[] isInHeap = new bool[count];
        //    minDistance[0] = 0;
        //    VertexNode vertexNode = new VertexNode(0, 0);
        //    BinaryHeap<VertexNode> heap = new BinaryHeap<VertexNode>(count);
        //    while (heap.Count != 0)
        //    {
        //        VertexNode minNode = heap.ExtractFirst();
        //    }
        //}

        //private double[][] GetNonEdgeGraph()
        //{
        //    double[][] result = new double[count][];
        //    for (int i = 0; i < count; i++)
        //    {
        //        result[i] = new double[count];
        //        for (int j = 0; j < count; j++)
        //        {
        //            result[i][j] = maxDistance;
        //        }
        //        result[i][i] = 0;
        //    }
        //    return result;
        //}

        /// <summary>
        /// Set unidirectional edge
        /// </summary>
        /// <param name="srcIndex">the source index of vertex</param>
        /// <param name="destIndex">the destination index of vertex</param>
        /// <param name="value">the value of the edge</param>
        public void SetUniEdge(int srcIndex, int destIndex, double value)
        {
            nodes[srcIndex].AddEdge(destIndex, value);
        }

        /// <summary>
        /// Set bidirectional edge
        /// </summary>
        /// <param name="srcIndex">the source index of vertex</param>
        /// <param name="destIndex">the destination index of vertex</param>
        /// <param name="value">the value of the edge</param>
        public void SetBidEdge(int srcIndex, int destIndex, double value)
        {
            nodes[srcIndex].AddEdge(destIndex, value);
            nodes[destIndex].AddEdge(srcIndex, value);
        }

        #endregion
    }
}
