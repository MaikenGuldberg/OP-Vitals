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
        private double _dia;
        private DAQSettingsDTO _daqDTO;
        public CalcDia2(DAQSettingsDTO daqDTO)
        {
            analyselist = new List<double>();
            MinList = new List<double>();
            threshold = 80; //Skal måske ændres
            _dia = 0;
            _daqDTO = daqDTO;
        }
        
        private void CalculateDia(List<double> dataList, DAQSettingsDTO DAQ)
        {
            for (int i = 0; i < dataList.Count; i++)
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
                            _dia = Math.Round(MinList.Min());
                            MinList.Clear();
                        }
                    }

                }
                if (analyselist.Count == 3 * DAQ.SampleRate)
                {
                    analyselist.RemoveAt(0);
                }
            }
        }

        public double GetDia()
        {
            return _dia;
        }
    }
}
