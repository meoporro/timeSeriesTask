using System.Collections.Generic;

namespace Engine
{
    public class ArithmeticMeanCalculator : ICalculator
    {
        // Constructor used only by the factory
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
