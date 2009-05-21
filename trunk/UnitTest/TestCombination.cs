using System;
using System.Collections.Generic;
using System.Text;
using ExtensionLibrary.Algorithms;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class TestCombination
    {
        [Test]
        public void Test1()
        {
            int[] array = new int[] {1, 2, 3, 4};
            EnumerableScanner.GetCombination2(array, 3, Show, delegate(int x, int y) { return x.CompareTo(y); });
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
