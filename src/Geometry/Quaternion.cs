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
    public struct Quaternion
    {
        public const double DEFAULT_COORDINATE_VALUE = 0.0;

        public double w;
        public double x;
        public double y;
        public double z;

        public Quaternion(double w, double x, double y, double z)
        {
            this.w = w;
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void SetValues(double w, double x, double y, double z)
        {
            this.w = w;
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void CopyValuesOf(Quaternion q)
        {
            this.x = q.x;
            this.y = q.y;
            this.z = q.z;
            this.w = q.w;
        }

        public void SetToZero()
        {
            this.x = DEFAULT_COORDINATE_VALUE;
            this.y = DEFAULT_COORDINATE_VALUE;
            this.z = DEFAULT_COORDINATE_VALUE;
            this.w = DEFAULT_COORDINATE_VALUE;
        }

        public bool IsZero()
        {
            return this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w <= MathHelper.POSITIVE_SQUARE_DOUBLE_EPSYLON;
        }

        public void Conjugate()
        {
            this.x = -this.x;
            this.y = -this.y;
            this.z = -this.z;
        }

        public Quaternion GetConjugated()
        {
            return new Quaternion(this.w, - this.x, -this.y, -this.z);
        }

        public double Module()
        {
            return Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w);
        }

        public bool Normalize()
        {
            double squareModule = this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w;

            if (squareModule < MathHelper.POSITIVE_SQUARE_DOUBLE_EPSYLON)
            {
                this.SetToZero();
                return false;
            }

            double module = Math.Sqrt(squareModule);

            this.x /= module;
            this.y /= module;
            this.z /= module;
            this.w /= module;

            return true;
        }

        public Quaternion Multiply(Quaternion q, bool assign = false)
        {
            double w = this.w * q.w - this.x * q.x - this.y * q.y - this.z * q.z;
            double x = this.y * q.z - this.z * q.y + this.w * q.x + this.x * q.w;
            double y = this.x * q.z - this.z * q.x + this.w * q.y + this.y * q.w;
            double z = this.x * q.y - this.y * q.x + this.w * q.z + this.z * q.w;

            if (assign)
            {
                this.SetValues(w, x, y, z);
                return this;
            }

            return new Quaternion(w, x, y, z);
        }

        public void SetMultiplicationOf(Quaternion q1, Quaternion q2)
        {
            this.SetValues(
                q1.w * q2.w - q1.x * q2.x - q1.y * q2.y - q1.z * q2.z,
                q1.y * q2.z - q1.z * q2.y + q1.w * q2.x + q1.x * q2.w,
                q1.x * q2.z - q1.z * q2.x + q1.w * q2.y + q1.y * q2.w,
                q2.x * q2.y - q1.y * q2.x + q1.w * q2.z + q1.z * q2.w
            );
        }

        public Quaternion Multiply(double value, bool assign = false)
        {
            if (!assign)
            {
                return new Quaternion(this.w * value, this.x * value, this.y * value, this.z * value); 
            }

            this.w *= value;
            this.x *= value;
            this.y *= value;
            this.z *= value;

            return this;
        }

        public Quaternion Divide(double value, bool assign = false)
        {
            if (!assign)
            {
                return new Quaternion(this.w / value, this.x / value, this.y / value, this.z / value);
            }

            this.x /= value;
            this.y /= value;
            this.z /= value;
            this.w /= value;

            return this;
        }

        public QuaternionF ToDouble()
        {
            return new QuaternionF((float)this.w, (float)this.x, (float)this.y, (float)this.z);
        }

        public static Quaternion operator *(Quaternion q1, Quaternion q2)
        {
            return new Quaternion(
                q1.w * q2.w - q1.x * q2.x - q1.y * q2.y - q1.z * q2.z,
                q1.y * q2.z - q1.z * q2.y + q1.w * q2.x + q1.x * q2.w,
                q1.x * q2.z - q1.z * q2.x + q1.w * q2.y + q1.y * q2.w,
                q2.x * q2.y - q1.y * q2.x + q1.w * q2.z + q1.z * q2.w
            );
        }

        public static Quaternion operator *(Quaternion quaternion, double value)
        {
            return new Quaternion(quaternion.w * value, quaternion.x * value, quaternion.y * value, quaternion.z * value);
        }

        public static Quaternion operator *(double value, Quaternion quaternion)
        {
            return new Quaternion(quaternion.w * value, quaternion.x * value, quaternion.y * value, quaternion.z * value);
        }

        public static Quaternion operator /(Quaternion quaternion, double value)
        {
            return new Quaternion(quaternion.w / value, quaternion.x / value, quaternion.y / value, quaternion.z / value);
        }

        public static Quaternion operator -(Quaternion quaternion)
        {
            return new Quaternion(quaternion.w, -quaternion.x, -quaternion.y, -quaternion.z);
        }

        public override string ToString()
        {
            return String.Format("Quaternion(w: {0}, x: {1}, y: {2}, z: {3})", this.w, this.x, this.y, this.z);
        }
    }
}
