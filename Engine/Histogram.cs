using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Histogram
    {
        private double[] binBoundaries;

        public Histogram(double minRange, double maxRange, int nBins)
        {
            if (minRange >= maxRange || nBins < 1) throw new ArgumentException(); 

            binBoundaries = new double[nBins + 1];
            double step = (maxRange - minRange) / nBins;
            binBoundaries[0] = minRange;
            for (int i = 1; i < nBins; i++)
            {
                binBoundaries[i] = minRange + i * step;
            }
            binBoundaries[nBins] = maxRange;
        }

        public int[] ComputeFrequenciesOf(IEnumerable<double> values)
        {
            if (values.Min() < binBoundaries[0] || values.Max() > binBoundaries.Last())
            {
                throw new ArgumentOutOfRangeException();
            }

            int nBins = binBoundaries.Length - 1;
            int[] frequencies = new int[nBins];

            foreach (double value in values)
            {
                bool binFound = false;
                for (int binIndex = 0; binIndex < nBins - 1; binIndex++)
                {
                    if (value >= binBoundaries[binIndex] && value < binBoundaries[binIndex + 1])
                    {
                        frequencies[binIndex]++;
                        binFound = true;
                        break;
                    }
                }
                if (!binFound) frequencies[nBins - 1]++;
            }
            return frequencies;
        }
    }
}
