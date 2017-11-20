using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DTO;
using OP_VitalsBL;

namespace OP_VitalsBL.Test.Unit
{
    [TestFixture]
    class CalcSysUnitTest
    {
        [Test]

        public void CalculateSys_ninepointin_Result9()
        {
            var uut = new CalcSys();
            DAQSettingsDTO DAQ = new DAQSettingsDTO();
            BloodpreasureDTO bloodpreasure = new BloodpreasureDTO();
            List<double> listOfTestValues = new List<double>(){1,2,3,4,9,4,3,2,1};
            DAQ.SampleRate = 3;

            uut.CalculateSys(listOfTestValues,bloodpreasure,DAQ);  
            
            Assert.That(bloodpreasure.Systole,Is.EqualTo(9));
            

        }
    }
}
