using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace OP_VitalsBL
{
    public class CalcSysSubject // public tilføjet
    {
        private List<CalcSysObserver> _observers = new List<CalcSysObserver>();

        public void Attach(CalcSysObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(CalcSysObserver observer)
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
