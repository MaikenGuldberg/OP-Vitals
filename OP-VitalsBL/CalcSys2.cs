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
        private double _sys;
        private DAQSettingsDTO _daqDTO;
        public CalcSys2(DAQSettingsDTO daqDTO)
        {
            _daqDTO = daqDTO;
            analyselist = new List<double>();
            MaxList = new List<double>();
            threshold = 100; //Skal måske ændres
            _sys = 0;
        }
       
        private void CalculateSys(List<double> dataList, DAQSettingsDTO DAQ)
        {
            for (int i = 0; i < dataList.Count; i++)
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
                            _sys = Math.Round(MaxList.Max());
                            MaxList.Clear();
                        }
                    }

                }
                if (analyselist.Count == 3 * DAQ.SampleRate)
                {
                    analyselist.RemoveAt(0);
                }
            }
        }

        public double GetSys()
        {
            return _sys;
        }
    }
}
