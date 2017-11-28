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
    public class CalcDia : CalcDiaSubject, IDeQueueObserver, ICalcDia // public tilføjet
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
        public void CalculateDia(List<double> dataList)
        {
            foreach (var value in dataList)
            {
                analyselist.Add(value);
            }
            if (analyselist.Count == 3 * _daqDTO.SampleRate)
            {
                _dia = Math.Round(analyselist.Min());
                Notify();
                analyselist.RemoveRange(0,100);
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
                CalculateDia(list);
            }
        }

        public void stopThread(bool result)
        {
            _stopThread = result;
        }
    }
}
