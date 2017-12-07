using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DTO;
using OP_VitalsDAL;

namespace OP_VitalsDAL.Test.Unit
{
    [TestFixture]
    public class ClinicalDatabaseUnitTest
    {
        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void SaveMeasurement_InsertEmployee_AddEmployeeWasCalled()
        {
            var parameterBuilder = new MuckParameterBuilder();
            var uut = new ClinicalDatabase(parameterBuilder);
            EmployeeDTO employee = new EmployeeDTO();
            OperationDTO operation = new OperationDTO();
            PatientDTO patient = new PatientDTO();
            DAQSettingsDTO daq = new DAQSettingsDTO();
            BPDataSequenceDTO bpDataSequence = new BPDataSequenceDTO();
            TransdusorDTO transdusor = new TransdusorDTO();
            string pathcomment = "";
            string pathoperation = "";

            uut.SaveMeasurement(employee, operation, patient, daq, bpDataSequence, transdusor, pathcomment,
                pathoperation);

            Assert.That(parameterBuilder.WasAddEmployeeCalled,Is.EqualTo(true));
        }
    }
}
