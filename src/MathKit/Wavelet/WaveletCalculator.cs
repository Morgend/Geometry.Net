using System;

namespace MathKit.Wavelet
{
    public class WaveletCalculator
    {
        private WaveletFunction function;

        public WaveletCalculator(WaveletFunction waveletFunction)
        {
            if (waveletFunction == null)
            {
                throw new ArgumentNullException("An instance of WaveletFunction was expected but NULL was got");
            }
            this.function = waveletFunction;
        }
    }
}
