using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using NUnit.Framework;

namespace OP_VitalsBL.Test.Unit
{
    [TestFixture]
    class ConverterUnitTest
    {
        private Converter uut;
        private DAQSettingsDTO _daqSettingsDto;
        [SetUp]
        public void Setup()
        {
            _daqSettingsDto = new DAQSettingsDTO();
            uut = new Converter(_daqSettingsDto);
        }

        [Test]

        public void Convert_Value2_ConvertsTo2000()
        {
            _daqSettingsDto.ConversionConstant_ = 2;
            _daqSettingsDto.ZeroPoint_ = 1000;
            double[] data = new[] {2.0};
            List<double> list = uut.Convert(data);

            Assert.That(list[0],Is.EqualTo(2000));
        }

    }
}
