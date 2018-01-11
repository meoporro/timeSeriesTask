using System.Collections.Generic;

namespace Calculator
{
    public interface ICalculator
    {
        double Compute(IEnumerable<double> values);
    }
}
