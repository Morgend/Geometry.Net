using System;

/*
 * Author: Andrey Pokidov
 * Date: 2 Feb 2019
 */

namespace MathKit.Geometry
{
    public class Rotation
    {
        private static readonly Quaternion DEFAULT_QUATERNION = new Quaternion(1.0, 0.0, 0.0, 0.0);

        private Quaternion q;

        public Rotation()
        {
            this.q = DEFAULT_QUATERNION;
        }

        public Rotation(Rotation turn)
        {
            this.SetTurn(turn);
        }

        public Rotation(Rotation firstTurn, Rotation secondTurn)
        {
            this.SetCombinationOf(firstTurn, secondTurn);
        }

        public Rotation(Rotation firstTurn, Rotation secondTurn, Rotation thirdTurn)
        {
            this.SetCombinationOf(firstTurn, secondTurn, thirdTurn);
        }

        public Rotation(Vector3 axis, Angle angle)
        {
            this.SetTurn(axis, angle);
        }

        public Rotation(Quaternion quaternion)
        {
            this.SetTurn(quaternion);
        }

        public Rotation(double w, double x, double y, double z)
        {
            this.SetTurn(w, x, y, z);
        }

        public Rotation(EulerAngles angles)
        {
            this.SetTurn(angles.Heading.Radians, angles.Elevation.Radians, angles.Bank.Radians);
        }

        public Rotation(Angle heading, Angle elevation, Angle bank)
        {
            this.SetTurn(heading.Radians, elevation.Radians, bank.Radians);
        }

        public Rotation(double heading, double elevation, double bank)
        {
            this.SetTurn(heading, elevation, bank);
        }

        public static void CheckRotation(Rotation rotation)
        {
            if (rotation == null)
            {
                throw new NullReferenceException("An instance of Rotation was expected but NULL was got");
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
                axis.Normalize();
                return axis;
            }
        }

