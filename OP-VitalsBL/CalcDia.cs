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
        private int ix;

        public CalcDia()
        {
            analyselist = new List<double>();
            ix = 0;
        }
        public void CalculateDia(List<double> dataList, BloodpreasureDTO bloodpreasure,DAQSettingsDTO DAQ)
        {
            for (int i = ix; i < ix+DAQ.SamplesPerChannel; i++)
            {
                if (analyselist.Count < 3 * DAQ.SampleRate)
                {
                    analyselist.Add(dataList[i]);
                }
                if (analyselist.Count == 3 * DAQ.SampleRate)
                {
                    bloodpreasure.Diastole = Math.Round(analyselist.Min());
                    analyselist.RemoveAt(0);
                }
            }
            ix = dataList.Count;
            
        }

        //foreach (var data in dataList)
        //{
        //    if (analyselist.Count< 3 * DAQ.SampleRate)
        //    {
        //        analyselist.Add(data);
        //    }
        //    if (analyselist.Count == 3 * DAQ.SampleRate)
        //    {
        //        bloodpreasure.Diastole = Math.Round(analyselist.Min());
        //        analyselist.RemoveAt(0);
        //    }

        //}
    }
}
