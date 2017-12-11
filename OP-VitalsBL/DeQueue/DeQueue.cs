using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DTO;

namespace OP_VitalsBL
{
    public class DeQueue:DeQueueSubject
    {
        private readonly ConcurrentQueue<RawData> _rawDataQueue;
        private List<double> _listOfRawData;
        private bool _stopThread;
        private DAQSettingsDTO _daqSettingsDTO;
        private Converter _converter;
        public DeQueue(ConcurrentQueue<RawData> rawDataQueue, DAQSettingsDTO daqSettingsDTO)
        {
            _stopThread = false;
            _rawDataQueue = rawDataQueue;
            _listOfRawData = new List<double>();
            _daqSettingsDTO = daqSettingsDTO;
            _converter = new Converter(_daqSettingsDTO);

        }

        public void GetDataFromQue()
        {
            while (!_stopThread)
            {
                RawData data;
                while (!_rawDataQueue.TryDequeue(out data))
                {
                    Thread.Sleep(0);
                }
                _listOfRawData = _converter.Convert(data.GetRawData100());
                Notify();
            }

        }

        public List<double> GetRawDataFromDeQueue()
        {
            return _listOfRawData;
        }

        public void stopThread(bool result)
        {
            _stopThread = result;
        }

        
    }
}
