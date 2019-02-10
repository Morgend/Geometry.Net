using System;

/*
 * Author: Andrey Pokidov
 * Date: 10 Feb 2019
 */

namespace MathKit.Geometry
{
    public struct Matrix2x2
    {
        public double a_1_1;
        public double a_1_2;

        public double a_2_1;
        public double a_2_2;

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

        public static Matrix2x2 operator *(Matrix2x2 leftMatrix, Matrix2x2 rightMatrix)
        {
            return leftMatrix.multiply(rightMatrix);
        }

        public static Vector2 operator *(Matrix2x2 matrix, Vector2 vector)
        {
            return matrix.multiply(vector);
        }
    }
}
