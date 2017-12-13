using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DTO;
using MathNet.Numerics;
using NUnit.Framework;

namespace OP_VitalsBL.Test.Unit
{
    [TestFixture]
    class CalcPulsUnitTest
    {
        private CalcPuls uut;
        [Test]

        public void CalculatePuls_SinusSignal1Hz_Puls60()
        {
            DAQSettingsDTO _daqSettings = new DAQSettingsDTO();
            AutoResetEvent _autoresetevent = new AutoResetEvent(false);
            ConcurrentQueue<RawData> _dataQueues = new ConcurrentQueue<RawData>();
            DeQueue dequeue = new DeQueue(_dataQueues, _daqSettings);
            uut = new CalcPuls(_daqSettings,_autoresetevent,dequeue);

            List<double> data = Generate.Sinusoidal(6000, 1000, 1, 2, 1, 0, 0).ToList();

            uut.CalculatePuls(data);

            Assert.That(uut.GetPuls(),Is.EqualTo(60));
        }

        [Test]

        public void CalculatePuls_SinusSignal2Hz_Puls120()
        {
            DAQSettingsDTO _daqSettings = new DAQSettingsDTO();
            AutoResetEvent _autoresetevent = new AutoResetEvent(false);
            ConcurrentQueue<RawData> _dataQueues = new ConcurrentQueue<RawData>();
            DeQueue dequeue = new DeQueue(_dataQueues, _daqSettings);
            uut = new CalcPuls(_daqSettings, _autoresetevent, dequeue);

            List<double> data = Generate.Sinusoidal(6000, 1000, 2, 2, 1, 0, 0).ToList();

            uut.CalculatePuls(data);

            Assert.That(uut.GetPuls(), Is.EqualTo(120));
        }

        [Test]

        public void CalculatePuls_SinusSignal0point33Hz_Puls20()
        {
            DAQSettingsDTO _daqSettings = new DAQSettingsDTO();
            AutoResetEvent _autoresetevent = new AutoResetEvent(false);
            ConcurrentQueue<RawData> _dataQueues = new ConcurrentQueue<RawData>();
            DeQueue dequeue = new DeQueue(_dataQueues, _daqSettings);
            uut = new CalcPuls(_daqSettings, _autoresetevent, dequeue);

            List<double> data = Generate.Sinusoidal(6000, 1000, 0.33, 2, 1, 0, 0).ToList();

            uut.CalculatePuls(data);

            Assert.That(uut.GetPuls(), Is.EqualTo(20));
        }

        [Test]

        public void CalculatePuls_SinusSignal0point25Hz_Puls15()
        {
            DAQSettingsDTO _daqSettings = new DAQSettingsDTO();
            AutoResetEvent _autoresetevent = new AutoResetEvent(false);
            ConcurrentQueue<RawData> _dataQueues = new ConcurrentQueue<RawData>();
            DeQueue dequeue = new DeQueue(_dataQueues, _daqSettings);
            uut = new CalcPuls(_daqSettings, _autoresetevent, dequeue);

            List<double> data = Generate.Sinusoidal(6000, 1000, 0.25, 2, 1, 0, 0).ToList();

            uut.CalculatePuls(data);

            Assert.That(uut.GetPuls(), Is.GreaterThanOrEqualTo(20));
        }

        [Test]

        public void CalculatePuls_SinusSignal4point166Hz_Puls250()
        {
            DAQSettingsDTO _daqSettings = new DAQSettingsDTO();
            AutoResetEvent _autoresetevent = new AutoResetEvent(false);
            ConcurrentQueue<RawData> _dataQueues = new ConcurrentQueue<RawData>();
            DeQueue dequeue = new DeQueue(_dataQueues, _daqSettings);
            uut = new CalcPuls(_daqSettings, _autoresetevent, dequeue);

            List<double> data = Generate.Sinusoidal(6000, 1000, 4.166, 2, 1, 0, 0).ToList();

            uut.CalculatePuls(data);

            Assert.That(uut.GetPuls(), Is.EqualTo(250));
        }
    }
}
