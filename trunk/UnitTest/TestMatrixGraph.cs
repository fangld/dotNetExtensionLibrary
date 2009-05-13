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
    }
}
