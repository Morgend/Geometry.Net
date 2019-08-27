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
            if (a < b)
            {
                return a + MathConst.EPSYLON >= b;
            }

            return b + MathConst.EPSYLON >= a;
        }

        public static bool AreEqual(double a, double b, double c)
        {
            return Minimal(a, b, c) + MathConst.EPSYLON >= Maximal(a, b, c);
        }
    }
}
