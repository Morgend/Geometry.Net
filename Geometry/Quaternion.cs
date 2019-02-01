using System;

/*
 * Author: Andrey Pokidov
 */

namespace MathKit.Geometry
{
    public struct Quaternion
    {
        public const double DEFAULT_TURN_VALUE = 1.0;
        public const double DEFAULT_COORDINATE_VALUE = 0.0;
        public const double EPSYLON = 0.00000001;

        private double x;
        private double y;
        private double z;
        private double w;

        public Quaternion(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
            this.normalize();
        }

        public Quaternion(double angle, Vector3 vector)
        {
            this.x = DEFAULT_COORDINATE_VALUE;
            this.y = DEFAULT_COORDINATE_VALUE;
            this.z = DEFAULT_COORDINATE_VALUE;
            this.w = DEFAULT_TURN_VALUE;

            this.setValue(angle, vector);
        }

        public Quaternion(Angle angle, Vector3 vector)
        {
            this.x = DEFAULT_COORDINATE_VALUE;
            this.y = DEFAULT_COORDINATE_VALUE;
            this.z = DEFAULT_COORDINATE_VALUE;
            this.w = DEFAULT_TURN_VALUE;

            this.setValue(angle.radians, vector);
        }

        public void setValue(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
            this.normalize();
        }

        public void setValue(Quaternion q)
        {
            this.x = q.x;
            this.y = q.y;
            this.z = q.z;
            this.w = q.w;
        }

        public void setValue(double angle, Vector3 vector)
        {
            double module = vector.module();

            if (module < EPSYLON)
            {
                this.reset();
                return;
            }

            double k = Math.Sin(angle * 0.5) / module;

            this.x = vector.x * k;
            this.y = vector.y * k;
            this.z = vector.z * k;
            this.w = Math.Cos(angle * 0.5);
        }

        public void setValue(Angle angle, Vector3 vector)
        {
            this.setValue(angle.radians, vector);
        }

        public void reset()
        {
            this.w = DEFAULT_TURN_VALUE;
            this.x = DEFAULT_COORDINATE_VALUE;
            this.y = DEFAULT_COORDINATE_VALUE;
            this.z = DEFAULT_COORDINATE_VALUE;
        }

        public double X
        {
            get
            {
                return this.x;
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }
        }

        public double Z
        {
            get
            {
                return this.z;
            }
        }

        public double W
        {
            get
            {
                return this.w;
            }
        }

        public void invert()
        {
            this.x = -this.x;
            this.y = -this.y;
            this.z = -this.z;
        }

        public Quaternion getInverted()
        {
            return new Quaternion(-this.x, -this.y, -this.z, this.w);
        }

        public double module()
        {
            return Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w);
        }

        public void normalize()
        {
            double module = this.module();

            if (module < EPSYLON)
            {
                this.reset();
                return;
            }

            this.x /= module;
            this.y /= module;
            this.z /= module;
            this.w /= module;
        }

        public Quaternion multiply(Quaternion q)
        {
            return new Quaternion(
                this.w * q.w - this.x * q.x - this.y * q.y - this.z * q.z,
                this.y * q.z - this.z * q.y + this.w * q.x + this.x * q.w,
                this.x * q.z - this.z * q.x + this.w * q.y + this.y * q.w,
                this.x * q.y - this.y * q.x + this.w * q.z + this.z * q.w
            );
        }

        public void multiplyAt(Quaternion q)
        {
            this.setValue(
                this.w * q.w - this.x * q.x - this.y * q.y - this.z * q.z,
                this.y * q.z - this.z * q.y + this.w * q.x + this.x * q.w,
                this.x * q.z - this.z * q.x + this.w * q.y + this.y * q.w,
                this.x * q.y - this.y * q.x + this.w * q.z + this.z * q.w
            );
        }

        public Vector3 turn(Vector3 vector)
        {
            double mw = this.x * vector.x + this.y * vector.y + this.z * vector.z;
            double vx = this.w * vector.x + this.y * vector.z - this.z * vector.y;
            double vy = this.w * vector.y + this.z * vector.x - this.x * vector.z;
            double vz = this.w * vector.z + this.x * vector.y - this.y * vector.x;

            return new Vector3(
                this.w * vx + mw * this.x - vy * this.z + vz * this.y,
                this.w * vy + mw * this.y - vz * this.x + vx * this.z,
                this.w * vz + mw * this.z - vx * this.y + vy * this.x
            );
        }

        public static Quaternion operator *(Quaternion q1, Quaternion q2)
        {
            return q1.multiply(q2);
        }

        public static Quaternion operator -(Quaternion q)
        {
            return q.getInverted();
        }
    }
}
