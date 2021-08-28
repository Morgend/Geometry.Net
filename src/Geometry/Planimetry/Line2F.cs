/*
 * Copyright 2019-2021 Andrey Pokidov <andrey.pokidov@gmail.com>
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

/*
 * Author: Andrey Pokidov
 * Date: 29 Aug 2019
 */

namespace Geometry.Planimetry
{
    public struct Line2F
    {
        public Vector2F BasicPoint;

        private Vector2F direction;
        private bool valid;

        public Line2F(Vector2F startPoint, Vector2F direction)
        {
            this.BasicPoint = startPoint;
            this.direction = direction;
            this.valid = this.direction.Normalize();
        }

        public Line2F(Line2F line)
        {
            this.BasicPoint = line.BasicPoint;
            this.direction = line.direction;
            this.valid = line.valid;
        }

        public Vector2F Direction
        {
            get
            {
                return direction;
            }

            set
            {
                this.direction = value;
                this.valid = this.direction.Normalize();
            }
        }

        public bool IsValid()
        {
            return this.valid;
        }

        public Vector2F PointAt(float position)
        {
            return new Vector2F(this.BasicPoint.x + direction.x * position, this.BasicPoint.y + direction.y * position);
        }

        public LineSegment2F Segment(float positionA, float positionB)
        {
            return new LineSegment2F(this.PointAt(positionA), this.PointAt(positionB));
        }

        public Line2 ToDouble()
        {
            return new Line2(this.BasicPoint.ToDouble(), this.direction.ToDouble());
        }
    }
}
