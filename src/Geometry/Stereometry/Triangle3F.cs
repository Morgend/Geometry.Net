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

namespace Geometry.Stereometry
{
    public struct Triangle3F
    {
        public Vector3F A;
        public Vector3F B;
        public Vector3F C;

        public Triangle3F(Vector3F A, Vector3F B, Vector3F C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }

        public Triangle3F(Triangle3F triangle)
        {
            this.A = triangle.A;
            this.B = triangle.B;
            this.C = triangle.C;
        }

        public LineSegment3F GetSideAB()
        {
            return new LineSegment3F(this.A, this.B);
        }

        public LineSegment3F GetSideBC()
        {
            return new LineSegment3F(this.B, this.C);
        }

        public LineSegment3F GetSideCA()
        {
            return new LineSegment3F(this.C, this.A);
        }

        public Vector3F GetVectorAB()
        {
            return B - A;
        }

        public Vector3F GetVectorBA()
        {
            return A - B;
        }

        public Vector3F GetVectorBC()
        {
            return C - B;
        }

        public Vector3F GetVectorCB()
        {
            return B - C;
        }

        public Vector3F GetVectorCA()
        {
            return A - C;
        }

        public Vector3F GetVectorAC()
        {
            return C - A;
        }


        public float Square()
        {
            return 0.5f * ((B - A).VectorMultiply(C - A)).Module();
        }

        public Vector3F MedianCentre()
        {
            return new Vector3F((A.x + B.x + C.x) / 3.0f, (A.y + B.y + C.y) / 3.0f, (A.z + B.z + C.z) / 3.0f);
        }

        public void MoveAt(Vector3F vector)
        {
            A.Add(vector, true);
            B.Add(vector, true);
            C.Add(vector, true);
        }
    }
}
