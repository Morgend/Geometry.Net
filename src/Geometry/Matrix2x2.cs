using System;

/*
 * Author: Andrey Pokidov
 * Date: 10 Feb 2019
 */

namespace Geometry
{
    public enum MatrixInitialMode
    {
        ZERO_MATRIX = 0x0,
        IDENTITY_MATRIX = 0x1,
    }

    public struct Matrix2x2
    {
        public const double DEFAULT_VALUE = 0.0;
        public const double DEFAULT_IDENTITY_VALUE = 1.0;

        public double a_1_1;
        public double a_1_2;

        public double a_2_1;
        public double a_2_2;

        public Matrix2x2(MatrixInitialMode matrixMode = MatrixInitialMode.IDENTITY_MATRIX)
        {
            if (matrixMode == MatrixInitialMode.IDENTITY_MATRIX)
            {
                this.a_1_1 = DEFAULT_IDENTITY_VALUE;
                this.a_2_2 = DEFAULT_IDENTITY_VALUE;
            }
            else
            {
                this.a_1_1 = DEFAULT_VALUE;
                this.a_2_2 = DEFAULT_VALUE;
            }

            this.a_1_2 = DEFAULT_VALUE;
            this.a_2_1 = DEFAULT_VALUE;
        }

        public Matrix2x2(Matrix2x2 matrix)
        {
            this.a_1_1 = matrix.a_1_1;
            this.a_1_2 = matrix.a_1_2;

            this.a_2_1 = matrix.a_2_1;
            this.a_2_2 = matrix.a_2_2;
        }

        public double Determinant()
        {
            return this.a_1_1 * this.a_2_2 - this.a_2_1 * this.a_1_2;
        }

        public void Reset(MatrixInitialMode matrixMode = MatrixInitialMode.IDENTITY_MATRIX)
        {
            if (matrixMode == MatrixInitialMode.IDENTITY_MATRIX)
            {
                this.a_1_1 = DEFAULT_IDENTITY_VALUE;
                this.a_2_2 = DEFAULT_IDENTITY_VALUE;
            }
            else
            {
                this.a_1_1 = DEFAULT_VALUE;
                this.a_2_2 = DEFAULT_VALUE;
            }

            this.a_1_2 = DEFAULT_VALUE;
            this.a_2_1 = DEFAULT_VALUE;
        }

        public Vector2 Row(int index)
        {
            switch (index)
            {
                case 1:
                    return new Vector2(this.a_1_1, this.a_1_2);

                case 2:
                    return new Vector2(this.a_2_1, this.a_2_2);
            }

            return Vector2.ZERO_VECTOR;
        }

        public Vector2 Column(int index)
        {
            switch (index)
            {
                case 1:
                    return new Vector2(this.a_1_1, this.a_2_1);

                case 2:
                    return new Vector2(this.a_1_2, this.a_2_2);
            }

            return Vector2.ZERO_VECTOR;
        }

        public void Transpose()
        {
            double value = a_1_2;
            a_1_2 = a_2_1;
            a_2_1 = value;
        }

        public void Set(Matrix2x2 matrix)
        {
            this.a_1_1 = matrix.a_1_1;
            this.a_1_2 = matrix.a_1_2;

            this.a_2_1 = matrix.a_2_1;
            this.a_2_2 = matrix.a_2_2;
        }

        public void Add(Matrix2x2 matrix)
        {
            this.a_1_1 += matrix.a_1_1;
            this.a_1_2 += matrix.a_1_2;

            this.a_2_1 += matrix.a_2_1;
            this.a_2_2 += matrix.a_2_2;
        }

        public void SetSumOf(Matrix3x3 firstMatrix, Matrix3x3 secondMatrix)
        {
            this.a_1_1 = firstMatrix.a_1_1 + secondMatrix.a_1_1;
            this.a_1_2 = firstMatrix.a_1_2 + secondMatrix.a_1_2;

            this.a_2_1 = firstMatrix.a_2_1 + secondMatrix.a_2_1;
            this.a_2_2 = firstMatrix.a_2_2 + secondMatrix.a_2_2;
        }

