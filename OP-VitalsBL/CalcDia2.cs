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
        private int ix;

        public CalcDia2()
        {
            analyselist = new List<double>();
            MinList = new List<double>();
            threshold = 80; //Skal måske ændres
            ix = 0;
        }
        
        public void CalculateDia(List<double> dataList, BloodpreasureDTO bloodpreasure, DAQSettingsDTO DAQ)
        {
            for (int i = ix; i < ix+DAQ.SamplesPerChannel; i++)
            {
                if (analyselist.Count < 3 * DAQ.SampleRate)
                {
                    analyselist.Add(dataList[i]);
                    if (dataList[i] < threshold)
                    {
                        MinList.Add(dataList[i]);

                    }
                    if (dataList[i] > threshold)
                    {

                        if (MinList.Count > 0)
                        {
                            bloodpreasure.Systole = Math.Round(MinList.Min());
                            MinList.Clear();
                        }
                    }

                }
                if (analyselist.Count == 3 * DAQ.SampleRate)
                {
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
        //        if (data<threshold)
        //        {
        //            MinList.Add(data);

        //        }
        //        if (data > threshold)
        //        {

        //            if (MinList.Count > 0)
        //            {
        //                bloodpreasure.Systole = Math.Round(MinList.Min());
        //                MinList.Clear();
        //            }
        //        }

        //    }
        //    if (analyselist.Count == 3 * DAQ.SampleRate)
        //    {
        //        analyselist.RemoveAt(0);
        //    }
        //}
    }
}
