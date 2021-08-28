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
 * Date: 10 Feb 2019
 */

namespace Geometry.Stereometry
{
    public struct Matrix3x3
    {
        public const double DEFAULT_VALUE = 0.0;
        public const double IDENTITY_VALUE = 1.0;

        public double r1c1;
        public double r1c2;
        public double r1c3;

        public double r2c1;
        public double r2c2;
        public double r2c3;

        public double r3c1;
        public double r3c2;
        public double r3c3;

        public Matrix3x3(Matrix3x3 matrix)
        {
            this.r1c1 = matrix.r1c1;
            this.r1c2 = matrix.r1c2;
            this.r1c3 = matrix.r1c3;

            this.r2c1 = matrix.r2c1;
            this.r2c2 = matrix.r2c2;
            this.r2c3 = matrix.r2c3;

            this.r3c1 = matrix.r3c1;
            this.r3c2 = matrix.r3c2;
            this.r3c3 = matrix.r3c3;
        }

        public Matrix3x3(Matrix3x3F matrix)
        {
            this.r1c1 = matrix.r1c1;
            this.r1c2 = matrix.r1c2;
            this.r1c3 = matrix.r1c3;

            this.r2c1 = matrix.r2c1;
            this.r2c2 = matrix.r2c2;
            this.r2c3 = matrix.r2c3;

            this.r3c1 = matrix.r3c1;
            this.r3c2 = matrix.r3c2;
            this.r3c3 = matrix.r3c3;
        }

        public void SetToIdentity()
        {
            this.r1c1 = IDENTITY_VALUE;
            this.r1c2 = DEFAULT_VALUE;
            this.r1c3 = DEFAULT_VALUE;

            this.r2c1 = DEFAULT_VALUE;
            this.r2c2 = IDENTITY_VALUE;
            this.r2c3 = DEFAULT_VALUE;

            this.r3c1 = DEFAULT_VALUE;
            this.r3c2 = DEFAULT_VALUE;
            this.r3c3 = IDENTITY_VALUE;
        }

        public void SetToZero()
        {
            this.r1c1 = DEFAULT_VALUE;
            this.r1c2 = DEFAULT_VALUE;
            this.r1c3 = DEFAULT_VALUE;

            this.r2c1 = DEFAULT_VALUE;
            this.r2c2 = DEFAULT_VALUE;
            this.r2c3 = DEFAULT_VALUE;

            this.r3c1 = DEFAULT_VALUE;
            this.r3c2 = DEFAULT_VALUE;
            this.r3c3 = DEFAULT_VALUE;
        }

        public void SetValuesFrom(Matrix3x3 matrix)
        {
            this.r1c1 = matrix.r1c1;
            this.r1c2 = matrix.r1c2;
            this.r1c3 = matrix.r1c3;

            this.r2c1 = matrix.r2c1;
            this.r2c2 = matrix.r2c2;
            this.r2c3 = matrix.r2c3;

            this.r3c1 = matrix.r3c1;
            this.r3c2 = matrix.r3c2;
            this.r3c3 = matrix.r3c3;
        }

        public double Determinant()
        {
            return this.r1c1 * this.r2c2 * this.r3c3
                 + this.r1c2 * this.r2c3 * this.r3c1
                 + this.r1c3 * this.r2c1 * this.r3c2
                 - this.r1c3 * this.r2c2 * this.r3c1
                 - this.r1c2 * this.r2c1 * this.r3c3
                 - this.r1c1 * this.r2c3 * this.r3c2;
        }

        public void Transpose()
        {
            double value = this.r1c2;
            this.r1c2 = this.r2c1;
            this.r2c1 = value;

            value = this.r1c3;
            this.r1c3 = this.r3c1;
            this.r3c1 = value;

            value = this.r2c3;
            this.r2c3 = this.r3c2;
            this.r3c2 = value;
        }

        public Vector3 Row1()
        {
            return new Vector3(this.r1c1, this.r1c2, this.r1c3);
        }

        public Vector3 Row2()
        {
            return new Vector3(this.r2c1, this.r2c2, this.r2c3);
        }

        public Vector3 Row3()
        {
            return new Vector3(this.r3c1, this.r3c2, this.r3c3);
        }

        public Vector3 Column1()
        {
            return new Vector3(this.r1c1, this.r2c1, this.r3c1);
        }

        public Vector3 Column2()
        {
            return new Vector3(this.r1c2, this.r2c2, this.r3c2);
        }

        public Vector3 Column3()
        {
            return new Vector3(this.r1c3, this.r2c3, this.r3c3);
        }

