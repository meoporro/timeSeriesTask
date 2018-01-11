using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    public class Histogram
    {
        /// <summary>
        /// Boundaries of the histogram bins.
        /// Assumption: bin[i] = [binBoundaries[i], binBoundaries[i + 1])
        /// with exception for the last one bin[nBins - 1] = [binBoundaries[nBins - 1], binBoundaries[nBins]]
        /// </summary>
        public double[] BinBoundaries { get; }

        /// <summary>
        /// Construct an histogram with nBins evenly spaced bins in the range [minRange, maxRange]
        /// </summary>
        /// <param name="minRange"></param>
        /// <param name="maxRange"></param>
        /// <param name="nBins"></param>
        public Histogram(double minRange, double maxRange, int nBins)
        {
            if (minRange >= maxRange || nBins < 1) throw new ArgumentException(); 

            BinBoundaries = new double[nBins + 1];
            double step = (maxRange - minRange) / nBins;
            BinBoundaries[0] = minRange;
            for (int i = 1; i < nBins; i++)
            {
                BinBoundaries[i] = minRange + i * step;
            }
            // Assing maxRange out of the loop to avoid floating precition rounding errors.
            BinBoundaries[nBins] = maxRange;
        }

        public int[] ComputeFrequenciesOf(IEnumerable<double> values)
        {
            if (values.Min() < BinBoundaries[0] || values.Max() > BinBoundaries.Last())
            {
                throw new ArgumentOutOfRangeException();
            }

            int nBins = BinBoundaries.Length - 1;
            int[] frequencies = new int[nBins];

            foreach (double value in values)
            {
                // Loop over the bins apart from the last one to consider the corner case of a value 
                // equal to BinBoundaries.Last()
                bool binFound = false;
                for (int binIndex = 0; binIndex < nBins - 1; binIndex++)
                {
                    if (value >= BinBoundaries[binIndex] && value < BinBoundaries[binIndex + 1])
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
