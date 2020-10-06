using System;

/*
 * Author: Andrey Pokidov
 * Date: 23 Aug 2019
 */

namespace Geometry
{
    public struct Triangle2
    {
        public Vector2 A;
        public Vector2 B;
        public Vector2 C;

        public Triangle2(Vector2 A, Vector2 B, Vector2 C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }
        public Triangle2(Triangle2 anotherTriangle)
        {
            A = anotherTriangle.A;
            B = anotherTriangle.B;
            C = anotherTriangle.C;
        }

        public LineSegment2 SideAB
        {
            get
            {
                return new LineSegment2(A, B);
            }
        }

        public LineSegment2 SideBC
        {
            get
            {
                return new LineSegment2(B, C);
            }
        }

        public LineSegment2 SideCA
        {
            get
            {
                return new LineSegment2(C, A);
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

        public Vector2 VectorBC
        {
            get
            {
                return C - B;
            }
        }

        public Vector2 VectorCB
        {
            get
            {
                return B - C;
            }
        }

        public Vector2 VectorCA
        {
            get
            {
                return A - C;
            }
        }

        public Vector2 VectorAC
        {
            get
            {
                return C - A;
            }
        }

        public bool IsDegenerated()
        {
            return (B - A).IsParallelTo(C - A);
        }

        public Angle AngleA()
        {
            return (B - A).AngleWith(C - A);
        }

        public Angle AngleB()
        {
            return (C - B).AngleWith(A - B);
        }

        public Angle AngleC()
        {
            return (A - C).AngleWith(B - C);
        }

        public double Square()
        {
            return 0.5 * Math.Abs((B.x - A.x) * (C.y - A.y) - (B.y - A.y) * (C.x - A.x));
        }

        public Vector2 MedianCentre()
        {
            return (A + B + C) / 3.0;
        }

        public void MoveAt(Vector2 vector)
        {
            A.Add(vector);
            B.Add(vector);
            C.Add(vector);
        }
    }
}
