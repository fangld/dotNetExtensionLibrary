using System;
using System.Collections.Generic;
using System.Text;
using ExtendLibrary.Algorithms;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class TestMixedRadixEnumerator
    {
        [Test]
        public void TestTwo()
        {
            int[] array = new int[] {1, 2};
            MixedRadixEnumerable<int> mixedRadixEnumerable = new MixedRadixEnumerable<int>(array);
            foreach (int[] item in mixedRadixEnumerable)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    Console.Write("{0} ", item[i]);
                }
                Console.WriteLine();
            }
        }

        [Test]
        public void TestFour()
        {
            int[] array = new int[] {1, 2, 3, 4};
            MixedRadixEnumerable<int> mixedRadixEnumerable = new MixedRadixEnumerable<int>(array);
            foreach (int[] item in mixedRadixEnumerable)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    Console.Write("{0} ", item[i]);
                }
                Console.WriteLine();
            }
        }
    }
}
