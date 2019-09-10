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
        public static readonly Vector2 ZERO_VECTOR = new Vector2(0.0, 0.0);

        public static readonly Vector2 UNIT_X_VECTOR = new Vector2(1.0, 0.0);
        public static readonly Vector2 UNIT_Y_VECTOR = new Vector2(0.0, 1.0);

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

        public bool IsUnit()
        {
            double squareModule = x * x + y * y;
            return 1.0 - MathConstant.SQUARE_EPSYLON <= squareModule && squareModule <= 1.0 + MathConstant.SQUARE_EPSYLON;
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

        // ================== Reflecting 2D entities ==================

        public Vector2 Reflect(Vector2 point)
        {
            return new Vector2(2.0 * x - point.x, 2.0 * y - point.y);
        }

        public StraightLine2 Reflect(StraightLine2 line)
        {
            return new StraightLine2(Reflect(line.BasicPoint), -line.Direction);
        }

        public RayLine2 Reflect(RayLine2 line)
        {
            return new RayLine2(Reflect(line.StartPoint), -line.Direction);
        }

        public LineSegment2 Reflect(LineSegment2 segment)
        {
            return new LineSegment2(Reflect(segment.A), Reflect(segment.B));
        }

        public Triangle2 Reflect(Triangle2 triangle)
        {
            return new Triangle2(Reflect(triangle.A), Reflect(triangle.B), Reflect(triangle.C));
        }

        // ============================================================

        public Angle AngleWith(Vector2 vector)
        {
            double m1 = this.Scalar(this);
            double m2 = vector.Scalar(vector);

            if (m1 <= MathConstant.SQUARE_EPSYLON || m2 <= MathConstant.SQUARE_EPSYLON)
            {
                return Angle.ZERO;
            }

            double cos = this.Scalar(vector) / Math.Sqrt(m1 * m2);

            if (cos >= 1.0)
            {
                return Angle.ZERO;
            }
            else if (cos <= -1.0)
            {
                return Angle.AnglePI;
            }

            return new Angle(Math.Acos(cos));
        }

        public Angle MinimalAngleWithAxis(Vector2 vector)
        {
            Angle angle = this.AngleWith(vector);
            if (angle.Radians > Angle.PId2)
            {
                angle.Radians = Angle.PI - angle.Radians;
            }
            return angle;
        }

        public Angle MaximalAngleWithAxis(Vector2 vector)
        {
            Angle angle = this.AngleWith(vector);
            if (angle.Radians < Angle.PId2)
            {
                angle.Radians = Angle.PI - angle.Radians;
            }
            return angle;
        }

        public bool IsEqualTo(Vector2 v)
        {
            return Comparison.AreEqual(this.x, v.x) && Comparison.AreEqual(this.y, v.y);
        }

        public bool IsStrictlyEqualTo(Vector3 v)
        {
            return this.x == v.x && this.y == v.y;
        }

        // ============= Parallelism check methods: =============

        public bool IsParallelTo(Vector2 v)
        {
            return Comparison.AreEqual(this.x * v.y, this.y * v.x);
        }

        public bool IsParallelTo(StraightLine2 line)
        {
            return line.IsValid && this.IsParallelTo(line.Direction);
        }

        public bool IsParallelTo(RayLine2 line)
        {
            return line.IsValid && this.IsParallelTo(line.Direction);
        }

        public bool IsParallelTo(LineSegment2 segment3)
        {
            return this.IsParallelTo(segment3.B - segment3.A);
        }

        // ============= Co-direction check methods: =============

        public bool IsCoDirectionalTo(Vector2 v)
        {
            return this.IsParallelTo(v) && this.Scalar(v) >= 0;
        }

        public bool IsCoDirectionalTo(RayLine2 line)
        {
            return line.IsValid && this.IsCoDirectionalTo(line.Direction);
        }

        // ============= Anti-direction check methods: =============

        public bool IsAntiDirectionalTo(Vector2 v)
        {
            return this.IsParallelTo(v) && this.Scalar(v) < 0;
        }

        public bool IsAntiDirectionalTo(RayLine2 line)
        {
            return line.IsValid && this.IsAntiDirectionalTo(line.Direction);
        }

        // ============= Orthogonality check methods: =============

        public bool IsOrthogonalTo(Vector2 v)
        {
            double scalar = this.Scalar(v);
            return -MathConstant.SQUARE_EPSYLON <= scalar && scalar <= MathConstant.SQUARE_EPSYLON;
        }

        public bool IsOrthogonalTo(StraightLine2 line)
        {
            return line.IsValid && this.IsOrthogonalTo(line.Direction);
        }

        public bool IsOrthogonalTo(RayLine2 line)
        {
            return line.IsValid && this.IsOrthogonalTo(line.Direction);
        }

        public bool IsOrthogonalTo(LineSegment2 segment3)
        {
            return this.IsOrthogonalTo(segment3.B - segment3.A);
        }

        // ========================================================

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
