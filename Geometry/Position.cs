using System;

/*
 * Author: Andrey Pokidov
 * Date: 5 Feb 2019
 */

namespace MathKit.Geometry
{
    public class Position
    {
        public Vector3 Point;

        private Turn turn;

        public Position()
        {
            this.Point = new Vector3();
            this.turn = new Turn();
        }

        public Position (Position first, Position second)
        {
            this.turn = new Turn();
            this.setCombinationOf(first, second);
        }

        public Turn Turn
        {
            get
            {
                return this.turn;
            }

            set
            {
                this.turn.copyOf(value);
            }
        }

        public Position combineWith(Position position)
        {
            return new Position(this, position);
        }

        public void setCombinationOf(Position first, Position second)
        {
            if (first == null || second == null)
            {
                throw new NullReferenceException("An instance of Position was expected but NULL was got");
            }

            this.Point = first.Point + first.turn.turn(second.Point);
            this.turn.setCombinationOf(first.turn, second.turn);
        }
    }
}
