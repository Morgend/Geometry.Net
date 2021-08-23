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
 * Date: 5 Feb 2019
 */

namespace Geometry
{
    public class MathHelper
    {
        public const float POSITIVE_FLOAT_EPSYLON = 1E-7f;
        public const float NEGATIVE_FLOAT_EPSYLON = -1E-7f;
        public const float POSITIVE_SQUARE_FLOAT_EPSYLON = 1E-13f;
        public const float NEGATIVE_SQUARE_FLOAT_EPSYLON = -1E-13f;

        public const float FLOAT_EPSYLON_EFFECTIVENESS = 1.0f;

        public const double POSITIVE_DOUBLE_EPSYLON = 1E-14;
        public const double NEGATIVE_DOUBLE_EPSYLON = -1E-14;
        public const double POSITIVE_SQUARE_DOUBLE_EPSYLON = 1E-27;
        public const double NEGATIVE_SQUARE_DOUBLE_EPSYLON = -1E-27;

        public const double DOUBLE_EPSYLON_EFFECTIVENESS = 1.0;

        private MathHelper()
        {
        }

        public static bool AreEqual(float value1, float value2)
        {
            float difference = (value1 < value2 ? value2 - value1 : value1 - value2);

            if (difference <= POSITIVE_FLOAT_EPSYLON)
            {
                return true;
            }

            float absoluteValue1 = (value1 >= 0 ? value1 : -value1);
            float absoluteValue2 = (value2 >= 0 ? value2 : -value2);

            if (absoluteValue1 < FLOAT_EPSYLON_EFFECTIVENESS && absoluteValue2 < FLOAT_EPSYLON_EFFECTIVENESS)
            {
                return false;
            }

            return (2.0f * difference / (absoluteValue1 + absoluteValue2)) <= POSITIVE_FLOAT_EPSYLON;
        }

        public static bool AreEqual(double value1, double value2)
        {
            double difference = (value1 < value2 ? value2 - value1 : value1 - value2);

            if (difference <= POSITIVE_DOUBLE_EPSYLON)
            {
                return true;
            }

            double absoluteValue1 = (value1 >= 0 ? value1 : -value1);
            double absoluteValue2 = (value2 >= 0 ? value2 : -value2);

            if (absoluteValue1 < DOUBLE_EPSYLON_EFFECTIVENESS && absoluteValue2 < DOUBLE_EPSYLON_EFFECTIVENESS)
            {
                return false;
            }

            return (2.0 * difference / (absoluteValue1 + absoluteValue2)) <= POSITIVE_FLOAT_EPSYLON;
        }
    }
}
