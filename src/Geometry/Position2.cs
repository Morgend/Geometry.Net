using System;

/*
 * Author: Andrey Pokidov
 * Date: 10 Feb 2019
 * 2D position (2D coordinate system)
 */

namespace Geometry
{
    public struct Position2
    {
        public Vector2 Point;
        public Angle Angle;

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
            this.Point = first.Point + first.Angle.Turn(second.Point);
            this.Angle = first.Angle + second.Angle;
        }

        public void SetPosition(Position2 position)
        {
            this.Point = position.Point;
            this.Angle = position.Angle;
        }

        public Position2 CombineWith(Position2 position)
        {
            return new Position2(this, position);
        }

        public void SetCombinationOf(Position2 first, Position2 second)
        {
            this.Point = first.Point + first.Angle.Turn(second.Point);
            this.Angle = first.Angle + second.Angle;
        }

        public Position2 DifferenceWith(Position2 position)
        {
            Position2 result = new Position2();
            result.SetDifferenceOf(this, position);
            return result;
        }

        public void SetDifferenceOf(Position2 position, Position2 subtrahend)
        {
            this.Point = subtrahend.Angle.TurnBackward(position.Point - subtrahend.Point);
            this.Angle = position.Angle - subtrahend.Angle;
        }

        public void Invert()
        {
            this.Point = this.Angle.TurnBackward(-this.Point);
            this.Angle.Invert();
        }

        public Position2 GetInverted()
        {
            Position2 result = new Position2(this);
            result.Invert();
            return result;
        }

        public Vector2 ToParentPositioning(Vector2 vector)
        {
            return this.Angle.Turn(vector) + this.Point;
        }

        public Vector2 ToLocalPositioning(Vector2 vector)
        {
            return this.Angle.TurnBackward(vector - this.Point);
        }

        public Vector2 ChangePositioningTo(Position2 position, Vector2 vector)
        {
            return position.Angle.TurnBackward(this.Angle.Turn(vector) + this.Point - position.Point);
        }

        public Vector2 ChangePositioningFrom(Position2 position, Vector2 vector)
        {
            return this.Angle.TurnBackward(position.Angle.Turn(vector) + position.Point - this.Point);
        }

        public static Position2 operator +(Position2 first, Position2 second)
        {
            return first.CombineWith(second);
        }

        public static Position2 operator -(Position2 position, Position2 subtrahend)
        {
            return position.DifferenceWith(subtrahend);
        }
    }
}
