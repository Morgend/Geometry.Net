
namespace MathKit.Geometry
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

        public bool IsParallelTo(StraightLine3 line)
        {
            return this.valid && line.valid && this.direction.IsParallelTo(line.direction);
        }

        public bool IsOrthogonal(Vector3 vector)
        {
            return this.valid && this.direction.IsOrthogonalTo(vector);
        }

        public bool IsOrthogonal(StraightLine3 line)
        {
            return this.valid && line.valid && this.direction.IsOrthogonalTo(line.direction);
        }

        public bool IsAtLine(Vector3 point)
        {
            return this.valid && this.direction.IsParallelTo(point - this.BasicPoint);
        }

        public Angle AngleWith(Vector3 vector)
        {
            return this.direction.AngleWith(vector);
        }

        public Angle AngleWith(StraightLine3 line)
        {
            return this.direction.AngleWith(line.Direction);
        }

        public Angle AngleWith(RayLine3 line)
        {
            return this.direction.AngleWith(line.Direction);
        }

        public Angle MinimalAngleWith(Vector3 vector)
        {
            return MinimalAngleBetweenLines(this.direction.AngleWith(vector));
        }

        public Angle MinimalAngleWith(StraightLine3 line)
        {
            if (!this.valid || !line.valid)
            {
                return new Angle();
            }

            return MinimalAngleBetweenLines(this.direction.AngleWith(line.direction));
        }

        public Angle MinimalAngleWith(RayLine3 line)
        {
            if (!this.valid || !line.IsValid)
            {
                return new Angle();
            }

            return MinimalAngleBetweenLines(this.direction.AngleWith(line.Direction));
        }

        public Angle MaximalAngleWith(Vector3 vector)
        {
            if (!this.valid || vector.IsZero())
            {
                return new Angle();
            }

            return MaximalAngleBetweenLines(this.direction.AngleWith(vector));
        }

        public Angle MaximalAngleWith(StraightLine3 line)
        {
            if (!this.valid || !line.valid)
            {
                return new Angle();
            }

            return MaximalAngleBetweenLines(this.direction.AngleWith(line.direction));
        }

        public Angle MaximalAngleWith(RayLine3 line)
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
