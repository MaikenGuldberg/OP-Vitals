using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Interfaces;

namespace OP_VitalsBL
{
    public class CalcSys : ICalcSys
    {
        private List<double> analyselist;

        public CalcSys()
        {
            analyselist = new List<double>();
        }
        public void CalculateSys(double value,BloodpreasureDTO bloodpreasure,DAQSettingsDTO DAQ)
        {
            
            if (analyselist.Count < 3*DAQ.SampleRate)
            {
                analyselist.Add(value);
            }
            if (analyselist.Count == 3*DAQ.SampleRate)
            {
                bloodpreasure.Systole = analyselist.Max();
            }
            if(analyselist.Count>3*DAQ.SampleRate)
            {
                analyselist.Clear();
                analyselist.Add(value);
            }
        }
    }
}
