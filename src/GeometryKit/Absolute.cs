using System;

/*
 * Author: Andrey Pokidov
 * Date: 30 Aug 2019
 */

namespace GeometryKit
{
    public class Absolute
    {
        private Absolute()
        {
        }

        public static byte Of(sbyte value)
        {
            return value >= 0 ? (byte)value : (byte)(-value);
        }

        public static ushort Of(short value)
        {
            return value >= 0 ? (ushort)value : (ushort)(-value);
        }

        public static uint Of(int value)
        {
            return value >= 0 ? (uint)value : (uint)(-value);
        }

        public static ulong Of(long value)
        {
            return value >= 0 ? (ulong)value : (ulong)(-value);
        }

        public static float Of(float value)
        {
            return value >= 0.0f ? value : -value;
        }

        public static double Of(double value)
        {
            return value >= 0.0 ? value : -value;
        }
    }
}
