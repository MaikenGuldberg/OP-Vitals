using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using MathNet.Filtering;
using MathNet.Numerics.IntegralTransforms;

namespace OP_VitalsBL
{
    class Puls
    {
        private List<double> analyselist;
        private List<double> pulsList;
        private int Counthighs;
        private double threashold;
        private double _puls;
        private DAQSettingsDTO _daqDTO;

        public Puls(DAQSettingsDTO daqDTO)
        {
            _daqDTO = daqDTO;
            analyselist = new List<double>();
            _puls = 0;
            Counthighs = 0;
        }
        
        //private void CalculatePuls(List<double> dataList,DAQSettingsDTO DAQ)
        //{
        //    Fourier.Forward(dataList);
        //    for (int i = 0; i < dataList.Count; i++)
        //    {
        //        if (analyselist.Count < 3 * DAQ.SampleRate)
        //        {
        //            analyselist.Add(dataList[i]);
        //        }
        //        if (analyselist.Count == 3 * DAQ.SampleRate)
        //        {
        //            _dia = Math.Round(analyselist.Min());
        //            analyselist.RemoveAt(0);
        //        }
        //    }
        //    //threashold = bloodpreasure.Systole * 0.80;
        //    foreach (var data in dataList)
        //    {
        //        if (analyselist.Count < 9 * DAQ.SampleRate)
        //        {
        //            analyselist.Add(data);
        //            if (data > threashold)
        //            {
        //                pulsList.Add(data);
                        
        //            }
        //            else
        //            {
        //                if (pulsList.Count > 0)
        //                {
        //                    Counthighs++;
        //                    pulsList.Clear();
        //                }
        //            }

        //        }
        //        if (analyselist.Count == 9 * DAQ.SampleRate)
        //        {
        //            _puls = Counthighs * (9 / 60);
        //            analyselist.RemoveAt(0);
        //            Counthighs = 0;
        //        }
        //    }
           
        //}

        //public double GetPuls()
        //{
        //    return _puls;
        //}
    }
}
