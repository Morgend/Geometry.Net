
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

        public bool IsCoDirectionalTo(Vector3 vector)
        {
            return this.valid && this.direction.IsCoDirectionalTo(vector);
        }

        public bool IsCoDirectionalTo(RayLine3 line)
        {
            return this.valid && line.valid && this.direction.IsCoDirectionalTo(line.direction);
        }

        public bool IsAntiDirectionalTo(Vector3 vector)
        {
            return this.valid && this.direction.IsAntiDirectionalTo(vector);
        }

        public bool IsAntiDirectionalTo(RayLine3 line)
        {
            return this.valid && line.valid && this.direction.IsAntiDirectionalTo(line.direction);
        }

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

        public bool IsEqualTo(RayLine3 line)
        {
            return this.IsCoDirectionalTo(line) && this.StartPoint.IsEqualTo(line.StartPoint);
        }

        public bool IsAtLine(Vector3 point)
        {
            return this.valid && this.direction.IsCoDirectionalTo(point - this.StartPoint);
        }

        public Angle AngleWith(Vector3 vector)
        {
            return this.direction.AngleWith(vector);
        }

        public Angle AngleWith(RayLine3 line)
        {
            return this.direction.AngleWith(line.direction);
        }

        public Angle AngleWith(StraightLine3 line)
        {
            return this.direction.AngleWith(line.Direction);
        }

        public Angle MinimalAngleWith(StraightLine3 line)
        {
            return line.MinimalAngleWith(this);
        }

        public Angle MaximalAngleWith(StraightLine3 line)
        {
            return line.MaximalAngleWith(this);
        }
    }
}
