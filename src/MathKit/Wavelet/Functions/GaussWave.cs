using System;

namespace MathKit.Wavelet.Functions
{
    public class GaussWave : WaveletFunction
    {
        public double calculate(double x)
        {
            return -x * Math.Exp(-x * x / 2.0);
        }
    }
}
