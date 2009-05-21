using System;
using System.Collections.Generic;
using System.Text;
using ExtensionLibrary.Tools;

namespace ExtensionLibrary.Algorithms
{
    public static class MathExtend
    {
        #region Floor Power 2

        public static sbyte GetFloorOfPower2(sbyte x)
        {
            x |= (sbyte)(x >> 1);
            x |= (sbyte)(x >> 2);
            x |= (sbyte)(x >> 4);
            return (sbyte)(x - (x >> 1));
        }

        public static short GetFloorOfPower2(short x)
        {
            x |= (short)(x >> 1);
            x |= (short)(x >> 2);
            x |= (short)(x >> 4);
            x |= (short)(x >> 8);
            return (short)(x - (x >> 1));
        }

        public static int GetFloorOfPower2(int x)
        {
            x |= (x >> 1);
            x |= (x >> 2);
            x |= (x >> 4);
            x |= (x >> 8);
            x |= (x >> 16);
            return x - (x >> 1);
        }

        public static long GetFloorOfPower2(long x)
        {
            x |= (x >> 1);
            x |= (x >> 2);
            x |= (x >> 4);
            x |= (x >> 8);
            x |= (x >> 16);
            x |= (x >> 32);
            return x - (x >> 1);
        }

        public static byte GetFloorOfPower2(byte x)
        {
            x |= (byte)(x >> 1);
            x |= (byte)(x >> 2);
            x |= (byte)(x >> 4);
            return (byte)(x - (x >> 1));
        }

        public static ushort GetFloorOfPower2(ushort x)
        {
            x |= (ushort)(x >> 1);
            x |= (ushort)(x >> 2);
            x |= (ushort)(x >> 4);
            x |= (ushort)(x >> 8);
            return (ushort)(x - (x >> 1));
        }

        public static uint GetFloorOfPower2(uint x)
        {
            x |= (x >> 1);
            x |= (x >> 2);
            x |= (x >> 4);
            x |= (x >> 8);
            x |= (x >> 16);
            return x - (x >> 1);
        }

        public static ulong GetFloorOfPower2(ulong x)
        {
            x |= (x >> 1);
            x |= (x >> 2);
            x |= (x >> 4);
            x |= (x >> 8);
            x |= (x >> 16);
            x |= (x >> 32);
            return x - (x >> 1);
        }

        #endregion

        #region Ceil Power 2

        public static sbyte GetCeilOfPower2(sbyte x)
        {
            x--;
            x |= (sbyte)(x >> 1);
            x |= (sbyte)(x >> 2);
            x |= (sbyte)(x >> 4);
            return (sbyte)(x + 1);
        }

        public static short GetCeilOfPower2(short x)
        {
            x--;
            x |= (short)(x >> 1);
            x |= (short)(x >> 2);
            x |= (short)(x >> 4);
            x |= (short)(x >> 8);
            return (short)(x + 1);
        }

        public static int GetCeilOfPower2(int x)
        {
            x--;
            x |= (x >> 1);
            x |= (x >> 2);
            x |= (x >> 4);
            x |= (x >> 8);
            x |= (x >> 16);
            return x + 1;
        }

        public static long GetCeilOfPower2(long x)
        {
            x--;
            x |= (x >> 1);
            x |= (x >> 2);
            x |= (x >> 4);
            x |= (x >> 8);
            x |= (x >> 16);
            x |= (x >> 32);
            return x + 1;
        }

        public static byte GetCeilOfPower2(byte x)
        {
            x--;
            x |= (byte)(x >> 1);
            x |= (byte)(x >> 2);
            x |= (byte)(x >> 4);
            return (byte)(x + 1);
        }

        public static ushort GetCeilOfPower2(ushort x)
        {
            x--;
            x |= (ushort)(x >> 1);
            x |= (ushort)(x >> 2);
            x |= (ushort)(x >> 4);
            x |= (ushort)(x >> 8);
            return (ushort)(x + 1);
        }

        public static uint GetCeilOfPower2(uint x)
        {
            x--;
            x |= (x >> 1);
            x |= (x >> 2);
            x |= (x >> 4);
            x |= (x >> 8);
            x |= (x >> 16);
            return x + 1;
        }

