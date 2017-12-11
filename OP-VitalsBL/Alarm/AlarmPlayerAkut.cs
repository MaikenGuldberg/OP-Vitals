using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Media;

namespace OP_VitalsBL
{
    class AlarmPlayerAkut : IAlarmPlayer
    {
        private SoundPlayer akutAlarmSound;

        public AlarmPlayerAkut()
        {
            akutAlarmSound = new SoundPlayer(@"C:\Users\Maiken Guldberg\Documents\3. Semester\Semesterprojekt\OP-Vitals\highAlarm.wav");
        }

        public void PlayAlarm()
        {
           akutAlarmSound.PlayLooping();
        }

        public void StopAlarm()
        {
            akutAlarmSound.Stop();
        }
    }
}
