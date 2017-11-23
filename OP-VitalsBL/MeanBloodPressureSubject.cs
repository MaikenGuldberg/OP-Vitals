using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace OP_VitalsBL
{
    class MeanBloodPressureSubject
    {
        private List<ICalcMeanBloodPressureObserver> _observers = new List<ICalcMeanBloodPressureObserver>();

        public void Attach(ICalcMeanBloodPressureObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(ICalcMeanBloodPressureObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.UpdateMeanBloodPressureGUI();
            }
        }
    }
}
