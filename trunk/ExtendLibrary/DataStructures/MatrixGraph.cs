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

        //public T Dijkstra()
        //{
        //    MinHeap<int> heap = new MinHeap<int>();
        //    for (int i = 0; i < count; i++)
        //        heap.Add(i);
        //    while(heap.Count != 0)
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

            for (int k = 0; k < count; k++)
            {
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < count; j++)
                    {
                        double newLength = result[i][k] + result[k][j];
                        if (newLength < result[i][j])
                        {
                            result[i][j] = newLength;
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
