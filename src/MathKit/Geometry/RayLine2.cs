
namespace MathKit.Geometry
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

        public bool IsOrthogonal(Vector2 vector)
        {
            return this.valid && this.direction.IsOrthogonalTo(vector);
        }

        public bool IsOrthogonal(RayLine2 line)
        {
            return this.valid && line.valid && this.direction.IsOrthogonalTo(line.direction);
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
