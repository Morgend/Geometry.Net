using System;

namespace Geometry
{
    public class GeometryException : Exception
    {
        public GeometryException(string message)
            : base(message)
        {
        }
    }
}
