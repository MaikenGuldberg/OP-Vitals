using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace OP_VitalsBL
{
    class AlarmPlayerSubakut : IAlarmPlayer
    {
        private SoundPlayer subakutAlarmSound;

        public AlarmPlayerSubakut()
        {
            subakutAlarmSound = new SoundPlayer(@"C:\Users\Maiken Guldberg\Documents\3. Semester\Semesterprojekt\OP-Vitals\mediumAlarm.wav");
        }

        public void PlayAlarm()
        {
            subakutAlarmSound.PlayLooping();
        }

        public void StopAlarm()
        {
            subakutAlarmSound.Stop();
        }
    }
}
