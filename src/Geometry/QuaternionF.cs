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
    public struct QuaternionF
    {
        public const float DEFAULT_COORDINATE_VALUE = 0.0f;

        public float w;
        public float x;
        public float y;
        public float z;

        public QuaternionF(float w, float x, float y, float z)
        {
            this.w = w;
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void SetValues(float w, float x, float y, float z)
        {
            this.w = w;
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void CopyValuesOf(QuaternionF q)
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
            return this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w <= MathHelper.POSITIVE_SQUARE_FLOAT_EPSYLON;
        }

        public bool IsUnit()
        {
            float squareModule = this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w - 1.0f;
            return MathHelper.NEGATIVE_FLOAT_EPSYLON <= squareModule && squareModule <= MathHelper.POSITIVE_FLOAT_EPSYLON;
        }

        public bool IsCloseTo(QuaternionF quaternion)
        {
            float dw = this.w - quaternion.w;
            float dx = this.x - quaternion.x;
            float dy = this.y - quaternion.y;
            float dz = this.z - quaternion.z;

            return dw * dw + dx * dx + dy * dy + dz * dz <= MathHelper.POSITIVE_SQUARE_FLOAT_EPSYLON;
        }

        public bool IsCloseTo(float w, float x, float y, float z)
        {
            float dw = this.w - w;
            float dx = this.x - x;
            float dy = this.y - y;
            float dz = this.z - z;

            return dw * dw + dx * dx + dy * dy + dz * dz <= MathHelper.POSITIVE_SQUARE_FLOAT_EPSYLON;
        }

        public void Conjugate()
        {
            this.x = -this.x;
            this.y = -this.y;
            this.z = -this.z;
        }

        public QuaternionF GetConjugated()
        {
            return new QuaternionF(this.w, - this.x, -this.y, -this.z);
        }

        public float Module()
        {
            return MathF.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w);
        }

        public bool Normalize()
        {
            float squareModule = this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w;

            if (squareModule < MathHelper.POSITIVE_SQUARE_FLOAT_EPSYLON)
            {
                this.SetToZero();
                return false;
            }

            float module = MathF.Sqrt(squareModule);

            this.x /= module;
            this.y /= module;
            this.z /= module;
            this.w /= module;

            return true;
        }

        public QuaternionF Multiply(QuaternionF q, bool assign = false)
        {
            float w = this.w * q.w - this.x * q.x - this.y * q.y - this.z * q.z;
            float x = this.y * q.z - this.z * q.y + this.w * q.x + this.x * q.w;
            float y = this.x * q.z - this.z * q.x + this.w * q.y + this.y * q.w;
            float z = this.x * q.y - this.y * q.x + this.w * q.z + this.z * q.w;

            if (assign)
            {
                this.SetValues(w, x, y, z);
                return this;
            }

            return new QuaternionF(w, x, y, z);
        }

        public void SetMultiplicationOf(QuaternionF q1, QuaternionF q2)
        {
            this.SetValues(
                q1.w * q2.w - q1.x * q2.x - q1.y * q2.y - q1.z * q2.z,
                q1.y * q2.z - q1.z * q2.y + q1.w * q2.x + q1.x * q2.w,
                q1.x * q2.z - q1.z * q2.x + q1.w * q2.y + q1.y * q2.w,
                q2.x * q2.y - q1.y * q2.x + q1.w * q2.z + q1.z * q2.w
            );
        }

        public QuaternionF Multiply(float value, bool assign = false)
        {
            if (!assign)
            {
                return new QuaternionF(this.w * value, this.x * value, this.y * value, this.z * value); 
            }

            this.w *= value;
            this.x *= value;
            this.y *= value;
            this.z *= value;

            return this;
        }

        public QuaternionF Divide(float value, bool assign = false)
        {
            if (!assign)
            {
                return new QuaternionF(this.w / value, this.x / value, this.y / value, this.z / value);
            }

            this.x /= value;
            this.y /= value;
            this.z /= value;
            this.w /= value;

            return this;
        }

        public Quaternion ToDouble()
        {
            return new Quaternion(this.w, this.x, this.y, this.z);
        }

        public static QuaternionF operator *(QuaternionF q1, QuaternionF q2)
        {
            return new QuaternionF(
                q1.w * q2.w - q1.x * q2.x - q1.y * q2.y - q1.z * q2.z,
                q1.y * q2.z - q1.z * q2.y + q1.w * q2.x + q1.x * q2.w,
                q1.x * q2.z - q1.z * q2.x + q1.w * q2.y + q1.y * q2.w,
                q2.x * q2.y - q1.y * q2.x + q1.w * q2.z + q1.z * q2.w
            );
        }

        public static QuaternionF operator *(QuaternionF quaternion, float value)
        {
            return new QuaternionF(quaternion.w * value, quaternion.x * value, quaternion.y * value, quaternion.z * value);
        }

        public static QuaternionF operator *(float value, QuaternionF quaternion)
        {
            return new QuaternionF(quaternion.w * value, quaternion.x * value, quaternion.y * value, quaternion.z * value);
        }

        public static QuaternionF operator /(QuaternionF quaternion, float value)
        {
            return new QuaternionF(quaternion.w / value, quaternion.x / value, quaternion.y / value, quaternion.z / value);
        }

        public static QuaternionF operator -(QuaternionF quaternion)
        {
            return new QuaternionF(quaternion.w, -quaternion.x, -quaternion.y, -quaternion.z);
        }

        public override string ToString()
        {
            return String.Format("QuaternionF(w: {0}, x: {1}, y: {2}, z: {3})", this.w, this.x, this.y, this.z);
        }
    }
}
