using System;

/*
 * Author: Andrey Pokidov
 * Date: 1 Feb 2019
 */

namespace MathKit.Geometry
{
    public struct Vector2
    {
        public const double DEFAULT_COORDINATE_VALUE = 0.0;

        public double x;
        public double y;

        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2(Vector2 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        public void Zero()
        {
            this.x = DEFAULT_COORDINATE_VALUE;
            this.y = DEFAULT_COORDINATE_VALUE;
        }

        public void SetValues(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public void SetValues(Vector2 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        public double Scalar(Vector2 v)
        {
            return this.x * v.x + this.y * v.y;
        }

        public double Module()
        {
            return Math.Sqrt(this.x * this.x + this.y * this.y);
        }

        public void Normalize()
        {
            double module = this.Module();

            if (module < MathConst.EPSYLON)
            {
                this.Zero();
                return;
            }

            this.x /= module;
            this.y /= module;
        }

        public Vector2 GetNormalized()
        {
            Vector2 result = this;
            result.Normalize();
            return result;
        }

        public void Add(Vector2 v)
        {
            this.x += v.x;
            this.y += v.y;
        }

        public void Subtract(Vector2 v)
        {
            this.x -= v.x;
            this.y -= v.y;
        }

        public void Multiply(double value)
        {
            this.x *= value;
            this.y *= value;
        }

        public void Divide(double value)
        {
            this.x /= value;
            this.y /= value;
        }

        public void Reverse()
        {
            this.x = -this.x;
            this.y = -this.y;
        }

        public Vector2 GetReverted()
        {
            return new Vector2(-this.x, -this.y);
        }

        public Angle AngleWith(Vector2 vector)
        {
            double m1 = this.Module();
            double m2 = vector.Module();

            if (m1 < MathConst.EPSYLON || m2 < MathConst.EPSYLON)
            {
                return new Angle(0.0);
            }

            return new Angle(Math.Acos(this.Scalar(vector) / (m1 * m2)));
        }

        public bool IsParallelTo(Vector2 v)
        {
            return MathKit.AreEqual(this.x * v.y, this.y * v.x);
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }

        public static double operator *(Vector2 v1, Vector2 v2)
        {
            return v1.Scalar(v2);
        }

        public static Vector2 operator *(Vector2 vector, double value)
        {
            return new Vector2(vector.x * value, vector.y * value);
        }

        public static Vector2 operator *(double value, Vector2 vector)
        {
            return new Vector2(vector.x * value, vector.y * value);
        }

        public static Vector2 operator /(Vector2 vector, double value)
        {
            return new Vector2(vector.x / value, vector.y / value);
        }

        public static Vector2 operator -(Vector2 v)
        {
            return new Vector2(-v.x, -v.y);
        }

        public override string ToString()
        {
            return String.Format("Vector2({0}, {1})", this.x, this.y);
        }
    }
}
