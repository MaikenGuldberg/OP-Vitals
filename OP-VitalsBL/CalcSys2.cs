using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Interfaces;

namespace OP_VitalsBL
{
    class CalcSys2 : ICalcSys
    {
        private List<double> analyselist;
        private List<double> MaxList;
        private double threshold;

        public CalcSys2()
        {
            analyselist = new List<double>();
            MaxList = new List<double>();
            threshold = 100; //Skal måske ændres
        }
        public void CalculateSys(double value, BloodpreasureDTO bloodpreasure,DAQSettingsDTO DAQ)
        {
            if (analyselist.Count < 3*DAQ.SampleRate)
            {
                if (value > threshold)
                {
                    MaxList.Add(value);
                    analyselist.Add(value);
                }
                else
                {
                    analyselist.Add(value);
                    if (MaxList.Count > 0)
                    {
                        bloodpreasure.Systole = MaxList.Max();
                        MaxList.Clear();
                    }
                }
               
            }
            if (analyselist.Count == 3*DAQ.SampleRate)
            {
                analyselist.Clear();
            }


        }
    }
}
