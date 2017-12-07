using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IAlarm
    {
        void CheckSubakutAlarmSys(double sys);
        void CheckSubakutAlarmDia(double dia);
        void CheckAkutAlarm(double sys);




    }
}
