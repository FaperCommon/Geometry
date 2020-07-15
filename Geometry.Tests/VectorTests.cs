
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geometry.Tests
{

    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void GetCenterOfVectorAtTwoPoints()
        {
            var p1 = new Point(1, 1);
            var p2 = new Point(3, 3);
            Point result = new Point(2, 2);

            var c1 = Vector.GetCenter(p1,p2);

            Assert.AreEqual(result, c1);
        }

        [TestMethod]
        public void GetVectorAtTwoPoints()
        {
            var p1 = new Point(1, 1);
            var p2 = new Point(3, 3);
            Point result = new Point(-2, -2);

            var v1 = Vector.GetVector(p1, p2);

            Assert.AreEqual(result, v1);
        }

        [TestMethod]
        public void GetLengthOfVectors()
        {
            var testingVector = new Point(0, -2);
            float result = 2f;

            var len = Vector.GetLength(testingVector);

            Assert.AreEqual(result, len);
        }
        

    }
}
