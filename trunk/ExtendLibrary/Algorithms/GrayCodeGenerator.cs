using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendLibrary.Algorithms
{
    public static class GrayCodeGenerator
    {
        #region GrayCode

        public static sbyte ToGrayCode(sbyte binaryCode)
        {
            return (sbyte)(binaryCode ^ (binaryCode >> 1));
        }

        public static short ToGrayCode(short binaryCode)
        {
            return (short)(binaryCode ^ (binaryCode >> 1));
        }

        public static int ToGrayCode(int binaryCode)
        {
            return binaryCode ^ (binaryCode >> 1);
        }

        public static long ToGrayCode(long binaryCode)
        {
            return binaryCode ^ (binaryCode >> 1);
        }

        public static byte ToGrayCode(byte binaryCode)
        {
            return (byte)(binaryCode ^ (binaryCode >> 1));
        }

        public static ushort ToGrayCode(ushort binaryCode)
        {
            return (ushort)(binaryCode ^ (binaryCode >> 1));
        }

        public static uint ToGrayCode(uint binaryCode)
        {
            return binaryCode ^ (binaryCode >> 1);
        }

        public static ulong ToGrayCode(ulong binaryCode)
        {
            return binaryCode ^ (binaryCode >> 1);
        }

        #endregion

        public static sbyte ToBinaryCode(sbyte grayCode)
        {
            sbyte result = grayCode;
            while ((grayCode >>= 1) != 0)
            {
                result ^= grayCode;
            }
            return result;
        }

        public static short ToBinaryCode(short grayCode)
        {
            short result = grayCode;
            while ((grayCode >>= 1) != 0)
            {
                result ^= grayCode;
            }
            return result;
        }

        public static int ToBinaryCode(int grayCode)
        {
            int result = grayCode;
            while ((grayCode >>= 1) != 0)
            {
                result ^= grayCode;
            }
            return result;
        }

        public static long ToBinaryCode(long grayCode)
        {
            long result = grayCode;
            while ((grayCode >>= 1) != 0)
            {
                result ^= grayCode;
            }
            return result;
        }

        public static byte ToBinaryCode(byte grayCode)
        {
            byte result = grayCode;
            while ((grayCode >>= 1) != 0)
            {
                result ^= grayCode;
            }
            return result;
        }

        public static ushort ToBinaryCode(ushort grayCode)
        {
            ushort result = grayCode;
            while ((grayCode >>= 1) != 0)
            {
                result ^= grayCode;
            }
            return result;
        }

        public static uint ToBinaryCode(uint grayCode)
        {
            uint result = grayCode;
            while ((grayCode >>= 1) != 0)
            {
                result ^= grayCode;
            }
            return result;
        }

        public static ulong ToBinaryCode(ulong grayCode)
        {
            ulong result = grayCode;
            while ((grayCode >>= 1) != 0)
            {
                result ^= grayCode;
            }
            return result;
        }
    }
}