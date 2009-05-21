using System;
using System.Collections.Generic;
using System.Text;
using ExtensionLibrary.Tools;

namespace ExtensionLibrary.Algorithms
{
    /// <summary>
    /// Quick integer math function
    /// </summary>
    public static class MathExtension
    {
        #region Floor Pow 2

        public static sbyte GetFloorOfPow2(sbyte x)
        {
            x |= (sbyte)(x >> 1);
            x |= (sbyte)(x >> 2);
            x |= (sbyte)(x >> 4);
            return (sbyte)(x - (x >> 1));
        }

        public static short GetFloorOfPow2(short x)
        {
            x |= (short)(x >> 1);
            x |= (short)(x >> 2);
            x |= (short)(x >> 4);
            x |= (short)(x >> 8);
            return (short)(x - (x >> 1));
        }

        public static int GetFloorOfPow2(int x)
        {
            x |= (x >> 1);
            x |= (x >> 2);
            x |= (x >> 4);
            x |= (x >> 8);
            x |= (x >> 16);
            return x - (x >> 1);
        }

        public static long GetFloorOfPow2(long x)
        {
            x |= (x >> 1);
            x |= (x >> 2);
            x |= (x >> 4);
            x |= (x >> 8);
            x |= (x >> 16);
            x |= (x >> 32);
            return x - (x >> 1);
        }

        public static byte GetFloorOfPow2(byte x)
        {
            x |= (byte)(x >> 1);
            x |= (byte)(x >> 2);
            x |= (byte)(x >> 4);
            return (byte)(x - (x >> 1));
        }

        public static ushort GetFloorOfPow2(ushort x)
        {
            x |= (ushort)(x >> 1);
            x |= (ushort)(x >> 2);
            x |= (ushort)(x >> 4);
            x |= (ushort)(x >> 8);
            return (ushort)(x - (x >> 1));
        }

        public static uint GetFloorOfPow2(uint x)
        {
            x |= (x >> 1);
            x |= (x >> 2);
            x |= (x >> 4);
            x |= (x >> 8);
            x |= (x >> 16);
            return x - (x >> 1);
        }

        public static ulong GetFloorOfPow2(ulong x)
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

        #region Ceil Pow 2

        public static sbyte GetCeilOfPow2(sbyte x)
        {
            x--;
            x |= (sbyte)(x >> 1);
            x |= (sbyte)(x >> 2);
            x |= (sbyte)(x >> 4);
            return (sbyte)(x + 1);
        }

        public static short GetCeilOfPow2(short x)
        {
            x--;
            x |= (short)(x >> 1);
            x |= (short)(x >> 2);
            x |= (short)(x >> 4);
            x |= (short)(x >> 8);
            return (short)(x + 1);
        }

        public static int GetCeilOfPow2(int x)
        {
            x--;
            x |= (x >> 1);
            x |= (x >> 2);
            x |= (x >> 4);
            x |= (x >> 8);
            x |= (x >> 16);
            return x + 1;
        }

        public static long GetCeilOfPow2(long x)
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

        public static byte GetCeilOfPow2(byte x)
        {
            x--;
            x |= (byte)(x >> 1);
            x |= (byte)(x >> 2);
            x |= (byte)(x >> 4);
            return (byte)(x + 1);
        }

        public static ushort GetCeilOfPow2(ushort x)
        {
            x--;
            x |= (ushort)(x >> 1);
            x |= (ushort)(x >> 2);
            x |= (ushort)(x >> 4);
            x |= (ushort)(x >> 8);
            return (ushort)(x + 1);
        }

        public static uint GetCeilOfPow2(uint x)
        {
            x--;
            x |= (x >> 1);
            x |= (x >> 2);
            x |= (x >> 4);
            x |= (x >> 8);
            x |= (x >> 16);
            return x + 1;
        }

        public static ulong GetCeilOfPow2(ulong x)
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

        #region Cbrt

        public static sbyte Cbrt(sbyte x)
        {
            int s = 6;
            sbyte y = 0;
            while (s >= 0)
            {
                y <<= 1;
                int b = (3 * y * (y + 1) + 1) << s;
                s -= 3;
                if (x >= b)
                {
                    x -= (sbyte)b;
                    y++;
                }
            }
            return y;
        }

        public static short Cbrt(short x)
        {
            int s = 15;
            short y = 0;
            while (s >= 0)
            {
                y <<= 1;
                int b = (3 * y * (y + 1) + 1) << s;
                s -= 3;
                if (x >= b)
                {
                    x -= (short)b;
                    y++;
                }
            }
            return y;
        }

        public static int Cbrt(int x)
        {
            int s = 30;
            int y = 0;
            while (s >= 0)
            {
                y <<= 1;
                int b = (3*y*(y + 1) + 1) << s;
                s -= 3;
                if (x >= b)
                {
                    x -= b;
                    y++;
                }
            }
            return y;
        }

        public static long Cbrt(long x)
        {
            int s = 60;
            long y = 0;
            while (s >= 0)
            {
                y <<= 1;
                long b = (3 * y * (y + 1) + 1) << s;
                s -= 3;
                if (x >= b)
                {
                    x -= b;
                    y++;
                }
            }
            return y;
        }

        public static byte Cbrt(byte x)
        {
            int s = 6;
            byte y = 0;
            while (s >= 0)
            {
                y <<= 1;
                int b = (3 * y * (y + 1) + 1) << s;
                s -= 3;
                if (x >= b)
                {
                    x -= (byte)b;
                    y++;
                }
            }
            return y;
        }

