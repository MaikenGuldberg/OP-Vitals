﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Interfaces;

namespace OP_VitalsBL
{
    public class CalcSys : ICalcSys
    {
        private List<double> analyselist;
        private double _sys;
        private DAQSettingsDTO _daqDTO;

        public CalcSys(DAQSettingsDTO daqDTO)
        {
            analyselist = new List<double>();
            _sys = 0;
            _daqDTO = daqDTO;
        }
        private void CalculateSys(List<double> dataList,DAQSettingsDTO DAQ)
        {
            for (int i = 0; i < dataList.Count; i++)
            {
                if (analyselist.Count < 3 * DAQ.SampleRate)
                {
                    analyselist.Add(dataList[i]);
                }
                if (analyselist.Count == 3 * DAQ.SampleRate)
                {
                    _sys = Math.Round(analyselist.Max());
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
