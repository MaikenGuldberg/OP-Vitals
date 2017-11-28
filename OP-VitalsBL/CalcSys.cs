using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DTO;
using Interfaces;

namespace OP_VitalsBL
{
    class CalcSys : CalcSysSubject, ICalcSys, IDeQueueObserver
    {
        private List<double> analyselist;
        private double _sys;
        private DAQSettingsDTO _daqDTO;
        private readonly AutoResetEvent _dataReadyEvent;
        private bool _stopThread;
        private DeQueue _deQueue;

        public CalcSys(DAQSettingsDTO daqDTO,AutoResetEvent dataReadyEvent, DeQueue deQueue)
        {
            analyselist = new List<double>();
            _sys = 0;
            _daqDTO = daqDTO;
            _dataReadyEvent = dataReadyEvent;
            _deQueue = deQueue;
            _deQueue.Attach(this);
        }
        private void CalculateSys(List<double> dataList,DAQSettingsDTO DAQ)
        {
            foreach (var value in dataList)
            {
                analyselist.Add(value);
            }
            if (analyselist.Count == 3 * DAQ.SampleRate)
            {
                _sys = Math.Round(analyselist.Max());
                Notify();
                analyselist.RemoveRange(0,100);
            }

        }

        public void RunCalcSys()
        {
            while (!_stopThread)
            {
                _dataReadyEvent.WaitOne();
                List<double> list = _deQueue.GetRawDataFromDeQueue();
                CalculateSys(list,_daqDTO);
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
