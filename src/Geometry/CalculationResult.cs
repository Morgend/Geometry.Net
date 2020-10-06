using System;

/*
 * Author: Andrey Pokidov
 * Date: 30 Aug 2019
 */

namespace Geometry
{
    public struct CalculationResult<ValueType>
    {
        public ValueType value;
        public bool success;
    }
}
