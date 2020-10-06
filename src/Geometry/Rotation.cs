using System;

/*
 * Author: Andrey Pokidov
 * Date: 2 Feb 2019
 */

namespace Geometry
{
    public enum RotationState
    {
        NON_NORMALIZED = 0x0,
        IDENTITY = 0x1,
        TURN = 0x2,
    }

    public struct Rotation
    {
        private static readonly Quaternion DEFAULT_QUATERNION = new Quaternion(1.0, 0.0, 0.0, 0.0);

        private Quaternion q;
        private RotationState state;

        public Rotation(Rotation turn)
        {
            q = turn.q;
            state = turn.state;

            Normalize();
        }

        public Rotation(Rotation firstTurn, Rotation secondTurn)
        {
            firstTurn.Normalize();
            secondTurn.Normalize();

            q = firstTurn.q;
            q.MultiplyAt(secondTurn.q);

            state = RotationState.TURN;

            CheckIdentity();
        }

        public Rotation(Rotation firstTurn, Rotation secondTurn, Rotation thirdTurn)
        {
            firstTurn.Normalize();
            secondTurn.Normalize();
            thirdTurn.Normalize();

            q = firstTurn.q;
            q.MultiplyAt(secondTurn.q);
            q.MultiplyAt(thirdTurn.q);

            state = RotationState.TURN;

            CheckIdentity();
        }

        public Rotation(Vector3 axis, Angle angle)
        {
            q = DEFAULT_QUATERNION;
            state = RotationState.IDENTITY;

            SetTurn(axis, angle);
        }

        public Rotation(Quaternion quaternion)
        {
            q = quaternion;
            state = RotationState.NON_NORMALIZED;

            Normalize();
        }

        public Rotation(double w, double x, double y, double z)
        {
            q = new Quaternion(w, x, y, z);
            state = RotationState.NON_NORMALIZED;

            Normalize();
        }

        public Rotation(EulerAngles angles)
        {
            q = DEFAULT_QUATERNION;
            state = RotationState.IDENTITY;

            SetTurn(angles.Heading.Radians, angles.Elevation.Radians, angles.Bank.Radians);
        }

        public Rotation(Angle heading, Angle elevation, Angle bank)
        {
            q = DEFAULT_QUATERNION;
            state = RotationState.IDENTITY;

            SetTurn(heading.Radians, elevation.Radians, bank.Radians);
        }

        public Rotation(double heading, double elevation, double bank)
        {
            q = DEFAULT_QUATERNION;
            state = RotationState.IDENTITY;

            SetTurn(heading, elevation, bank);
        }

        public static Rotation FromDegrees(double heading, double elevation, double bank)
        {
            return new Rotation(Angle.DegreesToRadians(heading), Angle.DegreesToRadians(elevation), Angle.DegreesToRadians(bank));
        }

        public static Rotation FromGradians(double heading, double elevation, double bank)
        {
            return new Rotation(Angle.GradiansToRadians(heading), Angle.GradiansToRadians(elevation), Angle.GradiansToRadians(bank));
        }

        public bool IsIdentity
        {
            get
            {
                Normalize();
                return state == RotationState.IDENTITY;
            }
        }

        public Angle Angle
        {
            get
            {
                Normalize();
                return state == RotationState.IDENTITY ? new Angle() : new Angle(2.0 * Math.Acos(q.w));
            }
        }

        public Vector3 Axis
        {
            get
            {
                Normalize();

                if (state == RotationState.IDENTITY)
                {
                    return Vector3.ZERO_VECTOR;
                }

                Vector3 axis = new Vector3(q.x, q.y, q.z);
                axis.Normalize();
                return axis;
            }
        }

        public EulerAngles EulerAngles
        {
            get
            {
                Normalize();

                if (state == RotationState.IDENTITY)
                {
                    return new EulerAngles();
                }

                EulerAngles result = new EulerAngles(
                    CalculateHeading(),
                    CalculateElevation(),
                    CalculateBank()
                );

                result.Normalize();

                return result;
            }
        }

        public Quaternion Quaternion
        {
            get
            {
                Normalize();
                return q;
            }
        }

        public Matrix3x3 GetRotationMatrix()
        {
            Normalize();

            if (state == RotationState.IDENTITY)
            {
                return new Matrix3x3(MatrixInitialMode.IDENTITY_MATRIX);
            }

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
            Normalize();

            if (state == RotationState.IDENTITY)
            {
                return new Matrix3x3(MatrixInitialMode.IDENTITY_MATRIX);
            }

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
            q = DEFAULT_QUATERNION;
            state = RotationState.IDENTITY;
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
                Reset();
                return;
            }

