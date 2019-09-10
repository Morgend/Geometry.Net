
/*
 * Author: Andrey Pokidov
 * Date: 10 Sept 2019
 */

namespace GeometryKit
{
    public class AxisX
    {
        public static readonly Vector2 VECTOR2 = Vector2.UNIT_X_VECTOR;
        public static readonly Vector3 VECTOR3 = Vector3.UNIT_X_VECTOR;

        public static readonly RayLine2 RAY2 = new RayLine2(Vector2.ZERO_VECTOR, VECTOR2);
        public static readonly RayLine3 RAY3 = new RayLine3(Vector3.ZERO_VECTOR, VECTOR3);

        public static readonly StraightLine2 AXIS2 = new StraightLine2(Vector2.ZERO_VECTOR, VECTOR2);
        public static readonly StraightLine3 AXIS3 = new StraightLine3(Vector3.ZERO_VECTOR, VECTOR3);

        private AxisX()
        {
        }

        // ================== Reflecting 2D entities ==================

        public static Vector2 Reflect(Vector2 vector)
        {
            return new Vector2(vector.x, -vector.y);
        }

        public static StraightLine2 Reflect(StraightLine2 line)
        {
            return new StraightLine2(Reflect(line.BasicPoint), Reflect(line.Direction));
        }

        public static RayLine2 Reflect(RayLine2 line)
        {
            return new RayLine2(Reflect(line.StartPoint), Reflect(line.Direction));
        }

        public static LineSegment2 Reflect(LineSegment2 segment)
        {
            return new LineSegment2(Reflect(segment.A), Reflect(segment.B));
        }

        public static Triangle2 Reflect(Triangle2 triangle)
        {
            return new Triangle2(Reflect(triangle.A), Reflect(triangle.B), Reflect(triangle.C));
        }

        // ================== Reflecting 3D entities ==================

        public static Vector3 Reflect(Vector3 vector)
        {
            return new Vector3(vector.x, -vector.y, -vector.z);
        }

        public static StraightLine3 Reflect(StraightLine3 line)
        {
            return new StraightLine3(Reflect(line.BasicPoint), Reflect(line.Direction));
        }

        public static RayLine3 Reflect(RayLine3 line)
        {
            return new RayLine3(Reflect(line.StartPoint), Reflect(line.Direction));
        }

        public static LineSegment3 Reflect(LineSegment3 segment)
        {
            return new LineSegment3(Reflect(segment.A), Reflect(segment.B));
        }

        public static Plane Reflect(Plane plane)
        {
            return new Plane(Reflect(plane.BasicPoint), Reflect(plane.Normal));
        }

        public static Triangle3 Reflect(Triangle3 triangle)
        {
            return new Triangle3(Reflect(triangle.A), Reflect(triangle.B), Reflect(triangle.C));
        }

        // ================== Turning 3D entities at 90 degrees ==================

        public static Vector3 TurnAt90Degrees(Vector3 vector)
        {
            return new Vector3(vector.x, vector.z, -vector.y);
        }

        public static StraightLine3 TurnAt90Degrees(StraightLine3 line)
        {
            return new StraightLine3(TurnAt90Degrees(line.BasicPoint), TurnAt90Degrees(line.Direction));
        }

        public static RayLine3 TurnAt90Degrees(RayLine3 line)
        {
            return new RayLine3(TurnAt90Degrees(line.StartPoint), TurnAt90Degrees(line.Direction));
        }

        public static LineSegment3 TurnAt90Degrees(LineSegment3 segment)
        {
            return new LineSegment3(TurnAt90Degrees(segment.A), TurnAt90Degrees(segment.B));
        }

        public static Plane TurnAt90Degrees(Plane plane)
        {
            return new Plane(TurnAt90Degrees(plane.BasicPoint), TurnAt90Degrees(plane.Normal));
        }

        public static Triangle3 TurnAt90Degrees(Triangle3 triangle)
        {
            return new Triangle3(TurnAt90Degrees(triangle.A), TurnAt90Degrees(triangle.B), TurnAt90Degrees(triangle.C));
        }

        // ================== Turning 3D entities at 270 degrees ==================

        public static Vector3 TurnAt270Degrees(Vector3 vector)
        {
            return new Vector3(vector.x, -vector.z, vector.y);
        }

        public static StraightLine3 TurnAt270Degrees(StraightLine3 line)
        {
            return new StraightLine3(TurnAt270Degrees(line.BasicPoint), TurnAt270Degrees(line.Direction));
        }

        public static RayLine3 TurnAt270Degrees(RayLine3 line)
        {
            return new RayLine3(TurnAt270Degrees(line.StartPoint), TurnAt270Degrees(line.Direction));
        }

        public static LineSegment3 TurnAt270Degrees(LineSegment3 segment)
        {
            return new LineSegment3(TurnAt270Degrees(segment.A), TurnAt270Degrees(segment.B));
        }

        public static Plane TurnAt270Degrees(Plane plane)
        {
            return new Plane(TurnAt270Degrees(plane.BasicPoint), TurnAt270Degrees(plane.Normal));
        }

        public static Triangle3 TurnAt270Degrees(Triangle3 triangle)
        {
            return new Triangle3(TurnAt270Degrees(triangle.A), TurnAt270Degrees(triangle.B), TurnAt270Degrees(triangle.C));
        }
    }
}
