﻿using System;

/*
 * Author: Andrey Pokidov
 * Date: 1 Feb 2019
 */

namespace MathKit.Geometry
{
    public struct Vector2
    {
        public const double DEFAULT_COORDINATE_VALUE = 0.0;

        public double x;
        public double y;

        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2(Vector2 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        public void zero()
        {
            this.x = DEFAULT_COORDINATE_VALUE;
            this.y = DEFAULT_COORDINATE_VALUE;
        }

        public void setValue(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public void setValue(Vector2 v)
        {
            this.x = v.x;
            this.y = v.y;
        }

        public double scalar(Vector2 v)
        {
            return this.x * v.x + this.y * v.y;
        }

        public double module()
        {
            return Math.Sqrt(this.x * this.x + this.y * this.y);
        }

        public void normalize()
        {
            double module = this.module();

            if (module < MathConst.EPSYLON)
            {
                this.zero();
                return;
            }

            this.x /= module;
            this.y /= module;
        }

        public Vector2 getNormalized()
        {
            Vector2 result = this;
            result.normalize();
            return result;
        }

        public void add(Vector2 v)
        {
            this.x += v.x;
            this.y += v.y;
        }

        public void subtract(Vector2 v)
        {
            this.x -= v.x;
            this.y -= v.y;
        }

        public void multiply(double value)
        {
            this.x *= value;
            this.y *= value;
        }

        public void divide(double value)
        {
            this.x /= value;
            this.y /= value;
        }

        public void reverse()
        {
            this.x = -this.x;
            this.y = -this.y;
        }

        public Vector2 getReverted()
        {
            return new Vector2(-this.x, -this.y);
        }

        public Angle angleWith(Vector2 vector)
        {
            double m1 = this.module();
            double m2 = vector.module();

            if (m1 < MathConst.EPSYLON || m2 < MathConst.EPSYLON)
            {
                return new Angle();
            }

            return new Angle(Math.Acos(this.scalar(vector) / (m1 * m2)));
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }

        public static double operator *(Vector2 v1, Vector2 v2)
        {
            return v1.scalar(v2);
        }

        public static Vector2 operator *(Vector2 vector, double value)
        {
            return new Vector2(vector.x * value, vector.y * value);
        }

        public static Vector2 operator *(double value, Vector2 vector)
        {
            return new Vector2(vector.x * value, vector.y * value);
        }

        public static Vector2 operator /(Vector2 vector, double value)
        {
            return new Vector2(vector.x / value, vector.y / value);
        }

        public static Vector2 operator -(Vector2 v)
        {
            return new Vector2(-v.x, -v.y);
        }

        public override string ToString()
        {
            return String.Format("Vector2({0}, {1})", this.x, this.y);
        }
    }
}