
/*
 * Author: Andrey Pokidov
 * Date: 29 Aug 2019
 */

namespace Geometry
{
    public struct StraightLine3
    {
        public Vector3 BasicPoint;

        private Vector3 direction;
        private bool valid;

        public StraightLine3(Vector3 basicPoint, Vector3 direction)
        {
            this.BasicPoint = basicPoint;
            this.direction = direction;
            this.direction.Normalize();
            this.valid = !this.direction.IsZero();
        }

        public StraightLine3(StraightLine3 line)
        {
            this.BasicPoint = line.BasicPoint;
            this.direction = line.direction;
            this.valid = line.valid;
        }

        public Vector3 Direction
        {
            get
            {
                return direction;
            }

            set
            {
                this.direction = value;
                this.direction.Normalize();
                this.valid = !this.direction.IsZero();
            }
        }

        public bool IsValid
        {
            get
            {
                return this.valid;
            }
        }

        public Vector3 PointAt(double position)
        {
            return BasicPoint + direction * position;
        }

        public LineSegment3 Segment(double positionA, double positionB)
        {
            return new LineSegment3(BasicPoint + positionA * direction, BasicPoint + positionB * direction);
        }

        public RayLine3 Ray()
        {
            return new RayLine3(BasicPoint, direction);
        }

        // ================== Reflecting 3D entities ==================

        public Vector3 Reflect(Vector3 point)
        {
            if (!this.valid)
            {
                return point;
            }

            return RelativelyReflect(point - BasicPoint) + BasicPoint;
        }

        public Vector3 RelativelyReflect(Vector3 vector)
        {
            if (!this.valid)
            {
                return vector;
            }

            return (2.0 * direction.Scalar(vector)) * direction - vector;
        }

        public StraightLine3 Reflect(StraightLine3 line)
        {
            if (!this.valid)
            {
                return line;
            }

            return new StraightLine3(Reflect(line.BasicPoint), RelativelyReflect(line.Direction));
        }

        public RayLine3 Reflect(RayLine3 line)
        {
            if (!this.valid)
            {
                return line;
            }

            return new RayLine3(Reflect(line.StartPoint), RelativelyReflect(line.Direction));
        }

        public LineSegment3 Reflect(LineSegment3 segment)
        {
            if (!this.valid)
            {
                return segment;
            }

            return new LineSegment3(Reflect(segment.A), Reflect(segment.B));
        }

        public Plane Reflect(Plane plane)
        {
            return new Plane(Reflect(plane.BasicPoint), RelativelyReflect(plane.Normal));
        }

        public Triangle3 Reflect(Triangle3 triangle)
        {
            if (!this.valid)
            {
                return triangle;
            }

            return new Triangle3(Reflect(triangle.A), Reflect(triangle.B), Reflect(triangle.C));
        }

        // ============= Parallelism check methods: =============

        public bool IsParallelTo(Vector3 vector)
        {
            return this.valid && this.direction.IsParallelTo(vector);
        }

        public bool IsParallelTo(StraightLine3 line)
        {
            return this.valid && line.valid && this.direction.IsParallelTo(line.direction);
        }

        public bool IsParallelTo(RayLine3 line)
        {
            return this.valid && line.IsValid && this.direction.IsParallelTo(line.Direction);
        }

        public bool IsParallelTo(LineSegment3 segment)
        {
            return this.valid && this.direction.IsParallelTo(segment.VectorAB);
        }

        public bool IsParallelTo(Plane plane)
        {
            return this.valid && plane.IsValid && this.direction.IsOrthogonalTo(plane.Normal);
        }

        // ============= Orthogonality check methods: =============

        public bool IsOrthogonalTo(Vector3 vector)
        {
            return this.valid && this.direction.IsOrthogonalTo(vector);
        }

        public bool IsOrthogonalTo(StraightLine3 line)
        {
            return this.valid && line.valid && this.direction.IsOrthogonalTo(line.direction);
        }

        public bool IsOrthogonalTo(RayLine3 line)
        {
            return this.valid && line.IsValid && this.direction.IsOrthogonalTo(line.Direction);
        }

        public bool IsOrthogonalTo(LineSegment3 segment)
        {
            return this.valid && this.direction.IsOrthogonalTo(segment.VectorAB);
        }

        public bool IsOrthogonalTo(Plane plane)
        {
            return this.valid && plane.IsValid && this.direction.IsParallelTo(plane.Normal);
        }

        // ========================================================

        public bool IsEqualTo(StraightLine3 line)
        {
            return this.IsParallelTo(line) && this.direction.IsParallelTo(line.BasicPoint - this.BasicPoint);
        }

        public bool IsAtLine(Vector3 point)
        {
            return this.valid && this.direction.IsParallelTo(point - this.BasicPoint);
        }

        // =================== Minimal angles: ====================

        public Angle MinimalAngleWith(Vector3 vector)
        {
            if (!this.valid)
            {
                return Angle.ZERO;
            }

            return this.direction.MinimalAngleWithAxis(vector);
        }

        public Angle MinimalAngleWith(StraightLine3 line)
        {
            if (!this.valid || !line.valid)
            {
                return Angle.ZERO;
            }

            return this.direction.MinimalAngleWithAxis(line.direction);
        }

        public Angle MinimalAngleWith(RayLine3 line)
        {
            if (!this.valid)
            {
                return Angle.ZERO;
            }

            return line.MinimalAngleWith(this.direction);
        }

        public Angle MinimalAngleWith(LineSegment3 line)
        {
            if (!this.valid)
            {
                return Angle.ZERO;
            }

            return this.direction.MinimalAngleWithAxis(line.VectorAB);
        }

        public Angle MinimalAngleWith(Plane plane)
        {
            if (!this.valid)
            {
                return Angle.ZERO;
            }

            return plane.MinimalAngleWith(this.direction);
        }


        // =================== Maximal angles: ====================

        public Angle MaximalAngleWith(Vector3 vector)
        {
            if (!this.valid)
            {
                return Angle.ZERO;
            }

            return this.direction.MaximalAngleWithAxis(vector);
        }

        public Angle MaximalAngleWith(StraightLine3 line)
        {
            if (!this.valid || !line.valid)
            {
                return Angle.ZERO;
            }

            return this.direction.MaximalAngleWithAxis(line.direction);
        }

        public Angle MaximalAngleWith(RayLine3 line)
        {
            if (!this.valid)
            {
                return Angle.ZERO;
            }

            return line.MaximalAngleWith(this.direction);
        }

        public Angle MaximalAngleWith(LineSegment3 line)
        {
            if (!this.valid)
            {
                return Angle.ZERO;
            }

            return this.direction.MaximalAngleWithAxis(line.VectorAB);
        }

        public Angle MaximalAngleWith(Plane plane)
        {
            if (!this.valid)
            {
                return Angle.ZERO;
            }

            return plane.MaximalAngleWith(this.direction);
        }
    }
}
