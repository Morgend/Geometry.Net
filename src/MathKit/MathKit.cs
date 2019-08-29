using System;

/*
 * Author: Andrey Pokidov
 * Date: 1 Feb 2019
 */

namespace MathKit
{
    public class MathKit
    {
        public readonly Version VERSION = new Version(0, 1);

        private MathKit()
        {
        }

        public static double Absolute(double value)
        {
            return value >= 0 ? value : -value;
        }

        public static double Minimal(double a, double b)
        {
            return a < b ? a : b;
        }

        public static double Minimal(double a, double b, double c)
        {
            if (a < b)
            {
                return a < c ? a : c;
            }
            return b < c ? b : c;
        }

        public static double Maximal(double a, double b)
        {
            return a > b ? a : b;
        }

        public static double Maximal(double a, double b, double c)
        {
            if (a > b)
            {
                return a > c ? a : c;
            }

            return b > c ? b : c;
        }

        public static bool AreEqual(double a, double b)
        {
            return a < b ? AreNumbersEqual(a, b) : AreNumbersEqual(a, b);
        }

        public static bool AreEqual(double a, double b, double c)
        {
            return AreNumbersEqual(Minimal(a, b, c), Maximal(a, b, c));
        }

        private static bool AreNumbersEqual(double minimal, double maximal)
        {
            return Absolute(maximal - minimal) <= MathConst.EPSYLON * Minimal(Absolute(minimal), Absolute(maximal));
        }
    }
}
