using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IMeanFilterObserver
    {
        void UpdateMeanFilterGUI();
    }

    public interface IDeQueueObserver
    {
        void UpdateRawData();
    }

    public interface ICalcSysObserver
    {
        void UpdateSysGUI();
    }

    public interface ICalcDiaObserver
    {
        void UpdateDiaGUI();
    }

    public interface ICalcMeanBloodPressureObserver
    {
        void UpdateMeanBloodPressureGUI();
    }

    public interface ICalcPulsObserver
    {
        void UpdatePulsGUI();
    }
}
