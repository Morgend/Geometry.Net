using System;

/*
 * Author: Andrey Pokidov
 * Date: 5 Feb 2019
 */

namespace MathKit.Geometry
{
    public struct Matrix3x3
    {
        public double a_1_1;
        public double a_1_2;
        public double a_1_3;

        public double a_2_1;
        public double a_2_2;
        public double a_2_3;

        public double a_3_1;
        public double a_3_2;
        public double a_3_3;

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

        public double determinant()
        {
            return this.a_1_1 * this.a_2_2 * this.a_3_3
                + this.a_3_1 * this.a_1_2 * this.a_2_3
                + this.a_2_1 * this.a_3_2 * this.a_1_3

                - this.a_3_1 * this.a_2_2 * this.a_1_3
                - this.a_2_1 * this.a_1_2 * this.a_3_3
                - this.a_1_1 * this.a_3_2 * this.a_2_3;
        }

        public Vector3 row(int index)
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

        public Vector3 column(int index)
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

        public void transpose()
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

        public Matrix3x3 multiply(Matrix3x3 rightMatrix)
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

        public Vector3 multiply(Vector3 vector)
        {
            return new Vector3(
                this.a_1_1 * vector.x + this.a_1_2 * vector.y + this.a_1_3 * vector.z,
                this.a_2_1 * vector.x + this.a_2_2 * vector.y + this.a_2_3 * vector.z,
                this.a_3_1 * vector.x + this.a_3_2 * vector.y + this.a_3_3 * vector.z
            );
        }

        public void multiplyAt(double number)
        {
            this.a_1_1 *= number;
            this.a_1_2 *= number;
            this.a_1_3 *= number;

            this.a_2_1 *= number;
            this.a_2_2 *= number;
            this.a_2_3 *= number;

            this.a_3_1 *= number;
            this.a_3_2 *= number;
            this.a_3_3 *= number;
        }

        public void divideAt(double number)
        {
            this.a_1_1 /= number;
            this.a_1_2 /= number;
            this.a_1_3 /= number;

            this.a_2_1 /= number;
            this.a_2_2 /= number;
            this.a_2_3 /= number;

            this.a_3_1 /= number;
            this.a_3_2 /= number;
            this.a_3_3 /= number;
        }

        public static Matrix3x3 operator *(Matrix3x3 leftMatrix, Matrix3x3 rightMatrix)
        {
            return leftMatrix.multiply(rightMatrix);
        }

        public static Vector3 operator *(Matrix3x3 matrix, Vector3 vector)
        {
            return matrix.multiply(vector);
        }

        public static Matrix3x3 operator *(Matrix3x3 matrix, double number)
        {
            Matrix3x3 result = matrix;
            result.multiplyAt(number);
            return result;
        }

        public static Matrix3x3 operator *(double number, Matrix3x3 matrix)
        {
            Matrix3x3 result = matrix;
            result.multiplyAt(number);
            return result;
        }

        public static Matrix3x3 operator /(Matrix3x3 matrix, double number)
        {
            Matrix3x3 result = matrix;
            result.divideAt(number);
            return result;
        }
    }
}
