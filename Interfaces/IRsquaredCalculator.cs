using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface iRsquaredCalculator
    {
        void LinearRegressionCalc(double[] xVals, double[] yVals,
            int inclusiveStart, int exclusiveEnd,
            out double rsquared, out double yintercept,
            out double slope);
    }
}
