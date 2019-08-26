using System;

/*
 * Author: Andrey Pokidov
 * Date: 23 Aug 2019
 */

namespace MathKit.Geometry
{
    public struct Triangle3
    {
        public Vector3 A;
        public Vector3 B;
        public Vector3 C;

        public Triangle3(Vector3 A, Vector3 B, Vector3 C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }

        public Triangle3(Triangle3 anotherTriangle)
        {
            A = anotherTriangle.A;
            B = anotherTriangle.B;
            C = anotherTriangle.C;
        }

        public Vector3 SideAB
        {
            get
            {
                return B - A;
            }
        }

        public Vector3 SideBA
        {
            get
            {
                return A - B;
            }
        }

        public Vector3 SideBC
        {
            get
            {
                return C - B;
            }
        }

        public Vector3 SideCB
        {
            get
            {
                return B - C;
            }
        }

        public Vector3 SideCA
        {
            get
            {
                return A - C;
            }
        }

        public Vector3 SideAC
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
            return 0.5 * (B - A).Vector(C - A).Module();
        }

        public Vector3 MedianCentre()
        {
            return (A + B + C) / 3.0;
        }

        public Vector3 Normal()
        {
            Vector3 n = (B - A).Vector(C - A);
            n.Normalize();
            return n;
        }
    }
}
