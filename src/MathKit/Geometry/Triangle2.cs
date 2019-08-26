using System;

/*
 * Author: Andrey Pokidov
 * Date: 23 Aug 2019
 */

namespace MathKit.Geometry
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

        public Vector2 SideAB
        {
            get
            {
                return B - A;
            }
        }

        public Vector2 SideBA
        {
            get
            {
                return A - B;
            }
        }

        public Vector2 SideBC
        {
            get
            {
                return C - B;
            }
        }

        public Vector2 SideCB
        {
            get
            {
                return B - C;
            }
        }

        public Vector2 SideCA
        {
            get
            {
                return A - C;
            }
        }

        public Vector2 SideAC
        {
            get
            {
                return C - A;
            }
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
    }
}
