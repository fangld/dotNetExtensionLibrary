using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtensionLibrary.Algorithms;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class TestPermutation
    {

        [Test]
        public void Test1()
        {
            int[] array = new int[] {1, 2, 3, 4};
            EnumerableScanner.ScanPermutation(array, Show);
        }

        private void Show(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }
    }
}
