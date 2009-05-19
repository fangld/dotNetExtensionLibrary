using System;
using System.Collections.Generic;
using System.Text;
using ExtendLibrary.Algorithms;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class TestCombination
    {
        [Test]
        public void Test1()
        {
            int[] array = new int[] {1, 2, 3, 4, 5, 6,7};
            CollectionGenerator.GetCombination(array, 3, Show);
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
