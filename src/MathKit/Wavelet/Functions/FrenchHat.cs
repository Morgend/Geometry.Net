using System;

namespace MathKit.Wavelet.Functions
{
    public class FrenchHat : WaveletFunction
    {
        private double ONE_THIRD = 1.0 / 3.0;
        public double calculate(double x)
        {
            double module = Math.Abs(x);

            if (module <= ONE_THIRD)
            {
                return 1.0;
            }

            if (module <= 1.0)
            {
                return 0.5;
            }

            return 0.0;
        }
    }
}
