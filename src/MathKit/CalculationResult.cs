using System;

namespace MathKit
{
    public struct CalculationResult<ValueType>
    {
        public ValueType value;
        public bool success;
    }
}
