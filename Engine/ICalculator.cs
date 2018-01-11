using System.Collections.Generic;

namespace Engine
{
    public interface ICalculator
    {
        double Compute(IEnumerable<double> values);
    }
}
