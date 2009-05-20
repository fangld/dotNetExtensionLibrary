using System;
using System.Collections.Generic;
using System.Text;
using ExtendLibrary.Tools;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class TestBitOperator
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(4, BitOperator.GetCountOfBitOne(0x1111));
            Assert.AreEqual(60, BitOperator.GetCountOfBitZero((long)0x1111));
            Assert.AreEqual(32, BitOperator.GetCountOfBitZero(0));
            Assert.AreEqual(64, BitOperator.GetCountOfBitZero((long)0));
        }
    }
}
