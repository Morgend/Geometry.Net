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
 * Date: 23 Aug 2019
 */

namespace Geometry.Float64.Planimetry
{
    public struct Triangle2
    {
        public Vector2 A;
        public Vector2 B;
        public Vector2 C;

        public Triangle2(Vector2 A, Vector2 B, Vector2 C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }

        public Triangle2(Triangle2 triangle)
        {
            this.A = triangle.A;
            this.B = triangle.B;
            this.C = triangle.C;
        }

        public LineSegment2 GetSideAB()
        {
            return new LineSegment2(this.A, this.B);
        }

        public LineSegment2 GetSideBC()
        {
            return new LineSegment2(this.B, this.C);
        }

        public LineSegment2 GetSideCA()
        {
            return new LineSegment2(this.C, this.A);
        }

        public Vector2 GetVectorAB()
        {
            return B - A;
        }

        public Vector2 GetVectorBA()
        {
            return A - B;
        }

        public Vector2 GetVectorBC()
        {
            return C - B;
        }

        public Vector2 GetVectorCB()
        {
            return B - C;
        }

        public Vector2 GetVectorCA()
        {
            return A - C;
        }

        public Vector2 GetVectorAC()
        {
            return C - A;
        }


        public double Square()
        {
            return 0.5 * Math.Abs((B.x - A.x) * (C.y - A.y) - (B.y - A.y) * (C.x - A.x));
        }

        public Vector2 MedianCentre()
        {
            return new Vector2((A.x + B.x + C.x) / 3.0, (A.y + B.y + C.y) / 3.0);
        }

        public void MoveAt(Vector2 vector)
        {
            A.Add(vector, true);
            B.Add(vector, true);
            C.Add(vector, true);
        }
    }
}
