using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathKit;
using MathKit.Geometry;

namespace MathKitTest.Geometry
{
    [TestClass]
    public class Triangle2Test
    {
        private const int TRIANGLE_AMOUNT = 1;

        private struct TriangleInfo
        {
            public Triangle2 triangle;
            public double expectedSquare;
            public Vector2 expectedMedianCentre;

            public Vector2 expectedAB;
            public Vector2 expectedBC;
            public Vector2 expectedCA;
        }

        private TriangleInfo[] testData;

        public Triangle2Test()
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

            return info;
        }

        [TestMethod]
        public void TestTriagles()
        {
            for (int i = 0; i < TRIANGLE_AMOUNT; i++)
            {
                CheckSquare(this.testData[i].expectedSquare, this.testData[i].triangle);
                CheckMedianCentre(this.testData[i].expectedMedianCentre, this.testData[i].triangle);

                CheckSide(this.testData[i].expectedAB, this.testData[i].triangle.SideAB);
                CheckSide(this.testData[i].expectedBC, this.testData[i].triangle.SideBC);
                CheckSide(this.testData[i].expectedCA, this.testData[i].triangle.SideCA);
            }
        }

        private void CheckSquare(double expectedSquare, Triangle2 triangle)
        {
            Assert.AreEqual(expectedSquare, triangle.CalculateSquare(), MathConst.EPSYLON);
        }

        private void CheckMedianCentre(Vector2 expectedCentre, Triangle2 triangle)
        {
            Vector2 median = triangle.CalculateMedianCentre();

            Assert.AreEqual(expectedCentre.x, median.x, MathConst.EPSYLON);
            Assert.AreEqual(expectedCentre.y, median.y, MathConst.EPSYLON);
        }

        private void CheckSide(Vector2 expectedSide, Vector2 side)
        {
            Assert.AreEqual(expectedSide.x, side.x, MathConst.EPSYLON);
            Assert.AreEqual(expectedSide.y, side.y, MathConst.EPSYLON);
        }
    }
}
