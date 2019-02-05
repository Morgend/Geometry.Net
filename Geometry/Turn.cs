using System;

/*
 * Author: Andrey Pokidov
 * Date: 2 Feb 2019
 */

namespace MathKit.Geometry
{
    public class Turn
    {
        public static readonly Angle DEFAULT_ANGLE = new Angle(0.0);
        public static readonly Vector3 DEFAULT_DIRECTION = new Vector3(0.0, 0.0, 1.0);
        public static readonly EulerAngles DEFAULT_ANGLES = new EulerAngles(0.0, 0.0, 0.0);
        public static readonly Quaternion DEFAULT_QUATERNION = new Quaternion(0.0, 0.0, 0.0, 1.0);

        private Quaternion q;
        //private 

        public Turn()
        {
            q = DEFAULT_QUATERNION;
        }

        public Turn(Vector3 axis, Angle angle)
        {
            this.setTurn(axis, angle);
        }

        public Turn(Quaternion quaternion)
        {
            this.setTurn(quaternion);
        }

        public Turn(double x, double y, double z, double w)
        {
            this.setTurn(x, y, z, w);
        }

        public Angle Angle
        {
            get
            {
                return new Angle(2.0 * Math.Acos(q.w));
            }
        }

        public Vector3 Axis
        {
            get
            {
                Vector3 axis = new Vector3(q.x, q.y, q.z);
                axis.normalize();
                return axis;
            }
        }

        public EulerAngles EulerAngles
        {
            get
            {
                EulerAngles angles = new EulerAngles(
                    this.calculateHeading(),
                    this.calculateElevation(),
                    this.calculateBank()
                );
                angles.normalize();
                return angles;
            }
        }

        public Quaternion Quaternion
        {
            get
            {
                return q;
            }
        }

        public void reset()
        {
            q = DEFAULT_QUATERNION;
        }

        private double calculateHeading()
        {
            return Math.Atan2(2.0 * (q.w * q.x + q.y * q.z), 1.0 - 2.0 * (q.x * q.x + q.y * q.y));
        }

        private double calculateElevation()
        {
            return Math.Asin(2.0 * (q.w * q.y - q.z * q.x));
        }

        private double calculateBank()
        {
            return 2.0 * Math.Atan2(2.0 * (q.w * q.z + q.x * q.y), 1.0 - 2.0 * (q.y * q.y + q.z * q.z));
        }

        public void setTurn(Vector3 axis, Angle angle)
        {
            double module = axis.module();

            if (module == 0.0)
            {
                this.reset();
                return;
            }

            double k = Math.Sin(angle.radians * 0.5) / module;

            q.x = axis.x * k;
            q.y = axis.y * k;
            q.z = axis.z * k;
            q.w = Math.Cos(angle.radians * 0.5);
        }

        public void setTurn(Quaternion quaternion)
        {
            q = quaternion;
            this.normalizeQuaternion();
        }

        public void setTurn(double x, double y, double z, double w)
        {
            q.setValue(x, y, z, w);
            this.normalizeQuaternion();
        }

        private void normalizeQuaternion()
        {
            double module = q.module();

            if (module < MathConst.EPSYLON)
            {
                this.reset();
                return;
            }

            q /= module;
        }

        public Vector3 turn(Vector3 vector)
        {
            double mw = q.x * vector.x + q.y * vector.y + q.z * vector.z;
            double vx = q.w * vector.x + q.y * vector.z - q.z * vector.y;
            double vy = q.w * vector.y + q.z * vector.x - q.x * vector.z;
            double vz = q.w * vector.z + q.x * vector.y - q.y * vector.x;

            return new Vector3(
                q.w * vx + mw * q.x - vy * q.z + vz * q.y,
                q.w * vy + mw * q.y - vz * q.x + vx * q.z,
                q.w * vz + mw * q.z - vx * q.y + vy * q.x
            );
        }
    }
}
