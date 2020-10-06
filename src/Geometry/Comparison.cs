using System;

/*
 * Author: Andrey Pokidov
 * Date: 30 Aug 2019
 */

namespace Geometry
{
    public class Comparison
    {
        private const double EPSYLON_EFFECTIVENESS_LOW = -100.0;
        private const double EPSYLON_EFFECTIVENESS_HIGH = 100.0;

        private Comparison()
        {
        }

        public static bool AreEqual(double a, double b)
        {
            return a < b ? GetEquality(a, b) : GetEquality(b, a);
        }

        public static bool AreEqual(double a, double b, double c)
        {
            return GetEquality(Maximum.Of(a, b, c), Minimum.Of(a, b, c));
        }

        private static bool GetEquality(double minimum, double maximum)
        {
            if (EPSYLON_EFFECTIVENESS_LOW <= minimum && maximum <= EPSYLON_EFFECTIVENESS_HIGH)
            {
                return minimum + MathConstant.EPSYLON >= maximum;
            }
            return maximum - minimum <= MathConstant.EPSYLON * Minimum.Of(Absolute.Of(maximum), Absolute.Of(minimum));
        }
    }
}
