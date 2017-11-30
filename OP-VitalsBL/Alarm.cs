using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Media;
using System.Runtime.CompilerServices;
using System.Threading;
using Interfaces;

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
        private bool AlarmIsPlaying;
        private bool _stopThread;
        private IAlarmPlayer _alarmPlayer;

        
        //connstructor
        public Alarm(AlarmDTO dtoalarm,IAlarmPlayer alarmPlayer)
        {
            SysCrossedTheLine = false;
            DiaCrossedTheLine = false;
            AlarmIsPlaying = false;
            _stopThread = false;
            highest_dia = dtoalarm.HighestDia;
            lowest_dia = dtoalarm.LowestDia;
            highest_sys = dtoalarm.HighestSys;
            lowest_sys = dtoalarm.LowestSys;
            thresholdlowestsys = Convert.ToInt32(lowest_sys * 0.1);
            thresholdhighestsys = Convert.ToInt32(highest_sys * 0.1);
            _alarmPlayer = alarmPlayer;
        }
        // alarmen kan ikke mutes men hvis blodtrykket normaliseres så slukkes alarmen automatisk
        public void CheckSubakutAlarmSys(double sys)
        {
            // hvis patientens diastolsk og systolsk værdier overskrider default grænseværdier
            if (sys < lowest_sys || sys > highest_sys)
            {
                //SysCrossedTheLine = true;
                if (SysCrossedTheLine == false & AlarmIsPlaying == false)
                {
                    _alarmPlayer.PlayAlarm("SubAkut");
                    SysCrossedTheLine = true;
                    AlarmIsPlaying = true;
                }
            }
            else if (sys > lowest_sys & sys < highest_sys)
            {
                if (SysCrossedTheLine = true & AlarmIsPlaying == true)
                {
                    SysCrossedTheLine = false;
                    _alarmPlayer.StopAlarm("SubAkut");
                    AlarmIsPlaying = false;
                }
            }
        }

        public void CheckSubakutAlarmDia(double dia)
        {
            // hvis patientens diastolsk og systolsk værdier overskrider default grænseværdier
            if (dia < lowest_dia || dia > highest_dia)
            {
                if (DiaCrossedTheLine == false & AlarmIsPlaying == false)
                {
                    DiaCrossedTheLine = true;
                    _alarmPlayer.PlayAlarm("SubAkut");
                    AlarmIsPlaying = true;
                }
            }
            else if (dia > lowest_dia & dia < highest_dia)
            {
                if (DiaCrossedTheLine == true & AlarmIsPlaying == true)
                {
                    DiaCrossedTheLine = false;
                    _alarmPlayer.StopAlarm("SubAkut");
                    AlarmIsPlaying = false;
                }
            }
        }

        public void ResetAlarm()
        {
            AlarmIsPlaying = false;
            SysCrossedTheLine = false;
            DiaCrossedTheLine = false;
        }
        

        

    }


}

