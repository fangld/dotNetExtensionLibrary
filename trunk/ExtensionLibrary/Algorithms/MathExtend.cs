using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
