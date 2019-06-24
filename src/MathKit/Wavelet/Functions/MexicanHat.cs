using System;

namespace MathKit.Wavelet.Functions
{
    public class MexicanHat : WaveletFunction
    {
        public double calculate(double x)
        {
            return (1.0 - x * x) * Math.Exp(-x * x / 2.0);
        }
    }
}
