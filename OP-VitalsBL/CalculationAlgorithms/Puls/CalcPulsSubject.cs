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
        private List<CalcPulsObserver> _observers = new List<CalcPulsObserver>();

        public void Attach(CalcPulsObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(CalcPulsObserver observer)
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
