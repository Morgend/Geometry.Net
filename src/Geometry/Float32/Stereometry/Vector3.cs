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

namespace Geometry.Float32.Stereometry
{
    public struct Vector3
    {
        public const float DEFAULT_COORDINATE_VALUE = 0.0f;
        public static readonly Vector3 ZERO_VECTOR = new Vector3(0.0f, 0.0f, 0.0f);

        public static readonly Vector3 UNIT_X_VECTOR = new Vector3(1.0f, 0.0f, 0.0f);
        public static readonly Vector3 UNIT_Y_VECTOR = new Vector3(0.0f, 1.0f, 0.0f);
        public static readonly Vector3 UNIT_Z_VECTOR = new Vector3(0.0f, 0.0f, 1.0f);

        public float x;
        public float y;
        public float z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(Vector3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        public void SetToZero()
        {
            this.x = DEFAULT_COORDINATE_VALUE;
            this.y = DEFAULT_COORDINATE_VALUE;
            this.z = DEFAULT_COORDINATE_VALUE;
        }

        public bool IsZero()
        {
            return x * x + y * y + z * z <= MathHelper.POSITIVE_FLOAT_EPSYLON;
        }

        public bool IsUnit()
        {
            float difference = x * x + y * y + z * z - 1.0f;
            return MathHelper.NEGATIVE_SQUARE_FLOAT_EPSYLON <= difference && difference <= MathHelper.POSITIVE_SQUARE_FLOAT_EPSYLON;
        }

        public void SetValues(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void CopyValuesFrom(Vector3 vector)
        {
            this.x = vector.x;
            this.y = vector.y;
            this.z = vector.z;
        }

        public void CopyValuesFrom(Geometry.Float64.Stereometry.Vector3 vector)
        {
            this.x = (float)vector.x;
            this.y = (float)vector.y;
            this.z = (float)vector.z;
        }

        public float Scalar(Vector3 vector)
        {
            return this.x * vector.x + this.y * vector.y + this.z * vector.z;
        }

        public float Module()
        {
            return MathF.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
        }

        public bool Normalize()
        {
            float squareModule = this.x * this.x + this.y * this.y + this.z * this.z;

            if (squareModule == 1.0)
            {
                return true;
            }

            if (squareModule == 0.0)
            {
                return false;
            }

            if (squareModule < MathHelper.POSITIVE_SQUARE_DOUBLE_EPSYLON)
            {
                this.SetToZero();
                return false;
            }

            float module = MathF.Sqrt(squareModule);

            this.x /= module;
            this.y /= module;
            this.z /= module;

            return true;
        }

        public Vector3 GetNormalized()
        {
            Vector3 result = this;
            result.Normalize();
            return result;
        }


        public Vector3 Add(Vector3 vector, bool assign = false)
        {
            if (assign)
            {
                this.x += vector.x;
                this.y += vector.y;
                this.z += vector.z;
                return this;
            }

            return new Vector3(this.x + vector.x, this.y + vector.y, this.z + vector.z);
        }

        public Vector3 Subtract(Vector3 vector, bool assign = false)
        {
            if (assign)
            {
                this.x += vector.x;
                this.y += vector.y;
                this.z += vector.z;
                return this;
            }

            return new Vector3(this.x + vector.x, this.y + vector.y, this.z + vector.z);
        }

        public Vector3 Multiply(float value, bool assign = false)
        {
            if (assign)
            {
                this.x *= value;
                this.y *= value;
                this.z *= value;
                return this;
            }

            return new Vector3(this.x * value, this.y * value, this.z * value);
        }

        public Vector3 VectorMultiply(Vector3 vector, bool assign = false)
        {
            float x = this.y * vector.z - this.z * vector.y;
            float y = this.z * vector.x - this.x * vector.z;
            float z = this.x * vector.y - this.y * vector.x;

            if (assign)
            {
                this.SetValues(x, y, z);
                return this;
            }

            return new Vector3(x, y, z);
        }

        public Vector3 Divide(float value, bool assign = false)
        {
            if (assign)
            {
                this.x /= value;
                this.y /= value;
                this.z /= value;
                return this;
            }

            return new Vector3(this.x / value, this.y / value, this.z / value);
        }

        public void Reverse()
        {
            this.x = -this.x;
            this.y = -this.y;
            this.z = -this.z;
        }

        public Vector3 GetReverted()
        {
            return new Vector3(-this.x, -this.y, -this.z);
        }

        public Geometry.Float64.Stereometry.Vector3 ToDouble()
        {
            return new Geometry.Float64.Stereometry.Vector3(this.x, this.y, this.z);
        }

        public bool IsEqualTo(Vector3 v)
        {
            return MathHelper.AreEqual(this.x, v.x) && MathHelper.AreEqual(this.y, v.y) && MathHelper.AreEqual(this.z, v.z);
        }

        public bool IsStrictlyEqualTo(Vector3 v)
        {
            return this.x == v.x && this.y == v.y && this.z == v.z;
        }

        // ========================================================

        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector3 operator *(Vector3 vector, float value)
        {
            return new Vector3(vector.x * value, vector.y * value, vector.z * value);
        }

        public static Vector3 operator *(float value, Vector3 vector)
        {
            return new Vector3(vector.x * value, vector.y * value, vector.z * value);
        }

        public static Vector3 operator /(Vector3 vector, float value)
        {
            return new Vector3(vector.x / value, vector.y / value, vector.z / value);
        }

        public static Vector3 operator -(Vector3 v)
        {
            return new Vector3(-v.x, -v.y, -v.z);
        }

        public override string ToString()
        {
            return String.Format("Vector3({0}, {1}, {2})", this.x, this.y, this.z);
        }
    }
}
