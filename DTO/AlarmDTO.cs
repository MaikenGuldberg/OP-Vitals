using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AlarmDTO
    {
        //grænseværdier til systoliske blodtryk
        public int HighestSys { get; set; }
        public int LowestSys { get; set; }
        //grænseværdier til diastolske blodtryk
        public int HighestDia { get; set; }
        public int LowestDia { get; set; }
        public bool AlarmState { get; set; }

        public AlarmDTO()
        {
            HighestDia = 90;
            LowestDia = 70;
            HighestSys = 2;
            LowestSys = 1;
        }

    }
}