        public Matrix3x3F ToFloat()
        {
            return new Matrix3x3F(this);
        }

        public static Matrix3x3 operator +(Matrix3x3 matrix1, Matrix3x3 matrix2)
        {
            Matrix3x3 result = matrix1;

            result.r1c1 += matrix2.r1c1;
            result.r1c2 += matrix2.r1c2;
            result.r1c3 += matrix2.r1c3;

            result.r2c1 += matrix2.r2c1;
            result.r2c2 += matrix2.r2c2;
            result.r2c3 += matrix2.r2c3;

            result.r3c1 += matrix2.r3c1;
            result.r3c2 += matrix2.r3c2;
            result.r3c3 += matrix2.r3c3;

            return result;
        }

        public static Matrix3x3 operator -(Matrix3x3 matrix1, Matrix3x3 matrix2)
        {
            Matrix3x3 result = matrix1;

            result.r1c1 -= matrix2.r1c1;
            result.r1c2 -= matrix2.r1c2;
            result.r1c3 -= matrix2.r1c3;

            result.r2c1 -= matrix2.r2c1;
            result.r2c2 -= matrix2.r2c2;
            result.r2c3 -= matrix2.r2c3;

            result.r3c1 -= matrix2.r3c1;
            result.r3c2 -= matrix2.r3c2;
            result.r3c3 -= matrix2.r3c3;

            return result;
        }

        public static Matrix3x3 operator *(Matrix3x3 matrix, double number)
        {
            Matrix3x3 result = matrix;

            result.r1c1 *= number;
            result.r1c2 *= number;
            result.r1c3 *= number;

            result.r2c1 *= number;
            result.r2c2 *= number;
            result.r2c3 *= number;

            result.r3c1 *= number;
            result.r3c2 *= number;
            result.r3c3 *= number;

            return result;
        }

        public static Vector3 operator *(Matrix3x3 matrix, Vector3 vector)
        {
            return new Vector3(
                matrix.r1c1 * vector.x + matrix.r1c2 * vector.y + matrix.r1c3 * vector.z,
                matrix.r2c1 * vector.x + matrix.r2c2 * vector.y + matrix.r2c3 * vector.z,
                matrix.r3c1 * vector.x + matrix.r3c2 * vector.y + matrix.r3c3 * vector.z
            );
        }

        public static Matrix3x3 operator *(Matrix3x3 matrix1, Matrix3x3 matrix2)
        {
            Matrix3x3 result = new Matrix3x3();

            result.r1c1 = matrix1.r1c1 * matrix2.r1c1 + matrix1.r1c2 * matrix2.r2c1 + matrix1.r1c3 * matrix2.r3c1;
            result.r1c2 = matrix1.r1c1 * matrix2.r1c2 + matrix1.r1c2 * matrix2.r2c2 + matrix1.r1c3 * matrix2.r3c2;
            result.r1c3 = matrix1.r1c1 * matrix2.r1c3 + matrix1.r1c2 * matrix2.r2c3 + matrix1.r1c3 * matrix2.r3c3;

            result.r2c1 = matrix1.r2c1 * matrix2.r1c1 + matrix1.r2c2 * matrix2.r2c1 + matrix1.r2c3 * matrix2.r3c1;
            result.r2c2 = matrix1.r2c1 * matrix2.r1c2 + matrix1.r2c2 * matrix2.r2c2 + matrix1.r2c3 * matrix2.r3c2;
            result.r2c3 = matrix1.r2c1 * matrix2.r1c3 + matrix1.r2c2 * matrix2.r2c3 + matrix1.r2c3 * matrix2.r3c3;

            result.r3c1 = matrix1.r3c1 * matrix2.r1c1 + matrix1.r3c2 * matrix2.r2c1 + matrix1.r3c3 * matrix2.r3c1;
            result.r3c2 = matrix1.r3c1 * matrix2.r1c2 + matrix1.r3c2 * matrix2.r2c2 + matrix1.r3c3 * matrix2.r3c2;
            result.r3c3 = matrix1.r3c1 * matrix2.r1c3 + matrix1.r3c2 * matrix2.r2c3 + matrix1.r3c3 * matrix2.r3c3;

            return result;
        }

        public static Matrix3x3 operator /(Matrix3x3 matrix, double number)
        {
            Matrix3x3 result = matrix;

            result.r1c1 /= number;
            result.r1c2 /= number;
            result.r1c3 /= number;

            result.r2c1 /= number;
            result.r2c2 /= number;
            result.r2c3 /= number;

            result.r3c1 /= number;
            result.r3c2 /= number;
            result.r3c3 /= number;

            return result;
        }
    }
}
