using System;
using System.Linq;
using Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser;

namespace Test
{
    [TestClass]
    public class TestSampleData
    {
        // Test implementation against built-in implementation.
        [TestMethod]
        public void SampleData()
        {
            string dataPath = "$(ProjectDir)/../../../../data/SampleData.csv";

            double[] data = CSVParser.CSVParserInstance.ParseDataSeries(dataPath);

            double arithmeticMean = CalculatorFactory.GetCalculator(CalculatorType.ArithmeticMean).Compute(data);
            
            double standardDeviation = CalculatorFactory.GetCalculator(CalculatorType.StandardDeviation).Compute(data);
            
            int minRange = 0;
            int maxRange = 100;
            int nBins = 10;
            var histogram = new Histogram(minRange, maxRange, nBins);
            int[] frequencies = histogram.ComputeFrequenciesOf(data);

            int N = data.Length;
            double tolerance = 1e-12;
            Assert.AreEqual(arithmeticMean, data.Average(), tolerance);
            Assert.AreEqual(standardDeviation, Math.Sqrt(data.Select(x => x * x).Sum() / (N - 1) - (double)N / (N - 1) * data.Average() * data.Average()), tolerance);
            Assert.AreEqual(N, frequencies.Sum());
        }
    }
}
