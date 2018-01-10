using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    interface IParser
    {
        double[] ParseDataSeries(string path);
    }
}
