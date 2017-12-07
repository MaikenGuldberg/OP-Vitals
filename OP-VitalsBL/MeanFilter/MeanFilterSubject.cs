using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace OP_VitalsBL
{
    public class MeanFilterSubject
    {
        private List<IMeanFilterObserver> _observers = new List<IMeanFilterObserver>();

        public void Attach(IMeanFilterObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IMeanFilterObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.UpdateMeanFilterGUI();
            }
        }
    }
}
