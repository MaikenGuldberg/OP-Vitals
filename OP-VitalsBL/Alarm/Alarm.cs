﻿using System;
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
    public class Alarm: IAlarm
    {
        // vi åbner et objekt af AlarmDTO klassen for at kunne tilgå den
        private AlarmDTO dtoalarm = new AlarmDTO();
        // vi åbner et objekt af OperationDTO klassen for at kunne tilgå
        // de aktuelle diastolske og systolske værdier
        private OperationDTO _operationDTO;
        private double highest_dia;
        private double lowest_dia;
        private double highest_sys;
        private double lowest_sys;
        private bool SysCrossedTheLine;
        private bool DiaCrossedTheLine;
        private bool AlarmIsPlaying;
        private bool akutalarmplays;
        private bool _stopThread;
        private IAlarmPlayer _akutAlarmPlayer;
        private IAlarmPlayer _subakutAlarmPlayer;
        private List<double> listofsys;

        
        //connstructor
        public Alarm(AlarmDTO dtoalarm,IAlarmPlayer subakutalarmPlayer,IAlarmPlayer akutAlarmPlayer,OperationDTO operationDTO)
        {
            SysCrossedTheLine = false;
            DiaCrossedTheLine = false;
            AlarmIsPlaying = false;
            akutalarmplays = false;
            _stopThread = false;
            highest_dia = dtoalarm.HighestDia;
            lowest_dia = dtoalarm.LowestDia;
            highest_sys = dtoalarm.HighestSys;
            lowest_sys = dtoalarm.LowestSys;
            _akutAlarmPlayer = akutAlarmPlayer;
            _subakutAlarmPlayer = subakutalarmPlayer;
            listofsys = new List<double>();
            _operationDTO = operationDTO;
        }
        // alarmen kan ikke mutes men hvis blodtrykket normaliseres så slukkes alarmen automatisk
        public void CheckSubakutAlarmSys(double sys)
        {
            // hvis patientens diastolsk og systolsk værdier overskrider default grænseværdier
            if (sys < lowest_sys || sys > highest_sys )
            {
                //SysCrossedTheLine = true;
                if (SysCrossedTheLine == false & AlarmIsPlaying == false)
                {
                    _subakutAlarmPlayer.PlayAlarm();
                    SysCrossedTheLine = true;
                    AlarmIsPlaying = true;
                    _operationDTO.NumberOfAlarms_++;
                }
            }
            else if (sys > lowest_sys & sys < highest_sys)
            {
                if (SysCrossedTheLine = true & AlarmIsPlaying == true)
                {
                    SysCrossedTheLine = false;
                    _subakutAlarmPlayer.StopAlarm();
                    AlarmIsPlaying = false;
                }
            }
        }

        public void CheckSubakutAlarmDia(double dia)
        {
            // hvis patientens diastolsk og systolsk værdier overskrider default grænseværdier
            if (dia < lowest_dia || dia > highest_dia)
            {
                if (DiaCrossedTheLine == false & AlarmIsPlaying == false & akutalarmplays == false)
                {
                    DiaCrossedTheLine = true;
                    _subakutAlarmPlayer.PlayAlarm();
                    AlarmIsPlaying = true;
                    _operationDTO.NumberOfAlarms_++;
                }
            }
            else if (dia > lowest_dia & dia < highest_dia)
            {
                if (DiaCrossedTheLine == true & AlarmIsPlaying == true)
                {
                    DiaCrossedTheLine = false;
                    _subakutAlarmPlayer.StopAlarm();
                    AlarmIsPlaying = false;
                }
            }
        }

        public void ResetAlarm()
        {
            AlarmIsPlaying = false;
            SysCrossedTheLine = false;
            DiaCrossedTheLine = false;
            akutalarmplays = false;
        }

        public void CheckAkutAlarm(double sys)
        {
            listofsys.Add(sys);
            if (listofsys.Count == 100)
            {
                if (listofsys[99] <= (listofsys[0]*0.9))
                {
                    if (akutalarmplays == false)
                    {
                        if (AlarmIsPlaying == true)
                        {
                            _subakutAlarmPlayer.StopAlarm();
                        }
                        _akutAlarmPlayer.PlayAlarm();
                        akutalarmplays = true;
                        _operationDTO.NumberOfAlarms_++;
                    }
                }
                else
                {
                    if (akutalarmplays == true)
                    {
                        _akutAlarmPlayer.StopAlarm();
                        akutalarmplays = false;
                        AlarmIsPlaying = false;
                        DiaCrossedTheLine = false;
                        SysCrossedTheLine = false;
                    }
                }
                listofsys.Clear();
            }
        }
        

    }


}

