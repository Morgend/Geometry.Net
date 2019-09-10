
/*
 * Author: Andrey Pokidov
 * Date: 30 Aug 2019
 */

namespace GeometryKit
{
    public struct RayLine3
    {
        public Vector3 StartPoint;

        private Vector3 direction;
        private bool valid;

        public RayLine3(Vector3 startPoint, Vector3 direction)
        {
            this.StartPoint = startPoint;
            this.direction = direction;
            this.direction.Normalize();
            this.valid = this.direction.IsZero();
        }

        public RayLine3(RayLine3 line)
        {
            this.StartPoint = line.StartPoint;
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

        public LineSegment3 Segment(double positionA, double positionB)
        {
            return new LineSegment3(StartPoint + positionA * direction, StartPoint + positionB * direction);
        }

        public StraightLine3 StraightLine()
        {
            return new StraightLine3(StartPoint, direction);
        }

        // ============= Parallelism check methods: =============

        public bool IsParallelTo(Vector3 vector)
        {
            return this.valid && this.direction.IsParallelTo(vector);
        }

        public bool IsParallelTo(RayLine3 line)
        {
            return this.valid && line.valid && this.direction.IsParallelTo(line.direction);
        }

        public bool IsParallelTo(StraightLine3 line)
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

        // ============= Co-direction check methods: =============

        public bool IsCoDirectionalTo(Vector3 vector)
        {
            return this.valid && this.direction.IsCoDirectionalTo(vector);
        }

        public bool IsCoDirectionalTo(RayLine3 line)
        {
            return this.valid && line.valid && this.direction.IsCoDirectionalTo(line.direction);
        }

        // ============= Anti-direction check methods: =============

        public bool IsAntiDirectionalTo(Vector3 vector)
        {
            return this.valid && this.direction.IsAntiDirectionalTo(vector);
        }

        public bool IsAntiDirectionalTo(RayLine3 line)
        {
            return this.valid && line.valid && this.direction.IsAntiDirectionalTo(line.direction);
        }

        // ============= Orthogonality check methods: =============

        public bool IsOrthogonalTo(Vector3 vector)
        {
            return this.valid && this.direction.IsOrthogonalTo(vector);
        }

        public bool IsOrthogonalTo(RayLine3 line)
        {
            return this.valid && line.valid && this.direction.IsOrthogonalTo(line.direction);
        }

        public bool IsOrthogonalTo(StraightLine3 line)
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

        public bool IsEqualTo(RayLine3 line)
        {
            return this.IsCoDirectionalTo(line) && this.StartPoint.IsEqualTo(line.StartPoint);
        }

        public bool IsAtLine(Vector3 point)
        {
            return this.valid && this.direction.IsCoDirectionalTo(point - this.StartPoint);
        }

        // ======================= Angles: ========================

        public Angle AngleWith(Vector3 vector)
        {
            return this.direction.AngleWith(vector);
        }

        public Angle AngleWith(RayLine3 line)
        {
            return this.direction.AngleWith(line.direction);
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
            if (!this.valid)
            {
                return Angle.ZERO;
            }

            return line.MinimalAngleWith(this.direction);
        }

        public Angle MinimalAngleWith(RayLine3 line)
        {
            if (!this.valid || !line.valid)
            {
                return Angle.ZERO;
            }

            return this.direction.MinimalAngleWithAxis(line.direction);
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
            if (!this.valid)
            {
                return Angle.ZERO;
            }

            return line.MaximalAngleWith(this.direction);
        }

        public Angle MaximalAngleWith(RayLine3 line)
        {
            if (!this.valid || !line.valid)
            {
                return Angle.ZERO;
            }

            return this.direction.MaximalAngleWithAxis(line.direction);
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
