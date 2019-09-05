using System;

/*
 * Author: Andrey Pokidov
 * Date: 1 Sep 2019
 */

namespace GeometryKit
{
    public struct Plane
    {
        public Vector3 BasicPoint;

        private Vector3 normal;
        private bool valid;

        public Plane(Vector3 basicPoint, Vector3 normal)
        {
            this.BasicPoint = basicPoint;
            this.normal = normal;
            this.normal.Normalize();
            this.valid = !this.normal.IsZero();
        }

        public Plane(Plane plane)
        {
            this.BasicPoint = plane.BasicPoint;
            this.normal = plane.normal;
            this.valid = plane.valid;
        }

        public Vector3 Normal
        {
            get
            {
                return this.normal;
            }

            set
            {
                this.normal = value;
                this.normal.Normalize();
                this.valid = !this.normal.IsZero();
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
            return this.valid && this.normal.IsOrthogonalTo(vector);
        }

        public bool IsParallelTo(StraightLine3 line)
        {
            return this.valid && line.IsValid && this.normal.IsOrthogonalTo(line.Direction);
        }

        public bool IsParallelTo(RayLine3 line)
        {
            return this.valid && line.IsValid && this.normal.IsOrthogonalTo(line.Direction);
        }

        public bool IsParallelTo(Plane plane)
        {
            return this.valid && plane.valid && this.normal.IsParallelTo(plane.normal);
        }

        public bool IsOrthogonalTo(Vector3 vector)
        {
            return this.valid && this.normal.IsParallelTo(vector);
        }

        public bool IsOrthogonalTo(StraightLine3 line)
        {
            return this.valid && line.IsValid && this.normal.IsParallelTo(line.Direction);
        }

        public bool IsOrthogonalTo(RayLine3 line)
        {
            return this.valid && line.IsValid && this.normal.IsParallelTo(line.Direction);
        }

        public bool IsOrthogonalTo(Plane plane)
        {
            return this.valid && plane.valid && this.normal.IsOrthogonalTo(plane.normal);
        }

        public bool IsEqualTo(Plane plane)
        {
            return this.IsParallelTo(plane) && this.normal.IsOrthogonalTo(plane.BasicPoint - this.BasicPoint);
        }

        public bool IsAtPlane(Vector3 point)
        {
            return this.valid && this.normal.IsOrthogonalTo(point - this.BasicPoint);
        }

        public Vector3 ProjectionOf(Vector3 point)
        {
            if (!valid)
            {
                return Vector3.ZERO_VECTOR;
            }

            return point - (point - BasicPoint).Scalar(normal) * normal;
        }
    }
}
