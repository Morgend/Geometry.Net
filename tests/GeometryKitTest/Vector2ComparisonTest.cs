using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometryKit;

namespace GeometryKitTest
{
    [TestClass]
    public class Vector2ComparisonTest
    {
        private const int EQUAL_AMOUNT = 5;
        private const int NONEQUAL_AMOUNT = 5;

        private Vector2Pair[] equalVectors;
        private Vector2Pair[] nonEqualVectors;

        public Vector2ComparisonTest()
        {
            InitEqualVectors();
            InitNonEqualVectors();
        }

        private void InitEqualVectors()
        {
            this.equalVectors = new Vector2Pair[EQUAL_AMOUNT];

            this.equalVectors[0] = new Vector2Pair(new Vector2(), new Vector2());
            this.equalVectors[1] = new Vector2Pair(new Vector2(2, 1), new Vector2(2, 1));
            this.equalVectors[2] = new Vector2Pair(new Vector2(2, 3), new Vector2(2 + MathConstant.EPSYLON / 2, 3 - MathConstant.EPSYLON));
            this.equalVectors[3] = new Vector2Pair(new Vector2(-500, 1000), new Vector2(-500 - MathConstant.EPSYLON, 1000 + MathConstant.EPSYLON));
            this.equalVectors[4] = new Vector2Pair(new Vector2(20000, -30000), new Vector2(20000, -30000));
        }

        private void InitNonEqualVectors()
        {
            this.nonEqualVectors = new Vector2Pair[NONEQUAL_AMOUNT];

            this.nonEqualVectors[0] = new Vector2Pair(new Vector2(1, 0), new Vector2(0, 1));
            this.nonEqualVectors[1] = new Vector2Pair(new Vector2(1, 0), new Vector2(1 - 1.1 * MathConstant.EPSYLON, 0));
            this.nonEqualVectors[2] = new Vector2Pair(new Vector2(3, 2), new Vector2(-3, -2));
            this.nonEqualVectors[3] = new Vector2Pair(new Vector2(10, MathConstant.EPSYLON), new Vector2(10, -MathConstant.EPSYLON));
            this.nonEqualVectors[4] = new Vector2Pair(new Vector2(2, 1), new Vector2(2, 1.1));
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
