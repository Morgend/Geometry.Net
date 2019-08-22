using System;

/*
 * Author: Andrey Pokidov
 * Date: 5 Feb 2019
 */

namespace MathKit.Geometry
{
    public struct Matrix3x3
    {
        public const double DEFAULT_VALUE = 0.0;
        public const double DEFAULT_IDENTITY_VALUE = 1.0;

        public double a_1_1;
        public double a_1_2;
        public double a_1_3;

        public double a_2_1;
        public double a_2_2;
        public double a_2_3;

        public double a_3_1;
        public double a_3_2;
        public double a_3_3;

        public Matrix3x3(MatrixInitialMode matrixMode = MatrixInitialMode.IDENTITY_MATRIX)
        {
            if (matrixMode == MatrixInitialMode.IDENTITY_MATRIX)
            {
                this.a_1_1 = DEFAULT_IDENTITY_VALUE;
                this.a_2_2 = DEFAULT_IDENTITY_VALUE;
                this.a_3_3 = DEFAULT_IDENTITY_VALUE;
            }
            else
            {
                this.a_1_1 = DEFAULT_VALUE;
                this.a_2_2 = DEFAULT_VALUE;
                this.a_3_3 = DEFAULT_VALUE;
            }

            this.a_1_2 = DEFAULT_VALUE;
            this.a_1_3 = DEFAULT_VALUE;

            this.a_2_1 = DEFAULT_VALUE;
            this.a_2_3 = DEFAULT_VALUE;

            this.a_3_1 = DEFAULT_VALUE;
            this.a_3_2 = DEFAULT_VALUE;
        }

        public Matrix3x3(Matrix3x3 matrix)
        {
            this.a_1_1 = matrix.a_1_1;
            this.a_1_2 = matrix.a_1_2;
            this.a_1_3 = matrix.a_1_3;

            this.a_2_1 = matrix.a_2_1;
            this.a_2_2 = matrix.a_2_2;
            this.a_2_3 = matrix.a_2_3;

            this.a_3_1 = matrix.a_3_1;
            this.a_3_2 = matrix.a_3_2;
            this.a_3_3 = matrix.a_3_3;
        }

        public double Determinant()
        {
            return this.a_1_1 * this.a_2_2 * this.a_3_3
                + this.a_3_1 * this.a_1_2 * this.a_2_3
                + this.a_2_1 * this.a_3_2 * this.a_1_3

                - this.a_3_1 * this.a_2_2 * this.a_1_3
                - this.a_2_1 * this.a_1_2 * this.a_3_3
                - this.a_1_1 * this.a_3_2 * this.a_2_3;
        }

        public void Reset(MatrixInitialMode matrixMode = MatrixInitialMode.IDENTITY_MATRIX)
        {
            if (matrixMode == MatrixInitialMode.IDENTITY_MATRIX)
            {
                this.a_1_1 = DEFAULT_IDENTITY_VALUE;
                this.a_2_2 = DEFAULT_IDENTITY_VALUE;
                this.a_3_3 = DEFAULT_IDENTITY_VALUE;
            }
            else
            {
                this.a_1_1 = DEFAULT_VALUE;
                this.a_2_2 = DEFAULT_VALUE;
                this.a_3_3 = DEFAULT_VALUE;
            }

            this.a_1_2 = DEFAULT_VALUE;
            this.a_1_3 = DEFAULT_VALUE;

            this.a_2_1 = DEFAULT_VALUE;
            this.a_2_3 = DEFAULT_VALUE;

            this.a_3_1 = DEFAULT_VALUE;
            this.a_3_2 = DEFAULT_VALUE;
        }

        public Vector3 Row(int index)
        {
            switch (index)
            {
                case 1:
                    return new Vector3(this.a_1_1, this.a_1_2, this.a_1_3);

                case 2:
                    return new Vector3(this.a_2_1, this.a_2_2, this.a_2_3);

                case 3:
                    return new Vector3(this.a_3_1, this.a_3_2, this.a_3_3);
            }

            return new Vector3();
        }

        public Vector3 Column(int index)
        {
            switch (index)
            {
                case 1:
                    return new Vector3(this.a_1_1, this.a_2_1, this.a_3_1);

                case 2:
                    return new Vector3(this.a_1_2, this.a_2_2, this.a_3_2);

                case 3:
                    return new Vector3(this.a_1_3, this.a_2_3, this.a_3_3);
            }

            return new Vector3();
        }

