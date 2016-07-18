using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryDisplay;

namespace BinaryDisplayTest
{
    //You can add more UnitTests. You are checking only the number of "1".
    [TestClass]
    public class TestBinaryDisplay
    {
        [TestMethod]
        public void BinaryDisplay_CalcNumberOfOnes_Zero()
        {
            int numberOfones = Program.CalcNumberOfOnes(0);

            Assert.AreEqual(0, numberOfones);
        }

        [TestMethod]
        public void BinaryDisplay_CalcNumberOfOnes_Seven()
        {
            int numberOfones = Program.CalcNumberOfOnes(7);

            Assert.AreEqual(3, numberOfones);
        }

        [TestMethod]
        public void BinaryDisplay_CalcNumberOfOnes_Five_Hundreds()
        {
            int numberOfones = Program.CalcNumberOfOnes(500);

            Assert.AreEqual(6, numberOfones);
        }

        [TestMethod]
        public void BinaryDisplay_CalcNumberOfOnes_Negativ_Seven()
        {
            int numberOfones = Program.CalcNumberOfOnes(-7);

            Assert.AreEqual(30, numberOfones);
        }
    }
}
