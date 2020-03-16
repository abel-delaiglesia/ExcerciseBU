using ExcerciseCubes.Domain.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace  CubesTest
{  
        [TestClass]
        public class CubeCollisionDetectionTest
        {
 
            [TestMethod]
            public void cubes_that_do_not_touch()
            {

                var cubeA = new CubeService().CenteredAt(2, 2, 2).WithEdgeLength(2).Build();
                var cubeB = new CubeService().CenteredAt(10, 10, 10).WithEdgeLength(2).Build();

                Assert.IsFalse(cubeA.CollidesWith(cubeB));
            }

            [TestMethod]
            public void cubes_that_overlap()
            {
                var cubeA = new CubeService().CenteredAt(2, 2, 2).WithEdgeLength(2).Build();
                var cubeB = new CubeService().CenteredAt(3, 2, 2).WithEdgeLength(2).Build();

                Assert.IsTrue(cubeA.CollidesWith(cubeB));
            }

            [TestMethod]
            public void cubes_that_touch()
            {
                var cubeA = new CubeService().CenteredAt(2, 2, 2).WithEdgeLength(2).Build();
                var cubeB = new CubeService().CenteredAt(4, 2, 2).WithEdgeLength(2).Build();

                Assert.IsTrue(cubeA.CollidesWith(cubeB));
            }
        }

        public class CubeIntersectionVolumeComputationTest
        {

            [TestMethod]
            public void cubes_that_do_not_intersect()
            {
               var cubeA = new CubeService().CenteredAt(2, 2, 2).WithEdgeLength(2).Build();
               var cubeB = new CubeService().CenteredAt(10, 10, 10).WithEdgeLength(2).Build();

                Assert.AreEqual(0, cubeA.IntersectionVolumeWith(cubeB));
            }

            [TestMethod]
            public void cubes_with_same_height_and_depth()
            {
                var cubeA = new CubeService().CenteredAt(2, 2, 2).WithEdgeLength(2).Build();
                var cubeB = new CubeService().CenteredAt(3, 2, 2).WithEdgeLength(2).Build();

                Assert.AreEqual(4, cubeA.IntersectionVolumeWith(cubeB));
            }

            [TestMethod]
            public void cubes_with_same_width_and_depth()
            {
                var cubeA = new CubeService().CenteredAt(2, 2, 2).WithEdgeLength(2).Build();
                var cubeB = new CubeService().CenteredAt(2, 3, 2).WithEdgeLength(2).Build();

                Assert.AreEqual(4, cubeA.IntersectionVolumeWith(cubeB));
            }

            [TestMethod]
            public void cubes_with_same_width_and_height()
            {
                var cubeA = new CubeService().CenteredAt(2, 2, 2).WithEdgeLength(2).Build();
                var cubeB = new CubeService().CenteredAt(2, 2, 3).WithEdgeLength(2).Build();

                Assert.AreEqual(4, cubeA.IntersectionVolumeWith(cubeB));
            }

            [TestMethod]
            public void one_cube_is_contained_within_the_other()
            {
                var cubeA = new CubeService().CenteredAt(2, 2, 2).WithEdgeLength(2).Build();
                var cubeB = new CubeService().CenteredAt(2, 2, 2).WithEdgeLength(1).Build();

                Assert.AreEqual(1, cubeA.IntersectionVolumeWith(cubeB));
            }

            [TestMethod]
            public void cubes_are_completely_overlapped()
            {
                var cubeA = new CubeService().CenteredAt(2, 2, 2).WithEdgeLength(2).Build();
                var cubeB = new CubeService().CenteredAt(2, 2, 2).WithEdgeLength(2).Build();

                Assert.AreEqual(8, cubeA.IntersectionVolumeWith(cubeB));
            }

            [TestMethod]
            public void cubes_are_touching_but_not_intersecting()
            {
                var cubeA = new CubeService().CenteredAt(2, 2, 2).WithEdgeLength(2).Build();
                var cubeB = new CubeService().CenteredAt(4, 2, 2).WithEdgeLength(2).Build();

                Assert.AreEqual(0, cubeA.IntersectionVolumeWith(cubeB));
            }

            [TestMethod]
            public void is_commutative()
            {
                var cubeA = new CubeService().CenteredAt(0, 0, 0).WithEdgeLength(3).Build();
                var cubeB = new CubeService().CenteredAt(2, 2, 2).WithEdgeLength(2).Build();

                Assert.AreEqual(cubeA.IntersectionVolumeWith(cubeB),
                    cubeB.IntersectionVolumeWith(cubeA));
            }
        }
}
 

