
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
    }
}