        public void Transpose()
        {
            double value;

            value = a_1_2;
            a_1_2 = a_2_1;
            a_2_1 = value;

            value = a_1_3;
            a_1_3 = a_3_1;
            a_3_1 = value;

            value = a_2_3;
            a_2_3 = a_3_2;
            a_3_2 = value;
        }

        public void Set(Matrix3x3 matrix)
        {
            this.a_1_1 = matrix.a_1_1;
            this.a_1_2 = matrix.a_1_2;
            this.a_1_3 = matrix.a_1_3;

            this.a_2_1 = matrix.a_2_1;
            this.a_2_2 = matrix.a_2_2;
            this.a_2_3 = matrix.a_2_3;

            this.a_3_1 = matrix.a_3_1;
            this.a_3_2 = matrix.a_3_2;
            this.a_3_3 = matrix.a_3_3;
        }

        public void Add(Matrix3x3 matrix)
        {
            this.a_1_1 += matrix.a_1_1;
            this.a_1_2 += matrix.a_1_2;
            this.a_1_3 += matrix.a_1_3;

            this.a_2_1 += matrix.a_2_1;
            this.a_2_2 += matrix.a_2_2;
            this.a_2_3 += matrix.a_2_3;

            this.a_3_1 += matrix.a_3_1;
            this.a_3_2 += matrix.a_3_2;
            this.a_3_3 += matrix.a_3_3;
        }

        public void SetSumOf(Matrix3x3 firstMatrix, Matrix3x3 secondMatrix)
        {
            this.a_1_1 = firstMatrix.a_1_1 + secondMatrix.a_1_1;
            this.a_1_2 = firstMatrix.a_1_2 + secondMatrix.a_1_2;
            this.a_1_3 = firstMatrix.a_1_3 + secondMatrix.a_1_3;

            this.a_2_1 = firstMatrix.a_2_1 + secondMatrix.a_2_1;
            this.a_2_2 = firstMatrix.a_2_2 + secondMatrix.a_2_2;
            this.a_2_3 = firstMatrix.a_2_3 + secondMatrix.a_2_3;

            this.a_3_1 = firstMatrix.a_3_1 + secondMatrix.a_3_1;
            this.a_3_2 = firstMatrix.a_3_2 + secondMatrix.a_3_2;
            this.a_3_3 = firstMatrix.a_3_3 + secondMatrix.a_3_3;
        }

        public void Subtract(Matrix3x3 matrix)
        {
            this.a_1_1 -= matrix.a_1_1;
            this.a_1_2 -= matrix.a_1_2;
            this.a_1_3 -= matrix.a_1_3;

            this.a_2_1 -= matrix.a_2_1;
            this.a_2_2 -= matrix.a_2_2;
            this.a_2_3 -= matrix.a_2_3;

            this.a_3_1 -= matrix.a_3_1;
            this.a_3_2 -= matrix.a_3_2;
            this.a_3_3 -= matrix.a_3_3;
        }

        public void SetDifferenceOf(Matrix3x3 firstMatrix, Matrix3x3 secondMatrix)
        {
            this.a_1_1 = firstMatrix.a_1_1 - secondMatrix.a_1_1;
            this.a_1_2 = firstMatrix.a_1_2 - secondMatrix.a_1_2;
            this.a_1_3 = firstMatrix.a_1_3 - secondMatrix.a_1_3;

            this.a_2_1 = firstMatrix.a_2_1 - secondMatrix.a_2_1;
            this.a_2_2 = firstMatrix.a_2_2 - secondMatrix.a_2_2;
            this.a_2_3 = firstMatrix.a_2_3 - secondMatrix.a_2_3;

            this.a_3_1 = firstMatrix.a_3_1 - secondMatrix.a_3_1;
            this.a_3_2 = firstMatrix.a_3_2 - secondMatrix.a_3_2;
            this.a_3_3 = firstMatrix.a_3_3 - secondMatrix.a_3_3;
        }

