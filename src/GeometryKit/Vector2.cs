using System;

/*
 * Author: Andrey Pokidov
 * Date: 1 Feb 2019
 */

namespace GeometryKit
{
    public struct Vector2
    {
        public const double DEFAULT_COORDINATE_VALUE = 0.0;
        public static readonly Vector2 ZERO_VECTOR = new Vector2(DEFAULT_COORDINATE_VALUE, DEFAULT_COORDINATE_VALUE);

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

        public bool IsZero()
        {
            return x * x + y * y <= MathConstant.SQUARE_EPSYLON;
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
            double squareModule = this.x * this.x + this.y * this.y;

            if (squareModule == 1.0 || squareModule == 0.0)
            {
                return;
            }

            if (squareModule < MathConstant.SQUARE_EPSYLON)
            {
                this.Zero();
                return;
            }

            double module = Math.Sqrt(squareModule);

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

            if (m1 < MathConstant.EPSYLON || m2 < MathConstant.EPSYLON)
            {
                return new Angle(0.0);
            }

            return new Angle(Math.Acos(this.Scalar(vector) / (m1 * m2)));
        }

        public bool IsEqualTo(Vector2 v)
        {
            return Comparison.AreEqual(this.x, v.x) && Comparison.AreEqual(this.y, v.y);
        }

        public bool IsStrictlyEqualTo(Vector3 v)
        {
            return this.x == v.x && this.y == v.y;
        }

        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            return v1.IsEqualTo(v2);
        }

        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            return !v1.IsEqualTo(v2);
        }

        public bool IsParallelTo(Vector2 v)
        {
            return Comparison.AreEqual(this.x * v.y, this.y * v.x);
        }

        public bool IsCoDirectionalTo(Vector2 v)
        {
            return this.IsParallelTo(v) && this.Scalar(v) >= 0;
        }

        public bool IsAntiDirectionalTo(Vector2 v)
        {
            return this.IsParallelTo(v) && this.Scalar(v) < 0;
        }

        public bool IsOrthogonalTo(Vector2 v)
        {
            double scalar = this.Scalar(v);
            return -MathConstant.SQUARE_EPSYLON <= scalar && scalar <= MathConstant.SQUARE_EPSYLON;
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
