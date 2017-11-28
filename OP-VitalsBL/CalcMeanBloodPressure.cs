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
    public class CalcMeanBloodPressure:MeanBloodPressureSubject,IDeQueueObserver //public tilføjet
    {

        private List<double> analyselist;
        private double _meanBloodPressure;
        private DAQSettingsDTO _daqDTO;
        private bool _stopThread;
        private readonly AutoResetEvent _dataReadyEvent;
        private DeQueue _deQueue;

        public CalcMeanBloodPressure(DAQSettingsDTO daqDTO,AutoResetEvent dataReadyEvent,DeQueue deQueue)
        {
            _dataReadyEvent = dataReadyEvent;
            _meanBloodPressure = 0;
            analyselist = new List<double>();
            _daqDTO = daqDTO;
            _deQueue = deQueue;
            _deQueue.Attach(this);
        }
        public void CalculateMean(List<double> dataList)
        {
            foreach (var value in dataList)
            {
                analyselist.Add(value);
            }
            if (analyselist.Count == 3 * _daqDTO.SampleRate)
            {
                _meanBloodPressure = Math.Round(analyselist.Average());
                Notify();
                analyselist.RemoveRange(0,100);
            }
            
        }

        public void RunCalcMeanBloodPressure()
        {
            while (!_stopThread)
            {
                _dataReadyEvent.WaitOne();
                List<double> list = _deQueue.GetRawDataFromDeQueue();
                CalculateMean(list);
            }
        }
        public double GetMeanBloodPressure()
        {
            return _meanBloodPressure;
        }

        public void UpdateRawData()
        {
            _dataReadyEvent.Set();
        }

        public void StopThread(bool result)
        {
            _stopThread = result;
        }
    }
}
