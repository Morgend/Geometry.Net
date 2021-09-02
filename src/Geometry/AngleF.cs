/*
 * Copyright 2019-2021 Andrey Pokidov <andrey.pokidov@gmail.com>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

/*
 * Author: Andrey Pokidov
 * Date: 1 Feb 2019
 */

namespace Geometry
{
    public struct AngleF
    {
        public const float DEFAULT_VALUE = 0.0f;

        /// <summary>
        /// PI 
        /// </summary>
        public const float PI = MathF.PI;

        /// <summary>
        /// 2 x PI 
        /// </summary>
        public const float PIx2 = MathF.PI * 2.0f;

        /// <summary>
        /// 0.5 PI (PI divided by 2)
        /// </summary>
        public const float PId2 = MathF.PI * 0.5f;

        /// <summary>
        /// 3/2 PI
        /// </summary>
        public const float PIx3d2 = MathF.PI * 1.5f;

        public readonly static AngleF ZERO = new AngleF(0.0f);
        public readonly static AngleF AngleFPI = new AngleF(PI);
        public readonly static AngleF AngleFPIx2 = new AngleF(PIx2);
        public readonly static AngleF AngleFPId2 = new AngleF(PId2);

        public const float DEGREES_IN_RADIAN = 57.295779513f;
        public const float GRADIANS_IN_RADIAN = 63.661977237f;
        public const float DEGREES_IN_GRADIAN = 0.9f;

        public float Radians;

        public AngleF(float radians)
        {
            this.Radians = radians;
        }

        public AngleF(AngleF angle)
        {
            this.Radians = angle.Radians;
        }

        public static AngleF FromDegrees(float degrees)
        {
            return new AngleF(AngleF.DegreesToRadians(degrees));
        }

        public static AngleF FromGradians(float gradians)
        {
            return new AngleF(AngleF.GradiansToRadians(gradians));
        }

        public static float DegreesToRadians(float degrees)
        {
            return degrees / DEGREES_IN_RADIAN;
        }

        public static float RadiansToDegrees(float radians)
        {
            return radians * DEGREES_IN_RADIAN;
        }

        public static float GradiansToRadians(float gradians)
        {
            return gradians / GRADIANS_IN_RADIAN;
        }

        public static float RadiansToGradians(float radians)
        {
            return radians * GRADIANS_IN_RADIAN;
        }

        public static float GradiansToDegrees(float gradians)
        {
            return gradians * DEGREES_IN_GRADIAN;
        }

        public static float DegreesToGradians(float degrees)
        {
            return degrees / DEGREES_IN_GRADIAN;
        }

        public float Degrees
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

        public float Gradians
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

        public float GetRoundedDegrees()
        {
            return MathF.Round(this.Radians * DEGREES_IN_RADIAN);
        }

        public float GetRoundedGradians()
        {
            return MathF.Round(Radians * GRADIANS_IN_RADIAN);
        }

        public float GetStickyDegrees()
        {
            float degrees = DEGREES_IN_RADIAN * this.Radians;
            float rounded = MathF.Round(degrees);

            if (MathHelper.AreEqual(degrees, rounded))
            {
                return rounded;
            }

            return degrees;
        }

        public float GetStickyGradians()
        {
            float gradians = GRADIANS_IN_RADIAN * this.Radians;
            float rounded = MathF.Round(gradians);

            if (MathHelper.AreEqual(gradians, rounded))
            {
                return rounded;
            }

            return gradians;
        }

        public void Normalize2Pi()
        {
            this.Radians -= PIx2 * MathF.Floor(this.Radians / PIx2);

            if (this.Radians >= 0)
            {
                return;
            }

            if (this.Radians > MathHelper.NEGATIVE_FLOAT_EPSYLON)
            {
                this.Radians = 0;
                return;
            }

            this.Radians += PIx2;

        }

