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
        private bool SysCrossedTheLine;
        private bool DiaCrossedTheLine;
        private bool _stopThread;

        //constructorder definerer default værdier

        // find og åbn wav filer
        SoundPlayer akutAlarmSound = new SoundPlayer(@"C:\Users\Margarit\Desktop\Semesterprojekt 3\hihghAlarm.wav");
        SoundPlayer subakutAlarmSound = new SoundPlayer(@"C:\Users\Maiken Guldberg\Documents\3. Semester\Semesterprojekt\OP-Vitals\mediumAlarm.wav");

        

        //connstructor
        public Alarm(AlarmDTO dtoalarm)
        {
            SysCrossedTheLine = false;
            DiaCrossedTheLine = false;
            _stopThread = false;
            highest_dia = dtoalarm.HighestDia;
            lowest_dia = dtoalarm.LowestDia;
            highest_sys = dtoalarm.HighestSys;
            lowest_sys = dtoalarm.LowestSys;
            thresholdlowestsys = Convert.ToInt32(lowest_sys * 0.1);
            thresholdhighestsys = Convert.ToInt32(highest_sys * 0.1);
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

        public void CheckSubakutAlarmSys(double sys)
        {
            // hvis patientens diastolsk og systolsk værdier overskrider default grænseværdier
            if (sys < lowest_sys || sys > highest_sys)
            {
                //SysCrossedTheLine = true;
                if (SysCrossedTheLine == false)
                {
                    subakutAlarmSound.PlayLooping();
                    SysCrossedTheLine = true;
                }
            }
            else if (sys > lowest_sys & sys < highest_sys)
            {
                if (SysCrossedTheLine = true)
                {
                    SysCrossedTheLine = false;
                    subakutAlarmSound.Stop();
                }
            }
        }

        public void CheckSubakutAlarmDia(double dia)
        {
            // hvis patientens diastolsk og systolsk værdier overskrider default grænseværdier
            if (dia < lowest_dia || dia > highest_dia)
            {
                DiaCrossedTheLine = true;
                subakutAlarmSound.PlayLooping();
            }
            else if (dia > lowest_dia & dia < highest_dia)
            {
                DiaCrossedTheLine = false;
                subakutAlarmSound.Stop();
            }
        }

        //public void RunSubakutAlarm()
        //{
        //    while (!_stopThread)
        //    {
        //        if (SysCrossedTheLine = true)
        //        {
        //            subakutAlarmSound.PlayLooping();
        //        }
        //        else if (SysCrossedTheLine = false)
        //        {
        //            subakutAlarmSound.Stop();
        //        }
        //    }
        //}
        private bool IsTrueOrFalse(bool diaCrossedTheLine, bool sysCrossedTheLine)
        {
            if (diaCrossedTheLine == true || sysCrossedTheLine == true)
            {
                return true;
            }
            else if (diaCrossedTheLine == false & sysCrossedTheLine == false)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public void stopThread(bool result)
        {
            _stopThread = result;
        }

    }


}

