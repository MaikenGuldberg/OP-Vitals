using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DAQSettingsDTO
    {
        private int samples_;
        private int sampleRate_;
        private List<double> dataList_;
        public string Data_Format_ { get; protected set; }
        public char Bin_or_text_ { get; protected set; }
        public string Measurement_Format_Type_ { get; protected set; }

        public string physicalChannelName_ { get; protected set; }

        public int MinValueVolt_ { get; protected set; }

        public int MaxValueVolt { get; protected set; }

        public int SamplesPerChannel { get; protected set; }

        public int SampleRate { get { return sampleRate_; } set { if (0 < value) sampleRate_ = value; } }

        public int Samples { get { return samples_; }set
        {
            if (0 < value) samples_ = value;
        } }

        public List<double> Datalist { get; set; }

        public double ConversionConstant_ { get; set; }
        public double ZeroPoint_ { get; set; }

        public DAQSettingsDTO()
        {
            //besluttes senere
           
            sampleRate_ = 1000;
            samples_ = 0;
            Data_Format_ = "bytearray"; //tjek om det er rigtigt
            Bin_or_text_ = 'b'; //tjek om det er rigtigt
            Measurement_Format_Type_ = "double";
            Datalist = new List<double>();
            ConversionConstant_ = 25; //tjek værdierne 
            ZeroPoint_ = 10; //tjek værdierne
            SamplesPerChannel = 100;
            physicalChannelName_ = "Dev2/ai0";
            MinValueVolt_ = -5;
            MaxValueVolt = 5;

        }
    }
}
