using System;

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

        public Vector3 SideBC
        {
            get
            {
                return C - B;
            }
        }

        public Vector3 SideCA
        {
            get
            {
                return A - C;
            }
        }

        public Angle CalculateAngleA()
        {
            return (B - A).AngleWith(C - A);
        }

        public Angle CalculateAngleB()
        {
            return (C - B).AngleWith(A - B);
        }

        public Angle CalculateAngleC()
        {
            return (A - C).AngleWith(B - C);
        }

        public double CalculateSquare()
        {
            return 0.5 * (B - A).Vector(C - A).Module();
        }

        public Vector3 CalculateMedianCentre()
        {
            return (A + B + C) / 3.0;
        }

        public Vector3 CalculateNormal()
        {
            Vector3 n = (B - A).Vector(C - A);
            n.Normalize();
            return n;
        }
    }
}
