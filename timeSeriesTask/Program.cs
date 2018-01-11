using Engine;
using Parser;
using System;

namespace timeSeriesTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataPath = "$(ProjectDir)/../../../../data/SampleData.csv";

            double[] data = CSVParser.CSVParserInstance.ParseDataSeries(dataPath);

            double arithmeticMean = CalculatorFactory.GetCalculator(CalculatorType.ArithmeticMean).Compute(data);

            Console.WriteLine("Hi!");
            Console.WriteLine("\n" +
                "The arithmetic mean of the sample data is: "
                + arithmeticMean);

            double standardDeviation = CalculatorFactory.GetCalculator(CalculatorType.StandardDeviation).Compute(data);

            Console.WriteLine("\n" +
                "Its standard deviation is: "
                + standardDeviation);

            int minRange = 0;
            int maxRange = 100;
            int nBins = 10;
            var histogram = new Histogram(minRange, maxRange, nBins);
            int[] frequencies = histogram.ComputeFrequenciesOf(data);

            Console.WriteLine(string.Format("\n" + "The frequencies of a histogram with {0} equally spaced bins are:", nBins));
            for (int bin = 0; bin < frequencies.Length; bin++)
            {
                Console.WriteLine(string.Format("[{0}, {1}" + (bin == frequencies.Length - 1 ? "]" : ")") + ": {2}",
                    histogram.BinBoundaries[bin], histogram.BinBoundaries[bin + 1], frequencies[bin]));
            }

            Console.WriteLine("\n" + "Thanks. Bye!");
            Console.ReadLine();
        }
    }
}
