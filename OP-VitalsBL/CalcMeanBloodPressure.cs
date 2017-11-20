using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace OP_VitalsBL
{
    public class CalcMeanBloodPressure
    {

        private List<double> analyselist;
        private double _meanBloodPressure;
        private DAQSettingsDTO _daqDTO;

        public CalcMeanBloodPressure(DAQSettingsDTO daqDTO)
        {
            _meanBloodPressure = 0;
            analyselist = new List<double>();
            _daqDTO = daqDTO;
        }
        public void CalculateMean(List<double> dataList,DAQSettingsDTO DAQ)
        {
            for (int i = 0; i < dataList.Count; i++)
            {
                if (analyselist.Count < 3 * DAQ.SampleRate)
                {
                    analyselist.Add(dataList[i]);

                }
                if (analyselist.Count == 3 * DAQ.SampleRate)
                {
                    _meanBloodPressure = Math.Round(analyselist.Average());
                    analyselist.RemoveAt(0);
                }
            }
        }

        public double GetMeanBloodPressure()
        {
            return _meanBloodPressure;
        }
    }
}
