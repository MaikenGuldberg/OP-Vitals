using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Media;
using System.Runtime.CompilerServices;
using System.Threading;

// uden reference til System.Media wav filen kan ikke afspilles så det er ret vigtigt

namespace OP_VitalsBL
{
     public class Alarm
    {
        // vi åbner et objekt af AlarmDTO klassen for at kunne tilgå den
        private AlarmDTO dtoalarm = new AlarmDTO();
        // vi åbner et objekt af OperationDTO klassen for at kunne tilgå
        // de aktuelle diastolske og systolske værdier
        private OperationDTO operation = new OperationDTO();
        private int highest_dia;
        private int lowest_dia;
        private int highest_sys;
        private int lowest_sys;

        private int thresholdlowestsys;
        private int thresholdhighestsys;
        
        //constructorder definerer default værdier
        public Alarm()
        {
            highest_dia = 90;
            lowest_dia = 70;
            highest_sys = 130;
            lowest_sys = 80;
            thresholdlowestsys = Convert.ToInt32(lowest_sys * 0.1);
            thresholdhighestsys = Convert.ToInt32(highest_sys * 0.1);
        }
        // find og åbn wav filer
        SoundPlayer akutAlarmSound = new SoundPlayer(@"C:\Users\Margarit\Desktop\Semesterprojekt 3\hihghAlarm.wav");
        SoundPlayer subakutAlarmSound = new SoundPlayer(@"C:\Users\Margarit\Desktop\Semesterprojekt 3\mediumAlarm.wav");


        //connstructor
        public Alarm (AlarmDTO dtoalarm)
        {
            highest_dia = dtoalarm.HighestDia;
            lowest_dia = dtoalarm.LowestDia;
            highest_sys = dtoalarm.HighestSys;
            lowest_sys = dtoalarm.LowestSys;
        }
        // alarmen kan ikke mutes men hvis blodtrykket normaliseres så slukkes alarmen automatisk
        public void StopAkutAlarm()
        {
            akutAlarmSound.Stop();
        }
        public void StopSubAkutAlarm()
        {
            subakutAlarmSound.Stop();
        }

        public void CheckAkutAlarm(OperationDTO operation)
        {

            //// 10% overskrider nederste systolsk grænseværdi
            //var changepercentlowest = ((lowest_sys - operation.Systole) / Math.Abs(operation.Systole)) * 100;
            //// 10 % overskrider øverste systolsk grænseværdi
            //var changepercenthighest = ((highest_sys - operation.Systole) / Math.Abs(operation.Systole)) * 100;
            //if (changepercentlowest > 10 || changepercenthighest > 10)
            //{
            //    // Playlooping metoden sørger for at lyden bliver afspilt kontinuerligt
            //    //ved hjælp af en tråde
            //    akutAlarmSound.PlayLooping();
            //}
            var changepercenthighestsys = operation.Systole - highest_sys;
            var changepercentlowestsys = operation.Systole - lowest_sys;
            if (changepercenthighestsys > thresholdhighestsys || changepercentlowestsys > thresholdlowestsys)
            {
                Task.Run(() =>
                {
                    while (true)
                    {
                        akutAlarmSound.Play();
                        Thread.Sleep(2500);
                    }
                });
            }
            else
            {
                akutAlarmSound.Stop();
            }
        }

        public void CheckSubakutAlarm(OperationDTO operation)
        {
            // hvis patientens diastolsk og systolsk værdier overskrider default grænseværdier
            if (operation.Diastole < lowest_dia || operation.Diastole > highest_dia || operation.Systole < lowest_sys || operation.Systole > highest_sys)
            {
                subakutAlarmSound.PlayLooping();
            }
            else if (operation.Diastole > lowest_dia & operation.Diastole < highest_dia & operation.Systole > lowest_sys & operation.Systole < highest_sys)
            {
                StopSubAkutAlarm();
            }
        }

       
}

    }

