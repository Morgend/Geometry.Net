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

namespace Geometry.Planimetry
{
    public struct Triangle2F
    {
        public Vector2F A;
        public Vector2F B;
        public Vector2F C;

        public Triangle2F(Vector2F A, Vector2F B, Vector2F C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }

        public Triangle2F(Triangle2F triangle)
        {
            this.A = triangle.A;
            this.B = triangle.B;
            this.C = triangle.C;
        }

        public LineSegment2F GetSideAB()
        {
            return new LineSegment2F(this.A, this.B);
        }

        public LineSegment2F GetSideBC()
        {
            return new LineSegment2F(this.B, this.C);
        }

        public LineSegment2F GetSideCA()
        {
            return new LineSegment2F(this.C, this.A);
        }

        public Vector2F GetVectorAB()
        {
            return B - A;
        }

        public Vector2F GetVectorBA()
        {
            return A - B;
        }

        public Vector2F GetVectorBC()
        {
            return C - B;
        }

        public Vector2F GetVectorCB()
        {
            return B - C;
        }

        public Vector2F GetVectorCA()
        {
            return A - C;
        }

        public Vector2F GetVectorAC()
        {
            return C - A;
        }


        public float Square()
        {
            return 0.5f * MathF.Abs((B.x - A.x) * (C.y - A.y) - (B.y - A.y) * (C.x - A.x));
        }

        public Vector2F MedianCentre()
        {
            return new Vector2F((A.x + B.x + C.x) / 3.0f, (A.y + B.y + C.y) / 3.0f);
        }

        public void MoveAt(Vector2F vector)
        {
            A.Add(vector, true);
            B.Add(vector, true);
            C.Add(vector, true);
        }
    }
}