        public EulerAngles EulerAngles
        {
            get
            {
                EulerAngles result = new EulerAngles(
                    this.CalculateHeading(),
                    this.CalculateElevation(),
                    this.CalculateBank()
                );

                result.Normalize();

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

        public Matrix3x3 GetRotationMatrix()
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

        public Matrix3x3 GetBackwardRotationMatrix()
        {
            Matrix3x3 matrix = new Matrix3x3();

            matrix.a_1_1 = 1.0 - 2.0 * (q.y * q.y + q.z * q.z);
            matrix.a_1_2 = 2.0 * (q.w * q.z + q.x * q.y);
            matrix.a_1_3 = 2.0 * (q.x * q.z - q.w * q.y);

            matrix.a_2_1 = 2.0 * (q.x * q.y - q.w * q.z);
            matrix.a_2_2 = 1.0 - 2.0 * (q.x * q.x + q.z * q.z);
            matrix.a_2_3 = 2.0 * (q.y * q.z + q.w * q.x);

            matrix.a_3_1 = 2.0 * (q.x * q.z + q.w * q.y);
            matrix.a_3_2 = 2.0 * (q.y * q.z - q.w * q.x);
            matrix.a_3_3 = 1.0 - 2.0 * (q.x * q.x + q.y * q.y);

            return matrix;
        }

        public void Reset()
        {
            this.q = DEFAULT_QUATERNION;
        }

        private double CalculateHeading()
        {
            return Math.Atan2(2.0 * (q.w * q.z + q.x * q.y), 1.0 - 2.0 * (q.y * q.y + q.z * q.z));
        }

        private double CalculateElevation()
        {
            return Math.Asin(2.0 * (q.w * q.y - q.z * q.x));
        }

        private double CalculateBank()
        {
            return Math.Atan2(2.0 * (q.w * q.x + q.y * q.z), 1.0 - 2.0 * (q.x * q.x + q.y * q.y));
        }

        public void SetTurn(Vector3 axis, Angle angle)
        {
            double module = axis.Module();

            if (module == 0.0)
            {
                this.Reset();
                return;
            }

            double k = Math.Sin(angle.Radians * 0.5) / module;

            q.x = axis.x * k;
            q.y = axis.y * k;
            q.z = axis.z * k;
            q.w = Math.Cos(angle.Radians * 0.5);
        }

        public void SetTurn(Quaternion quaternion)
        {
            q = quaternion;
            this.NormalizeQuaternion();
        }

        public void SetTurn(double w, double x, double y, double z)
        {
            q.SetValues(w, x, y, z);
            this.NormalizeQuaternion();
        }

        public void SetTurn(EulerAngles angles)
        {
            this.SetTurn(angles.Heading.Radians, angles.Elevation.Radians, angles.Bank.Radians);
        }

        public void SetTurn(Angle heading, Angle elevation, Angle bank)
        {
            this.SetTurn(heading.Radians, elevation.Radians, bank.Radians);
        }

        public void SetTurn(double heading, double elevation, double bank)
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

            this.NormalizeQuaternion();
        }

        public void SetTurnDegrees(double heading, double elevation, double bank)
        {
            this.SetTurn(Angle.DegreesToRadians(heading), Angle.DegreesToRadians(elevation), Angle.DegreesToRadians(bank));
        }

        private void NormalizeQuaternion()
        {
            double module = q.Module();

            if (module < MathConst.EPSYLON)
            {
                this.Reset();
                return;
            }

            q /= module;

            if (q.w < MathConst.EPSYLON - DEFAULT_QUATERNION.w || q.w > DEFAULT_QUATERNION.w - MathConst.EPSYLON)
            {
                this.Reset();
            }
        }

        public void SetTurn(Rotation turn)
        {
            CheckRotation(turn);
            this.q = turn.q;
        }

        public Rotation CombineWith(Rotation nextTurn)
        {
            return new Rotation(this, nextTurn);
        }

        public void SetCombinationOf(Rotation firstTurn, Rotation secondTurn)
        {
            this.q.SetMultiplicationOf(firstTurn.q, secondTurn.q);
            this.NormalizeQuaternion();
        }

        public void SetCombinationOf(Rotation firstTurn, Rotation secondTurn, Rotation thirdTurn)
        {
            this.q = firstTurn.q;
            this.q.MultiplyAt(secondTurn.q);
            this.q.MultiplyAt(thirdTurn.q);
            this.NormalizeQuaternion();
        }

        public Rotation DifferenceWith(Rotation subtrahend)
        {
            Rotation result = new Rotation();
            result.SetDifferenceOf(this, subtrahend);
            return result;
        }

        public void SetDifferenceOf(Rotation turn, Rotation subtrahend)
        {
            this.q.SetMultiplicationOf(subtrahend.q.GetConjugated(), turn.q);
        }

        public void Invert()
        {
            this.q.Conjugate();
        }

        public Rotation GetInverted()
        {
            Rotation result = new Rotation();
            result.Invert();
            return result;
        }

        public Vector3 Turn(Vector3 vector)
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

        public Vector3 TurnBackward(Vector3 vector)
        {
            double mw = - q.x * vector.x - q.y * vector.y - q.z * vector.z;
            double vx = q.w * vector.x - q.y * vector.z + q.z * vector.y;
            double vy = q.w * vector.y - q.z * vector.x + q.x * vector.z;
            double vz = q.w * vector.z - q.x * vector.y + q.y * vector.x;

            return new Vector3(
                q.w * vx - mw * q.x + vy * q.z - vz * q.y,
                q.w * vy - mw * q.y + vz * q.x - vx * q.z,
                q.w * vz - mw * q.z + vx * q.y - vy * q.x
            );
        }

        public static Rotation operator +(Rotation first, Rotation second)
        {
            return first.CombineWith(second);
        }

        public static Rotation operator -(Rotation rotation, Rotation subtrahend)
        {
            return rotation.DifferenceWith(subtrahend);
        }
    }
}
