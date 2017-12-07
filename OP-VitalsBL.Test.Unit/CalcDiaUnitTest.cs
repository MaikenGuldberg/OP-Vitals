using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OP_VitalsBL;
using DTO;
using MathNet.Numerics;

namespace OP_VitalsBL.Test.Unit
{ 

    [TestFixture]
    public class CalcDiaUnitTest
    {
        private CalcDia uut;

        [Test]
        public void CalculateDia_sinusWithAmplityde3_sysIsminus3()
        {
            DAQSettingsDTO daq = new DAQSettingsDTO();
            AutoResetEvent _autoresetevent = new AutoResetEvent(false);
            ConcurrentQueue<RawDataQueue> _dataQueues = new ConcurrentQueue<RawDataQueue>();
            DeQueue dequeue = new DeQueue(_dataQueues, daq);
            var alarm = new MuckAlarm();
            uut = new CalcDia(daq, _autoresetevent, dequeue, alarm);

            List<double> data = Generate.Sinusoidal(3000, 1000, 1, 3, 0, 0, 0).ToList();

            uut.CalculateDia(data);

            Assert.That(uut.GetDia(), Is.EqualTo(-3));
        }

        [Test]
        public void CalculateDia_sinusWithAmplityde5_diaIsminus5()
        {
            DAQSettingsDTO daq = new DAQSettingsDTO();
            AutoResetEvent _autoresetevent = new AutoResetEvent(false);
            ConcurrentQueue<RawDataQueue> _dataQueues = new ConcurrentQueue<RawDataQueue>();
            DeQueue dequeue = new DeQueue(_dataQueues, daq);
            var alarm = new MuckAlarm();
            uut = new CalcDia(daq, _autoresetevent, dequeue, alarm);

            List<double> data = Generate.Sinusoidal(3000, 1000, 1, -5, 0, 0, 0).ToList();

            uut.CalculateDia(data);

            Assert.That(uut.GetDia(), Is.EqualTo(-5));
        }
        [Test]
        public void CalculateDia_sinusWithAmplityde5og4_subakutalarmIsCalled()
        {
            DAQSettingsDTO daq = new DAQSettingsDTO();
            AutoResetEvent _autoresetevent = new AutoResetEvent(false);
            ConcurrentQueue<RawDataQueue> _dataQueues = new ConcurrentQueue<RawDataQueue>();
            DeQueue dequeue = new DeQueue(_dataQueues, daq);
            var alarm = new MuckAlarm();
            uut = new CalcDia(daq, _autoresetevent, dequeue, alarm);

            List<double> data1 = Generate.Sinusoidal(3000, 1000, 1, 5, 0, 0, 0).ToList();
            List<double> data2 = Generate.Sinusoidal(3000, 1000, 1, 4, 0, 0, 0).ToList();

            uut.CalculateDia(data1);
            uut.CalculateDia(data2);

            Assert.That(alarm.CheckSubakutAlarmDiaWasCalled, Is.EqualTo(true));
        }


    }
}
