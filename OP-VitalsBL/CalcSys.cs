using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Interfaces;

namespace OP_VitalsBL
{
    class CalcSys : ICalcSys
    {
        private List<double> analyselist;

        public CalcSys()
        {
            analyselist = new List<double>();
        }
        public void CalculateSys(double value,BloodpreasureDTO bloodpreasure)
        {
            if (analyselist.Count < 3000)
            {
                analyselist.Add(value);
            }
            if (analyselist.Count == 3000)
            {
                bloodpreasure.Systole = analyselist.Max();
            }
            else
            {
                analyselist.Clear();
            }
        }
    }
}
