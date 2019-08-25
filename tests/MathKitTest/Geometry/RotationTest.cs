using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathKit;
using MathKit.Geometry;

namespace MathKitTest.Geometry
{
    [TestClass]
    public class RotationTest
    {
        [TestMethod]
        public void TestRotation()
        {
            Rotation r = new Rotation(EulerAngles.FromDegrees(-90, 0, 0));

            Assert.AreEqual(90.0, r.Angle.Degrees, MathConst.EPSYLON);
            Assert.AreEqual(-1.0, r.Axis.z, MathConst.EPSYLON);

            r.SetTurn(EulerAngles.FromDegrees(270, 0, 0));

            Assert.AreEqual(270.0, r.Angle.Degrees, MathConst.EPSYLON);
            Assert.AreEqual(1.0, r.Axis.z, MathConst.EPSYLON);
        }
    }
}
