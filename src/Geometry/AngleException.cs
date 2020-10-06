using System;

namespace Geometry
{
    public class AngleException : GeometryException
    {
        public AngleException(string message)
            : base(message)
        {
        }
    }
}