        public Matrix3x3 Multiply(Matrix3x3 rightMatrix)
        {
            Matrix3x3 result = new Matrix3x3();

            result.a_1_1 = this.a_1_1 * rightMatrix.a_1_1 + this.a_1_2 * rightMatrix.a_2_1 + this.a_1_3 * rightMatrix.a_3_1;
            result.a_1_2 = this.a_1_1 * rightMatrix.a_1_2 + this.a_1_2 * rightMatrix.a_2_2 + this.a_1_3 * rightMatrix.a_3_2;
            result.a_1_3 = this.a_1_1 * rightMatrix.a_1_3 + this.a_1_2 * rightMatrix.a_2_3 + this.a_1_3 * rightMatrix.a_3_3;

            result.a_2_1 = this.a_2_1 * rightMatrix.a_1_1 + this.a_2_2 * rightMatrix.a_2_1 + this.a_2_3 * rightMatrix.a_3_1;
            result.a_2_2 = this.a_2_1 * rightMatrix.a_1_2 + this.a_2_2 * rightMatrix.a_2_2 + this.a_2_3 * rightMatrix.a_3_2;
            result.a_2_3 = this.a_2_1 * rightMatrix.a_1_3 + this.a_2_2 * rightMatrix.a_2_3 + this.a_2_3 * rightMatrix.a_3_3;

            result.a_3_1 = this.a_3_1 * rightMatrix.a_1_1 + this.a_3_2 * rightMatrix.a_2_1 + this.a_3_3 * rightMatrix.a_3_1;
            result.a_3_2 = this.a_3_1 * rightMatrix.a_1_2 + this.a_3_2 * rightMatrix.a_2_2 + this.a_3_3 * rightMatrix.a_3_2;
            result.a_3_3 = this.a_3_1 * rightMatrix.a_1_3 + this.a_3_2 * rightMatrix.a_2_3 + this.a_3_3 * rightMatrix.a_3_3;

            return result;
        }

        public Vector3 Multiply(Vector3 vector)
        {
            return new Vector3(
                this.a_1_1 * vector.x + this.a_1_2 * vector.y + this.a_1_3 * vector.z,
                this.a_2_1 * vector.x + this.a_2_2 * vector.y + this.a_2_3 * vector.z,
                this.a_3_1 * vector.x + this.a_3_2 * vector.y + this.a_3_3 * vector.z
            );
        }

        public Matrix3x3 Multiply(double value)
        {
            Matrix3x3 result = this;
            result.MultiplyAt(value);
            return result;
        }

        public void MultiplyAt(Matrix3x3 rightMatrix)
        {
            this.Set(this.Multiply(rightMatrix));
        }

        public void MultiplyAt(double value)
        {
            this.a_1_1 *= value;
            this.a_1_2 *= value;
            this.a_1_3 *= value;

            this.a_2_1 *= value;
            this.a_2_2 *= value;
            this.a_2_3 *= value;

            this.a_3_1 *= value;
            this.a_3_2 *= value;
            this.a_3_3 *= value;
        }

        public Matrix3x3 Divide(double value)
        {
            Matrix3x3 result = this;
            result.DivideAt(value);
            return result;
        }

        public void DivideAt(double value)
        {
            this.a_1_1 /= value;
            this.a_1_2 /= value;
            this.a_1_3 /= value;

            this.a_2_1 /= value;
            this.a_2_2 /= value;
            this.a_2_3 /= value;

            this.a_3_1 /= value;
            this.a_3_2 /= value;
            this.a_3_3 /= value;
        }

        public void SetMultiplicationOf(Matrix3x3 firstMatrix, Matrix3x3 secondMatrix)
        {
            this.Set(firstMatrix.Multiply(secondMatrix));
        }

        public static Matrix3x3 operator +(Matrix3x3 leftMatrix, Matrix3x3 rightMatrix)
        {
            Matrix3x3 result = leftMatrix;
            result.Add(rightMatrix);
            return result;
        }

        public static Matrix3x3 operator -(Matrix3x3 leftMatrix, Matrix3x3 rightMatrix)
        {
            Matrix3x3 result = leftMatrix;
            result.Subtract(rightMatrix);
            return result;
        }

        public static Matrix3x3 operator *(Matrix3x3 leftMatrix, Matrix3x3 rightMatrix)
        {
            return leftMatrix.Multiply(rightMatrix);
        }

        public static Vector3 operator *(Matrix3x3 matrix, Vector3 vector)
        {
            return matrix.Multiply(vector);
        }

        public static Matrix3x3 operator *(Matrix3x3 matrix, double value)
        {
            Matrix3x3 result = matrix;
            result.MultiplyAt(value);
            return result;
        }

        public static Matrix3x3 operator *(double value, Matrix3x3 matrix)
        {
            Matrix3x3 result = matrix;
            result.MultiplyAt(value);
            return result;
        }

        public static Matrix3x3 operator /(Matrix3x3 matrix, double value)
        {
            Matrix3x3 result = matrix;
            result.DivideAt(value);
            return result;
        }
    }
}
