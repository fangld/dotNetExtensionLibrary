using System;
using System.Collections.Generic;
using System.Text;
using ExtensionLibrary.Algorithms;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class TestMixedRadix
    {
        [Test]
        public void TestTwoMethod()
        {
            int[] array = new int[] { 1, 2 };
            EnumerableScanner.ScanMixedRadix(array, Show);
            
            foreach (int[] item in EnumerableGenerator.GetMixedRadixEnumerator(array))
            {
                Show(item);
            }
        }

        [Test]
        public void TestFourMethod()
        {
            int[] array = new int[] {1, 2, 3, 4};
            EnumerableScanner.ScanMixedRadix(array, Show);
        }

        private void Show(int[] array)
        {
            //array[0] = 2;
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
            array[0] = 2;
        }
    }
}
