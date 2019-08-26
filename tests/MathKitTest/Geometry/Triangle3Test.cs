using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathKit;
using MathKit.Geometry;

namespace MathKitTest.Geometry
{
    [TestClass]
    public class Triangle3Test
    {
        private const int TRIANGLE_AMOUNT = 3;

        private struct TriangleInfo
        {
            public Triangle3 triangle;
            public double expectedSquare;
            public Vector3 expectedMedianCentre;

            public Vector3 expectedAB;
            public Vector3 expectedBC;
            public Vector3 expectedCA;

            public double angleA;
            public double angleB;
            public double angleC;
        }

        private TriangleInfo[] testData;

        public Triangle3Test()
        {
            testData = new TriangleInfo[TRIANGLE_AMOUNT];
            testData[0] = GetTestTriangle1();
            testData[1] = GetTestTriangle2();
            testData[2] = GetTestTriangle3();
        }

        private TriangleInfo GetTestTriangle1()
        {
            TriangleInfo info = new TriangleInfo();

            info.triangle = new Triangle3(new Vector3(0, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 0, 0));
            info.expectedSquare = 0.5;

            info.expectedMedianCentre = new Vector3(1.0 / 3.0, 1.0 / 3.0, 0);

            info.expectedAB = new Vector3(0, 1, 0);
            info.expectedBC = new Vector3(1, -1, 0);
            info.expectedCA = new Vector3(-1, 0, 0);

            info.angleA = MathConst.PId2;
            info.angleB = MathConst.PI / 4.0;
            info.angleC = MathConst.PI / 4.0;

            return info;
        }

        private TriangleInfo GetTestTriangle2()
        {
            TriangleInfo info = new TriangleInfo();

            info.triangle = new Triangle3(new Vector3(0, 0, 0), new Vector3(0, 0, 1), new Vector3(1, 0, 0));
            info.expectedSquare = 0.5;

            info.expectedMedianCentre = new Vector3(1.0 / 3.0, 0, 1.0 / 3.0);

            info.expectedAB = new Vector3(0, 0, 1);
            info.expectedBC = new Vector3(1, 0, -1);
            info.expectedCA = new Vector3(-1, 0, 0);

            info.angleA = MathConst.PId2;
            info.angleB = MathConst.PI / 4.0;
            info.angleC = MathConst.PI / 4.0;

            return info;
        }

        private TriangleInfo GetTestTriangle3()
        {
            TriangleInfo info = new TriangleInfo();

            info.triangle = new Triangle3(new Vector3(0, 0, 0), new Vector3(0, 0, 1), new Vector3(0, 1, 0));
            info.expectedSquare = 0.5;

            info.expectedMedianCentre = new Vector3(0, 1.0 / 3.0, 1.0 / 3.0);

            info.expectedAB = new Vector3(0, 0, 1);
            info.expectedBC = new Vector3(0, 1, -1);
            info.expectedCA = new Vector3(0, -1, 0);

            info.angleA = MathConst.PId2;
            info.angleB = MathConst.PI / 4.0;
            info.angleC = MathConst.PI / 4.0;

            return info;
        }

        [TestMethod]
        public void TestTriagles()
        {
            for (int i = 0; i < TRIANGLE_AMOUNT; i++)
            {
                CheckSquare(this.testData[i]);
                CheckMedianCentre(this.testData[i]);
                CheckSides(this.testData[i]);
                CheckAngles(this.testData[i]);
            }
        }

        private void CheckSquare(TriangleInfo info)
        {
            Assert.AreEqual(info.expectedSquare, info.triangle.Square(), MathConst.EPSYLON);
        }

        private void CheckMedianCentre(TriangleInfo info)
        {
            Vector3 median = info.triangle.MedianCentre();

            Assert.AreEqual(info.expectedMedianCentre.x, median.x, MathConst.EPSYLON);
            Assert.AreEqual(info.expectedMedianCentre.y, median.y, MathConst.EPSYLON);
            Assert.AreEqual(info.expectedMedianCentre.z, median.z, MathConst.EPSYLON);
        }

        private void CheckSides(TriangleInfo info)
        {
            CheckSide(info.expectedAB, info.triangle.SideAB);
            CheckSide(info.expectedBC, info.triangle.SideBC);
            CheckSide(info.expectedCA, info.triangle.SideCA);
        }

        private void CheckSide(Vector3 expectedSide, Vector3 side)
        {
            Assert.AreEqual(expectedSide.x, side.x, MathConst.EPSYLON);
            Assert.AreEqual(expectedSide.y, side.y, MathConst.EPSYLON);
            Assert.AreEqual(expectedSide.z, side.z, MathConst.EPSYLON);
        }

        private void CheckAngles(TriangleInfo info)
        {
            Assert.AreEqual(info.angleA, info.triangle.AngleA(), MathConst.EPSYLON);
            Assert.AreEqual(info.angleB, info.triangle.AngleB(), MathConst.EPSYLON);
            Assert.AreEqual(info.angleC, info.triangle.AngleC(), MathConst.EPSYLON);
        }
    }
}
