using System;
using System.Collections.Generic;

namespace Engine
{
    public class StandardDeviationCalculator : ICalculator
    {
        private ICalculator arithmeticMeanCalculator { get; }

        internal StandardDeviationCalculator()
        {
            arithmeticMeanCalculator = CalculatorFactory.GetCalculator(CalculatorType.ArithmeticMean);
        }

        public double Compute(IEnumerable<double> values)
        {
            double mean = arithmeticMeanCalculator.Compute(values);

            double sumOfSquaredDifferences = 0;
            int counter = 0;
            foreach (double value in values)
            {
                sumOfSquaredDifferences += (value - mean) * (value - mean);
                counter++;
            }

            // Case counter == 1 is dealt with separately.
            return counter > 1 ? Math.Sqrt(sumOfSquaredDifferences / (counter - 1)) : 0d;
        }
    }
}
