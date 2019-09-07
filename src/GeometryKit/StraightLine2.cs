
/*
 * Author: Andrey Pokidov
 * Date: 29 Aug 2019
 */

namespace GeometryKit
{
    public struct StraightLine2
    {
        public Vector2 BasicPoint;

        private Vector2 direction;
        private bool valid;

        public StraightLine2(Vector2 basicPoint, Vector2 direction)
        {
            this.BasicPoint = basicPoint;
            this.direction = direction;
            this.direction.Normalize();
            this.valid = !this.direction.IsZero();
        }

        public StraightLine2(StraightLine2 line)
        {
            this.BasicPoint = line.BasicPoint;
            this.direction = line.direction;
            this.valid = line.valid;
        }

        public Vector2 Direction
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

        // ============= Parallelism check methods: =============

        public bool IsParallelTo(Vector2 vector)
        {
            return this.valid && this.direction.IsParallelTo(vector);
        }

        public bool IsParallelTo(StraightLine2 line)
        {
            return this.valid && line.valid && this.direction.IsParallelTo(line.direction);
        }

        public bool IsParallelTo(RayLine2 line)
        {
            return this.valid && line.IsValid && this.direction.IsParallelTo(line.Direction);
        }

        public bool IsParallelTo(LineSegment2 segment)
        {
            return this.valid && this.direction.IsParallelTo(segment.VectorAB);
        }

        // ============= Orthogonality check methods: =============

        public bool IsOrthogonalTo(Vector2 vector)
        {
            return this.valid && this.direction.IsOrthogonalTo(vector);
        }

        public bool IsOrthogonalTo(StraightLine2 line)
        {
            return this.valid && line.valid && this.direction.IsOrthogonalTo(line.direction);
        }

        public bool IsOrthogonalTo(RayLine2 line)
        {
            return this.valid && line.IsValid && this.direction.IsOrthogonalTo(line.Direction);
        }

        public bool IsOrthogonalTo(LineSegment2 segment)
        {
            return this.valid && this.direction.IsOrthogonalTo(segment.VectorAB);
        }

        // ========================================================

        public bool IsEqualTo(StraightLine2 line)
        {
            return this.IsParallelTo(line) && this.direction.IsParallelTo(line.BasicPoint - this.BasicPoint);
        }

        public bool IsAtLine(Vector2 point)
        {
            return this.valid && this.direction.IsParallelTo(point - this.BasicPoint);
        }

        public Angle AngleWith(Vector2 vector)
        {
            return this.direction.AngleWith(vector);
        }

        public Angle AngleWith(StraightLine2 line)
        {
            return this.direction.AngleWith(line.Direction);
        }

        public Angle AngleWith(RayLine2 line)
        {
            return this.direction.AngleWith(line.Direction);
        }

        public Angle MinimalAngleWith(Vector2 vector)
        {
            return MinimalAngleBetweenLines(this.direction.AngleWith(vector));
        }

        public Angle MinimalAngleWith(StraightLine2 line)
        {
            if (!this.valid || !line.valid)
            {
                return new Angle();
            }

            return MinimalAngleBetweenLines(this.direction.AngleWith(line.direction));
        }

        public Angle MinimalAngleWith(RayLine2 line)
        {
            if (!this.valid || !line.IsValid)
            {
                return new Angle();
            }

            return MinimalAngleBetweenLines(this.direction.AngleWith(line.Direction));
        }

        public Angle MaximalAngleWith(Vector2 vector)
        {
            if (!this.valid || vector.IsZero())
            {
                return new Angle();
            }

            return MaximalAngleBetweenLines(this.direction.AngleWith(vector));
        }

        public Angle MaximalAngleWith(StraightLine2 line)
        {
            if (!this.valid || !line.valid)
            {
                return new Angle();
            }

            return MaximalAngleBetweenLines(this.direction.AngleWith(line.direction));
        }

        public Angle MaximalAngleWith(RayLine2 line)
        {
            if (!this.valid || !line.IsValid)
            {
                return new Angle();
            }

            return MaximalAngleBetweenLines(this.direction.AngleWith(line.Direction));
        }

        private static Angle MinimalAngleBetweenLines(Angle angle)
        {
            if (angle.Radians > MathConstant.PId2)
            {
                angle.Radians = MathConstant.PI - angle.Radians;
            }

            return angle;
        }

        private static Angle MaximalAngleBetweenLines(Angle angle)
        {
            if (angle.Radians < MathConstant.PId2)
            {
                angle.Radians = MathConstant.PI - angle.Radians;
            }

            return angle;
        }
    }
}
