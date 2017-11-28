using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OP_VitalsBL;
using DTO;

namespace OP_VitalsBL.Test.Unit
{ 

    [TestFixture]
    public class CalcDiaUnitTest
    {
        private CalcDia uut;

        [SetUp]
        public void Setup()
        {
            uut = new CalcDia();
        }

        [Test]
        public void CalculateDia_somepointsin_lowestnumbersys()
        {
            DAQSettingsDTO DAQ = new DAQSettingsDTO();

            List<double> testanalyselist = new List<double>() { 1, 2, 3, 4, 9, 4, 3, 2, 1 };
            DAQ.SampleRate = 3;

            uut.CalculateDia(testanalyselist, DAQ);

            Assert.That(uut.GetDia(), Is.EqualTo(9));

        }
        [Test]
        public void CalculateDia_noinput_dia0()
        {
            DAQSettingsDTO DAQ = new DAQSettingsDTO();
            List<double> test2analyselist = new List<double>() { };
            DAQ.SampleRate = 3;
            uut.CalculateDia(test2analyselist, DAQ);

            Assert.That(uut.GetDia(), Is.EqualTo(0));

        }
    }
}
