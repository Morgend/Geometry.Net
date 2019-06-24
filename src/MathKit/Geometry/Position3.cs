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
            this.setCombinationOf(first, second);
        }

        public Rotation Rotation
        {
            get
            {
                return this.rotation;
            }

            set
            {
                this.rotation.copyOf(value);
            }
        }

        public void set(Position3 position)
        {
            this.Point = position.Point;
            this.rotation.set(position.rotation);
        }

        public Position3 combineWith(Position3 position)
        {
            return new Position3(this, position);
        }

        public void setCombinationOf(Position3 first, Position3 second)
        {
            if (first == null || second == null)
            {
                throw new NullReferenceException("An instance of Position3 was expected but NULL was got");
            }

            this.Point = first.Point + first.rotation.turn(second.Point);
            this.rotation.setCombinationOf(first.rotation, second.rotation);
        }

        public Position3 differenceWith(Position3 position)
        {
            Position3 result = new Position3();
            result.setDifferenceOf(this, position);
            return result;
        }

        public void setDifferenceOf(Position3 position, Position3 subtrahend)
        {
            if (position == null || subtrahend == null)
            {
                throw new NullReferenceException("An instance of Position3 was expected but NULL was got");
            }

            this.Point = subtrahend.rotation.turnBackward(position.Point - subtrahend.Point);
            this.rotation.setDifferenceOf(position.rotation, subtrahend.rotation);
        }

        public void invert()
        {
            this.Point = this.rotation.turnBackward(-this.Point);
            this.rotation.invert();
        }

        public Position3 getInverted()
        {
            Position3 result = new Position3(this);
            result.invert();
            return result;
        }

        public Vector3 toParentPositioning(Vector3 vector)
        {
            return this.rotation.turn(vector) + this.Point;
        }

        public Vector3 toLocalPositioning(Vector3 vector)
        {
            return this.rotation.turnBackward(vector - this.Point);
        }

        public Vector3 changePositioningTo(Position3 position, Vector3 vector)
        {
            if (position == null)
            {
                throw new ArgumentNullException("An instance of Position3 was expected but NULL was got");
            }

            if (position == this)
            {
                return vector;
            }

            return position.rotation.turnBackward(this.rotation.turn(vector) + this.Point - position.Point);
        }

        public Vector3 changePositioningFrom(Position3 position, Vector3 vector)
        {
            if (position == null)
            {
                throw new ArgumentNullException("An instance of Position3 was expected but NULL was got");
            }

            if (position == this)
            {
                return vector;
            }

            return this.rotation.turnBackward(position.rotation.turn(vector) + position.Point - this.Point);
        }

        public static Position3 operator +(Position3 first, Position3 second)
        {
            return first.combineWith(second);
        }

        public static Position3 operator -(Position3 position, Position3 subtrahend)
        {
            return position.differenceWith(subtrahend);
        }
    }
}
