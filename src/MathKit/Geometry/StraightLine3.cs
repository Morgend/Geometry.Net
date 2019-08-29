
namespace MathKit.Geometry
{
    public struct StraightLine3
    {
        public Vector3 BasicPoint;

        private Vector3 direction;
        private bool degenerated;

        public StraightLine3(Vector3 basicPoint, Vector3 direction)
        {
            this.BasicPoint = basicPoint;
            this.direction = direction;
            this.direction.Normalize();
            this.degenerated = this.direction.IsZero();
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

        public bool IsParallelTo(Vector3 vector)
        {
            return !this.degenerated && this.direction.IsParallelTo(vector);
        }

        public bool IsParallelTo(StraightLine3 line)
        {
            return !this.degenerated && !line.degenerated && this.direction.IsParallelTo(line.direction);
        }

        public bool IsOrthogonal(Vector3 vector)
        {
            return !this.degenerated && this.direction.IsOrthogonalTo(vector);
        }

        public bool IsOrthogonal(StraightLine3 line)
        {
            return !this.degenerated && !line.degenerated && this.direction.IsOrthogonalTo(line.direction);
        }

        public bool IsOnLine(Vector3 point)
        {
            return !this.degenerated && this.direction.IsParallelTo(point - this.BasicPoint);
        }
    }
}
