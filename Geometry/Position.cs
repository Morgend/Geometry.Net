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
    }
}
