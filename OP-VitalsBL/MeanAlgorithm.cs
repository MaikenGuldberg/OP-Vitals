using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace OP_VitalsBL
{
    public class MeanAlgorithm
    {

        private List<double> analyselist;
        private int ix;

        public MeanAlgorithm()
        {
            analyselist = new List<double>();
            ix = 0;
        }
        private void CalculateMean(List<double> dataList,BloodpreasureDTO bloodpreasure,DAQSettingsDTO DAQ)
        {
            for (int i = ix; i < ix+DAQ.SamplesPerChannel; i++)
            {
                if (analyselist.Count < 3 * DAQ.SampleRate)
                {
                    analyselist.Add(dataList[i]);

                }
                if (analyselist.Count == 3 * DAQ.SampleRate)
                {
                    bloodpreasure.Meanpressure = Math.Round(analyselist.Average());
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
        //        bloodpreasure.Meanpressure = Math.Round(analyselist.Average());
        //        analyselist.RemoveAt(0);
        //    }
        //}

    }
}
