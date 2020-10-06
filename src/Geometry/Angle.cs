using System;

/*
 * Author: Andrey Pokidov
 * Date: 1 Feb 2019
 */

namespace Geometry
{
    public struct Angle : IComparable<Angle>
    {
        public const double DEFAULT_VALUE = 0.0;

        public const double PI = MathConstant.PI;
        public const double PIx2 = MathConstant.PIx2;
        public const double PId2 = MathConstant.PId2;

        public readonly static Angle ZERO = new Angle(0.0);
        public readonly static Angle AnglePI = new Angle(PI);
        public readonly static Angle AnglePIx2 = new Angle(PIx2);
        public readonly static Angle AnglePId2 = new Angle(PId2);

        public const double DEGREES_IN_RADIAN = 57.2957795130823209;
        public const double GRADIANS_IN_RADIAN = 63.6619772367581343;
        public const double DEGREES_IN_GRADIAN = 0.9;

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

        public static Angle FromGradians(double gradians)
        {
            return new Angle(Angle.GradiansToRadians(gradians));
        }

        public static double DegreesToRadians(double degrees)
        {
            return degrees / DEGREES_IN_RADIAN;
        }

        public static double RadiansToDegrees(double radians)
        {
            return radians * DEGREES_IN_RADIAN;
        }

        public static double GradiansToRadians(double gradians)
        {
            return gradians / GRADIANS_IN_RADIAN;
        }

        public static double RadiansToGradians(double radians)
        {
            return radians * GRADIANS_IN_RADIAN;
        }

        public static double GradiansToDegrees(double gradians)
        {
            return gradians * DEGREES_IN_GRADIAN;
        }

        public static double DegreesToGradians(double degrees)
        {
            return degrees / DEGREES_IN_GRADIAN;
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

        public double Gradians
        {
            get
            {
                return GRADIANS_IN_RADIAN * this.Radians;
            }

            set
            {
                this.Radians = value / GRADIANS_IN_RADIAN;
            }
        }

        public double GetRoundedDegrees()
        {
            return Math.Round(this.Radians * DEGREES_IN_RADIAN);
        }

        public double GetRoundedGradians()
        {
            return Math.Round(Radians * GRADIANS_IN_RADIAN);
        }

        public double GetStickyDegrees()
        {
            double degrees = DEGREES_IN_RADIAN * this.Radians;
            double rounded = Math.Round(degrees);

            if (Comparison.AreEqual(degrees, rounded))
            {
                return rounded;
            }

            return degrees;
        }

        public double GetStickyGradians()
        {
            double gradians = GRADIANS_IN_RADIAN * this.Radians;
            double rounded = Math.Round(gradians);

            if (Comparison.AreEqual(gradians, rounded))
            {
                return rounded;
            }

            return gradians;
        }

        public void Normalize2Pi()
        {
            this.Radians -= PIx2 * Math.Floor(this.Radians / PIx2);

            if (this.Radians >= 0)
            {
                return;
            }

            if (this.Radians > MathConstant.NEGATIVE_EPSYLON)
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
                if (this.Radians < PI + MathConstant.EPSYLON)
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
                if (this.Radians > -PI - MathConstant.EPSYLON)
                {
                    this.Radians = PI;
                }
                else
                {
                    this.Radians += PIx2;
                }
            }
        }

        public void RoundInDegrees()
        {
            this.Radians = Math.Round(this.Radians * DEGREES_IN_GRADIAN) / DEGREES_IN_GRADIAN;
        }

        public void RoundInGradians()
        {
            this.Radians = Math.Round(this.Radians * GRADIANS_IN_RADIAN) / GRADIANS_IN_RADIAN;
        }

        public void Zero()
        {
            this.Radians = DEFAULT_VALUE;
        }

        public static Angle Arcsin(double value)
        {
            if (value < -1.0 - MathConstant.EPSYLON || 1.0 + MathConstant.EPSYLON < value)
            {
                throw new AngleException(String.Format("Sinus value {0} is out of acceptable range [-1, 1]", value));
            }

            if (value >= 1.0)
            {
                return Angle.AnglePI;
            }

            if (value <= -1.0)
            {
                return Angle.AnglePI;
            }

            return new Angle(Math.Asin(value));
        }

        public static Angle Arccos(double value)
        {
            if (value < -1.0 - MathConstant.EPSYLON || 1.0 + MathConstant.EPSYLON < value)
            {
                throw new AngleException(String.Format("Cosinus value {0} is out of acceptable range [-1, 1]", value));
            }

            if (value >= 1.0)
            {
                return Angle.ZERO;
            }

            if (value <= -1.0)
            {
                return Angle.AnglePIx2;
            }

            return new Angle(Math.Acos(value));
        }

        public static Angle Arctg(double value)
        {
            return new Angle(Math.Atan(value));
        }

        public static Angle Arctg2(double y, double x)
        {
            return new Angle(Math.Atan2(y, x));
        }

        public static Angle Arсctg(double value)
        {
            return new Angle(Angle.PId2 - Math.Atan(value));
        }

        public static Angle Arсctg2(double x, double y)
        {
            return new Angle(Angle.PId2 - Math.Atan2(y, x));
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

        public void AddGradians(double gradians)
        {
            this.Radians += GradiansToRadians(gradians);
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

        public void SubtractGradians(double gradians)
        {
            this.Radians -= GradiansToRadians(gradians);
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

        public bool IsEqualTo(Angle angle)
        {
            return Comparison.AreEqual(this.Radians, angle.Radians);
        }

        public bool IsEqualTo(double radians)
        {
            return Comparison.AreEqual(this.Radians, radians);
        }

        public bool IsStrictlyEqualTo(Angle angle)
        {
            return this.Radians == angle.Radians;
        }

        public int CompareTo(Angle angle)
        {
            if (this.Radians < angle.Radians)
            {
                return -1;
            }

            if (this.Radians > angle.Radians)
            {
                return 1;
            }

            return 0;
        }

        public override bool Equals(Object angleInstance)
        {
            return Comparison.AreEqual(this.Radians, ((Angle)angleInstance).Radians);
        }

        public override int GetHashCode()
        {
            return this.Radians.GetHashCode();
        }

        public static bool operator >(Angle angle1, Angle angle2)
        {
            return angle1.Radians > angle2.Radians;
        }

        public static bool operator >=(Angle angle1, Angle angle2)
        {
            return angle1.Radians >= angle2.Radians;
        }

        public static bool operator <(Angle angle1, Angle angle2)
        {
            return angle1.Radians < angle2.Radians;
        }

        public static bool operator <=(Angle angle1, Angle angle2)
        {
            return angle1.Radians <= angle2.Radians;
        }

        public static bool operator ==(Angle angle1, Angle angle2)
        {
            return Comparison.AreEqual(angle1.Radians, angle2.Radians);
        }

        public static bool operator !=(Angle angle1, Angle angle2)
        {
            return !Comparison.AreEqual(angle1.Radians, angle2.Radians);
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
