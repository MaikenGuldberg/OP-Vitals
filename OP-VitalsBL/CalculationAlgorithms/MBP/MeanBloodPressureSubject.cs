using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace OP_VitalsBL
{
    public class MeanBloodPressureSubject // public tilføjet
    {
        private List<CalcMeanBloodPressureObserver> _observers = new List<CalcMeanBloodPressureObserver>();

        public void Attach(CalcMeanBloodPressureObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(CalcMeanBloodPressureObserver observer)
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
