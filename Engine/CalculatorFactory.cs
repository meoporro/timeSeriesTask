using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public enum CalculatorType
    {
        Null,
        Mean,
        StandardDeviation
    }

    public class CalculatorFactory
    {
        public static ICalculator GetCalculator(CalculatorType calculatorType)
        {
            switch (calculatorType)
            {
                case CalculatorType.Mean:
                    return new MeanCalculator();
                case CalculatorType.StandardDeviation:
                    return new StandardDeviationCalculator();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
