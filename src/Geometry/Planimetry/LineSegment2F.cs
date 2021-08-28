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
    public struct LineSegment2F
    {
        public Vector2F A;
        public Vector2F B;

        public LineSegment2F(Vector2F A, Vector2F B)
        {
            this.A = A;
            this.B = B;
        }

        public LineSegment2F(LineSegment2F segment)
        {
            this.A = segment.A;
            this.B = segment.B;
        }

        public double GetLength()
        {
            return (B - A).Module();
        }

        public Vector2F GetVectorAB()
        {
            return B - A;
        }

        public Vector2F GetVectorBA()
        {
            return A - B;
        }

        public void MoveAt(Vector2F vector)
        {
            A.Add(vector, true);
            B.Add(vector, true);
        }

        public Vector2F PointAt(float position)
        {
            return A * (1.0f - position) + B * position;
        }
    }
}
