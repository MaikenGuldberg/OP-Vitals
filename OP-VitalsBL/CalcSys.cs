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
        private int ix;

        public CalcSys()
        {
            analyselist = new List<double>();
            ix = 0;
        }
        public void CalculateSys(List<double> dataList,BloodpreasureDTO bloodpreasure,DAQSettingsDTO DAQ)
        {
            for (int i = ix; i < ix+DAQ.SamplesPerChannel; i++)
            {
                if (analyselist.Count < 3 * DAQ.SampleRate)
                {
                    analyselist.Add(dataList[i]);
                }
                if (analyselist.Count == 3 * DAQ.SampleRate)
                {
                    bloodpreasure.Systole = Math.Round(analyselist.Max());
                    analyselist.RemoveAt(0);
                }
            }
            ix = dataList.Count;

        }

        // foreach (var data in dataList)
        //{
        //    if (analyselist.Count< 3 * DAQ.SampleRate)
        //    {
        //        analyselist.Add(data);
        //    }
        //    if (analyselist.Count == 3 * DAQ.SampleRate)
        //    {
        //        bloodpreasure.Systole = Math.Round(analyselist.Max());
        //        analyselist.RemoveAt(0);
        //    }
        //}
    }
}
