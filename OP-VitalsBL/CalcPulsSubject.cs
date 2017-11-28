using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace OP_VitalsBL
{
    public class CalcPulsSubject
    {
        private List<ICalcPulsObserver> _observers = new List<ICalcPulsObserver>();

        public void Attach(ICalcPulsObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(ICalcPulsObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.UpdatePulsGUI();
            }
        }
    }
}
