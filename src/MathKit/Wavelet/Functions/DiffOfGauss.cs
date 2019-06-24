using System;

namespace MathKit.Wavelet.Functions
{
    public class DiffOfGauss : WaveletFunction
    {
        public double calculate(double x)
        {
            return Math.Exp(-x * x / 2.0) - 0.5 * Math.Exp(-x * x / 8.0);
        }
    }
}
