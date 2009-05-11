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
        public void TestOneEdge()
        {
            MatrixGraph graph = new MatrixGraph(2, 10);
            graph.SetEdge(0, 1, 2);
            double[][] result = graph.FloydWarshall();
            Assert.AreEqual(10, result[1][0]);
            Assert.AreEqual(2, result[0][1]);
        }

        [Test]
        public void TestNormal()
        {
            MatrixGraph graph = new MatrixGraph(3, 10);
            graph.SetEdge(0, 1, 2);
            graph.SetEdge(1, 2, 5);
            graph.SetEdge(0, 2, 6);
            double[][] result = graph.FloydWarshall();
            Assert.AreEqual(2, result[0][1]);
            Assert.AreEqual(6, result[0][2]);
            Assert.AreEqual(5, result[1][2]);
        }
    }
}
