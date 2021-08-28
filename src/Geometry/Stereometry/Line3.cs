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

namespace Geometry.Stereometry
{
    public struct Line3
    {
        public Vector3 BasicPoint;

        private Vector3 direction;
        private bool valid;

        public Line3(Vector3 startPoint, Vector3 direction)
        {
            this.BasicPoint = startPoint;
            this.direction = direction;
            this.valid = this.direction.Normalize();
        }

        public Line3(Line3 line)
        {
            this.BasicPoint = line.BasicPoint;
            this.direction = line.direction;
            this.valid = line.valid;
        }

        public Vector3 Direction
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

        public Vector3 PointAt(double position)
        {
            return new Vector3(this.BasicPoint.x + direction.x * position, this.BasicPoint.y + direction.y * position, this.BasicPoint.z + direction.z * position);
        }

        public LineSegment3 Segment(double positionA, double positionB)
        {
            return new LineSegment3(this.PointAt(positionA), this.PointAt(positionB));
        }

        public Line3F ToFloat()
        {
            return new Line3F(this.BasicPoint.ToFloat(), this.direction.ToFloat());
        }
    }
}
