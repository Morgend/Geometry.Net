using System;
using System.Collections.Generic;

namespace MathKit.Wavelet
{
    public class Sequence
    {
        private TimeValue[] points;
        private int amount;

        public Sequence(int capacity)
        {
            this.points = new TimeValue[capacity];
        }

        public int Capacity
        {
            get
            {
                return this.points.Length;
            }
        }

        public int Length
        {
            get
            {
                return this.amount;
            }
        }

        public bool isEmpty()
        {
            return this.amount == 0;
        }

        public void add(int time, double value)
        {
        }

        private int findIndex(int time)
        {
            if (this.isEmpty())
            {
                return 0;
            }

            return 0;
        }
    }
}
