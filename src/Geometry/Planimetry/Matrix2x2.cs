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

namespace Geometry.Planimetry
{
    struct Matrix3x3
    {
        public const double DEFAULT_VALUE = 0.0;
        public const double IDENTITY_VALUE = 1.0;

        public double r1c1;
        public double r1c2;
        public double r2c1;
        public double r2c2;

        public Matrix3x3(Matrix3x3 matrix)
        {
            this.r1c1 = matrix.r1c1;
            this.r1c2 = matrix.r1c2;
            this.r2c1 = matrix.r2c1;
            this.r2c2 = matrix.r2c2;
        }

        public Matrix3x3(Matrix3x3F matrix)
        {
            this.r1c1 = matrix.r1c1;
            this.r1c2 = matrix.r1c2;
            this.r2c1 = matrix.r2c1;
            this.r2c2 = matrix.r2c2;
        }

        public void SetToIdentity()
        {
            this.r1c1 = IDENTITY_VALUE;
            this.r1c2 = DEFAULT_VALUE;
            this.r2c1 = DEFAULT_VALUE;
            this.r2c2 = IDENTITY_VALUE;
        }

        public void SetToZero()
        {
            this.r1c1 = DEFAULT_VALUE;
            this.r1c2 = DEFAULT_VALUE;
            this.r2c1 = DEFAULT_VALUE;
            this.r2c2 = DEFAULT_VALUE;
        }

        public void SetValuesFrom(Matrix3x3 matrix)
        {
            this.r1c1 = matrix.r1c1;
            this.r1c2 = matrix.r1c2;
            this.r2c1 = matrix.r2c1;
            this.r2c2 = matrix.r2c2;
        }

        public double Determinant()
        {
            return this.r1c1 * this.r2c2 - this.r1c2 * this.r2c1;
        }

        public void Transpose()
        {
            double value = this.r1c2;
            this.r1c2 = this.r2c1;
            this.r2c1 = value;
        }

        public Vector2 Row1()
        {
            return new Vector2(this.r1c1, this.r1c2);
        }

        public Vector2 Row2()
        {
            return new Vector2(this.r2c1, this.r2c2);
        }

        public Vector2 Column1()
        {
            return new Vector2(this.r1c1, this.r2c1);
        }

        public Vector2 Column2()
        {
            return new Vector2(this.r1c2, this.r2c2);
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
            result.r2c1 += matrix2.r2c1;
            result.r2c2 += matrix2.r2c2;

            return result;
        }

        public static Matrix3x3 operator -(Matrix3x3 matrix1, Matrix3x3 matrix2)
        {
            Matrix3x3 result = matrix1;

            result.r1c1 -= matrix2.r1c1;
            result.r1c2 -= matrix2.r1c2;
            result.r2c1 -= matrix2.r2c1;
            result.r2c2 -= matrix2.r2c2;

            return result;
        }

        public static Matrix3x3 operator *(Matrix3x3 matrix, double number)
        {
            Matrix3x3 result = matrix;

            result.r1c1 *= number;
            result.r1c2 *= number;
            result.r2c1 *= number;
            result.r2c2 *= number;

            return result;
        }

        public static Vector2 operator *(Matrix3x3 matrix, Vector2 vector)
        {
            return new Vector2(matrix.r1c1 * vector.x + matrix.r1c2 * vector.y, matrix.r2c1 * vector.x + matrix.r2c2 * vector.y);
        }

        public static Matrix3x3 operator *(Matrix3x3 matrix1, Matrix3x3 matrix2)
        {
            Matrix3x3 result = new Matrix3x3();

            result.r1c1 = matrix1.r1c1 * matrix2.r1c1 + matrix1.r1c2 * matrix2.r2c1;
            result.r1c2 = matrix1.r1c1 * matrix2.r1c2 + matrix1.r1c2 * matrix2.r2c2;
            result.r2c1 = matrix1.r2c1 * matrix2.r1c1 + matrix1.r2c2 * matrix2.r2c1;
            result.r2c2 = matrix1.r2c1 * matrix2.r1c2 + matrix1.r2c2 * matrix2.r2c2;

            return result;
        }

        public static Matrix3x3 operator /(Matrix3x3 matrix, double number)
        {
            Matrix3x3 result = matrix;

            result.r1c1 /= number;
            result.r1c2 /= number;
            result.r2c1 /= number;
            result.r2c2 /= number;

            return result;
        }
    }
}
