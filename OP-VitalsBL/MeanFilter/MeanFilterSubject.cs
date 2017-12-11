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
        private List<MeanFilterObserver> _observers = new List<MeanFilterObserver>();

        public void Attach(MeanFilterObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(MeanFilterObserver observer)
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
