using System;

/*
 * Author: Andrey Pokidov
 * Date: 1 Feb 2019
 */

namespace MathKit.Geometry
{
    public struct Quaternion
    {
        public const double DEFAULT_COORDINATE_VALUE = 0.0;

        public double w;
        public double x;
        public double y;
        public double z;

        public Quaternion(double w, double x, double y, double z)
        {
            this.w = w;
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void SetValues(double w, double x, double y, double z)
        {
            this.w = w;
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void SetValues(Quaternion q)
        {
            this.x = q.x;
            this.y = q.y;
            this.z = q.z;
            this.w = q.w;
        }

        public void Zero()
        {
            this.x = DEFAULT_COORDINATE_VALUE;
            this.y = DEFAULT_COORDINATE_VALUE;
            this.z = DEFAULT_COORDINATE_VALUE;
            this.w = DEFAULT_COORDINATE_VALUE;
        }

        public void Conjugate()
        {
            this.x = -this.x;
            this.y = -this.y;
            this.z = -this.z;
        }

        public Quaternion GetConjugated()
        {
            return new Quaternion(this.w, - this.x, -this.y, -this.z);
        }

        public double Module()
        {
            return Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w);
        }

        public void Mormalize()
        {
            double module = this.Module();

            if (module < MathConst.EPSYLON)
            {
                this.Zero();
                return;
            }

            this.x /= module;
            this.y /= module;
            this.z /= module;
            this.w /= module;
        }

        public Quaternion Multiply(Quaternion q)
        {
            return new Quaternion(
                this.w * q.w - this.x * q.x - this.y * q.y - this.z * q.z,
                this.y * q.z - this.z * q.y + this.w * q.x + this.x * q.w,
                this.x * q.z - this.z * q.x + this.w * q.y + this.y * q.w,
                this.x * q.y - this.y * q.x + this.w * q.z + this.z * q.w
            );
        }

        public void MultiplyAt(Quaternion q)
        {
            this.SetValues(
                this.w * q.w - this.x * q.x - this.y * q.y - this.z * q.z,
                this.y * q.z - this.z * q.y + this.w * q.x + this.x * q.w,
                this.x * q.z - this.z * q.x + this.w * q.y + this.y * q.w,
                this.x * q.y - this.y * q.x + this.w * q.z + this.z * q.w
            );
        }

        public void SetMultiplicationOf(Quaternion q1, Quaternion q2)
        {
            this.SetValues(
                q1.w * q2.w - q1.x * q2.x - q1.y * q2.y - q1.z * q2.z,
                q1.y * q2.z - q1.z * q2.y + q1.w * q2.x + q1.x * q2.w,
                q1.x * q2.z - q1.z * q2.x + q1.w * q2.y + q1.y * q2.w,
                q2.x * q2.y - q1.y * q2.x + q1.w * q2.z + q1.z * q2.w
            );
        }

        public Quaternion Multiply(double value)
        {
            return new Quaternion(this.w * value, this.x * value, this.y * value, this.z * value);
        }

        public void MultiplyAt(double value)
        {
            this.x *= value;
            this.y *= value;
            this.z *= value;
            this.w *= value;
        }

        public Quaternion Divide(double value)
        {
            return new Quaternion(this.w / value, this.x / value, this.y / value, this.z / value);
        }

        public void DivideAt(double value)
        {
            this.x /= value;
            this.y /= value;
            this.z /= value;
            this.w /= value;
        }

        public static Quaternion operator *(Quaternion q1, Quaternion q2)
        {
            return q1.Multiply(q2);
        }

        public static Quaternion operator *(Quaternion quaternion, double value)
        {
            return quaternion.Multiply(value);
        }

        public static Quaternion operator *(double value, Quaternion quaternion)
        {
            return quaternion.Multiply(value);
        }

        public static Quaternion operator /(Quaternion quaternion, double value)
        {
            return quaternion.Divide(value);
        }

        public static Quaternion operator -(Quaternion q)
        {
            return q.GetConjugated();
        }

        public override string ToString()
        {
            return String.Format("Quaternion(w: {0}, x: {1}, y: {2}, z: {3})", this.w, this.x, this.y, this.z);
        }
    }
}
