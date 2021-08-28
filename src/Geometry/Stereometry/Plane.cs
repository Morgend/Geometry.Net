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
 * Date: 1 Sep 2019
 */

namespace Geometry.Stereometry
{
    public struct Plane
    {
        public Vector3 BasicPoint;

        private Vector3 normal;
        private bool valid;

        public Plane(Vector3 basicPoint, Vector3 normal)
        {
            this.BasicPoint = basicPoint;
            this.normal = normal;
            this.valid = this.normal.Normalize();
        }

        public Plane(Plane plane)
        {
            this.BasicPoint = plane.BasicPoint;
            this.normal = plane.normal;
            this.valid = plane.valid;
        }

        public Vector3 Normal
        {
            get
            {
                return this.normal;
            }

            set
            {
                this.normal = value;
                this.valid = this.normal.Normalize();
            }
        }

        public bool IsValid()
        {
            return this.valid;
        }
    }
}
