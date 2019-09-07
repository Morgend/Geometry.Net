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

        // ============= Parallelism check methods: =============

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

        public bool IsParallelTo(LineSegment3 line)
        {
            return this.valid && this.normal.IsOrthogonalTo(line.VectorAB);
        }

        public bool IsParallelTo(Plane plane)
        {
            return this.valid && plane.valid && this.normal.IsParallelTo(plane.normal);
        }

        // ============= Orthogonality check methods: =============

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

        public bool IsOrthogonalTo(LineSegment3 line)
        {
            return this.valid && this.normal.IsParallelTo(line.VectorAB);
        }

        // ========================================================

        public bool IsEqualTo(Plane plane)
        {
            return this.IsParallelTo(plane) && this.normal.IsOrthogonalTo(plane.BasicPoint - this.BasicPoint);
        }


        public bool IsAtPlane(Vector3 point)
        {
            return this.valid && this.normal.IsOrthogonalTo(point - this.BasicPoint);
        }

        // =================== Minimal angles: ====================

        public Angle MinimalAngleWith(Vector3 vector)
        {
            if (!this.valid)
            {
                return Angle.ZERO;
            }

            return Angle.PId2 - this.normal.AngleWith(vector);
        }

        public Angle MinimalAngleWith(StraightLine3 line)
        {
            if (!this.valid || !line.IsValid)
            {
                return Angle.ZERO;
            }

            return Angle.PId2 - this.normal.AngleWith(line.Direction);
        }

        public Angle MinimalAngleWith(RayLine3 line)
        {
            if (!this.valid || !line.IsValid)
            {
                return Angle.ZERO;
            }

            return Angle.PId2 - this.normal.AngleWith(line.Direction);
        }

        public Angle MinimalAngleWith(LineSegment3 line)
        {
            if (!this.valid)
            {
                return Angle.ZERO;
            }

            return Angle.PId2 - this.normal.AngleWith(line.VectorAB);
        }

        public Angle MinimalAngleWith(Plane plane)
        {
            if (!this.valid || !plane.valid)
            {
                return Angle.ZERO;
            }

            return this.normal.MinimalAngleWithAxis(plane.normal);
        }

        // =================== Maximal angles: ====================

        public Angle MaximalAngleWith(Vector3 vector)
        {
            if (!this.valid)
            {
                return Angle.ZERO;
            }

            return Angle.PId2 + this.normal.AngleWith(vector);
        }

        public Angle MaximalAngleWith(StraightLine3 line)
        {
            if (!this.valid || !line.IsValid)
            {
                return Angle.ZERO;
            }

            return Angle.PId2 + this.normal.AngleWith(line.Direction);
        }

        public Angle MaximalAngleWith(RayLine3 line)
        {
            if (!this.valid || !line.IsValid)
            {
                return Angle.ZERO;
            }

            return Angle.PId2 + this.normal.AngleWith(line.Direction);
        }

        public Angle MaximalAngleWith(LineSegment3 line)
        {
            if (!this.valid)
            {
                return Angle.ZERO;
            }

            return Angle.PId2 + this.normal.AngleWith(line.VectorAB);
        }

        public Angle MaximalAngleWith(Plane plane)
        {
            if (!this.valid || !plane.valid)
            {
                return Angle.ZERO;
            }

            return this.normal.MaximalAngleWithAxis(plane.normal);
        }

        // ========================================================

        public Vector3 ProjectionOf(Vector3 point)
        {
            if (!valid)
            {
                return Vector3.ZERO_VECTOR;
            }

            return point - (point - BasicPoint).Scalar(normal) * normal;
        }

        public PlaneCoordinateSystem MakeRightCoordinateSystem(Vector3 protoX)
        {
            if (!valid)
            {
                return new PlaneCoordinateSystem(); // Return invalid coordinate system
            }

            Vector3 xVector = protoX - normal * normal.Scalar(protoX);

            return new PlaneCoordinateSystem(this.BasicPoint, xVector, normal.Vector(xVector));
        }

        public PlaneCoordinateSystem MakeLeftCoordinateSystem(Vector3 protoX)
        {
            if (!valid)
            {
                return new PlaneCoordinateSystem(); // Return invalid coordinate system
            }

            Vector3 xVector = protoX - normal * normal.Scalar(protoX);

            return new PlaneCoordinateSystem(this.BasicPoint, xVector, xVector.Vector(normal));
        }
    }
}
