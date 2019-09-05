using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometryKit;

namespace MathKitTest.Geometry
{
    [TestClass]
    public class Vector2ParallelismTest
    {
        private const int PARALLEL_AMOUNT = 5;
        private const int NONPARALLEL_AMOUNT = 5;

        private Vector2Pair[] parallelVectors;
        private Vector2Pair[] nonParallelVectors;

        public Vector2ParallelismTest()
        {
            InitParallelVectors();
            InitNonParallelVectors();
        }

        private void InitParallelVectors()
        {
            this.parallelVectors = new Vector2Pair[PARALLEL_AMOUNT];

            this.parallelVectors[0] = new Vector2Pair(new Vector2(), new Vector2());
            this.parallelVectors[1] = new Vector2Pair(new Vector2(2, 1), new Vector2(4.2, 2.1));
            this.parallelVectors[2] = new Vector2Pair(new Vector2(1, 2), new Vector2());
            this.parallelVectors[3] = new Vector2Pair(new Vector2(-1, 3), new Vector2(2, -6));
            this.parallelVectors[4] = new Vector2Pair(new Vector2(0.8, 0.1), new Vector2(4, 0.5));
        }

        private void InitNonParallelVectors()
        {
            this.nonParallelVectors = new Vector2Pair[NONPARALLEL_AMOUNT];

            this.nonParallelVectors[0] = new Vector2Pair(new Vector2(1, 0), new Vector2(0, 1));
            this.nonParallelVectors[1] = new Vector2Pair(new Vector2(2, 1), new Vector2(4.1, 2.1));
            this.nonParallelVectors[2] = new Vector2Pair(new Vector2(1, 2), new Vector2(-1, -1.9));
            this.nonParallelVectors[3] = new Vector2Pair(new Vector2(1, 3), new Vector2(2, -6));
            this.nonParallelVectors[4] = new Vector2Pair(new Vector2(0.8, 0.1), new Vector2(3.8, -0.5));
        }

        [TestMethod]
        public void TestParallelVectors()
        {
            for (int i = 0; i < PARALLEL_AMOUNT; i++)
            {
                Assert.IsTrue(this.parallelVectors[i].a.IsParallelTo(this.parallelVectors[i].b));
            }
        }

        [TestMethod]
        public void TestNonParallelVectors()
        {
            for (int i = 0; i < NONPARALLEL_AMOUNT; i++)
            {
                Assert.IsFalse(this.nonParallelVectors[i].a.IsParallelTo(this.nonParallelVectors[i].b));
            }
        }
    }
}
