using System;

namespace GeometryKit
{
    public struct PlaneCoordinateSystem
    {
        public Vector3 Center;

        private Vector3 x;
        private Vector3 y;
        private Vector3 normal;
        private bool valid;

        public PlaneCoordinateSystem(PlaneCoordinateSystem system)
        {
            Center = system.Center;
            valid = system.valid;

            x = system.x;
            y = system.y;
            normal = system.normal;
        }

        public PlaneCoordinateSystem(Vector3 center, Vector3 protoX, Vector3 protoY)
        {
            Center = center;

            x = protoX;
            y = protoY;
            normal = Vector3.ZERO_VECTOR;
            valid = false;

            Normalize();
        }

        private void Normalize()
        {
            x.Normalize();

            if (x.IsZero())
            {
                Reset();
                return;
            }

            y -= x * x.Scalar(y);

            if (y.IsZero())
            {
                Reset();
                return;
            }

            y.Normalize();

            normal = x.Vector(y);
            valid = true;
        }

        private void Reset()
        {
            x = Vector3.ZERO_VECTOR;
            y = Vector3.ZERO_VECTOR;
            normal = Vector3.ZERO_VECTOR;
            valid = false;
        }

        public bool Valid
        {
            get
            {
                return valid;
            }
        }

        public Plane Plane
        {
            get
            {
                return new Plane(this.Center, normal);
            }
        }

        public Vector3 VectorX
        {
            get
            {
                return x;
            }
        }

        public Vector3 VectorY
        {
            get
            {
                return y;
            }
        }

        public RayLine3 Ox
        {
            get
            {
                return new RayLine3(Center, x);
            }
        }

        public RayLine3 Oy
        {
            get
            {
                return new RayLine3(Center, y);
            }
        }

        public StraightLine3 AxisX
        {
            get
            {
                return new StraightLine3(Center, x);
            }
        }

        public StraightLine3 AxisY
        {
            get
            {
                return new StraightLine3(Center, y);
            }
        }

        public Vector2 Projection2dOf(Vector3 point)
        {
            if (!valid)
            {
                return Vector2.ZERO_VECTOR;
            }

            Vector3 relativePoint = point - Center;

            return new Vector2(relativePoint.Scalar(x), relativePoint.Scalar(y));
        }

        public Vector3 Projection3dOf(Vector3 point)
        {
            if (!valid)
            {
                return Vector3.ZERO_VECTOR;
            }

            return point - (point - Center).Scalar(normal) * normal;
        }

        public Vector3 Point3dOf(Vector2 point)
        {
            if (!valid)
            {
                return Vector3.ZERO_VECTOR;
            }

            return x * point.x + y * point.y + Center;
        }
    }
}
