
/*
 * Author: Andrey Pokidov
 * Date: 4 Sept 2019
 */

namespace GeometryKit
{
    public struct LineSegment3
    {
        public Vector3 A;
        public Vector3 B;

        public LineSegment3(Vector3 A, Vector3 B)
        {
            this.A = A;
            this.B = B;
        }

        public LineSegment3(LineSegment3 line)
        {
            this.A = line.A;
            this.B = line.B;
        }

        public double Length
        {
            get
            {
                return (B - A).Module();
            }
        }

        public Vector3 VectorAB
        {
            get
            {
                return B - A;
            }
        }

        public Vector3 VectorBA
        {
            get
            {
                return A - B;
            }
        }

        public Vector3 PointAt(double position)
        {
            return (1.0 - position) * A + position * B;
        }

        public RayLine3 RayAB()
        {
            return new RayLine3(A, B - A);
        }

        public RayLine3 RayBA()
        {
            return new RayLine3(B, A - B);
        }

        public StraightLine3 StraightLine()
        {
            return new StraightLine3(A, B - A);
        }

        // ============= Parallelism check methods: =============

        public bool IsParallelTo(Vector3 vector)
        {
            return vector.IsParallelTo(B - A);
        }

        public bool IsParallelTo(StraightLine3 line)
        {
            return line.IsValid && line.Direction.IsParallelTo(B - A);
        }

        public bool IsParallelTo(RayLine3 line)
        {
            return line.IsValid && line.Direction.IsParallelTo(B - A);
        }

        public bool IsParallelTo(LineSegment3 segment)
        {
            return (B - A).IsParallelTo(segment.B - segment.A);
        }

        public bool IsParallelTo(Plane plane)
        {
            return plane.IsValid && plane.Normal.IsOrthogonalTo(B - A);
        }

        // ============= Orthogonality check methods: =============

        public bool IsOrthogonalTo(Vector3 vector)
        {
            return vector.IsOrthogonalTo(B - A);
        }

        public bool IsOrthogonalTo(StraightLine3 line)
        {
            return line.IsValid && line.Direction.IsOrthogonalTo(B - A);
        }

        public bool IsOrthogonalTo(RayLine3 line)
        {
            return line.IsValid && line.Direction.IsOrthogonalTo(B - A);
        }

        public bool IsOrthogonalTo(LineSegment3 segment)
        {
            return (B - A).IsOrthogonalTo(segment.B - segment.A);
        }

        public bool IsOrthogonalTo(Plane plane)
        {
            return plane.IsValid && plane.Normal.IsParallelTo(B - A);
        }

        // ========================================================

        public bool IsEqualTo(LineSegment3 line)
        {
            return (A.IsEqualTo(line.A) && B.IsEqualTo(line.B)) || (A.IsEqualTo(line.B) && B.IsEqualTo(line.A));
        }

        // =================== Minimal angles: ====================

        public Angle MinimalAngleWith(Vector3 vector)
        {
            return this.VectorAB.MinimalAngleWithAxis(vector);
        }

        public Angle MinimalAngleWith(StraightLine3 line)
        {
            return line.MinimalAngleWith(this.VectorAB);
        }

        public Angle MinimalAngleWith(RayLine3 line)
        {
            return line.MinimalAngleWith(this.VectorAB);
        }

        public Angle MinimalAngleWith(LineSegment3 line)
        {
            return this.VectorAB.MinimalAngleWithAxis(line.VectorAB);
        }

        public Angle MinimalAngleWith(Plane plane)
        {
            return plane.MinimalAngleWith(this.VectorAB);
        }

        // =================== Maximal angles: ====================

        public Angle MaximalAngleWith(Vector3 vector)
        {
            return this.VectorAB.MaximalAngleWithAxis(vector);
        }

        public Angle MaximalAngleWith(StraightLine3 line)
        {
            return line.MaximalAngleWith(this.VectorAB);
        }

        public Angle MaximalAngleWith(RayLine3 line)
        {
            return line.MaximalAngleWith(this.VectorAB);
        }

        public Angle MaximalAngleWith(LineSegment3 line)
        {
            return this.VectorAB.MaximalAngleWithAxis(line.VectorAB);
        }

        public Angle MaximalAngleWith(Plane plane)
        {
            return plane.MaximalAngleWith(this.VectorAB);
        }
    }
}
