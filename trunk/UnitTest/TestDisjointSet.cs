using System;
using System.Collections.Generic;
using System.Text;
using ExtendLibrary.DataStructures;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class TestDisjointSet
    {
        [Test]
        public void TestIsSame()
        {
            DisjointSet set = new DisjointSet(4);
            Assert.AreEqual(0, set.FindSet(0));
            Assert.AreEqual(1, set.FindSet(1));
            Assert.AreEqual(2, set.FindSet(2));
            Assert.AreEqual(3, set.FindSet(3));
            Assert.IsFalse(set.IsSame(0, 1));
            Assert.AreEqual(0, set.FindSet(0));
            Assert.AreEqual(1, set.FindSet(1));
            Assert.AreEqual(2, set.FindSet(2));
            Assert.AreEqual(3, set.FindSet(3));
        }

        [Test]
        public void TestUnionOne()
        {
            DisjointSet set = new DisjointSet(4);
            set.Union(0, 1);
            Assert.AreEqual(0, set.FindSet(0));
            Assert.AreEqual(0, set.FindSet(1));
        }

        [Test]
        public void TestUnionMutiple()
        {
            DisjointSet set = new DisjointSet(4);
            set.Union(0, 1);
            set.Union(1, 2);
            set.Union(2, 3);
            Assert.AreEqual(0, set.FindSet(0));
            Assert.AreEqual(0, set.FindSet(1));
            Assert.AreEqual(0, set.FindSet(2));
            Assert.AreEqual(0, set.FindSet(3));
        }

    }
}
