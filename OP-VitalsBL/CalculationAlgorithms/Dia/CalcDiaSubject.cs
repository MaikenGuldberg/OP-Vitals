using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace OP_VitalsBL
{
    public class CalcDiaSubject //public tilføjet
    {
        private List<ICalcDiaObserver> _observers = new List<ICalcDiaObserver>();

        public void Attach(ICalcDiaObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(ICalcDiaObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.UpdateDiaGUI();
            }
        }
    }
}
