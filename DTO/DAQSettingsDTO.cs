﻿using System;
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

        public double ConversionConstant_ { get; set; }
        public double ZeroPoint_ { get; set; }

        public int SaveInterval_ { get; protected set; } //med hvilket interval målingerne skal gemmes ned i en fil i sekunder.

        public int Interval_s { get; set; }
        public DAQSettingsDTO()
        {
           
            SampleRate = 1000;
            Interval_s = 1;
            Data_Format_ = "CSV";
            Bin_or_text_ = 'b';
            Measurement_Format_Type_ = "double";
            ConversionConstant_ = 1;
            ZeroPoint_ = 0.0;
            SamplesPerChannel = 100;
            physicalChannelName_ = "Dev2/ai0";
            MinValueVolt_ = -5;
            MaxValueVolt = 5;
            SaveInterval_ = 300;

        }
    }
}
