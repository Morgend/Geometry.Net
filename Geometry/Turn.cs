using System;

/*
 * Author: Andrey Pokidov
 * Date: 2 Feb 2019
 */

namespace MathKit.Geometry
{
    public class Turn
    {
        public static readonly Quaternion DEFAULT_QUATERNION = new Quaternion(0.0, 0.0, 0.0, 1.0);

        private Quaternion q;

        public Turn()
        {
            this.reset();
        }

        public Turn(Turn turn)
        {
            this.copyOf(turn);
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

        public Turn(EulerAngles angles)
        {
            this.setTurn(angles.heading.radians, angles.elevation.radians, angles.bank.radians);
        }

        public Turn(Angle heading, Angle elevation, Angle bank)
        {
            this.setTurn(heading.radians, elevation.radians, bank.radians);
        }

        public Turn(double heading, double elevation, double bank)
        {
            this.setTurn(heading, elevation, bank);
        }

        public static void checkTurn(Turn turn)
        {
            if (turn == null)
            {
                throw new NullReferenceException("An instance of Turn was expected but NULL was got");
            }
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
                EulerAngles result = new EulerAngles(
                    this.calculateHeading(),
                    this.calculateElevation(),
                    this.calculateBank()
                );

                result.normalize();

                return result;
            }
        }

        public Quaternion Quaternion
        {
            get
            {
                return this.q;
            }
        }

        public Matrix3x3 buildRotationMatrix()
        {
            Matrix3x3 matrix = new Matrix3x3();

            matrix.a_1_1 = 1.0 - 2.0 * (q.y * q.y + q.z * q.z);
            matrix.a_1_2 = 2.0 * (q.x * q.y - q.w * q.z);
            matrix.a_1_3 = 2.0 * (q.w * q.y + q.x * q.z);

            matrix.a_2_1 = 2.0 * (q.x * q.y + q.w * q.z);
            matrix.a_2_2 = 1.0 - 2.0 * (q.x * q.x + q.z * q.z);
            matrix.a_2_3 = 2.0 * (q.y * q.z - q.w * q.x);

            matrix.a_3_1 = 2.0 * (q.x * q.z - q.w * q.y);
            matrix.a_3_2 = 2.0 * (q.w * q.x + q.y * q.z);
            matrix.a_3_3 = 1.0 - 2.0 * (q.x * q.x + q.y * q.y);

            return matrix;
        }

        public void reset()
        {
            this.q = DEFAULT_QUATERNION;
        }

        private double calculateHeading()
        {
            return Math.Atan2(2.0 * (q.w * q.z + q.x * q.y), 1.0 - 2.0 * (q.y * q.y + q.z * q.z));
        }

        private double calculateElevation()
        {
            return Math.Asin(2.0 * (q.w * q.y - q.z * q.x));
        }

        private double calculateBank()
        {
            return Math.Atan2(2.0 * (q.w * q.x + q.y * q.z), 1.0 - 2.0 * (q.x * q.x + q.y * q.y));
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

        public void setTurn(EulerAngles angles)
        {
            this.setTurn(angles.heading.radians, angles.elevation.radians, angles.bank.radians);
        }

        public void setTurn(Angle heading, Angle elevation, Angle bank)
        {
            this.setTurn(heading.radians, elevation.radians, bank.radians);
        }

        public void setTurn(double heading, double elevation, double bank)
        {
            double cosHeading = Math.Cos(0.5 * heading);
            double sinHeading = Math.Sin(0.5 * heading);

            double cosElevation = Math.Cos(0.5 * elevation);
            double sinElevation = Math.Sin(0.5 * elevation);

            double cosBank = Math.Cos(0.5 * bank);
            double sinBank = Math.Sin(0.5 * bank);

            q.w = cosHeading * cosElevation * cosBank + sinHeading * sinElevation * sinBank;
            q.x = cosHeading * cosElevation * sinBank - sinHeading * sinElevation * cosBank;
            q.y = sinHeading * cosElevation * sinBank + cosHeading * sinElevation * cosBank;
            q.z = sinHeading * cosElevation * cosBank - cosHeading * sinElevation * sinBank;

            this.normalizeQuaternion();
        }

        public void setTurnDegrees(double heading, double elevation, double bank)
        {
            this.setTurn(Angle.degreesToRadians(heading), Angle.degreesToRadians(elevation), Angle.degreesToRadians(bank));
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

        public void copyOf(Turn turn)
        {
            checkTurn(turn);
            this.q = turn.q;
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
