using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometryKit;

namespace MathKitTest.Geometry
{
    [TestClass]
    public class AngleTest
    {
        [TestMethod]
        public void TestDegrees()
        {
            Angle a = new Angle(MathConstant.PI / 4.0);

            Assert.AreEqual(45.0, a.Degrees, MathConstant.EPSYLON);

            a.Degrees = -10;

            Assert.AreEqual(-MathConstant.PI / 18.0, a.Radians, MathConstant.EPSYLON);
        }
    }
}
