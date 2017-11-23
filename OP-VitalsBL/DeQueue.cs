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
    class DeQueue:DeQueueSubject
    {
        private readonly ConcurrentQueue<RawDataQueue> _rawDataQueue;
        private List<double> _listOfRawData;
        private bool _stopThread;
        public DeQueue(ConcurrentQueue<RawDataQueue> rawDataQueue)
        {
            _stopThread = false;
            _rawDataQueue = rawDataQueue;
            _listOfRawData = new List<double>();

        }

        public void GetDataFromQue()
        {
            while (!_stopThread)
            {
                RawDataQueue dataQueue;
                while (!_rawDataQueue.TryDequeue(out dataQueue))
                {
                    Thread.Sleep(0);
                }
                _listOfRawData = dataQueue.GetRawData100().ToList();
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
