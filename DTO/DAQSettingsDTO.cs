using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DAQSettingsDTO
    {
        public string Data_Format_ { get; protected set; }
        public char Bin_or_text_ { get; protected set; }
        public string Measurement_Format_Type_ { get; protected set; }

        public string physicalChannelName_ { get; protected set; }

        public int MinValueVolt_ { get; protected set; }

        public int MaxValueVolt { get; protected set; }

        public int SamplesPerChannel { get; protected set; }

        public int SampleRate { get; protected set; }

        public int Samples {get; protected set;}

        public double ConversionConstant_ { get; set; }
        public double ZeroPoint_ { get; set; }

        public int SaveInterval_ { get; protected set; } //med hvilket interval målingerne skal gemmes ned i en fil i sekunder.

        public int Interval_ms { get; protected set; }
        public DAQSettingsDTO()
        {
            //besluttes senere
           
            SampleRate = 1000;
            Interval_ms = 1;
            Data_Format_ = "bytearray"; //tjek om det er rigtigt
            Bin_or_text_ = 'b'; //tjek om det er rigtigt
            Measurement_Format_Type_ = "double";
            ConversionConstant_ = 1; //tjek værdierne 
            ZeroPoint_ = 0.0; //tjek værdierne
            SamplesPerChannel = 100;
            physicalChannelName_ = "Dev2/ai0";
            MinValueVolt_ = -5;
            MaxValueVolt = 5;
            SaveInterval_ = 5000;

        }
    }
}
