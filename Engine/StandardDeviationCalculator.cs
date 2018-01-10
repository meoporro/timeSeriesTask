using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class StandardDeviationCalculator : ICalculator
    {
        private ICalculator meanCalculator { get; }

        internal StandardDeviationCalculator()
        {
            meanCalculator = CalculatorFactory.GetCalculator(CalculatorType.Mean);
        }

        public double Compute(IEnumerable<double> values)
        {
            double mean = meanCalculator.Compute(values);

            double sumOfSquaredDifferences = 0;
            int counter = 0;
            foreach (double value in values)
            {
                sumOfSquaredDifferences += (value - mean) * (value - mean);
                counter++;
            }

            return counter > 1 ? Math.Sqrt(sumOfSquaredDifferences / (counter - 1)) : 0d;
        }
    }
}
