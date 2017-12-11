using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace OP_VitalsBL
{
    public class DeQueueSubject // public tilføjet
    {
        private List<DeQueueObserver> _observers = new List<DeQueueObserver>();

        public void Attach(DeQueueObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(DeQueueObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.UpdateRawData();
            }
        }
    }
}