        public static ulong GetCeilOfPower2(ulong x)
        {
            x--;
            x |= (x >> 1);
            x |= (x >> 2);
            x |= (x >> 4);
            x |= (x >> 8);
            x |= (x >> 16);
            x |= (x >> 32);
            return x + 1;
        }

        #endregion

        #region Sqrt

        public static sbyte Sqrt(sbyte x)
        {
            if (x <= 1)
                return x;
            int s = 4 - (BitOperator.GetNumberOfLeadingZero(x - 1) >> 1);

            sbyte g0 = (sbyte)(1 << s);
            sbyte g1 = (sbyte)((g0 + (x >> s)) >> 1);
            while (g1 < g0)
            {
                g0 = g1;
                g1 = (sbyte)((g0 + x / g0) >> 1);
            }
            return g0;
        }

        public static short Sqrt(short x)
        {
            if (x <= 1)
                return x;
            int s = 4 - (BitOperator.GetNumberOfLeadingZero(x - 1) >> 1);

            short g0 = (short)(1 << s);
            short g1 = (short)((g0 + (x >> s)) >> 1);
            while (g1 < g0)
            {
                g0 = g1;
                g1 = (sbyte)((g0 + x / g0) >> 1);
            }
            return g0;
        }

        public static int Sqrt(int x)
        {
            if (x <= 1)
                return x;
            int s = 16 - (BitOperator.GetNumberOfLeadingZero(x - 1) >> 1);

            int g0 = (1 << s);
            int g1 = ((g0 + (x >> s)) >> 1);
            while (g1 < g0)
            {
                g0 = g1;
                g1 = (g0 + x/g0) >> 1;
            }
            return g0;
        }

        public static long Sqrt(long x)
        {
            if (x <= 1)
                return x;
            int s = 32 - (BitOperator.GetNumberOfLeadingZero(x - 1) >> 1);

            long g0 = ((long)1) << s;
            long g1 = (g0 + (x >> s)) >> 1;
            while (g1 < g0)
            {
                g0 = g1;
                g1 = (g0 + x / g0) >> 1;
            }
            return g0;
        }

        public static byte Sqrt(byte x)
        {
            if (x <= 1)
                return x;
            byte s = (byte)(4 - (BitOperator.GetNumberOfLeadingZero(x - 1) >> 1));

            byte g0 = (byte)(1 << s);
            byte g1 = (byte)((g0 + (x >> s)) >> 1);
            while (g1 < g0)
            {
                g0 = g1;
                g1 = (byte)((g0 + x / g0) >> 1);
            }
            return g0;
        }

        public static ushort Sqrt(ushort x)
        {
            if (x <= 1)
                return x;
            ushort s = (ushort)(4 - (BitOperator.GetNumberOfLeadingZero(x - 1) >> 1));

            ushort g0 = (ushort)(1 << s);
            ushort g1 = (ushort)((g0 + (x >> s)) >> 1);
            while (g1 < g0)
            {
                g0 = g1;
                g1 = (ushort)((g0 + x / g0) >> 1);
            }
            return g0;
        }

        public static uint Sqrt(uint x)
        {
            if (x <= 1)
                return x;
            int s = (16 - (BitOperator.GetNumberOfLeadingZero(x - 1) >> 1));

            uint g0 = (uint)(1 << s);
            uint g1 = ((g0 + (x >> s)) >> 1);
            while (g1 < g0)
            {
                g0 = g1;
                g1 = (g0 + x / g0) >> 1;
            }
            return g0;
        }

        public static ulong Sqrt(ulong x)
        {
            if (x <= 1)
                return x;
            int s = 32 - (BitOperator.GetNumberOfLeadingZero(x - 1) >> 1);

            ulong g0 = ((ulong)1) << s;
            ulong g1 = (g0 + (x >> s)) >> 1;
            while (g1 < g0)
            {
                g0 = g1;
                g1 = (g0 + x / g0) >> 1;
            }
            return g0;
        }

        #endregion
    }
}
