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

namespace Geometry.Float64.Stereometry
{
    public struct Triangle3
    {
        public Vector3 A;
        public Vector3 B;
        public Vector3 C;

        public Triangle3(Vector3 A, Vector3 B, Vector3 C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }

        public Triangle3(Triangle3 triangle)
        {
            this.A = triangle.A;
            this.B = triangle.B;
            this.C = triangle.C;
        }

        public LineSegment3 GetSideAB()
        {
            return new LineSegment3(this.A, this.B);
        }

        public LineSegment3 GetSideBC()
        {
            return new LineSegment3(this.B, this.C);
        }

        public LineSegment3 GetSideCA()
        {
            return new LineSegment3(this.C, this.A);
        }

        public Vector3 GetVectorAB()
        {
            return B - A;
        }

        public Vector3 GetVectorBA()
        {
            return A - B;
        }

        public Vector3 GetVectorBC()
        {
            return C - B;
        }

        public Vector3 GetVectorCB()
        {
            return B - C;
        }

        public Vector3 GetVectorCA()
        {
            return A - C;
        }

        public Vector3 GetVectorAC()
        {
            return C - A;
        }


        public double Square()
        {
            return 0.5 * ((B - A).VectorMultiply(C - A)).Module();
        }

        public Vector3 MedianCentre()
        {
            return new Vector3((A.x + B.x + C.x) / 3.0, (A.y + B.y + C.y) / 3.0, (A.z + B.z + C.z) / 3.0);
        }

        public void MoveAt(Vector3 vector)
        {
            A.Add(vector, true);
            B.Add(vector, true);
            C.Add(vector, true);
        }
    }
}
