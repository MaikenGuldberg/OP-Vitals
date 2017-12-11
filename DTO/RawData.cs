using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments;

namespace DTO
{
    public class RawData
    {
        private double[] _rawData = new double[100];

        public double[] GetRawData100()
        {
            return _rawData;
        }

        public void SetRawDataSample(AnalogWaveform<double>[] dataAnalogWaveform)
        {
            foreach (AnalogWaveform<double> waveform in dataAnalogWaveform)
            {
                for (int i = 0; i < waveform.Samples.Count; i++)
                {
                    _rawData[i] = waveform.Samples[i].Value;
                }
            }
        }
    }
}
