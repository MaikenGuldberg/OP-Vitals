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
using OP_VitalsBL;

namespace OP_VitalsBL.Test.Unit
{
    [TestFixture]
    public class CalcMeanUnitTest
    {

        private CalcMeanBloodPressure uut;



        [Test]
        public void CalcMeanBloodPressure_DC0_MeanIs0()
        {
            DAQSettingsDTO daq = new DAQSettingsDTO();
            AutoResetEvent _autoresetevent = new AutoResetEvent(false);
            ConcurrentQueue<RawData> _dataQueues = new ConcurrentQueue<RawData>();
            DeQueue dequeue = new DeQueue(_dataQueues, daq);

            uut = new CalcMeanBloodPressure(daq, _autoresetevent, dequeue);

            List<double> data = Generate.Sinusoidal(3000, 1000, 3, 0, 0, 0, 0).ToList();

            uut.CalculateMean(data);

            Assert.That(uut.GetMeanBloodPressure(), Is.EqualTo(0));
        }
        [Test]
        public void CalcMeanBloodPressure_DC3_MeanIs3()
        {
            DAQSettingsDTO daq = new DAQSettingsDTO();
            AutoResetEvent _autoresetevent = new AutoResetEvent(false);
            ConcurrentQueue<RawData> _dataQueues = new ConcurrentQueue<RawData>();
            DeQueue dequeue = new DeQueue(_dataQueues, daq);

            uut = new CalcMeanBloodPressure(daq, _autoresetevent, dequeue);

            List<double> data = Generate.Sinusoidal(3000, 1000, 3, 0, 3, 0, 0).ToList();

            uut.CalculateMean(data);

            Assert.That(uut.GetMeanBloodPressure(), Is.EqualTo(3));
        }
    }


}
