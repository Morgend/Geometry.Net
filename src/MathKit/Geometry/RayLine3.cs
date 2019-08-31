
namespace MathKit.Geometry
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

        public bool IsEqualTo(RayLine3 line)
        {
            return this.valid && line.valid && this.StartPoint.IsEqualTo(line.StartPoint) && this.direction.IsCoDirectionalTo(line.direction);
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
