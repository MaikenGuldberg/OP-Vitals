using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace OP_VitalsBL
{
    public class Converter
    {
        private DAQSettingsDTO _daqSettingsDTO;

        public Converter(DAQSettingsDTO daqSettingsDTO)
        {
            _daqSettingsDTO = daqSettingsDTO;
        }

        public List<double> Convert(double[] listOfRawData)
        {
            List<double> convertetList = new List<double>();
            foreach (var value in listOfRawData)
            {
                double result = ((value * 1000)-_daqSettingsDTO.ZeroPoint_)* _daqSettingsDTO.ConversionConstant_;
                convertetList.Add(result);
            }
            return convertetList;
        }

    }
}
