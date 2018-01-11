using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ArithmeticMeanCalculator : ICalculator
    {
        internal ArithmeticMeanCalculator()
        { }

        public double Compute(IEnumerable<double> values)
            {
            double sum = 0;
            int counter = 0;
            foreach (double value in values)
            {
                sum += value;
                counter++;
            }

            return sum / counter;
        }
    }
}
