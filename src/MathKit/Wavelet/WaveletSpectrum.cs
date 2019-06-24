using System;

namespace MathKit.Wavelet
{
    public class WaveletSpectrum
    {
        private int time;
        private double[] spectrum;

        internal WaveletSpectrum(int capacity)
        {
            this.time = 0;
            this.spectrum = new double[capacity];
        }

        public int Time
        {
            get
            {
                return this.time;
            }
        }

        internal void setTime(int newTime)
        {
            this.time = newTime;
        }
    }
}
