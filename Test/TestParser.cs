using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser;
using System.Linq;

namespace Test
{
    [TestClass]
    public class TestParser
    {
        [TestMethod]
        public void CSVParserSingleLine()
        {
            var parser = CSVParser.CSVParserInstance;
            string dataPath = "$(ProjectDir)/../../../data/testDataSingleLine.csv";
            double[] parsedDataSeries = parser.ParseDataSeries(dataPath);
            CollectionAssert.AreEqual(parsedDataSeries, Enumerable.Range(0, 6).Select(x => (double)x).ToArray());
        }

        [TestMethod]
        public void CSVParserTwoLines()
        {
            var parser = CSVParser.CSVParserInstance;
            string dataPath = "$(ProjectDir)/../../../data/testDataTwoLines.csv";
            double[] parsedDataSeries = parser.ParseDataSeries(dataPath);
            CollectionAssert.AreEqual(parsedDataSeries, Enumerable.Range(0, 11).Select(x => (double)x).ToArray());
        }
    }
}
