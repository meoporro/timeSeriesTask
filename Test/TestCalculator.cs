using System;
using System.Linq;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class TestCalculator
    {
        [TestMethod]
        public void MeanOfConstantArray()
        {
            double constant = 1d;
            int n = 10;
            double[] constantArray = new double[n].Select(x => constant).ToArray();
            double arrayMean = workerTestCalculator(CalculatorType.Mean, constantArray);
            Assert.AreEqual(constant, arrayMean);
        }

        [TestMethod]
        public void MeanOfLinearArray()
        {
            int n = 10;
            double[] linearArray = Enumerable.Range(1, n).Select(x => (double)x).ToArray();
            double arrayMean = workerTestCalculator(CalculatorType.Mean, linearArray);
            Assert.AreEqual((1 + n) / 2d, arrayMean);
        }

        [TestMethod]
        public void MeanOfSquaresArray()
        {
            int n = 10;
            double[] squaresArray = Enumerable.Range(1, n).Select(x => (double)(x * x)).ToArray();
            double arrayMean = workerTestCalculator(CalculatorType.Mean, squaresArray);
            Assert.AreEqual((n + 1) * (2 * n + 1) / 6d, arrayMean);
        }

        private double workerTestCalculator(CalculatorType calculatorType, double[] array)
        {
            var calculator = CalculatorFactory.GetCalculator(calculatorType);
            return calculator.Compute(array);
        }
    }
}