        public void Subtract(Matrix2x2 matrix)
        {
            this.a_1_1 -= matrix.a_1_1;
            this.a_1_2 -= matrix.a_1_2;

            this.a_2_1 -= matrix.a_2_1;
            this.a_2_2 -= matrix.a_2_2;
        }

        public void SetDifferenceOf(Matrix3x3 firstMatrix, Matrix3x3 secondMatrix)
        {
            this.a_1_1 = firstMatrix.a_1_1 - secondMatrix.a_1_1;
            this.a_1_2 = firstMatrix.a_1_2 - secondMatrix.a_1_2;

            this.a_2_1 = firstMatrix.a_2_1 - secondMatrix.a_2_1;
            this.a_2_2 = firstMatrix.a_2_2 - secondMatrix.a_2_2;
        }

        public Matrix2x2 Multiply(Matrix2x2 rightMatrix)
        {
            Matrix2x2 result = new Matrix2x2();

            result.a_1_1 = this.a_1_1 * rightMatrix.a_1_1 + this.a_1_2 * rightMatrix.a_2_1;
            result.a_1_2 = this.a_1_1 * rightMatrix.a_1_2 + this.a_1_2 * rightMatrix.a_2_2;

            result.a_2_1 = this.a_2_1 * rightMatrix.a_1_1 + this.a_2_2 * rightMatrix.a_2_1;
            result.a_2_2 = this.a_2_1 * rightMatrix.a_1_2 + this.a_2_2 * rightMatrix.a_2_2;

            return result;
        }

        public Vector2 Multiply(Vector2 vector)
        {
            return new Vector2(
                this.a_1_1 * vector.x + this.a_1_2 * vector.y,
                this.a_2_1 * vector.x + this.a_2_2 * vector.y
            );
        }

        public Matrix2x2 Multiply(double value)
        {
            Matrix2x2 result = this;
            result.DivideAt(value);
            return result;
        }

        public void MultiplyAt(Matrix2x2 rightMatrix)
        {
            this.Set(this.Multiply(rightMatrix));
        }

        public void MultiplyAt(double value)
        {
            this.a_1_1 *= value;
            this.a_1_2 *= value;
            this.a_2_1 *= value;
            this.a_2_2 *= value;
        }

        public Matrix2x2 Divide(double value)
        {
            Matrix2x2 result = this;
            result.DivideAt(value);
            return result;
        }

        public void DivideAt(double value)
        {
            this.a_1_1 /= value;
            this.a_1_2 /= value;
            this.a_2_1 /= value;
            this.a_2_2 /= value;
        }

        public void SetMultiplicationOf(Matrix2x2 firstMatrix, Matrix2x2 secondMatrix)
        {
            this.Set(firstMatrix.Multiply(secondMatrix));
        }

        public static Matrix2x2 operator +(Matrix2x2 leftMatrix, Matrix2x2 rightMatrix)
        {
            Matrix2x2 result = leftMatrix;
            result.Add(rightMatrix);
            return result;
        }

        public static Matrix2x2 operator -(Matrix2x2 leftMatrix, Matrix2x2 rightMatrix)
        {
            Matrix2x2 result = leftMatrix;
            result.Subtract(rightMatrix);
            return result;
        }

        public static Matrix2x2 operator *(Matrix2x2 leftMatrix, Matrix2x2 rightMatrix)
        {
            return leftMatrix.Multiply(rightMatrix);
        }

        public static Vector2 operator *(Matrix2x2 matrix, Vector2 vector)
        {
            return matrix.Multiply(vector);
        }

        public static Matrix2x2 operator *(Matrix2x2 matrix, double value)
        {
            Matrix2x2 result = matrix;
            result.MultiplyAt(value);
            return result;
        }

        public static Matrix2x2 operator *(double value, Matrix2x2 matrix)
        {
            Matrix2x2 result = matrix;
            result.MultiplyAt(value);
            return result;
        }

        public static Matrix2x2 operator /(Matrix2x2 matrix, double value)
        {
            Matrix2x2 result = matrix;
            result.DivideAt(value);
            return result;
        }
    }
}
