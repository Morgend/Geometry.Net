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
 * Date: 4 Sept 2019
 */

namespace Geometry.Planimetry
{
    public struct LineSegment2
    {
        public Vector2 A;
        public Vector2 B;

        public LineSegment2(Vector2 A, Vector2 B)
        {
            this.A = A;
            this.B = B;
        }

        public LineSegment2(LineSegment2 segment)
        {
            this.A = segment.A;
            this.B = segment.B;
        }

        public double GetLength()
        {
            return (B - A).Module();
        }

        public Vector2 GetVectorAB()
        {
            return B - A;
        }

        public Vector2 GetVectorBA()
        {
            return A - B;
        }

        public void MoveAt(Vector2 vector)
        {
            A.Add(vector, true);
            B.Add(vector, true);
        }

        public Vector2 PointAt(double position)
        {
            return A * (1.0 - position) + B * position;
        }
    }
}
