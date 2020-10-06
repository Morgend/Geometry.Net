using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometry;

namespace GeometryTest
{
    [TestClass]
    public class Vector3ParallelismTest
    {
        private const int PARALLEL_AMOUNT = 5;
        private const int NONPARALLEL_AMOUNT = 8;

        private Vector3Pair[] parallelVectors;
        private Vector3Pair[] nonParallelVectors;

        public Vector3ParallelismTest()
        {
            InitParallelVectors();
            InitNonParallelVectors();
        }

        private void InitParallelVectors()
        {
            this.parallelVectors = new Vector3Pair[PARALLEL_AMOUNT];

            this.parallelVectors[0] = new Vector3Pair(Vector3.ZERO_VECTOR, Vector3.ZERO_VECTOR);
            this.parallelVectors[1] = new Vector3Pair(new Vector3(2, 1, 0.4), new Vector3(4.2, 2.1, 0.84));
            this.parallelVectors[2] = new Vector3Pair(new Vector3(1, 2, 3), Vector3.ZERO_VECTOR);
            this.parallelVectors[3] = new Vector3Pair(new Vector3(-1, 3, -2.5), new Vector3(2, -6, 5));
            this.parallelVectors[4] = new Vector3Pair(new Vector3(0.8, 0.1, 100.2), new Vector3(4.0, 0.5, 501.0));
        }

        private void InitNonParallelVectors()
        {
            this.nonParallelVectors = new Vector3Pair[NONPARALLEL_AMOUNT];

            this.nonParallelVectors[0] = new Vector3Pair(new Vector3(1, 0, 0), new Vector3(0, 1, 0));
            this.nonParallelVectors[1] = new Vector3Pair(new Vector3(1, 0, 0), new Vector3(0, 0, 1));
            this.nonParallelVectors[2] = new Vector3Pair(new Vector3(0, 1, 0), new Vector3(1, 0, 0));
            this.nonParallelVectors[3] = new Vector3Pair(new Vector3(0, 1, 0), new Vector3(0, 0, 1));
            this.nonParallelVectors[4] = new Vector3Pair(new Vector3(2, 1, 2), new Vector3(4.1, 2.1, 4.2));
            this.nonParallelVectors[5] = new Vector3Pair(new Vector3(1, 2, 1), new Vector3(-1, -2, -0.9));
            this.nonParallelVectors[6] = new Vector3Pair(new Vector3(1, 3, 3), new Vector3(2, -6, -6));
            this.nonParallelVectors[7] = new Vector3Pair(new Vector3(0.8, 0.1, 100.2), new Vector3(3.8, -0.5, 501.0));
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
