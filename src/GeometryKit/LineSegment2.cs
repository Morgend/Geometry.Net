
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

        public void MoveAt(Vector2 vector)
        {
            A.Add(vector);
            B.Add(vector);
        }

        public Vector2 PointAt(double position)
        {
            return (1.0 - position) * A + position * B;
        }

        public RayLine2 RayAB()
        {
            return new RayLine2(A, B - A);
        }

        public RayLine2 RayBA()
        {
            return new RayLine2(B, A - B);
        }

        public StraightLine2 StraightLine()
        {
            return new StraightLine2(A, B - A);
        }

        // ============= Parallelism check methods: =============

        public bool IsParallelTo(Vector2 vector)
        {
            return vector.IsParallelTo(B - A);
        }

        public bool IsParallelTo(StraightLine2 line)
        {
            return line.IsValid && line.Direction.IsParallelTo(B - A);
        }

        public bool IsParallelTo(RayLine2 line)
        {
            return line.IsValid && line.Direction.IsParallelTo(B - A);
        }

        public bool IsParallelTo(LineSegment2 segment)
        {
            return (B - A).IsParallelTo(segment.B - segment.A);
        }

        // ============= Orthogonality check methods: =============

        public bool IsOrthogonalTo(Vector2 vector)
        {
            return vector.IsOrthogonalTo(B - A);
        }

        public bool IsOrthogonalTo(StraightLine2 line)
        {
            return line.IsValid && line.Direction.IsOrthogonalTo(B - A);
        }

        public bool IsOrthogonalTo(RayLine2 line)
        {
            return line.IsValid && line.Direction.IsOrthogonalTo(B - A);
        }

        public bool IsOrthogonalTo(LineSegment2 segment)
        {
            return (B - A).IsOrthogonalTo(segment.B - segment.A);
        }

        // ========================================================

        public bool IsEqualTo(LineSegment2 line)
        {
            return (A.IsEqualTo(line.A) && B.IsEqualTo(line.B)) || (A.IsEqualTo(line.B) && B.IsEqualTo(line.A));
        }

        // =================== Minimal angles: ====================

        public Angle MinimalAngleWith(Vector2 vector)
        {
            return this.VectorAB.MinimalAngleWithAxis(vector);
        }

        public Angle MinimalAngleWith(StraightLine2 line)
        {
            return line.MinimalAngleWith(this.VectorAB);
        }

        public Angle MinimalAngleWith(RayLine2 line)
        {
            return line.MinimalAngleWith(this.VectorAB);
        }

        public Angle MinimalAngleWith(LineSegment2 line)
        {
            return this.VectorAB.MinimalAngleWithAxis(line.VectorAB);
        }

        // =================== Maximal angles: ====================

        public Angle MaximalAngleWith(Vector2 vector)
        {
            return this.VectorAB.MaximalAngleWithAxis(vector);
        }

        public Angle MaximalAngleWith(StraightLine2 line)
        {
            return line.MaximalAngleWith(this.VectorAB);
        }

        public Angle MaximalAngleWith(RayLine2 line)
        {
            return line.MaximalAngleWith(this.VectorAB);
        }

        public Angle MaximalAngleWith(LineSegment2 line)
        {
            return this.VectorAB.MaximalAngleWithAxis(line.VectorAB);
        }
    }
}
