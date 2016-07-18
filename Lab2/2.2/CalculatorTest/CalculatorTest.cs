
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace CalculatorTest
{
    //Consider extracting each class to different file

    [TestClass]
    public class TestCalculatorOperetionAdd
    {
        [TestMethod]
        public void Calc_Add_BothPositive()
        {
            CalculatorOperetion op = new CalculatorOperetion();
            double result = op.Add(5, 6);
            Assert.AreEqual(11,result);
        }
        [TestMethod]
        public void Calc_Add_PositivWithNegative()
        {
            CalculatorOperetion op = new CalculatorOperetion();
            double result = op.Add(5, -3);
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void Calc_Add_TwoZeros()
        {
            CalculatorOperetion op = new CalculatorOperetion();
            double result = op.Add(0, 0);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Calc_Add_MaxFloatWithPositive()
        {
            CalculatorOperetion op = new CalculatorOperetion();
            double result = op.Add(1, float.MaxValue);
            Assert.AreEqual((double)(float.MaxValue) +1, result);
        }

        [TestMethod]
        public void Calc_Add_MaxDoubleWithPositive()
        {
            CalculatorOperetion op = new CalculatorOperetion();
            double result = op.Add(1, double.MaxValue);
            Assert.AreEqual((double.MaxValue), result);
        }

    }

    [TestClass]
    public class TestCalculatorOperetionSub
    {
        [TestMethod]
        public void Calc_Sub_BothPositive()
        {
            CalculatorOperetion op = new CalculatorOperetion();
            double result = op.Sub(70, 1);
            Assert.AreEqual(69, result);
        }
        [TestMethod]
        public void Calc_Sub_PositiveWithNegative()
        {
            CalculatorOperetion op = new CalculatorOperetion();
            double result = op.Sub(70, -1);
            Assert.AreEqual(71, result);
        }
        [TestMethod]
        public void Calc_Sub_BothZeros()
        {
            CalculatorOperetion op = new CalculatorOperetion();
            double result = op.Sub(0, 0);
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void Calc_Sub_ToNegativ()
        {
            CalculatorOperetion op = new CalculatorOperetion();
            double result = op.Sub(1, float.MaxValue);
            Assert.AreEqual(1 - (float.MaxValue), result);
        }

        [TestMethod]
        public void Calc_Sub_DoubleMinWithPositive()
        {
            CalculatorOperetion op = new CalculatorOperetion();
            double result = op.Sub(double.MinValue, 1);
            Assert.AreEqual(double.MinValue, result);
        }

    }

    [TestClass]
    public class TestCalculatorOperetionMul
    {
        [TestMethod]
        public void Calc_Mul_BothPositive()
        {
            CalculatorOperetion op = new CalculatorOperetion();
            double result = op.Mul(1, 9);
            Assert.AreEqual(9, result);
        }


        [TestMethod]
        public void Calc_Mul_PsativeWithNegative()
        {
            CalculatorOperetion op = new CalculatorOperetion();
            double result = op.Mul(-81, 10);
            Assert.AreEqual(-810, result);
        }


        [TestMethod]
        public void Calc_Mul_BothZero()
        {
            CalculatorOperetion op = new CalculatorOperetion();
            double result = op.Mul(0, 0);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Calc_MulMaxValueByPosative()
        {
            CalculatorOperetion op = new CalculatorOperetion();
            double result = op.Mul(double.MaxValue, 2);
            Assert.AreEqual(double.PositiveInfinity, result);
        }

        [TestMethod]
        public void Calc_Mul_MaxValueByNegative()
        {
            CalculatorOperetion op = new CalculatorOperetion();
            double result = op.Mul(double.MaxValue, -2);
            Assert.AreEqual(double.NegativeInfinity, result);
        }
    }

    [TestClass]
    public class TestCalculatorOperetionDiv
    {
        [TestMethod]
        public void Calc_Div_BothPositive()
        {
            CalculatorOperetion op = new CalculatorOperetion();
            double result = op.Div(10, 1);
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Calc_Div_PositivWithNegative()
        {
            CalculatorOperetion op = new CalculatorOperetion();
            double result = op.Div(10, -1);
            Assert.AreEqual(-10, result);
        }

        [TestMethod]
        public void Calc_Div_TwoZeros()
        {
            CalculatorOperetion op = new CalculatorOperetion();
            double result = op.Div(0, 0);
            Assert.AreEqual(double.NaN, result);
        }

        [TestMethod]
        public void Calc_Div_ByZero()
        {
            CalculatorOperetion op = new CalculatorOperetion();
            double result = op.Div(10, 0);
            Assert.AreEqual(double.PositiveInfinity, result);
        }
    }
}
