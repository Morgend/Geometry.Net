
/*
 * Author: Andrey Pokidov
 * Date: 4 Sept 2019
 */

namespace MathKit.Geometry
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
    }
}
