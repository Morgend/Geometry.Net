
/*
 * Author: Andrey Pokidov
 * Date: 30 Aug 2019
 */

namespace GeometryKit
{
    public struct RayLine2
    {
        public Vector2 StartPoint;

        private Vector2 direction;
        private bool valid;

        public RayLine2(Vector2 startPoint, Vector2 direction)
        {
            this.StartPoint = startPoint;
            this.direction = direction;
            this.direction.Normalize();
            this.valid = this.direction.IsZero();
        }

        public RayLine2(RayLine2 line)
        {
            this.StartPoint = line.StartPoint;
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

        public bool IsParallelTo(Vector2 vector)
        {
            return this.valid && this.direction.IsParallelTo(vector);
        }

        public bool IsParallelTo(RayLine2 line)
        {
            return this.valid && line.valid && this.direction.IsParallelTo(line.direction);
        }

        public bool IsParallelTo(StraightLine2 line)
        {
            return this.valid && line.IsValid && this.direction.IsParallelTo(line.Direction);
        }

        public bool IsParallelTo(LineSegment2 segment)
        {
            return this.valid && this.direction.IsParallelTo(segment.VectorAB);
        }

        public bool IsCoDirectionalTo(Vector2 vector)
        {
            return this.valid && this.direction.IsCoDirectionalTo(vector);
        }

        public bool IsCoDirectionalTo(RayLine2 line)
        {
            return this.valid && line.valid && this.direction.IsCoDirectionalTo(line.direction);
        }

        public bool IsAntiDirectionalTo(Vector2 vector)
        {
            return this.valid && this.direction.IsAntiDirectionalTo(vector);
        }

        public bool IsAntiDirectionalTo(RayLine2 line)
        {
            return this.valid && line.valid && this.direction.IsAntiDirectionalTo(line.direction);
        }

        public bool IsOrthogonalTo(Vector2 vector)
        {
            return this.valid && this.direction.IsOrthogonalTo(vector);
        }

        public bool IsOrthogonalTo(RayLine2 line)
        {
            return this.valid && line.valid && this.direction.IsOrthogonalTo(line.direction);
        }

        public bool IsOrthogonalTo(StraightLine2 line)
        {
            return this.valid && line.IsValid && this.direction.IsOrthogonalTo(line.Direction);
        }

        public bool IsOrthogonalTo(LineSegment2 segment)
        {
            return this.valid && this.direction.IsOrthogonalTo(segment.VectorAB);
        }

        public bool IsEqualTo(RayLine2 line)
        {
            return this.IsCoDirectionalTo(line) && this.StartPoint.IsEqualTo(line.StartPoint);
        }

        public bool IsAtLine(Vector2 point)
        {
            return this.valid && this.direction.IsCoDirectionalTo(point - this.StartPoint);
        }

        public Angle AngleWith(Vector2 vector)
        {
            return this.direction.AngleWith(vector);
        }

        public Angle AngleWith(RayLine2 line)
        {
            return this.direction.AngleWith(line.direction);
        }

        public Angle AngleWith(StraightLine2 line)
        {
            return this.direction.AngleWith(line.Direction);
        }

        public Angle MinimalAngleWith(StraightLine2 line)
        {
            return line.MinimalAngleWith(this);
        }

        public Angle MaximalAngleWith(StraightLine2 line)
        {
            return line.MaximalAngleWith(this);
        }
    }
}
