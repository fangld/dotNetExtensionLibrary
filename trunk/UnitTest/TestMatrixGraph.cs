using System;
using System.Collections.Generic;
using System.Text;
using ExtendLibrary.DataStructures;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class TestMatrixGraph
    {
        [Test]
        public void TestOneEdgeFloyd()
        {
            MatrixGraph graph = new MatrixGraph(2, 10);
            graph.SetUniEdge(0, 1, 2);
            double[][] result = graph.Floyd();
            Assert.AreEqual(10, result[1][0]);
            Assert.AreEqual(2, result[0][1]);
        }

        [Test]
        public void TestNormalFloyd()
        {
            MatrixGraph graph = new MatrixGraph(3, 10);
            graph.SetUniEdge(0, 1, 2);
            graph.SetUniEdge(1, 2, 5);
            graph.SetUniEdge(0, 2, 6);
            double[][] result = graph.Floyd();
            Assert.AreEqual(2, result[0][1]);
            Assert.AreEqual(6, result[0][2]);
            Assert.AreEqual(5, result[1][2]);
        }

        [Test]
        public void TestOneEdgeDijkstra()
        {
            MatrixGraph graph = new MatrixGraph(2, 10);
            graph.SetUniEdge(0, 1, 2);
            double[] result = graph.Dijkstra(0);
            Assert.AreEqual(0, result[0]);
            Assert.AreEqual(2, result[1]);
        }

        [Test]
        public void TestNormalDijkstra()
        {
            MatrixGraph graph = new MatrixGraph(3, 10);
            graph.SetUniEdge(0, 1, 2);
            graph.SetUniEdge(1, 2, 5);
            graph.SetUniEdge(0, 2, 6);
            double[] result = graph.Dijkstra(0);
            Assert.AreEqual(0, result[0]);
            Assert.AreEqual(2, result[1]);
            Assert.AreEqual(6, result[2]);

            result = graph.Dijkstra(1);
            Assert.AreEqual(10, result[0]);
            Assert.AreEqual(0, result[1]);
            Assert.AreEqual(5, result[2]);

            result = graph.Dijkstra(2);
            Assert.AreEqual(10, result[0]);
            Assert.AreEqual(10, result[1]);
            Assert.AreEqual(0, result[2]);
        }

        [Test]
        public void Test()
        {
            Random ran = new Random();
            MatrixGraph graph = new MatrixGraph(100, 101);
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    graph.SetUniEdge(i, j, ran.Next(100));
                }
                graph.SetUniEdge(i, i, 0);
            }
            double[][] floyd = graph.Floyd();
            for (int i = 0; i < 100; i++)
            {
                double[] dijkstra = graph.Dijkstra(i);
                for (int j = 0; j < 100; j++)
                {
                    if (floyd[i][j] != dijkstra[j])
                    {
                        Console.WriteLine("i:{0} j:{1} floyd:{2} dijkstra:{3}", i, j, floyd[i][j], dijkstra[j]);
                    }
                    Assert.AreEqual(floyd[i][j], dijkstra[j]);
                }
            }
        }
    }
}
