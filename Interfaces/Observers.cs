using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface MeanFilterObserver
    {
        void UpdateMeanFilterGUI();
    }

    public interface DeQueueObserver
    {
        void UpdateRawData();
    }

    public interface CalcSysObserver
    {
        void UpdateSysGUI();
    }

    public interface CalcDiaObserver
    {
        void UpdateDiaGUI();
    }

    public interface CalcMeanBloodPressureObserver
    {
        void UpdateMeanBloodPressureGUI();
    }

    public interface CalcPulsObserver
    {
        void UpdatePulsGUI();
    }
}
