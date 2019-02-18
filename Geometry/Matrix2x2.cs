using System;

/*
 * Author: Andrey Pokidov
 * Date: 10 Feb 2019
 */

namespace MathKit.Geometry
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

        public double determinant()
        {
            return this.a_1_1 * this.a_2_2 - this.a_2_1 * this.a_1_2;
        }

        public void reset(MatrixInitialMode matrixMode = MatrixInitialMode.IDENTITY_MATRIX)
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

        public Vector2 row(int index)
        {
            switch (index)
            {
                case 1:
                    return new Vector2(this.a_1_1, this.a_1_2);

                case 2:
                    return new Vector2(this.a_2_1, this.a_2_2);
            }

            return new Vector2();
        }

        public Vector2 column(int index)
        {
            switch (index)
            {
                case 1:
                    return new Vector2(this.a_1_1, this.a_2_1);

                case 2:
                    return new Vector2(this.a_1_2, this.a_2_2);
            }

            return new Vector2();
        }

        public void transpose()
        {
            double value = a_1_2;
            a_1_2 = a_2_1;
            a_2_1 = value;
        }

        public void set(Matrix2x2 matrix)
        {
            this.a_1_1 = matrix.a_1_1;
            this.a_1_2 = matrix.a_1_2;

            this.a_2_1 = matrix.a_2_1;
            this.a_2_2 = matrix.a_2_2;
        }

        public void add(Matrix2x2 matrix)
        {
            this.a_1_1 += matrix.a_1_1;
            this.a_1_2 += matrix.a_1_2;

            this.a_2_1 += matrix.a_2_1;
            this.a_2_2 += matrix.a_2_2;
        }

        public void setSumOf(Matrix3x3 firstMatrix, Matrix3x3 secondMatrix)
        {
            this.a_1_1 = firstMatrix.a_1_1 + secondMatrix.a_1_1;
            this.a_1_2 = firstMatrix.a_1_2 + secondMatrix.a_1_2;

            this.a_2_1 = firstMatrix.a_2_1 + secondMatrix.a_2_1;
            this.a_2_2 = firstMatrix.a_2_2 + secondMatrix.a_2_2;
        }

        public void subtract(Matrix2x2 matrix)
        {
            this.a_1_1 -= matrix.a_1_1;
            this.a_1_2 -= matrix.a_1_2;

            this.a_2_1 -= matrix.a_2_1;
            this.a_2_2 -= matrix.a_2_2;
        }

        public void setDifferenceOf(Matrix3x3 firstMatrix, Matrix3x3 secondMatrix)
        {
            this.a_1_1 = firstMatrix.a_1_1 - secondMatrix.a_1_1;
            this.a_1_2 = firstMatrix.a_1_2 - secondMatrix.a_1_2;

            this.a_2_1 = firstMatrix.a_2_1 - secondMatrix.a_2_1;
            this.a_2_2 = firstMatrix.a_2_2 - secondMatrix.a_2_2;
        }

        public Matrix2x2 multiply(Matrix2x2 rightMatrix)
        {
            Matrix2x2 result = new Matrix2x2();

            result.a_1_1 = this.a_1_1 * rightMatrix.a_1_1 + this.a_1_2 * rightMatrix.a_2_1;
            result.a_1_2 = this.a_1_1 * rightMatrix.a_1_2 + this.a_1_2 * rightMatrix.a_2_2;

            result.a_2_1 = this.a_2_1 * rightMatrix.a_1_1 + this.a_2_2 * rightMatrix.a_2_1;
            result.a_2_2 = this.a_2_1 * rightMatrix.a_1_2 + this.a_2_2 * rightMatrix.a_2_2;

            return result;
        }

        public Vector2 multiply(Vector2 vector)
        {
            return new Vector2(
                this.a_1_1 * vector.x + this.a_1_2 * vector.y,
                this.a_2_1 * vector.x + this.a_2_2 * vector.y
            );
        }

        public Matrix2x2 multiply(double value)
        {
            Matrix2x2 result = this;
            result.divideAt(value);
            return result;
        }

        public void multiplyAt(Matrix2x2 rightMatrix)
        {
            this.set(this.multiply(rightMatrix));
        }

        public void multiplyAt(double value)
        {
            this.a_1_1 *= value;
            this.a_1_2 *= value;
            this.a_2_1 *= value;
            this.a_2_2 *= value;
        }

        public Matrix2x2 divide(double value)
        {
            Matrix2x2 result = this;
            result.divideAt(value);
            return result;
        }

        public void divideAt(double value)
        {
            this.a_1_1 /= value;
            this.a_1_2 /= value;
            this.a_2_1 /= value;
            this.a_2_2 /= value;
        }

        public void setMultiplicationOf(Matrix2x2 firstMatrix, Matrix2x2 secondMatrix)
        {
            this.set(firstMatrix.multiply(secondMatrix));
        }

        public static Matrix2x2 operator +(Matrix2x2 leftMatrix, Matrix2x2 rightMatrix)
        {
            Matrix2x2 result = leftMatrix;
            result.add(rightMatrix);
            return result;
        }

        public static Matrix2x2 operator -(Matrix2x2 leftMatrix, Matrix2x2 rightMatrix)
        {
            Matrix2x2 result = leftMatrix;
            result.subtract(rightMatrix);
            return result;
        }

        public static Matrix2x2 operator *(Matrix2x2 leftMatrix, Matrix2x2 rightMatrix)
        {
            return leftMatrix.multiply(rightMatrix);
        }

        public static Vector2 operator *(Matrix2x2 matrix, Vector2 vector)
        {
            return matrix.multiply(vector);
        }

        public static Matrix2x2 operator *(Matrix2x2 matrix, double value)
        {
            Matrix2x2 result = matrix;
            result.multiplyAt(value);
            return result;
        }

        public static Matrix2x2 operator *(double value, Matrix2x2 matrix)
        {
            Matrix2x2 result = matrix;
            result.multiplyAt(value);
            return result;
        }

        public static Matrix2x2 operator /(Matrix2x2 matrix, double value)
        {
            Matrix2x2 result = matrix;
            result.divideAt(value);
            return result;
        }
    }
}
