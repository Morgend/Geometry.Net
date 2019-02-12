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

        public double radians;

        public Angle(double radians)
        {
            this.radians = radians;
        }

        public Angle(Angle angle)
        {
            this.radians = angle.radians;
        }

        public static Angle fromDegrees(double degrees)
        {
            return new Angle(Angle.degreesToRadians(degrees));
        }

        public static Angle fromGrads(double grads)
        {
            return new Angle(Angle.gradsToRadians(grads));
        }

        public static double degreesToRadians(double degrees)
        {
            return degrees / DEGREES_IN_RADIAN;
        }

        public static double radiansToDegrees(double radians)
        {
            return radians * DEGREES_IN_RADIAN;
        }

        public static double gradsToRadians(double degrees)
        {
            return degrees / GRADS_IN_RADIAN;
        }

        public static double radiansToGrads(double radians)
        {
            return radians * GRADS_IN_RADIAN;
        }

        public double degrees
        {
            get
            {
                return DEGREES_IN_RADIAN * this.radians;
            }

            set
            {
                this.radians = value / DEGREES_IN_RADIAN;
            }
        }

        public double grads
        {
            get
            {
                return GRADS_IN_RADIAN * this.radians;
            }

            set
            {
                this.radians = value / GRADS_IN_RADIAN;
            }
        }


        public void setRadians(double radians)
        {
            this.radians = radians;
        }

        public void setDegrees(double degrees)
        {
            this.radians = degreesToRadians(degrees);
        }

        public void setGrads(double grads)
        {
            this.radians = gradsToRadians(degrees);
        }

        public void set(Angle angle)
        {
            this.radians = angle.radians;
        }
            

        public void normalize2Pi()
        {
            this.radians -= PIx2 * Math.Floor(this.radians / PIx2);

            if (this.radians < 0)
            {
                this.radians += PIx2;
            }
        }

        public void normalizePiMinusPi()
        {
            this.radians -= PIx2 * Math.Floor(this.radians / PIx2);

            if (this.radians > PI)
            {
                this.radians -= PIx2;
                return;
            }

            if (this.radians <= -PI)
            {
                this.radians += PIx2;
            }
        }

        public void zero()
        {
            this.radians = DEFAULT_VALUE;
        }

        public double sin()
        {
            return Math.Sin(this.radians);
        }

        public double cos()
        {
            return Math.Cos(this.radians);
        }

        public double tg()
        {
            return Math.Tan(this.radians);
        }

        public double ctg()
        {
            return 1.0 / this.tg();
        }

        public void add(Angle angle)
        {
            this.radians += angle.radians;
        }

        public void addRadians(double radians)
        {
            this.radians += radians;
        }

        public void addDegrees(double degrees)
        {
            this.radians += degreesToRadians(degrees);
        }

        public void addGrads(double grads)
        {
            this.radians += gradsToRadians(grads);
        }

        public void subtract(Angle angle)
        {
            this.radians -= angle.radians;
        }

        public void subtractRadians(double radians)
        {
            this.radians -= radians;
        }

        public void subtractDegrees(double degrees)
        {
            this.radians -= degreesToRadians(degrees);
        }

        public void subtractGrads(double grads)
        {
            this.radians -= gradsToRadians(grads);
        }

        public void mutiply(double value)
        {
            this.radians *= value;
        }

        public void divide(double value)
        {
            this.radians /= value;
        }

        public void invert()
        {
            this.radians = -this.radians;
        }

        public Angle getInverted()
        {
            return new Angle(-this.radians);
        }

        public Vector2 turn(Vector2 vector)
        {
            double cos = this.cos();
            double sin = this.sin();
            return new Vector2(
                vector.x * cos - vector.y * sin,
                vector.x * sin + vector.y * cos
            );
        }

        public Vector2 turnBackward(Vector2 vector)
        {
            double cos = this.cos();
            double sin = this.sin();
            return new Vector2(
                vector.x * cos + vector.y * sin,
                vector.y * cos - vector.x * sin
            );
        }

        public Matrix2x2 buildRotationMatrix()
        {
            double cos = this.cos();
            double sin = this.sin();

            Matrix2x2 result = new Matrix2x2();

            result.a_1_1 = cos;
            result.a_1_2 = -sin;

            result.a_2_1 = sin;
            result.a_2_2 = cos;

            return result;
        }

        public Matrix2x2 buildBackwardRotationMatrix()
        {
            double cos = this.cos();
            double sin = this.sin();

            Matrix2x2 result = new Matrix2x2();

            result.a_1_1 = cos;
            result.a_1_2 = sin;

            result.a_2_1 = -sin;
            result.a_2_2 = cos;

            return result;
        }

        public static Angle operator +(Angle a1, Angle a2)
        {
            return new Angle(a1.radians + a2.radians);
        }

        public static Angle operator +(Angle angle, double radians)
        {
            return new Angle(angle.radians + radians);
        }

        public static Angle operator +(double radians, Angle angle)
        {
            return new Angle(angle.radians + radians);
        }

        public static Angle operator -(Angle a1, Angle a2)
        {
            return new Angle(a1.radians - a2.radians);
        }

        public static Angle operator -(Angle angle, double radians)
        {
            return new Angle(angle.radians - radians);
        }

        public static Angle operator -(double radians, Angle angle)
        {
            return new Angle(radians - angle.radians);
        }

        public static Angle operator *(Angle angle, double value)
        {
            return new Angle(angle.radians * value);
        }

        public static Angle operator *(double value, Angle angle)
        {
            return new Angle(angle.radians * value);
        }

        public static Angle operator /(Angle angle, double value)
        {
            return new Angle(angle.radians / value);
        }

        public static Angle operator -(Angle angle)
        {
            return new Angle(-angle.radians);
        }

        public static implicit operator double(Angle angle)
        {
            return angle.radians;
        }

        public override string ToString()
        {
            return String.Format("Angle(radians = {0}, degrees = {1})", this.radians, this.degrees);
        }
    }
}