        public static ushort Cbrt(ushort x)
        {
            int s = 15;
            ushort y = 0;
            while (s >= 0)
            {
                y <<= 1;
                int b = (3 * y * (y + 1) + 1) << s;
                s -= 3;
                if (x >= b)
                {
                    x -= (ushort)b;
                    y++;
                }
            }
            return y;
        }

        public static uint Cbrt(uint x)
        {
            int s = 30;
            uint y = 0;
            while (s >= 0)
            {
                y <<= 1;
                uint b = (3 * y * (y + 1) + 1) << s;
                s -= 3;
                if (x >= b)
                {
                    x -= b;
                    y++;
                }
            }
            return y;
        }

        public static ulong Cbrt(ulong x)
        {
            int s = 60;
            ulong y = 0;
            while (s >= 0)
            {
                y <<= 1;
                ulong b = (3 * y * (y + 1) + 1) << s;
                s -= 3;
                if (x >= b)
                {
                    x -= b;
                    y++;
                }
            }
            return y;
        }

        #endregion

        #region Pow

        public static int Pow(int x, uint y)
        {
            int z = 1;
            int p = x;
            do
            {
                if ((y & 1) != 0)
                {
                    z *= p;
                }
                y >>= 1;
                if (y==0)
                {
                    return z;
                }
                p *= p;
            } while (true);
        }

        public static long Pow(long x, ulong y)
        {
            long z = 1;
            long p = x;
            do
            {
                if ((y & 1) != 0)
                {
                    z *= p;
                }
                y >>= 1;
                if (y == 0)
                {
                    return z;
                }
                p *= p;
            } while (true);
        }

        public static uint Pow(uint x, uint y)
        {
            uint z = 1;
            uint p = x;
            do
            {
                if ((y & 1) != 0)
                {
                    z *= p;
                }
                y >>= 1;
                if (y == 0)
                {
                    return z;
                }
                p *= p;
            } while (true);
        }

        public static ulong Pow(ulong x, ulong y)
        {
            ulong z = 1;
            ulong p = x;
            do
            {
                if ((y & 1) != 0)
                {
                    z *= p;
                }
                y >>= 1;
                if (y == 0)
                {
                    return z;
                }
                p *= p;
            } while (true);
        }

        public static float Pow(float x, uint y)
        {
            float z = 1.0f;
            float p = x;
            do
            {
                if ((y & 1) != 0)
                {
                    z *= p;
                }
                y >>= 1;
                if (y == 0)
                {
                    return z;
                }
                p *= p;
            } while (true);
        }

        public static double Pow(double x, uint y)
        {
            double z = 1.0;
            double p = x;
            do
            {
                if ((y & 1) != 0)
                {
                    z *= p;
                }
                y >>= 1;
                if (y == 0)
                {
                    return z;
                }
                p *= p;
            } while (true);
        }

        #endregion

        #region Log 2

        public static sbyte Log2(sbyte x)
        {
            return (sbyte)(7 - BitOperator.GetNumberOfLeadingZero(x));
        }

        public static short Log2(short x)
        {
            return (short)(15 - BitOperator.GetNumberOfLeadingZero(x));
        }

        public static int Log2(int x)
        {
            return 31 - BitOperator.GetNumberOfLeadingZero(x);
        }

        public static long Log2(long x)
        {
            return 63 - BitOperator.GetNumberOfLeadingZero(x);
        }

        public static byte Log2(byte x)
        {
            return (byte)(7 - BitOperator.GetNumberOfLeadingZero(x));
        }

        public static ushort Log2(ushort x)
        {
            return (ushort)(15 - BitOperator.GetNumberOfLeadingZero(x));
        }

        public static uint Log2(uint x)
        {
            return (uint)(31 - BitOperator.GetNumberOfLeadingZero(x));
        }

        public static ulong Log2(ulong x)
        {
            return (ulong)(63 - BitOperator.GetNumberOfLeadingZero(x));
        }

        #endregion

        #region Log10

        public static sbyte Log10(sbyte x)
        {
            sbyte result = -1;
            sbyte p = 1;
            for (; result <= 3; result++)
            {
                if (x < p)
                {
                    return result;
                }
                p *= 10;
            }
            return result;
        }

        public static short Log10(short x)
        {
            short result = -1;
            short p = 1;
            for (; result <= 5; result++)
            {
                if (x < p)
                {
                    return result;
                }
                p *= 10;
            }
            return result;
        }

        public static int Log(int x)
        {
            int result = -1;
            int p = 1;
            for (; result <= 8; result++)
            {
                if (x < p)
                {
                    return result;
                }
                p *= 10;
            }
            return result;
        }

        public static long Log(long x)
        {
            int result = -1;
            int p = 1;
            for (; result <= 20; result++)
            {
                if (x < p)
                {
                    return result;
                }
                p *= 10;
            }
            return result;
        }

        public static byte Log(byte x)
        {
            byte result = 0;
            byte p = 1;
            for (; result <= 3; result++)
            {
                if (x < p)
                {
                    return result;
                }
                p *= 10;
            }
            return result;
        }

        public static ushort Log(ushort x)
        {
            ushort result = 0;
            ushort p = 1;
            for (; result <= 3; result++)
            {
                if (x < p)
                {
                    return result;
                }
                p *= 10;
            }
            return result;
        }

        public static uint Log(uint x)
        {
            uint result = 0;
            uint p = 1;
            for (; result <= 3; result++)
            {
                if (x < p)
                {
                    return result;
                }
                p *= 10;
            }
            return result;
        }

        public static ulong Log(ulong x)
        {
            ulong result = 0;
            ulong p = 1;
            for (; result <= 3; result++)
            {
                if (x < p)
                {
                    return result;
                }
                p *= 10;
            }
            return result;
        }

        #endregion
    }
}
