using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathKit;
using MathKit.Geometry;

namespace MathKitTest.Geometry
{
    [TestClass]
    public class Vector3ComparisonTest
    {
        private const int EQUAL_AMOUNT = 5;
        private const int NONEQUAL_AMOUNT = 5;

        private Vector3Pair[] equalVectors;
        private Vector3Pair[] nonEqualVectors;

        public Vector3ComparisonTest()
        {
            InitEqualVectors();
            InitNonEqualVectors();
        }

        private void InitEqualVectors()
        {
            this.equalVectors = new Vector3Pair[EQUAL_AMOUNT];

            this.equalVectors[0] = new Vector3Pair(new Vector3(), new Vector3());
            this.equalVectors[1] = new Vector3Pair(new Vector3(2, 1, 0.4), new Vector3(2, 1, 0.4));
            this.equalVectors[2] = new Vector3Pair(new Vector3(1, 2, 3), new Vector3(1 + MathConstant.EPSYLON / 2, 2 - MathConstant.EPSYLON / 3, 3 - MathConstant.EPSYLON / 2));
            this.equalVectors[3] = new Vector3Pair(new Vector3(-1, -500, 1000), new Vector3(-1, -500 + MathConstant.EPSYLON, 1000 - MathConstant.EPSYLON));
            this.equalVectors[4] = new Vector3Pair(new Vector3(10000, -20000, 30000), new Vector3(10000, -20000, 30000));
        }

        private void InitNonEqualVectors()
        {
            this.nonEqualVectors = new Vector3Pair[NONEQUAL_AMOUNT];

            this.nonEqualVectors[0] = new Vector3Pair(new Vector3(1, 0, 0), new Vector3(0, 1, 0));
            this.nonEqualVectors[1] = new Vector3Pair(new Vector3(1, 0, 0), new Vector3(1 + 1.1 * MathConstant.EPSYLON, 0, 0));
            this.nonEqualVectors[2] = new Vector3Pair(new Vector3(3, 2, 1), new Vector3(-3, -2, -1));
            this.nonEqualVectors[3] = new Vector3Pair(new Vector3(1, 2, MathConstant.EPSYLON), new Vector3(1, 2, -MathConstant.EPSYLON));
            this.nonEqualVectors[4] = new Vector3Pair(new Vector3(2, 1, 2), new Vector3(2, 1.1, 2));
        }

        [TestMethod]
        public void TestEqualVectors()
        {
            for (int i = 0; i < EQUAL_AMOUNT; i++)
            {
                Assert.IsTrue(this.equalVectors[i].a.IsEqualTo(this.equalVectors[i].b));
            }
        }

        [TestMethod]
        public void TestNonEqualVectors()
        {
            for (int i = 0; i < NONEQUAL_AMOUNT; i++)
            {
                Assert.IsFalse(this.nonEqualVectors[i].a.IsEqualTo(this.nonEqualVectors[i].b));
            }
        }
    }
}
