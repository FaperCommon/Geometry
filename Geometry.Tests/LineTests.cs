using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometry.Tests
{
    [TestClass]
    public class LineTests
    {

        //Tests for IsParallelLines
        public void LinesParallelismTest(Line l1, Line l2, bool expected)
        {
            var result = Line.IsParallelLines(l1, l2);

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestForTwoParallelLines()
        {
            Line l1 = new Line(new Point(1, 1), new Point(2, 2));
            Line l2 = new Line(new Point(2, 1), new Point(3, 2));

            LinesParallelismTest(l1, l2, true);
        }


        [TestMethod]
        public void TestForTwoNotParallelLines()
        {
            Line l1 = new Line(new Point(1, 1), new Point(2, 2));
            Line l2 = new Line(new Point(2, 1), new Point(2, 2));

            LinesParallelismTest(l1, l2, false);
        }

        //Tests for IsIntersectingState
        public void TestForTwoLinesState(Line l1, Line l2, StateOfLines expectedState)
        {
            var result = Line.IsIntersectingState(l1, l2);

            Assert.AreEqual(result, expectedState);
        }

        [TestMethod]
        public void TestForTwoCoincidentLinesState()
        {
            Line l1 = new Line(new Point(1, 1), new Point(2, 2));
            Line l2 = new Line(new Point(3, 3), new Point(4, 4));

            TestForTwoLinesState(l1, l2, StateOfLines.Coincident);
        }

        [TestMethod]
        public void TestForTwoIntersectLinesState()
        {
            Line l1 = new Line(new Point(1, 1), new Point(2, 2));
            Line l2 = new Line(new Point(1, -1), new Point(-1, 1));

            TestForTwoLinesState(l1, l2, StateOfLines.Intersect);
        }

        [TestMethod]
        public void TestForTwoParallelLinesState()
        {
            Line l1 = new Line(new Point(1, 1), new Point(2, 2));
            Line l2 = new Line(new Point(1, 3), new Point(-1, 1));

            TestForTwoLinesState(l1, l2, StateOfLines.Parallel);
        }

        //Tests for PointBelongsToVector
        public void TestForPointBelongsToVector(Line line, Point point, bool expected)
        {
            var result = Line.PointBelongsToVector(line, point);

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestForBelongsPoint()
        {
            Line l1 = new Line(new Point(1, 1), new Point(2, 2));
            Point p1 = new Point(1.5f, 1.5f);
            TestForPointBelongsToVector(l1, p1, true);
        }


        [TestMethod]
        public void TestForNotBelongsPoint()
        {
            Line l1 = new Line(new Point(1, 1), new Point(2, 2));
            Point p1 = new Point(1.5f, 1.6f);

            TestForPointBelongsToVector(l1, p1, false);
        }

        //Tests for IntersectionPointOfLines
        [TestMethod]
        public void TestForIntersectionPointOfLines()
        {
            Line l1 = new Line(new Point(1, 1), new Point(-2, -2));
            Line l2 = new Line(new Point(-1, 1), new Point(2, -2));

            var result = Line.IntersectionPointOfLines(l1, l2);

            Assert.AreEqual(result, new Point(0,0));
        }

        [TestMethod]
        public void TestForNotIntersectionPointOfLines()
        {
            Line l1 = new Line(new Point(1, 1), new Point(2, 2));
            Line l2 = new Line(new Point(1, 1), new Point(2, 2));

            var result = Line.IntersectionPointOfLines(l1, l2);

            Assert.AreEqual(result, null);
        }


        //Tests for IntersectionPointOfVectors
        public void TestForIntersectionPointOfVectors(Line l1, Line l2, Point expectedPoint)
        {
            var result = Line.IntersectionPointOfVectors(l1, l2);

            Assert.AreEqual(result, expectedPoint);
        }

        [TestMethod]
        public void TestForIntersectionLines()
        {
            Line l1 = new Line(new Point(1, 1), new Point(-2, -2));
            Line l2 = new Line(new Point(-1, 1), new Point(2, -2));

            TestForIntersectionPointOfVectors(l1, l2, new Point(0, 0));
        }

        [TestMethod]
        public void TestForParallelLines()
        {
            Line l1 = new Line(new Point(1, 1), new Point(2, 2));
            Line l2 = new Line(new Point(3, 3), new Point(4, 4));


            TestForIntersectionPointOfVectors(l1, l2, null);
        }

        [TestMethod]
        public void TestForCoincidentLines()
        {
            Line l1 = new Line(new Point(1, 1), new Point(3, 3));
            Line l2 = new Line(new Point(2, 2), new Point(5, 5));

            TestForIntersectionPointOfVectors(l1, l2, null);
        }

    }
}
