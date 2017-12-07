using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IAlarmPlayer
    {
        void PlayAlarm(string type);
        void StopAlarm(string type);
    }
}
