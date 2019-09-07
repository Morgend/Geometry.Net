
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
    }
}
