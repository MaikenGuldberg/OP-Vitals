using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using DTO;

namespace OP_VitalsBL.Test.Unit
{
    public class MuckRsquaredCalculator : iRsquaredCalculator
    {
        public bool LinearRegressionCalcCalled { get; set; }

        public MuckRsquaredCalculator()
        {
            LinearRegressionCalcCalled = false;
        }
        public void LinearRegressionCalc(double[] xVals, double[] yVals, int inclusiveStart, int exclusiveEnd, out double rsquared, out double yintercept, out double slope)
        {
            LinearRegressionCalcCalled = true;
            rsquared = 0;
            yintercept = 0;
            slope = 0;
        }
    }

    public class MuckAlarm : IAlarm
    {
        public bool CheckAkutAlarmWasCalled { get; set; }
        public bool CheckSubakutAlarmDiaWasCalled { get; set; }
        public bool CheckSubakutAlarmSysWasCalled { get; set; }

        public MuckAlarm()
        {
            CheckAkutAlarmWasCalled = false;
            CheckSubakutAlarmDiaWasCalled = false;
            CheckSubakutAlarmSysWasCalled = false;
        }
        public void CheckAkutAlarm(double sys)
        {
            CheckAkutAlarmWasCalled = true;
        }

        public void CheckSubakutAlarmDia(double dia)
        {
            CheckSubakutAlarmDiaWasCalled = true;
        }

        public void CheckSubakutAlarmSys(double sys)
        {
            CheckSubakutAlarmSysWasCalled = true;
        }
    }

    public class MuckSubAkutAlarmPlayer : IAlarmPlayer
    {
        public bool PlayAlarmIsCalled { get; set; }
        public bool StopAlarmIsCalled { get; set; }

        public MuckSubAkutAlarmPlayer()
        {
            PlayAlarmIsCalled = false;
            StopAlarmIsCalled = false;
        }
        public void PlayAlarm()
        {
            PlayAlarmIsCalled = true;
        }

        public void StopAlarm()
        {
            StopAlarmIsCalled = true;
        }
    }

    public class MuckAkutAlarmPlayer : IAlarmPlayer
    {
        public bool PlayAlarmIsCalled { get; set; }
        public bool StopAlarmIsCalled { get; set; }

        public MuckAkutAlarmPlayer()
        {
            PlayAlarmIsCalled = false;
            StopAlarmIsCalled = false;
        }
        public void PlayAlarm()
        {
            PlayAlarmIsCalled = true;
        }

        public void StopAlarm()
        {
            StopAlarmIsCalled = true;
        }
    }
}
