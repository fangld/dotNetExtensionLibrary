using System;
using System.Collections.Generic;
using System.Text;
using ExtensionLibrary.DataStructures;
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
        public void TestDepthFirstSearch()
        {
            MatrixGraph graph = new MatrixGraph(4, 10);
            graph.SetUniEdge(0, 1, 2);
            graph.SetUniEdge(1, 2, 5);
            graph.SetUniEdge(0, 2, 6);
            graph.SetUniEdge(1, 3, 2);
            graph.SetUniEdge(2, 3, 2);
            graph.SetUniEdge(3, 2, 2);
            graph.DepthFirstSearch(0);

            Console.WriteLine();
            graph.DepthFirstSearch(1);

            Console.WriteLine();
            graph.DepthFirstSearch(2);

            Console.WriteLine();
            graph.DepthFirstSearch(3);
        }

        [Test]
        public void TestBreadthFirstSearch()
        {
            MatrixGraph graph = new MatrixGraph(4, 10);
            graph.SetUniEdge(0, 1, 2);
            graph.SetUniEdge(1, 2, 5);
            graph.SetUniEdge(0, 2, 6);
            graph.SetUniEdge(1, 3, 2);
            graph.SetUniEdge(2, 3, 2);
            graph.SetUniEdge(3, 2, 2);
            graph.BreadthFirstSearch(0);

            Console.WriteLine();
            graph.BreadthFirstSearch(1);

            Console.WriteLine();
            graph.BreadthFirstSearch(2);

            Console.WriteLine();
            graph.BreadthFirstSearch(3);
        }

        [Test]
        public void TestGetCutPoints1()
        {
            MatrixGraph graph = new MatrixGraph(9, 10);
            graph.SetBidEdge(0, 1, 1);
            graph.SetBidEdge(1, 2, 1);
            graph.SetBidEdge(2, 0, 1);
            graph.SetBidEdge(1, 3, 1);
            graph.SetBidEdge(1, 4, 1);
            graph.SetBidEdge(3, 4, 1);
            graph.SetBidEdge(3, 5, 1);
            graph.SetBidEdge(5, 6, 1);
            graph.SetBidEdge(5, 7, 1);
            graph.SetBidEdge(5, 8, 1);
            graph.SetBidEdge(6, 7, 1);
            graph.SetBidEdge(7, 8, 1);

            HashSet<int> cutPoints = graph.GetCutPoints();
            Assert.AreEqual(4, cutPoints.Count);
            Assert.IsTrue(cutPoints.Contains(0));
            Assert.IsTrue(cutPoints.Contains(1));
            Assert.IsTrue(cutPoints.Contains(3));
            Assert.IsTrue(cutPoints.Contains(5));
        }

        [Test]
        public void TestGetCutPoints2()
        {
            MatrixGraph graph = new MatrixGraph(9, 10);
            graph.SetBidEdge(0, 1, 1);
            graph.SetBidEdge(1, 2, 1);
            graph.SetBidEdge(1, 3, 1);
            graph.SetBidEdge(1, 4, 1);
            graph.SetBidEdge(3, 4, 1);
            graph.SetBidEdge(3, 5, 1);
            graph.SetBidEdge(5, 6, 1);
            graph.SetBidEdge(5, 7, 1);
            graph.SetBidEdge(5, 8, 1);
            graph.SetBidEdge(6, 7, 1);
            graph.SetBidEdge(7, 8, 1);

            HashSet<int> cutPoints = graph.GetCutPoints();
            Assert.AreEqual(3, cutPoints.Count);
            Assert.IsTrue(cutPoints.Contains(1));
            Assert.IsTrue(cutPoints.Contains(3));
            Assert.IsTrue(cutPoints.Contains(5));
        }

        [Test]
        public void TestBinaryHeapDijkstra()
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
                double[] dijkstra = graph.Dijkstra(i, new BinaryHeap<VertexNode>());
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

        [Test]
        public void TestArrayHeapDijkstra()
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
                double[] dijkstra = graph.Dijkstra(i, new ArrayHeap<VertexNode>());
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
