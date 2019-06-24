using System;

/*
 * Author: Andrey Pokidov
 * Date: 10 Feb 2019
 * 2D position (2D coordinate system)
 */

namespace MathKit.Geometry
{
    public class Position2
    {
        public Vector2 Point;
        public Angle Angle;

        public Position2()
        {
            this.Point = new Vector2();
            this.Angle = new Angle();
        }

        public Position2(Position2 position)
        {
            this.Point = position.Point;
            this.Angle = position.Angle;
        }

        public Position2(Vector2 point, Angle angle)
        {
            this.Point = point;
            this.Angle = angle;
        }

        public Position2(Vector2 point, double angle)
        {
            this.Point = point;
            this.Angle = new Angle(angle);
        }

        public Position2(double x, double y, double angle)
        {
            this.Point = new Vector2(x, y);
            this.Angle = new Angle(angle);
        }

        public Position2(Position2 first, Position2 second)
        {
            this.setCombinationOf(first, second);
        }

        public Position2 combineWith(Position2 position)
        {
            return new Position2(this, position);
        }

        public void setCombinationOf(Position2 first, Position2 second)
        {
            if (first == null || second == null)
            {
                throw new NullReferenceException("An instance of Position2 was expected but NULL was got");
            }

            this.Point = first.Point + first.Angle.turn(second.Point);
            this.Angle = first.Angle + second.Angle;
        }

        public Position2 differenceWith(Position2 position)
        {
            Position2 result = new Position2();
            result.setDifferenceOf(this, position);
            return result;
        }

        public void setDifferenceOf(Position2 position, Position2 subtrahend)
        {
            if (position == null || subtrahend == null)
            {
                throw new NullReferenceException("An instance of Position2 was expected but NULL was got");
            }

            this.Point = subtrahend.Angle.turnBackward(position.Point - subtrahend.Point);
            this.Angle = position.Angle - subtrahend.Angle;
        }

        public void invert()
        {
            this.Point = this.Angle.turnBackward(-this.Point);
            this.Angle.invert();
        }

        public Position2 getInverted()
        {
            Position2 result = new Position2(this);
            result.invert();
            return result;
        }

        public Vector2 toParentPositioning(Vector2 vector)
        {
            return this.Angle.turn(vector) + this.Point;
        }

        public Vector2 toLocalPositioning(Vector2 vector)
        {
            return this.Angle.turnBackward(vector - this.Point);
        }

        public Vector2 changePositioningTo(Position2 position, Vector2 vector)
        {
            if (position == null)
            {
                throw new ArgumentNullException("An instance of Position2 was expected but NULL was got");
            }

            if (position == this)
            {
                return vector;
            }

            return position.Angle.turnBackward(this.Angle.turn(vector) + this.Point - position.Point);
        }

        public Vector2 changePositioningFrom(Position2 position, Vector2 vector)
        {
            if (position == null)
            {
                throw new ArgumentNullException("An instance of Position2 was expected but NULL was got");
            }

            if (position == this)
            {
                return vector;
            }

            return this.Angle.turnBackward(position.Angle.turn(vector) + position.Point - this.Point);
        }

        public static Position2 operator +(Position2 first, Position2 second)
        {
            return first.combineWith(second);
        }

        public static Position2 operator -(Position2 position, Position2 subtrahend)
        {
            return position.differenceWith(subtrahend);
        }
    }
}
