using System;

/*
 * Author: Andrey Pokidov
 * Date: 5 Feb 2019
 * 3D position (3D coordinate system)
 */

namespace GeometryKit
{
    public struct Position3
    {
        public Vector3 Point;
        public Rotation Rotation;

        public Position3(Position3 position)
        {
            this.Point = position.Point;
            this.Rotation = position.Rotation;
        }

        public Position3(Vector3 point, EulerAngles angles)
        {
            this.Point = point;
            this.Rotation = new Rotation(angles);
        }

        public Position3(Vector3 point, Angle heading, Angle elevation, Angle bank)
        {
            this.Point = point;
            this.Rotation = new Rotation(heading, elevation, bank);
        }

        public Position3(Vector3 point, double heading, double elevation, double bank)
        {
            this.Point = point;
            this.Rotation = new Rotation(heading, elevation, bank);
        }

        public Position3(Position3 first, Position3 second)
        {
            this.Point = new Vector3();
            this.Rotation = new Rotation();

            this.SetCombinationOf(first, second);
        }

        public void SetPosition(Position3 position)
        {
            this.Point = position.Point;
            this.Rotation.SetTurn(position.Rotation);
        }

        public Position3 CombineWith(Position3 position)
        {
            return new Position3(this, position);
        }

        public void SetCombinationOf(Position3 first, Position3 second)
        {
            this.Point = first.Point + first.Rotation.Turn(second.Point);
            this.Rotation.SetCombinationOf(first.Rotation, second.Rotation);
        }

        public Position3 DifferenceWith(Position3 position)
        {
            Position3 result = new Position3();
            result.SetDifferenceOf(this, position);
            return result;
        }

        public void SetDifferenceOf(Position3 position, Position3 subtrahend)
        {
            this.Point = subtrahend.Rotation.TurnBackward(position.Point - subtrahend.Point);
            this.Rotation.SetDifferenceOf(position.Rotation, subtrahend.Rotation);
        }

        public void Invert()
        {
            this.Point = this.Rotation.TurnBackward(-this.Point);
            this.Rotation.Invert();
        }

        public Position3 GetInverted()
        {
            Position3 result = new Position3(this);
            result.Invert();
            return result;
        }

        public Vector3 ToParentPositioning(Vector3 vector)
        {
            return this.Rotation.Turn(vector) + this.Point;
        }

        public Vector3 ToLocalPositioning(Vector3 vector)
        {
            return this.Rotation.TurnBackward(vector - this.Point);
        }

        public Vector3 ChangePositioningTo(Position3 position, Vector3 vector)
        {
            return position.Rotation.TurnBackward(this.Rotation.Turn(vector) + this.Point - position.Point);
        }

        public Vector3 ChangePositioningFrom(Position3 position, Vector3 vector)
        {
            return this.Rotation.TurnBackward(position.Rotation.Turn(vector) + position.Point - this.Point);
        }

        public static Position3 operator +(Position3 first, Position3 second)
        {
            return first.CombineWith(second);
        }

        public static Position3 operator -(Position3 position, Position3 subtrahend)
        {
            return position.DifferenceWith(subtrahend);
        }
    }
}
