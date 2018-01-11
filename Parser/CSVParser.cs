using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class CSVParser : IParser
    {
        private static CSVParser instance;

        private CSVParser()
        {
        }

        public static CSVParser CSVParserInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CSVParser();
                }
                return instance;
            }
        }

        /// <summary>
        /// Parse comma separated values in a CSV file.
        /// Assumption: values on different lines are merged into a single data series.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public double[] ParseDataSeries(string path)
        {
            List<double> dataSeries = new List<double>();

            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    dataSeries.AddRange(line.Split(',').Select(x => double.Parse(x)));
                }
            }

            return dataSeries.ToArray();
        }
    }
}
