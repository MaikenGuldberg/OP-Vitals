using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace OP_VitalsBL
{
    class CalcSysSubject
    {
        private List<ICalcSysObserver> _observers = new List<ICalcSysObserver>();

        public void Attach(ICalcSysObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(ICalcSysObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.UpdateSysGUI();
            }
        }
    }
}
