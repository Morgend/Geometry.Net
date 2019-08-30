using System;

/*
 * Author: Andrey Pokidov
 * Date: 30 Aug 2019
 */

namespace MathKit
{
    public class Maximum
    {
        private Maximum()
        {
        }

        public static byte Of(byte a, byte b)
        {
            return a > b ? a : b;
        }

        public static sbyte Of(sbyte a, sbyte b)
        {
            return a > b ? a : b;
        }

        public static short Of(short a, short b)
        {
            return a > b ? a : b;
        }

        public static ushort Of(ushort a, ushort b)
        {
            return a > b ? a : b;
        }

        public static int Of(int a, int b)
        {
            return a > b ? a : b;
        }

        public static uint Of(uint a, uint b)
        {
            return a > b ? a : b;
        }

        public static long Of(long a, long b)
        {
            return a > b ? a : b;
        }

        public static ulong Of(ulong a, ulong b)
        {
            return a > b ? a : b;
        }

        public static float Of(float a, float b)
        {
            return a > b ? a : b;
        }

        public static double Of(double a, double b)
        {
            return a > b ? a : b;
        }


        public static sbyte Of(sbyte a, sbyte b, sbyte c)
        {
            if (a > b)
            {
                return a > c ? a : c;
            }
            return b > c ? b : c;
        }

        public static byte Of(byte a, byte b, byte c)
        {
            if (a > b)
            {
                return a > c ? a : c;
            }
            return b > c ? b : c;
        }

        public static short Of(short a, short b, short c)
        {
            if (a > b)
            {
                return a > c ? a : c;
            }
            return b > c ? b : c;
        }

        public static ushort Of(ushort a, ushort b, ushort c)
        {
            if (a > b)
            {
                return a > c ? a : c;
            }
            return b > c ? b : c;
        }

        public static int Of(int a, int b, int c)
        {
            if (a > b)
            {
                return a > c ? a : c;
            }
            return b > c ? b : c;
        }

        public static uint Of(uint a, uint b, uint c)
        {
            if (a > b)
            {
                return a > c ? a : c;
            }
            return b > c ? b : c;
        }

        public static long Of(long a, long b, long c)
        {
            if (a > b)
            {
                return a > c ? a : c;
            }
            return b > c ? b : c;
        }

        public static ulong Of(ulong a, ulong b, ulong c)
        {
            if (a > b)
            {
                return a > c ? a : c;
            }
            return b > c ? b : c;
        }

        public static float Of(float a, float b, float c)
        {
            if (a > b)
            {
                return a > c ? a : c;
            }
            return b > c ? b : c;
        }

        public static double Of(double a, double b, double c)
        {
            if (a > b)
            {
                return a > c ? a : c;
            }
            return b > c ? b : c;
        }
    }
}
