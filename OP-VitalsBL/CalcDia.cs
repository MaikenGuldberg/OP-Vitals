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
        private double _dia;
        private DAQSettingsDTO _daqDTO;

        public CalcDia(DAQSettingsDTO daqDTO)
        {
            analyselist = new List<double>();
            _dia = 0;
            _daqDTO = daqDTO;
        }
        private void CalculateDia(List<double> dataList,DAQSettingsDTO DAQ)
        {
            for (int i = 0; i < dataList.Count; i++)
            {
                if (analyselist.Count < 3 * DAQ.SampleRate)
                {
                    analyselist.Add(dataList[i]);
                }
                if (analyselist.Count == 3 * DAQ.SampleRate)
                {
                    _dia = Math.Round(analyselist.Min());
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
