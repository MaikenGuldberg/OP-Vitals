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
    class CalcDia : CalcDiaSubject, IDeQueueObserver, ICalcDia
    {
        private List<double> analyselist;
        private double _dia;
        private DAQSettingsDTO _daqDTO;
        private AutoResetEvent _dataReadyEvent;
        private DeQueue _deQueue;
        private bool _stopThread;

        public CalcDia(DAQSettingsDTO daqDTO, AutoResetEvent dataReadyEvent, DeQueue deQueue)
        {
            analyselist = new List<double>();
            _dia = 0;
            _daqDTO = daqDTO;
            _dataReadyEvent = dataReadyEvent;
            _deQueue = deQueue;
            _deQueue.Attach(this);
        }
        private void CalculateDia(List<double> dataList,DAQSettingsDTO DAQ)
        {
            for (int i = 0; i < dataList.Count; i++)
            {
                if (analyselist.Count < 3 * DAQ.SampleRate)
                {
                    analyselist.Add(dataList[i]);
                }
                if (analyselist.Count == 3 * DAQ.SampleRate)
                {
                    _dia = Math.Round(analyselist.Min());
                    analyselist.RemoveAt(0);
                }
            }
        }

        public double GetDia()
        {
            return _dia;
        }

        public void UpdateRawData()
        {
            _dataReadyEvent.Set();
        }

        public void RunCalcDia()
        {
            while (!_stopThread)
            {
                _dataReadyEvent.WaitOne();
                List<double> list = _deQueue.GetRawDataFromDeQueue();
                CalculateDia(list, _daqDTO);
                Notify();
            }
        }

        public void stopThread(bool result)
        {
            _stopThread = result;
        }
    }
}
