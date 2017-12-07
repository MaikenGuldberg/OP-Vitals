using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using DTO;
using Interfaces;
using OP_VitalsBL;
using MathNet.Numerics;

namespace OP_VitalsBL.Test.Unit
{
    [TestFixture]
    public class CalcSysUnitTest
    {
        private CalcSys uut;
        
        [SetUp]
        public void Setup()
        {
        
        }

        [Test]
        public void CalculateSys_sinusWithAmplityde3_sysIs3()
        {
            DAQSettingsDTO daq = new DAQSettingsDTO();
            AutoResetEvent _autoresetevent = new AutoResetEvent(false);
            ConcurrentQueue<RawDataQueue> _dataQueues = new ConcurrentQueue<RawDataQueue>();
            DeQueue dequeue = new DeQueue(_dataQueues, daq);
            var alarm = new MuckAlarm();
            uut = new CalcSys(daq, _autoresetevent, dequeue, alarm);

            List<double> data = Generate.Sinusoidal(3000, 1000, 1, 3, 0, 0, 0).ToList();

            uut.CalculateSys(data);

            Assert.That(uut.GetSys(),Is.EqualTo(3));
        }

        [Test]
        public void CalculateSys_sinusWithAmplityde5_sysIs5()
        {
            DAQSettingsDTO daq = new DAQSettingsDTO();
            AutoResetEvent _autoresetevent = new AutoResetEvent(false);
            ConcurrentQueue<RawDataQueue> _dataQueues = new ConcurrentQueue<RawDataQueue>();
            DeQueue dequeue = new DeQueue(_dataQueues, daq);
            var alarm = new MuckAlarm();
            uut = new CalcSys(daq, _autoresetevent, dequeue, alarm);

            List<double> data = Generate.Sinusoidal(3000, 1000, 1, 5, 0, 0, 0).ToList();

            uut.CalculateSys(data);

            Assert.That(uut.GetSys(), Is.EqualTo(5));
        }

        [Test]
        public void CalculateSys_sinusWithAmplityde5_akutalarmIsCalled()
        {
            DAQSettingsDTO daq = new DAQSettingsDTO();
            AutoResetEvent _autoresetevent = new AutoResetEvent(false);
            ConcurrentQueue<RawDataQueue> _dataQueues = new ConcurrentQueue<RawDataQueue>();
            DeQueue dequeue = new DeQueue(_dataQueues, daq);
            var alarm = new MuckAlarm();
            uut = new CalcSys(daq, _autoresetevent, dequeue, alarm);

            List<double> data = Generate.Sinusoidal(3000, 1000, 1, 5, 0, 0, 0).ToList();

            uut.CalculateSys(data);
            
            Assert.That(alarm.CheckAkutAlarmWasCalled,Is.EqualTo(true));
        }
        [Test]
        public void CalculateSys_sinusWithAmplityde3and4_SubAkutIsCalled()
        {
            DAQSettingsDTO daq = new DAQSettingsDTO();
            AutoResetEvent _autoresetevent = new AutoResetEvent(false);
            ConcurrentQueue<RawDataQueue> _dataQueues = new ConcurrentQueue<RawDataQueue>();
            DeQueue dequeue = new DeQueue(_dataQueues, daq);
            var alarm = new MuckAlarm();
            uut = new CalcSys(daq, _autoresetevent, dequeue, alarm);

            List<double> data = Generate.Sinusoidal(3000, 1000, 1, 3, 0, 0, 0).ToList();
            List<double> data2 = Generate.Sinusoidal(3000, 1000, 1, 4, 0, 0, 0).ToList();

            uut.CalculateSys(data);
            uut.CalculateSys(data2);

            Assert.That(alarm.CheckSubakutAlarmSysWasCalled, Is.EqualTo(true));
        }
    }
}