        public void NormalizePiMinusPi()
        {
            this.Radians -= PIx2 * MathF.Floor(this.Radians / PIx2);

            if (this.Radians > PI)
            {
                if (this.Radians < PI + MathHelper.POSITIVE_FLOAT_EPSYLON)
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
                if (this.Radians > -PI - MathHelper.POSITIVE_FLOAT_EPSYLON)
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
            this.Radians = MathF.Round(this.Radians * DEGREES_IN_GRADIAN) / DEGREES_IN_GRADIAN;
        }

        public void RoundInGradians()
        {
            this.Radians = MathF.Round(this.Radians * GRADIANS_IN_RADIAN) / GRADIANS_IN_RADIAN;
        }

        public void Zero()
        {
            this.Radians = DEFAULT_VALUE;
        }

        public static AngleF Arcsin(float value)
        {
            if (value < -1.0 - MathHelper.POSITIVE_FLOAT_EPSYLON || 1.0 + MathHelper.POSITIVE_FLOAT_EPSYLON < value)
            {
                throw new AngleException(String.Format("Sinus value {0} is out of acceptable range [-1, 1]", value));
            }

            if (value >= 1.0)
            {
                return AngleF.AngleFPI;
            }

            if (value <= -1.0)
            {
                return AngleF.AngleFPI;
            }

            return new AngleF(MathF.Asin(value));
        }

        public static AngleF Arccos(float value)
        {
            if (value < -1.0 - MathHelper.POSITIVE_FLOAT_EPSYLON || 1.0 + MathHelper.POSITIVE_FLOAT_EPSYLON < value)
            {
                throw new AngleException(String.Format("Cosinus value {0} is out of acceptable range [-1, 1]", value));
            }

            if (value >= 1.0)
            {
                return AngleF.ZERO;
            }

            if (value <= -1.0)
            {
                return AngleF.AngleFPIx2;
            }

            return new AngleF(MathF.Acos(value));
        }

        public static AngleF Arctg(float value)
        {
            return new AngleF(MathF.Atan(value));
        }

        public static AngleF Arctg2(float y, float x)
        {
            return new AngleF(MathF.Atan2(y, x));
        }

        public static AngleF Arсctg(float value)
        {
            return new AngleF(AngleF.PId2 - MathF.Atan(value));
        }

        public static AngleF Arсctg2(float x, float y)
        {
            return new AngleF(AngleF.PId2 - MathF.Atan2(y, x));
        }

        public float Sin()
        {
            return MathF.Sin(this.Radians);
        }

        public float Cos()
        {
            return MathF.Cos(this.Radians);
        }

        public float Tg()
        {
            return MathF.Tan(this.Radians);
        }

        public float Ctg()
        {
            return 1.0f / this.Tg();
        }

        public void Add(AngleF angle)
        {
            this.Radians += angle.Radians;
        }

        public void AddRadians(float radians)
        {
            this.Radians += radians;
        }

        public void AddDegrees(float degrees)
        {
            this.Radians += DegreesToRadians(degrees);
        }

        public void AddGradians(float gradians)
        {
            this.Radians += GradiansToRadians(gradians);
        }

        public void Subtract(AngleF angle)
        {
            this.Radians -= angle.Radians;
        }

        public void SubtractRadians(float radians)
        {
            this.Radians -= radians;
        }

        public void SubtractDegrees(float degrees)
        {
            this.Radians -= DegreesToRadians(degrees);
        }

        public void SubtractGradians(float gradians)
        {
            this.Radians -= GradiansToRadians(gradians);
        }

        public void Mutiply(float value)
        {
            this.Radians *= value;
        }

        public void Divide(float value)
        {
            this.Radians /= value;
        }

        public void Invert()
        {
            this.Radians = -this.Radians;
        }

        public AngleF GetInverted()
        {
            return new AngleF(-this.Radians);
        }

        public Angle ToDouble()
        {
            return new Angle(this.Radians);
        }

        public bool IsEqualTo(AngleF angle)
        {
            return MathHelper.AreEqual(this.Radians, angle.Radians);
        }

        public bool IsEqualTo(float radians)
        {
            return MathHelper.AreEqual(this.Radians, radians);
        }

        public bool IsStrictlyEqualTo(AngleF angle)
        {
            return this.Radians == angle.Radians;
        }

        public override bool Equals(Object angleInstance)
        {
            return MathHelper.AreEqual(this.Radians, ((AngleF)angleInstance).Radians);
        }

        public override int GetHashCode()
        {
            return this.Radians.GetHashCode();
        }

        public static bool operator >(AngleF angle1, AngleF angle2)
        {
            return angle1.Radians > angle2.Radians;
        }

        public static bool operator >(AngleF angle, float radians)
        {
            return angle.Radians > radians;
        }

        public static bool operator >(float radians, AngleF angle)
        {
            return radians > angle.Radians;
        }

        public static bool operator >=(AngleF angle1, AngleF angle2)
        {
            return angle1.Radians >= angle2.Radians;
        }

        public static bool operator >=(AngleF angle, float radians)
        {
            return angle.Radians >= radians;
        }

        public static bool operator >=(float radians, AngleF angle)
        {
            return radians >= angle.Radians;
        }

        public static bool operator <(AngleF angle1, AngleF angle2)
        {
            return angle1.Radians < angle2.Radians;
        }

        public static bool operator <(AngleF angle, float radians)
        {
            return angle.Radians < radians;
        }

        public static bool operator <(float radians, AngleF angle)
        {
            return radians < angle.Radians;
        }

        public static bool operator <=(AngleF angle1, AngleF angle2)
        {
            return angle1.Radians <= angle2.Radians;
        }

        public static bool operator <=(AngleF angle, float radians)
        {
            return angle.Radians <= radians;
        }

        public static bool operator <=(float radians, AngleF angle)
        {
            return radians <= angle.Radians;
        }

        public static bool operator ==(AngleF angle1, AngleF angle2)
        {
            return angle1.Radians == angle2.Radians;
        }

        public static bool operator ==(AngleF angle, float radians)
        {
            return angle.Radians == radians;
        }

        public static bool operator ==(float radians, AngleF angle)
        {
            return radians == angle.Radians;
        }

        public static bool operator !=(AngleF angle1, AngleF angle2)
        {
            return angle1.Radians != angle2.Radians;
        }

        public static bool operator !=(AngleF angle, float radians)
        {
            return angle.Radians != radians;
        }

        public static bool operator !=(float radians, AngleF angle)
        {
            return radians != angle.Radians;
        }

        public static AngleF operator +(AngleF a1, AngleF a2)
        {
            return new AngleF(a1.Radians + a2.Radians);
        }

        public static AngleF operator +(AngleF angle, float radians)
        {
            return new AngleF(angle.Radians + radians);
        }

        public static AngleF operator +(float radians, AngleF angle)
        {
            return new AngleF(angle.Radians + radians);
        }

        public static AngleF operator -(AngleF a1, AngleF a2)
        {
            return new AngleF(a1.Radians - a2.Radians);
        }

        public static AngleF operator -(AngleF angle, float radians)
        {
            return new AngleF(angle.Radians - radians);
        }

        public static AngleF operator -(float radians, AngleF angle)
        {
            return new AngleF(radians - angle.Radians);
        }

        public static AngleF operator *(AngleF angle, float value)
        {
            return new AngleF(angle.Radians * value);
        }

        public static AngleF operator *(float value, AngleF angle)
        {
            return new AngleF(angle.Radians * value);
        }

        public static AngleF operator /(AngleF angle, float value)
        {
            return new AngleF(angle.Radians / value);
        }

        public static float operator /(AngleF angle1, AngleF angle2)
        {
            return angle1.Radians / angle2.Radians;
        }

        public static AngleF operator -(AngleF angle)
        {
            return new AngleF(-angle.Radians);
        }

        public override string ToString()
        {
            return String.Format("AngleFD(radians = {0}, degrees = {1})", this.Radians, this.Degrees);
        }
    }
}
