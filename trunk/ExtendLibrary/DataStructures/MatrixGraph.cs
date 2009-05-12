using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.DataStructures
{
    public class MatrixGraph
    {
        private int count;

        private double[][] matrix;

        public MatrixGraph(int count, double maxDistance)
        {
            this.count = count;
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

        //public double[] Dijkstra()
        //{
        //    BinaryHeap<int> heap = new BinaryHeap<int>();
        //    for (int i = 0; i < count; i++)
        //        heap.Add(i);
        //    while (heap.Count != 0)
        //    {

        //    }
        //}

        public double[][] FloydWarshall()
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

        public void SetEdge(int source, int destination, double value)
        {
            matrix[source][destination] = value;
        }
    }
}
