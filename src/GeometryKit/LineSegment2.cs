
/*
 * Author: Andrey Pokidov
 * Date: 4 Sept 2019
 */

namespace GeometryKit
{
    public struct LineSegment2
    {
        public Vector2 A;
        public Vector2 B;

        public LineSegment2(Vector2 A, Vector2 B)
        {
            this.A = A;
            this.B = B;
        }

        public LineSegment2(LineSegment2 line)
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

        public Vector2 VectorAB
        {
            get
            {
                return B - A;
            }
        }

        public Vector2 VectorBA
        {
            get
            {
                return A - B;
            }
        }

        public bool IsParallelTo(Vector2 vector)
        {
            return vector.IsParallelTo(B - A);
        }

        public bool IsParallelTo(StraightLine2 line)
        {
            return line.IsParallelTo(this);
        }

        public bool IsParallelTo(RayLine2 line)
        {
            return line.IsParallelTo(this);
        }

        public bool IsParallelTo(LineSegment2 segment)
        {
            return (B - A).IsParallelTo(segment.B - segment.A);
        }

        public bool IsOrthogonalTo(Vector2 vector)
        {
            return vector.IsOrthogonalTo(B - A);
        }

        public bool IsOrthogonalTo(StraightLine2 line)
        {
            return line.IsOrthogonalTo(this);
        }

        public bool IsOrthogonalTo(RayLine2 line)
        {
            return line.IsOrthogonalTo(this);
        }

        public bool IsOrthogonalTo(LineSegment2 segment)
        {
            return (B - A).IsOrthogonalTo(segment.B - segment.A);
        }

        public bool IsEqualTo(LineSegment2 line)
        {
            return (A.IsEqualTo(line.A) && B.IsEqualTo(line.B)) || (A.IsEqualTo(line.B) && B.IsEqualTo(line.A));
        }

        public static bool operator ==(LineSegment2 line1, LineSegment2 line2)
        {
            return line1.IsEqualTo(line2);
        }

        public static bool operator !=(LineSegment2 line1, LineSegment2 line2)
        {
            return !line1.IsEqualTo(line2);
        }
    }
}
