using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Media;

namespace OP_VitalsBL
{
    class AlarmPlayer : IAlarmPlayer
    {
        private SoundPlayer akutAlarmSound;
        private SoundPlayer subakutAlarmSound;

        public AlarmPlayer()
        {
            akutAlarmSound = new SoundPlayer(@"C:\Users\Maiken Guldberg\Documents\3. Semester\Semesterprojekt\OP-Vitals\highAlarm.wav");
            subakutAlarmSound = new SoundPlayer(@"C:\Users\Maiken Guldberg\Documents\3. Semester\Semesterprojekt\OP-Vitals\mediumAlarm.wav");
        }

        public void PlayAlarm(string type)
        {
            if (type == "Akut")
            {
                akutAlarmSound.PlayLooping();
            }
            else if (type == "SubAkut")
            {
                subakutAlarmSound.PlayLooping();
            }
        }

        public void StopAlarm(string type)
        {
            if (type == "Akut")
            {
                akutAlarmSound.Stop();
            }
            else if (type == "SubAkut")
            {
                subakutAlarmSound.Stop();
            }
        }
    }
}
