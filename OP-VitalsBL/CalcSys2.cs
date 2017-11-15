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
        private int ix;
        public CalcSys2()
        {
            analyselist = new List<double>();
            MaxList = new List<double>();
            threshold = 100; //Skal måske ændres
            ix = 0;
        }
       
        public void CalculateSys(List<double> dataList, BloodpreasureDTO bloodpreasure, DAQSettingsDTO DAQ)
        {
            for (int i = ix; i < ix+DAQ.SamplesPerChannel; i++)
            {
                if (analyselist.Count < 3 * DAQ.SampleRate)
                {
                    analyselist.Add(dataList[i]);
                    if (dataList[i] > threshold)
                    {
                        MaxList.Add(dataList[i]);

                    }
                    if (dataList[i] < threshold)
                    {

                        if (MaxList.Count > 0)
                        {
                            bloodpreasure.Systole = Math.Round(MaxList.Max());
                            MaxList.Clear();
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
        //        if (data > threshold)
        //        {
        //            MaxList.Add(data);
                       
        //        }
        //        if(data<threshold)
        //        {
                        
        //            if (MaxList.Count > 0)
        //            {
        //                bloodpreasure.Systole = Math.Round(MaxList.Max());
        //                MaxList.Clear();
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
