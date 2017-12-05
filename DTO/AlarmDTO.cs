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
        public double HighestSys { get; set; }
        public double LowestSys { get; set; }
        //grænseværdier til diastolske blodtryk
        public double HighestDia { get; set; }
        public double LowestDia { get; set; }
        public bool AlarmState { get; set; }
        public int NormalSys { get; set; }
        public int NormalDia { get; set; }

        public AlarmDTO()
        {
            NormalSys = 120;
            NormalDia = 80;
            HighestDia = Convert.ToDouble(NormalDia)*1.15; 
            LowestDia = Convert.ToDouble(NormalDia)*0.85; 
            HighestSys = Convert.ToDouble(NormalSys)*1.15; 
            LowestSys = Convert.ToDouble(NormalSys)*0.85; 
        }

    }
}
