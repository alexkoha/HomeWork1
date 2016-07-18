using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quad;

namespace QuadTest
{
    [TestClass]
    public class TestEquation
    {

        [TestMethod]
        public void TestEquation_One_Result()
        {
            Equation test = new Equation();
            var x = test.Resolve(1,2,1);

            Assert.AreEqual(-1 , x[0]);
        }
        [TestMethod]

        public void TestEquation_Two_Results()
        {
            Equation test = new Equation();
            var x = test.Resolve(5, 6, 1);

            Assert.AreEqual(-0.2, x[0]);
            Assert.AreEqual(-1, x[1]);
        }

        [TestMethod]
        public void TestEquation_None_Results()
        {
            Equation test = new Equation();
            var x = test.Resolve(5, 1, 1);

            //Please notice the order of the argument. The expected argument come first
            Assert.AreEqual(x, null);
        }

        [TestMethod]
        public void TestEquation_NaN_And_Negative_Infinity()
        {
            Equation test = new Equation();
            var x = test.Resolve(0,1, 5);

            Assert.AreEqual(x[0], Double.NaN);
            Assert.AreEqual(x[1], Double.NegativeInfinity);

        }

    }
}
