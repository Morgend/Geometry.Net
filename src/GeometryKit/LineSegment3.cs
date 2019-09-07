
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

        public bool IsParallelTo(Vector3 vector)
        {
            return vector.IsParallelTo(B - A);
        }

        public bool IsParallelTo(StraightLine3 line)
        {
            return line.IsParallelTo(this);
        }

        public bool IsParallelTo(RayLine3 line)
        {
            return line.IsParallelTo(this);
        }

        public bool IsParallelTo(LineSegment3 segment)
        {
            return (B - A).IsParallelTo(segment.B - segment.A);
        }

        public bool IsOrthogonalTo(Vector3 vector)
        {
            return vector.IsOrthogonalTo(B - A);
        }

        public bool IsOrthogonalTo(StraightLine3 line)
        {
            return line.IsOrthogonalTo(this);
        }

        public bool IsOrthogonalTo(RayLine3 line)
        {
            return line.IsOrthogonalTo(this);
        }

        public bool IsOrthogonalTo(LineSegment3 segment)
        {
            return (B - A).IsOrthogonalTo(segment.B - segment.A);
        }

        public bool IsEqualTo(LineSegment3 line)
        {
            return (A.IsEqualTo(line.A) && B.IsEqualTo(line.B)) || (A.IsEqualTo(line.B) && B.IsEqualTo(line.A));
        }
    }
}
