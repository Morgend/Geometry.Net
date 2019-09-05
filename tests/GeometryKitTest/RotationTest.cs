using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometryKit;

namespace MathKitTest.Geometry
{
    [TestClass]
    public class RotationTest
    {
        [TestMethod]
        public void TestRotation()
        {
            Rotation r = new Rotation(EulerAngles.FromDegrees(-90, 0, 0));

            Assert.AreEqual(90.0, r.Angle.Degrees, MathConstant.EPSYLON);
            Assert.AreEqual(-1.0, r.Axis.z, MathConstant.EPSYLON);

            r.SetTurn(EulerAngles.FromDegrees(270, 0, 0));

            Assert.AreEqual(270.0, r.Angle.Degrees, MathConstant.EPSYLON);
            Assert.AreEqual(1.0, r.Axis.z, MathConstant.EPSYLON);
        }
    }
}
