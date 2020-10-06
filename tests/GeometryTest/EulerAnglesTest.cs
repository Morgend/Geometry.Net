using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometry;

namespace GeometryTest
{
    [TestClass]
    public class EulerAnglesTest
    {
        [TestMethod]
        public void TestAnglesInitialization()
        {
            EulerAngles angles = EulerAngles.FromDegrees(90.0, -110.0, 50.0);

            Assert.AreEqual(90.0, angles.Heading.Degrees, MathConstant.EPSYLON);
            Assert.AreEqual(-110.0, angles.Elevation.Degrees, MathConstant.EPSYLON);
            Assert.AreEqual(50.0, angles.Bank.Degrees, MathConstant.EPSYLON);

            angles.Normalize();

            Assert.AreEqual(-90.0, angles.Heading.Degrees, MathConstant.EPSYLON);
            Assert.AreEqual(-70.0, angles.Elevation.Degrees, MathConstant.EPSYLON);
            Assert.AreEqual(-130.0, angles.Bank.Degrees, MathConstant.EPSYLON);
        }
    }
}
