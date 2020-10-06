using System;

/*
 * Author: Andrey Pokidov
 * Date: 1 Feb 2019
 */

namespace Geometry
{
    public struct Vector3
    {
        public const double DEFAULT_COORDINATE_VALUE = 0.0;
        public static readonly Vector3 ZERO_VECTOR = new Vector3(0.0, 0.0, 0.0);

        public static readonly Vector3 UNIT_X_VECTOR = new Vector3(1.0, 0.0, 0.0);
        public static readonly Vector3 UNIT_Y_VECTOR = new Vector3(0.0, 1.0, 0.0);
        public static readonly Vector3 UNIT_Z_VECTOR = new Vector3(0.0, 0.0, 1.0);

        public double x;
        public double y;
        public double z;

        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(Vector3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        public void SetToZero()
        {
            this.x = DEFAULT_COORDINATE_VALUE;
            this.y = DEFAULT_COORDINATE_VALUE;
            this.z = DEFAULT_COORDINATE_VALUE;
        }

        public bool IsZero()
        {
            return x * x + y * y + z * z <= MathConstant.SQUARE_EPSYLON;
        }

        public bool IsUnit()
        {
            double squareModule = x * x + y * y + z * z;
            return 1.0 - MathConstant.SQUARE_EPSYLON <= squareModule && squareModule <= 1.0 + MathConstant.SQUARE_EPSYLON;
        }

        public void SetValues(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void CopyValuesOf(Vector3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        public double Scalar(Vector3 v)
        {
            return this.x * v.x + this.y * v.y + this.z * v.z;
        }

        public Vector3 Vector(Vector3 v)
        {
            return new Vector3(
                this.y * v.z - this.z * v.y,
                this.z * v.x - this.x * v.z,
                this.x * v.y - this.y * v.x
            );
        }

        public double Module()
        {
            return Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
        }

        public void Normalize()
        {
            double squareModule = this.x * this.x + this.y * this.y + this.z * this.z;

            if (squareModule == 1.0 || squareModule == 0.0)
            {
                return;
            }

            if (squareModule < MathConstant.SQUARE_EPSYLON)
            {
                this.SetToZero();
                return;
            }

            double module = Math.Sqrt(squareModule);

            this.x /= module;
            this.y /= module;
            this.z /= module;
        }

        public Vector3 GetNormalized()
        {
            Vector3 result = this;
            result.Normalize();
            return result;
        }

        public void Add(Vector3 v)
        {
            this.x += v.x;
            this.y += v.y;
            this.z += v.z;
        }

        public void Subtract(Vector3 v)
        {
            this.x -= v.x;
            this.y -= v.y;
            this.z -= v.z;
        }

        public void Multiply(double value)
        {
            this.x *= value;
            this.y *= value;
            this.z *= value;
        }

        public void VectorMultiplyAt(Vector3 vector)
        {
            this.SetValues(
                this.y * vector.z - this.z * vector.y,
                this.z * vector.x - this.x * vector.z,
                this.x * vector.y - this.y * vector.x
           );
        }

        public void Divide(double value)
        {
            this.x /= value;
            this.y /= value;
            this.z /= value;
        }

        public void Reverse()
        {
            this.x = -this.x;
            this.y = -this.y;
            this.z = -this.z;
        }

        public Vector3 GetReverted()
        {
            return new Vector3(-this.x, -this.y, -this.z);
        }

        // ================== Reflecting 3D entities ==================

        public Vector3 Reflect(Vector3 point)
        {
            return new Vector3(2.0 * x - point.x, 2.0 * y - point.y, 2.0 * z - point.z);
        }

        public StraightLine3 Reflect(StraightLine3 line)
        {
            return new StraightLine3(Reflect(line.BasicPoint), -line.Direction);
        }

        public RayLine3 Reflect(RayLine3 line)
        {
            return new RayLine3(Reflect(line.StartPoint), -line.Direction);
        }

        public LineSegment3 Reflect(LineSegment3 segment)
        {
            return new LineSegment3(Reflect(segment.A), Reflect(segment.B));
        }

        public Plane Reflect(Plane plane)
        {
            return new Plane(Reflect(plane.BasicPoint), -plane.Normal);
        }

        public Triangle3 Reflect(Triangle3 triangle)
        {
            return new Triangle3(Reflect(triangle.A), Reflect(triangle.B), Reflect(triangle.C));
        }

        // ============================================================

        public Angle AngleWith(Vector3 vector)
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

        public Angle MinimalAngleWithAxis(Vector3 vector)
        {
            Angle angle = this.AngleWith(vector);
            if (angle.Radians > Angle.PId2)
            {
                angle.Radians = Angle.PI - angle.Radians;
            }
            return angle;
        }

        public Angle MaximalAngleWithAxis(Vector3 vector)
        {
            Angle angle = this.AngleWith(vector);
            if (angle.Radians < Angle.PId2)
            {
                angle.Radians = Angle.PI - angle.Radians;
            }
            return angle;
        }

        public bool IsEqualTo(Vector3 v)
        {
            return Comparison.AreEqual(this.x, v.x) && Comparison.AreEqual(this.y, v.y) && Comparison.AreEqual(this.z, v.z);
        }

        public bool IsStrictlyEqualTo(Vector3 v)
        {
            return this.x == v.x && this.y == v.y && this.z == v.z;
        }

        // ============= Parallelism check methods: =============

        public bool IsParallelTo(Vector3 v)
        {
            return Comparison.AreEqual(this.x * v.y, this.y * v.x) && Comparison.AreEqual(this.x * v.z, this.z * v.x) && Comparison.AreEqual(this.y * v.z, this.z * v.y);
        }

        public bool IsParallelTo(StraightLine3 line)
        {
            return line.IsValid && this.IsParallelTo(line.Direction);
        }

        public bool IsParallelTo(RayLine3 line)
        {
            return line.IsValid && this.IsParallelTo(line.Direction);
        }

        public bool IsParallelTo(LineSegment3 segment3)
        {
            return this.IsParallelTo(segment3.B - segment3.A);
        }

        public bool IsParallelTo(Plane plane)
        {
            return plane.IsValid && this.IsOrthogonalTo(plane.Normal);
        }

        // ============= Co-direction check methods: =============

        public bool IsCoDirectionalTo(Vector3 v)
        {
            return this.IsParallelTo(v) && this.Scalar(v) >= 0;
        }

        public bool IsCoDirectionalTo(RayLine3 line)
        {
            return line.IsValid && this.IsCoDirectionalTo(line.Direction);
        }

        // ============= Anti-direction check methods: =============

        public bool IsAntiDirectionalTo(Vector3 v)
        {
            return this.IsParallelTo(v) && this.Scalar(v) < 0;
        }

        public bool IsAntiDirectionalTo(RayLine3 line)
        {
            return line.IsValid && this.IsAntiDirectionalTo(line.Direction);
        }

        // ============= Orthogonality check methods: =============

        public bool IsOrthogonalTo(Vector3 v)
        {
            double scalar = this.Scalar(v);
            return -MathConstant.SQUARE_EPSYLON <= scalar && scalar <= MathConstant.SQUARE_EPSYLON;
        }

        public bool IsOrthogonalTo(StraightLine3 line)
        {
            return line.IsValid && this.IsOrthogonalTo(line.Direction);
        }

        public bool IsOrthogonalTo(RayLine3 line)
        {
            return line.IsValid && this.IsOrthogonalTo(line.Direction);
        }

        public bool IsOrthogonalTo(LineSegment3 segment3)
        {
            return this.IsOrthogonalTo(segment3.B - segment3.A);
        }

        public bool IsOrthogonalTo(Plane plane)
        {
            return plane.IsValid && this.IsParallelTo(plane.Normal);
        }

        // ========================================================

        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector3 operator *(Vector3 vector, double value)
        {
            return new Vector3(vector.x * value, vector.y * value, vector.z * value);
        }

        public static Vector3 operator *(double value, Vector3 vector)
        {
            return new Vector3(vector.x * value, vector.y * value, vector.z * value);
        }

        public static Vector3 operator /(Vector3 vector, double value)
        {
            return new Vector3(vector.x / value, vector.y / value, vector.z / value);
        }

        public static Vector3 operator -(Vector3 v)
        {
            return new Vector3(-v.x, -v.y, -v.z);
        }

        public override string ToString()
        {
            return String.Format("Vector3({0}, {1}, {2})", this.x, this.y, this.z);
        }
    }
}
