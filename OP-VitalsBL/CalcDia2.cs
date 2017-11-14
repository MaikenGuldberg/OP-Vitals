using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Interfaces;

namespace OP_VitalsBL
{
    class CalcDia2 : ICalcDia
    {
        private List<double> analyselist;
        private List<double> MinList;
        private double threshold;

        public CalcDia2()
        {
            analyselist = new List<double>();
            MinList = new List<double>();
            threshold = 80; //Skal måske ændres
        }
        public void CalculateDia(double value, BloodpreasureDTO bloodpreasure,DAQSettingsDTO DAQ)
        {
            if (analyselist.Count < 3*DAQ.SampleRate)
            {
                if (value < threshold)
                {
                   MinList.Add(value);
                   analyselist.Add(value);
                }
                else
                {
                    analyselist.Add(value);
                    if (MinList.Count > 0)
                    {
                        bloodpreasure.Diastole = MinList.Min();
                        MinList.Clear();
                    }
                }
                analyselist.Add(value);
            }
            if (analyselist.Count == 3*DAQ.SampleRate)
            {
                analyselist.Clear();
            }


        }
    }
}
