using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace OP_VitalsBL
{
    class NoFilter : IFilter
    {
        public List<double> FilterData(double[] data)
        {
            return data.ToList();
        }
    }
}
