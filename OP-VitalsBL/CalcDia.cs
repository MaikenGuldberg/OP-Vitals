using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Interfaces;

namespace OP_VitalsBL
{
    class CalcDia : ICalcDia
    {
        private List<double> analyselist;

        public CalcDia()
        {
            analyselist = new List<double>();
        }
        public void CalculateDia(double value, BloodpreasureDTO bloodpreasure,DAQSettingsDTO DAQ)
        {
            if (analyselist.Count < 3*DAQ.SampleRate)
            {
                analyselist.Add(value);
            }
            if (analyselist.Count == 3*DAQ.SampleRate)
            {
                bloodpreasure.Diastole = analyselist.Min();
            }
            else
            {
                analyselist.Clear();
            }
        }
    }
}
