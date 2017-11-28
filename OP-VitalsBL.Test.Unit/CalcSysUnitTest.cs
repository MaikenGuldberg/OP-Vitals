using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using DTO;
using OP_VitalsBL;

namespace OP_VitalsBL.Test.Unit
{
    [TestFixture]
    public class CalcSysUnitTest
    {

        private CalcSys uut;

        [SetUp]
        public void Setup()
        {
            uut = new CalcSys();
        }

        [Test]

        public void CalculateSys_ninepointin_syshighestnumber()
        {
        
            DAQSettingsDTO DAQ = new DAQSettingsDTO();
       
            List<double> testanalyselist = new List<double>(){1,2,3,4,9,4,3,2,1};
            DAQ.SampleRate = 3;

            uut.CalculateSys(testanalyselist, DAQ);  
            
            Assert.That(uut.GetSys(),Is.EqualTo(9));
            

        }

        public void CalculateSys_noinput_sys0()
        {
            DAQSettingsDTO DAQ = new DAQSettingsDTO();
            List<double> test2analyselist = new List<double>() {};
            DAQ.SampleRate = 3;
            uut.CalculateSys(test2analyselist, DAQ);

            Assert.That(uut.GetSys(), Is.EqualTo(0));

        }
    }
}
