using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Interfaces;

namespace OP_VitalsBL
{
    public class MeanFilter : MeanFilterSubject, DeQueueObserver //public tilføjet
    {
        private List<double> _displayList;
        private readonly AutoResetEvent _dataReadyEvent;
        private DeQueue _deQueue;
        private bool _stopThread;
        private FilterFactory _filterFactory;
        public MeanFilter(AutoResetEvent dataReadyEvent, DeQueue deQueue, FilterFactory filterFactory)
        {
            _displayList = new List<double>();
            _dataReadyEvent = dataReadyEvent;
            _stopThread = false;
            _deQueue = deQueue;
            _deQueue.Attach(this);
            _filterFactory = filterFactory;
        }


        private void SortList(List<double> listofdata)
        {

            for (int i = 0; i < listofdata.Count; i = i + 10)
            {
                double avg = (listofdata.GetRange(i, 10).Average());
                _displayList.Add(avg);

                if (_displayList.Count > 1000)
                {
                    _displayList.RemoveAt(0);
                }
            }

        }

        public List<double> GetDisplayList()
        {
            return _displayList;
        }

        public void UpdateRawData()
        {
            _dataReadyEvent.Set();
        }

        public void RunMeanFilter()
        {
            while (!_stopThread)
            {
                _dataReadyEvent.WaitOne();
                List<double> list = _deQueue.GetRawDataFromDeQueue();
                IFilter filter = _filterFactory.CreateFilter();
                SortList(filter.FilterData(list.ToArray()));
                Notify();
            }

        }

        public void stopThread(bool result)
        {
            _stopThread = result;
        }
    }
}
