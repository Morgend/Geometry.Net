using System;

/*
 * Author: Andrey Pokidov
 * Date: 1 Feb 2019
 */

namespace MathKit.Geometry
{
    public struct Angle
    {
        public const double DEFAULT_VALUE = 0.0;

        public const double PI = MathConst.PI;
        public const double PIx2 = MathConst.PIx2;
        public const double PId2 = MathConst.PId2;

        public const double DEGREES_IN_RADIAN = 57.2957795130823209;
        public const double GRADS_IN_RADIAN = 63.6619772367581343;

        public double Radians;

        public Angle(double radians)
        {
            this.Radians = radians;
        }

        public Angle(Angle angle)
        {
            this.Radians = angle.Radians;
        }

        public static Angle FromDegrees(double degrees)
        {
            return new Angle(Angle.DegreesToRadians(degrees));
        }

        public static Angle FromGrads(double grads)
        {
            return new Angle(Angle.GradsToRadians(grads));
        }

        public static double DegreesToRadians(double degrees)
        {
            return degrees / DEGREES_IN_RADIAN;
        }

        public static double RadiansToDegrees(double radians)
        {
            return radians * DEGREES_IN_RADIAN;
        }

        public static double GradsToRadians(double degrees)
        {
            return degrees / GRADS_IN_RADIAN;
        }

        public static double RadiansToGrads(double radians)
        {
            return radians * GRADS_IN_RADIAN;
        }

        public double Degrees
        {
            get
            {
                return DEGREES_IN_RADIAN * this.Radians;
            }

            set
            {
                this.Radians = value / DEGREES_IN_RADIAN;
            }
        }

        public double Grads
        {
            get
            {
                return GRADS_IN_RADIAN * this.Radians;
            }

            set
            {
                this.Radians = value / GRADS_IN_RADIAN;
            }
        }

        public void Normalize2Pi()
        {
            this.Radians -= PIx2 * Math.Floor(this.Radians / PIx2);

            if (this.Radians >= 0)
            {
                return;
            }

            if (this.Radians > MathConst.NEGATIVE_EPSYLON)
            {
                this.Radians = 0;
                return;
            }

            this.Radians += PIx2;

        }

        public void NormalizePiMinusPi()
        {
            this.Radians -= PIx2 * Math.Floor(this.Radians / PIx2);

            if (this.Radians > PI)
            {
                if (this.Radians < PI + MathConst.EPSYLON)
                {
                    this.Radians = PI;
                }
                else
                {
                    this.Radians -= PIx2;
                }
                return;
            }

            if (this.Radians <= -PI)
            {
                if (this.Radians > -PI - MathConst.EPSYLON)
                {
                    this.Radians = PI;
                }
                else
                {
                    this.Radians += PIx2;
                }
            }
        }

        public void Zero()
        {
            this.Radians = DEFAULT_VALUE;
        }

        public double Sin()
        {
            return Math.Sin(this.Radians);
        }

        public double Cos()
        {
            return Math.Cos(this.Radians);
        }

        public double Tg()
        {
            return Math.Tan(this.Radians);
        }

        public double Ctg()
        {
            return 1.0 / this.Tg();
        }

        public void Add(Angle angle)
        {
            this.Radians += angle.Radians;
        }

        public void AddRadians(double radians)
        {
            this.Radians += radians;
        }

        public void AddDegrees(double degrees)
        {
            this.Radians += DegreesToRadians(degrees);
        }

        public void AddGrads(double grads)
        {
            this.Radians += GradsToRadians(grads);
        }

        public void Subtract(Angle angle)
        {
            this.Radians -= angle.Radians;
        }

        public void SubtractRadians(double radians)
        {
            this.Radians -= radians;
        }

        public void SubtractDegrees(double degrees)
        {
            this.Radians -= DegreesToRadians(degrees);
        }

        public void SubtractGrads(double grads)
        {
            this.Radians -= GradsToRadians(grads);
        }

        public void Mutiply(double value)
        {
            this.Radians *= value;
        }

        public void Divide(double value)
        {
            this.Radians /= value;
        }

        public void Invert()
        {
            this.Radians = -this.Radians;
        }

        public Angle GetInverted()
        {
            return new Angle(-this.Radians);
        }

        public Vector2 Turn(Vector2 vector)
        {
            double cos = this.Cos();
            double sin = this.Sin();
            return new Vector2(
                vector.x * cos - vector.y * sin,
                vector.x * sin + vector.y * cos
            );
        }

        public Vector2 TurnBackward(Vector2 vector)
        {
            double cos = this.Cos();
            double sin = this.Sin();
            return new Vector2(
                vector.x * cos + vector.y * sin,
                vector.y * cos - vector.x * sin
            );
        }

        public Matrix2x2 GetRotationMatrix()
        {
            double cos = this.Cos();
            double sin = this.Sin();

            Matrix2x2 result = new Matrix2x2();

            result.a_1_1 = cos;
            result.a_1_2 = -sin;

            result.a_2_1 = sin;
            result.a_2_2 = cos;

            return result;
        }

        public Matrix2x2 GetBackwardRotationMatrix()
        {
            double cos = this.Cos();
            double sin = this.Sin();

            Matrix2x2 result = new Matrix2x2();

            result.a_1_1 = cos;
            result.a_1_2 = sin;

            result.a_2_1 = -sin;
            result.a_2_2 = cos;

            return result;
        }

        public static Angle operator +(Angle a1, Angle a2)
        {
            return new Angle(a1.Radians + a2.Radians);
        }

        public static Angle operator +(Angle angle, double radians)
        {
            return new Angle(angle.Radians + radians);
        }

        public static Angle operator +(double radians, Angle angle)
        {
            return new Angle(angle.Radians + radians);
        }

        public static Angle operator -(Angle a1, Angle a2)
        {
            return new Angle(a1.Radians - a2.Radians);
        }

        public static Angle operator -(Angle angle, double radians)
        {
            return new Angle(angle.Radians - radians);
        }

        public static Angle operator -(double radians, Angle angle)
        {
            return new Angle(radians - angle.Radians);
        }

        public static Angle operator *(Angle angle, double value)
        {
            return new Angle(angle.Radians * value);
        }

        public static Angle operator *(double value, Angle angle)
        {
            return new Angle(angle.Radians * value);
        }

        public static Angle operator /(Angle angle, double value)
        {
            return new Angle(angle.Radians / value);
        }

        public static Angle operator -(Angle angle)
        {
            return new Angle(-angle.Radians);
        }

        public static implicit operator double(Angle angle)
        {
            return angle.Radians;
        }

        public static explicit operator Angle(double radians)
        {
            return new Angle(radians);
        }

        public static implicit operator float(Angle angle)
        {
            return (float)angle.Radians;
        }

        public static explicit operator Angle(float radians)
        {
            return new Angle(radians);
        }

        public override string ToString()
        {
            return String.Format("AngleD(radians = {0}, degrees = {1})", this.Radians, this.Degrees);
        }
    }
}
