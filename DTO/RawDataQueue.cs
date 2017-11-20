using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments;

namespace DTO
{
    public class RawDataQueue
    {
        private double[] RawData = new double[100];

        public double[] GetRawData100()
        {
            return RawData;
        }

        public void SetRawDataSample(AnalogWaveform<double>[] dataAnalogWaveform)
        {
            foreach (AnalogWaveform<double> waveform in dataAnalogWaveform)
            {
                for (int i = 0; i < waveform.Samples.Count; i++)
                {
                    RawData[i] = waveform.Samples[i].Value;
                }
            }
        }
    }
}