            double sinus = Math.Sin(angle.Radians * 0.5);

            if (MathConstant.NEGATIVE_EPSYLON <= sinus && sinus <= MathConstant.POSITIVE_EPSYLON)
            {
                Reset();
                return;
            }

            double k = sinus / module;

            q.x = axis.x * k;
            q.y = axis.y * k;
            q.z = axis.z * k;
            q.w = Math.Cos(angle.Radians * 0.5);

            state = RotationState.TURN;
        }

        public void SetTurn(Quaternion quaternion)
        {
            q = quaternion;
            state = RotationState.NON_NORMALIZED;

            Normalize();
        }

        public void SetTurn(double w, double x, double y, double z)
        {
            q.SetValues(w, x, y, z);
            state = RotationState.NON_NORMALIZED;

            Normalize();
        }

        public void SetTurn(EulerAngles angles)
        {
            SetTurn(angles.Heading.Radians, angles.Elevation.Radians, angles.Bank.Radians);
        }

        public void SetTurn(Angle heading, Angle elevation, Angle bank)
        {
            SetTurn(heading.Radians, elevation.Radians, bank.Radians);
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

            state = RotationState.TURN;

            CheckIdentity();
        }

        public void SetTurnInDegrees(double heading, double elevation, double bank)
        {
            SetTurn(Angle.DegreesToRadians(heading), Angle.DegreesToRadians(elevation), Angle.DegreesToRadians(bank));
        }

        public void SetTurnInGradians(double heading, double elevation, double bank)
        {
            SetTurn(Angle.GradiansToRadians(heading), Angle.GradiansToRadians(elevation), Angle.GradiansToRadians(bank));
        }

        public void Normalize()
        {
            if (state != RotationState.NON_NORMALIZED)
            {
                return;
            }

            double module = q.Module();

            if (module < MathConstant.EPSYLON)
            {
                Reset();
                return;
            }

            q.DivideAt(module);
            state = RotationState.TURN;

            CheckIdentity();
        }

        private void CheckIdentity()
        {
            if (state != RotationState.IDENTITY && 1.0 - MathConstant.EPSYLON <= q.w && q.w <= 1.0 + MathConstant.EPSYLON)
            {
                Reset();
            }
        }

        public void SetTurn(Rotation turn)
        {
            q = turn.q;
            state = turn.state;

            Normalize();
        }

        public Rotation CombineWith(Rotation nextTurn)
        {
            Normalize();

            if (state == RotationState.IDENTITY)
            {
                return nextTurn;
            }

            if (nextTurn.state == RotationState.IDENTITY)
            {
                return this;
            }

            return new Rotation(this, nextTurn);
        }

        public void SetCombinationOf(Rotation firstTurn, Rotation secondTurn)
        {
            firstTurn.Normalize();
            secondTurn.Normalize();

            q.SetMultiplicationOf(firstTurn.q, secondTurn.q);
            state = RotationState.TURN;

            CheckIdentity();
        }

        public void SetCombinationOf(Rotation firstTurn, Rotation secondTurn, Rotation thirdTurn)
        {
            firstTurn.Normalize();
            secondTurn.Normalize();
            thirdTurn.Normalize();

            q.SetMultiplicationOf(firstTurn.q, secondTurn.q);
            q.MultiplyAt(thirdTurn.q);
            state = RotationState.TURN;

            CheckIdentity();
        }

        public Rotation DifferenceWith(Rotation subtrahend)
        {
            Normalize();
            subtrahend.Normalize();

            Rotation result = new Rotation();
            result.SetDifferenceOf(this, subtrahend);
            return result;
        }

        public void SetDifferenceOf(Rotation turn, Rotation subtrahend)
        {
            turn.Normalize();
            subtrahend.Normalize();

            q.SetMultiplicationOf(subtrahend.q.GetConjugated(), turn.q);
            state = RotationState.IDENTITY;
        }

        public void Invert()
        {
            if (state != RotationState.IDENTITY)
            {
                q.Conjugate();
            }
        }

        public Rotation GetInverted()
        {
            Normalize();

            if (state == RotationState.IDENTITY)
            {
                return this;
            }

            Rotation result = new Rotation(this);
            result.Invert();
            return result;
        }

        public Vector3 Turn(Vector3 vector)
        {
            Normalize();

            if (state == RotationState.IDENTITY)
            {
                return vector;
            }

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
            Normalize();

            if (state == RotationState.IDENTITY)
            {
                return vector;
            }

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
