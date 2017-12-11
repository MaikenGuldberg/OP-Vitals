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
        private List<CalcDiaObserver> _observers = new List<CalcDiaObserver>();

        public void Attach(CalcDiaObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(CalcDiaObserver observer)
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
