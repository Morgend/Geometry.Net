
namespace MathKit.Geometry
{
    public struct StraightLine2
    {
        public Vector2 BasicPoint;

        private Vector2 direction;
        private bool degenerated;

        public StraightLine2(Vector2 basicPoint, Vector2 direction)
        {
            this.BasicPoint = basicPoint;
            this.direction = direction;
            this.direction.Normalize();
            this.degenerated = this.direction.IsZero();
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
                this.degenerated = this.direction.IsZero();
            }
        }

        public bool IsDegenerated
        {
            get
            {
                return this.degenerated;
            }
        }

        public bool IsParallelTo(Vector2 vector)
        {
            return !this.degenerated && this.direction.IsParallelTo(vector);
        }

        public bool IsParallelTo(StraightLine2 line)
        {
            return !this.degenerated && !line.degenerated && this.direction.IsParallelTo(line.direction);
        }

        public bool IsOrthogonal(Vector2 vector)
        {
            return !this.degenerated && this.direction.IsOrthogonalTo(vector);
        }

        public bool IsOrthogonal(StraightLine2 line)
        {
            return !this.degenerated && !line.degenerated && this.direction.IsOrthogonalTo(line.direction);
        }

        public bool IsOnLine(Vector2 point)
        {
            return !this.degenerated && this.direction.IsParallelTo(point - this.BasicPoint);
        }
    }
}
