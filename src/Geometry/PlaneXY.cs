
/*
 * Author: Andrey Pokidov
 * Date: 10 Sept 2019
 */

namespace Geometry
{
    public class PlaneXY
    {
        private PlaneXY()
        {
        }

        // ================== Reflecting 3D entities ==================

        public static Vector3 Reflect(Vector3 point)
        {
            return new Vector3(point.x, point.y, -point.z);
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
    }
}
