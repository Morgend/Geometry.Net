using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometryKit;

namespace MathKitTest.Geometry
{
    [TestClass]
    public class Triangle2Test
    {
        private const int TRIANGLE_AMOUNT = 1;

        private const int DEGENERATED_TRIANGLE_AMOUNT = 5;

        private struct TriangleInfo
        {
            public Triangle2 triangle;
            public double expectedSquare;
            public Vector2 expectedMedianCentre;

            public Vector2 expectedAB;
            public Vector2 expectedBC;
            public Vector2 expectedCA;

            public double angleA;
            public double angleB;
            public double angleC;
        }

        private TriangleInfo[] testData;

        private Triangle2[] degeneratedTriangle;

        public Triangle2Test()
        {
            InitCommonTrianlges();
            InitDegeneratedTriangles();
        }

        private void InitCommonTrianlges()
        {
            testData = new TriangleInfo[TRIANGLE_AMOUNT];
            testData[0] = GetTestTriangle1();
        }

        private TriangleInfo GetTestTriangle1()
        {
            TriangleInfo info = new TriangleInfo();

            info.triangle = new Triangle2(new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 0));
            info.expectedSquare = 0.5;

            info.expectedMedianCentre = new Vector2(1.0 / 3.0, 1.0 / 3.0);

            info.expectedAB = new Vector2(0, 1);
            info.expectedBC = new Vector2(1, -1);
            info.expectedCA = new Vector2(-1, 0);

            info.angleA = MathConstant.PId2;
            info.angleB = MathConstant.PI / 4.0;
            info.angleC = MathConstant.PI / 4.0;

            return info;
        }

        private void InitDegeneratedTriangles()
        {
            this.degeneratedTriangle = new Triangle2[DEGENERATED_TRIANGLE_AMOUNT];
            this.degeneratedTriangle[0] = new Triangle2(new Vector2(), new Vector2(), new Vector2());
            this.degeneratedTriangle[1] = new Triangle2(new Vector2(1, 2), new Vector2(1, 2), new Vector2(1, 2));
            this.degeneratedTriangle[2] = new Triangle2(new Vector2(1, 2), new Vector2(2, 1), new Vector2(1, 2));
            this.degeneratedTriangle[3] = new Triangle2(new Vector2(3, 5), new Vector2(7, 9), new Vector2(5, 7));
            this.degeneratedTriangle[4] = new Triangle2(new Vector2(-3, 2), new Vector2(-4, 2.5), new Vector2(1, 0));
        }

        [TestMethod]
        public void TestCommonTriagles()
        {
            for (int i = 0; i < TRIANGLE_AMOUNT; i++)
            {
                CheckSquare(this.testData[i]);
                CheckMedianCentre(this.testData[i]);
                CheckSides(this.testData[i]);
                CheckAngles(this.testData[i]);

                Assert.IsFalse(this.testData[i].triangle.IsDegenerated());
            }
        }

        private void CheckSquare(TriangleInfo info)
        {
            Assert.AreEqual(info.expectedSquare, info.triangle.Square(), MathConstant.EPSYLON);
        }

        private void CheckMedianCentre(TriangleInfo info)
        {
            Vector2 median = info.triangle.MedianCentre();

            Assert.AreEqual(info.expectedMedianCentre.x, median.x, MathConstant.EPSYLON);
            Assert.AreEqual(info.expectedMedianCentre.y, median.y, MathConstant.EPSYLON);
        }

        private void CheckSides(TriangleInfo info)
        {
            CheckSide(info.expectedAB, info.triangle.VectorAB);
            CheckSide(info.expectedBC, info.triangle.VectorBC);
            CheckSide(info.expectedCA, info.triangle.VectorCA);
        }

        private void CheckSide(Vector2 expectedSide, Vector2 side)
        {
            Assert.AreEqual(expectedSide.x, side.x, MathConstant.EPSYLON);
            Assert.AreEqual(expectedSide.y, side.y, MathConstant.EPSYLON);
        }

        private void CheckAngles(TriangleInfo info)
        {
            Assert.AreEqual(info.angleA, info.triangle.AngleA(), MathConstant.EPSYLON);
            Assert.AreEqual(info.angleB, info.triangle.AngleB(), MathConstant.EPSYLON);
            Assert.AreEqual(info.angleC, info.triangle.AngleC(), MathConstant.EPSYLON);
        }

        [TestMethod]
        public void TestDegeneratedTriagles()
        {
            for (int i = 0; i < DEGENERATED_TRIANGLE_AMOUNT; i++)
            {
                Assert.IsTrue(this.degeneratedTriangle[i].IsDegenerated());
            }
        }
    }
}
