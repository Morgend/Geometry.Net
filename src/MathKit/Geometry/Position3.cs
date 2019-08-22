using System;

/*
 * Author: Andrey Pokidov
 * Date: 5 Feb 2019
 * 3D position (3D coordinate system)
 */

namespace MathKit.Geometry
{
    public class Position3
    {
        public Vector3 Point;

        private Rotation rotation;

        public Position3()
        {
            this.Point = new Vector3();
            this.rotation = new Rotation();
        }

        public Position3(Position3 position)
        {
            this.Point = position.Point;
            this.rotation = new Rotation(position.rotation);
        }

        public Position3(Vector3 point, EulerAngles angles)
        {
            this.Point = point;
            this.rotation = new Rotation(angles);
        }

        public Position3(Vector3 point, Angle heading, Angle elevation, Angle bank)
        {
            this.Point = point;
            this.rotation = new Rotation(heading, elevation, bank);
        }

        public Position3(Vector3 point, double heading, double elevation, double bank)
        {
            this.Point = point;
            this.rotation = new Rotation(heading, elevation, bank);
        }

        public Position3(Position3 first, Position3 second)
        {
            this.rotation = new Rotation();
            this.SetCombinationOf(first, second);
        }

        public Rotation Rotation
        {
            get
            {
                return this.rotation;
            }

            set
            {
                this.rotation.SetTurn(value);
            }
        }

        public void SetPosition(Position3 position)
        {
            this.Point = position.Point;
            this.rotation.SetTurn(position.rotation);
        }

        public Position3 CombineWith(Position3 position)
        {
            return new Position3(this, position);
        }

        public void SetCombinationOf(Position3 first, Position3 second)
        {
            if (first == null || second == null)
            {
                throw new NullReferenceException("An instance of Position3 was expected but NULL was got");
            }

            this.Point = first.Point + first.rotation.Turn(second.Point);
            this.rotation.SetCombinationOf(first.rotation, second.rotation);
        }

        public Position3 DifferenceWith(Position3 position)
        {
            Position3 result = new Position3();
            result.SetDifferenceOf(this, position);
            return result;
        }

        public void SetDifferenceOf(Position3 position, Position3 subtrahend)
        {
            if (position == null || subtrahend == null)
            {
                throw new NullReferenceException("An instance of Position3 was expected but NULL was got");
            }

            this.Point = subtrahend.rotation.TurnBackward(position.Point - subtrahend.Point);
            this.rotation.SetDifferenceOf(position.rotation, subtrahend.rotation);
        }

        public void Invert()
        {
            this.Point = this.rotation.TurnBackward(-this.Point);
            this.rotation.Invert();
        }

        public Position3 GetInverted()
        {
            Position3 result = new Position3(this);
            result.Invert();
            return result;
        }

        public Vector3 ToParentPositioning(Vector3 vector)
        {
            return this.rotation.Turn(vector) + this.Point;
        }

        public Vector3 ToLocalPositioning(Vector3 vector)
        {
            return this.rotation.TurnBackward(vector - this.Point);
        }

        public Vector3 ChangePositioningTo(Position3 position, Vector3 vector)
        {
            if (position == null)
            {
                throw new ArgumentNullException("An instance of Position3 was expected but NULL was got");
            }

            if (position == this)
            {
                return vector;
            }

            return position.rotation.TurnBackward(this.rotation.Turn(vector) + this.Point - position.Point);
        }

        public Vector3 ChangePositioningFrom(Position3 position, Vector3 vector)
        {
            if (position == null)
            {
                throw new ArgumentNullException("An instance of Position3 was expected but NULL was got");
            }

            if (position == this)
            {
                return vector;
            }

            return this.rotation.TurnBackward(position.rotation.Turn(vector) + position.Point - this.Point);
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
