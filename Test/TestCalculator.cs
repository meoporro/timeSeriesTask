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
        public void CalculatorFactoryMean()
        {
            var calculator = CalculatorFactory.GetCalculator(CalculatorType.Mean);
            Assert.IsInstanceOfType(calculator, typeof(ArithmeticMeanCalculator));
        }

        [TestMethod]
        public void CalculatorFactoryStandardDeviation()
        {
            var calculator = CalculatorFactory.GetCalculator(CalculatorType.StandardDeviation);
            Assert.IsInstanceOfType(calculator, typeof(StandardDeviationCalculator));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculatorFactoryNull()
        {
            var calculator = CalculatorFactory.GetCalculator(CalculatorType.Null);
        }

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

        [TestMethod]
        public void StandardDeviationOfConstantArray()
        {
            double constant = 1d;
            int n = 10;
            double[] constantArray = new double[n].Select(x => constant).ToArray();
            double arrayStandardDeviation = workerTestCalculator(CalculatorType.StandardDeviation, constantArray);
            Assert.AreEqual(0, arrayStandardDeviation);
        }

        [TestMethod]
        public void StandardDeviationOfSingleValue()
        {
            double constant = 1d;
            double[] singleValue = new double[] { constant };
            double arrayStandardDeviation = workerTestCalculator(CalculatorType.StandardDeviation, singleValue);
            Assert.AreEqual(0, arrayStandardDeviation);
        }

        [TestMethod]
        public void StandardDeviationOfLinearValue()
        {
            int n = 11;
            double[] linearArray = Enumerable.Range(1, n).Select(x => (double)x).ToArray();
            double arrayStandardDeviation = workerTestCalculator(CalculatorType.StandardDeviation, linearArray);
            Assert.AreEqual(Math.Sqrt((n * (n + 1)) / 12d), arrayStandardDeviation);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void HistogramInconsistentRange()
        {
            var histogram = new Histogram(10, 0, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void HistogramNonPositiveNumberOfBins()
        {
            var histogram = new Histogram(0, 1, -1);
        }
        
        [TestMethod]
        public void HistogramOddNumbers()
        {
            int n = 5;
            double[] oddNumbers = Enumerable.Range(1, n).Select(x => (double)1 + 2 * (x - 1)).ToArray();
            var histogram = new Histogram(0d, 2d * n, n);
            int[] frequencies = histogram.ComputeFrequenciesOf(oddNumbers);
            CollectionAssert.AreEqual(new int[n].Select(x => 1).ToArray(), frequencies);
        }

        private ICalculator workerGetCalculator(CalculatorType calculatorType)
        {
            return CalculatorFactory.GetCalculator(calculatorType);
        }

        private double workerTestCalculator(CalculatorType calculatorType, double[] array)
        {
            var calculator = CalculatorFactory.GetCalculator(calculatorType);
            return calculator.Compute(array);
        }
    }
}
