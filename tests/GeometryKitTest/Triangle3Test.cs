using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometryKit;

namespace GeometryKitTest
{
    [TestClass]
    public class Triangle3Test
    {
        private const int TRIANGLE_AMOUNT = 3;

        private const int DEGENERATED_TRIANGLE_AMOUNT = 6;

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

        private Triangle3[] degeneratedTriangle;

        public Triangle3Test()
        {
            InitCommonTrianlges();
            InitDegeneratedTriangles();
        }

        private void InitCommonTrianlges()
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

            info.angleA = MathConstant.PId2;
            info.angleB = MathConstant.PI / 4.0;
            info.angleC = MathConstant.PI / 4.0;

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

            info.angleA = MathConstant.PId2;
            info.angleB = MathConstant.PI / 4.0;
            info.angleC = MathConstant.PI / 4.0;

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

            info.angleA = MathConstant.PId2;
            info.angleB = MathConstant.PI / 4.0;
            info.angleC = MathConstant.PI / 4.0;

            return info;
        }

        private void InitDegeneratedTriangles()
        {
            this.degeneratedTriangle = new Triangle3[DEGENERATED_TRIANGLE_AMOUNT];
            this.degeneratedTriangle[0] = new Triangle3(Vector3.ZERO_VECTOR, Vector3.ZERO_VECTOR, Vector3.ZERO_VECTOR);
            this.degeneratedTriangle[1] = new Triangle3(new Vector3(1, 2, 3), new Vector3(1, 2, 3), new Vector3(1, 2, 3));
            this.degeneratedTriangle[2] = new Triangle3(new Vector3(1, 2, 3), new Vector3(2, 1, 3), new Vector3(1, 2, 3));
            this.degeneratedTriangle[3] = new Triangle3(new Vector3(1, 2, 3), new Vector3(1, 3, 2), new Vector3(1, 2, 3));
            this.degeneratedTriangle[4] = new Triangle3(new Vector3(3, 5, 4), new Vector3(7, 9, 8), new Vector3(5, 7, 6));
            this.degeneratedTriangle[5] = new Triangle3(new Vector3(-3, 2, -1), new Vector3(-4, 2.5, 2), new Vector3(1, 0, -13));
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
            Vector3 median = info.triangle.MedianCentre();

            Assert.AreEqual(info.expectedMedianCentre.x, median.x, MathConstant.EPSYLON);
            Assert.AreEqual(info.expectedMedianCentre.y, median.y, MathConstant.EPSYLON);
            Assert.AreEqual(info.expectedMedianCentre.z, median.z, MathConstant.EPSYLON);
        }

        private void CheckSides(TriangleInfo info)
        {
            CheckSide(info.expectedAB, info.triangle.VectorAB);
            CheckSide(info.expectedBC, info.triangle.VectorBC);
            CheckSide(info.expectedCA, info.triangle.VectorCA);
        }

        private void CheckSide(Vector3 expectedSide, Vector3 side)
        {
            Assert.AreEqual(expectedSide.x, side.x, MathConstant.EPSYLON);
            Assert.AreEqual(expectedSide.y, side.y, MathConstant.EPSYLON);
            Assert.AreEqual(expectedSide.z, side.z, MathConstant.EPSYLON);
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
