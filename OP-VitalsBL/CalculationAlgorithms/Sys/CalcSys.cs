﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DTO;
using Interfaces;

namespace OP_VitalsBL
{
     public class CalcSys : CalcSysSubject, DeQueueObserver //+public tilføjet
    {
        private List<double> analyselist;
        private double _sys;
        private DAQSettingsDTO _daqDTO;
        private readonly AutoResetEvent _dataReadyEvent;
        private bool _stopThread;
        private DeQueue _deQueue;
        private IAlarm _alarm;
        private double sys;

        public CalcSys(DAQSettingsDTO daqDTO,AutoResetEvent dataReadyEvent, DeQueue deQueue,IAlarm alarm) 
        {
            analyselist = new List<double>();
            _sys = 0;
            _daqDTO = daqDTO;
            _dataReadyEvent = dataReadyEvent;
            _deQueue = deQueue;
            _deQueue.Attach(this);
            _alarm = alarm;
            sys = 0;
        }

        public void CalculateSys(List<double> dataList)
        {
            foreach (var value in dataList)
            {
                analyselist.Add(value);
            }
            if (analyselist.Count == 3 * _daqDTO.SampleRate)
            {
                _sys = Math.Round(analyselist.Max());
                _alarm.CheckAkutAlarm(_sys);
                _alarm.CheckSubakutAlarmSys(_sys);
                Notify();
                if (sys != _sys)
                {
                    //_alarm.CheckSubakutAlarmSys(_sys);
                    sys = _sys;
                }
                analyselist.RemoveRange(0,100);
            }
            

        }

        public void RunCalcSys() //GOF
        {
            while (!_stopThread)
            {
                _dataReadyEvent.WaitOne();
                List<double> list = _deQueue.GetRawDataFromDeQueue();
                CalculateSys(list);
            }

        }

        public double GetSys()
        {
            return _sys;
        }

        public void UpdateRawData()
        {
            _dataReadyEvent.Set();
        }

        public void stopThread(bool result)
        {
            _stopThread = result;
        }
    }
}
