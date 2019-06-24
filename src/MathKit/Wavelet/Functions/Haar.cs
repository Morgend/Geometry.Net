using System;

namespace MathKit.Wavelet.Functions
{
    public class Haar : WaveletFunction
    {
        public double calculate(double x)
        {
            if (0.0 <= x && x <= 0.5)
            {
                return 1.0;
            }

            if (0.5 < x && x <= 1.0)
            {
                return -1.0;
            }

            return 0.0;
        }
    }
}
