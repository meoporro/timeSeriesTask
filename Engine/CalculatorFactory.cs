using System;

namespace Engine
{
    public enum CalculatorType
    {
        Null,
        ArithmeticMean,
        StandardDeviation
    }

    public class CalculatorFactory
    {
        public static ICalculator GetCalculator(CalculatorType calculatorType)
        {
            switch (calculatorType)
            {
                case CalculatorType.ArithmeticMean:
                    return new ArithmeticMeanCalculator();
                case CalculatorType.StandardDeviation:
                    return new StandardDeviationCalculator();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
