using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using MathNet.Numerics;
using NUnit.Framework;

namespace OP_VitalsBL.Test.Unit
{
    [TestFixture]
    class AlarmUnitTest
    {
        private Alarm uut;
        private AlarmDTO alarmDto;
        private OperationDTO operationDto;
        private MuckAkutAlarmPlayer akutAlarmPlayer;
        private MuckSubAkutAlarmPlayer subAkutAlarmPlayer;
        [SetUp]
        public void Setup()
        {
            alarmDto = new AlarmDTO();
            operationDto = new OperationDTO();
            akutAlarmPlayer = new MuckAkutAlarmPlayer();
            subAkutAlarmPlayer = new MuckSubAkutAlarmPlayer();
            uut = new Alarm(alarmDto,subAkutAlarmPlayer,akutAlarmPlayer,operationDto);
        }

        [Test]

        public void CheckSubakutAlarmSys_SysIs138_AlarmDoNotSound()
        {
            uut.CheckSubakutAlarmSys(138);

            Assert.That(subAkutAlarmPlayer.PlayAlarmIsCalled,Is.EqualTo(false));
        }

        [Test]

        public void CheckSubakutAlarmSys_SysIs140_AlarmSounds()
        {
            uut.CheckSubakutAlarmSys(140);

            Assert.That(subAkutAlarmPlayer.PlayAlarmIsCalled,Is.EqualTo(true));
        }

        [Test]

        public void CheckSubakutAlarmSys_SysIs130_AlarmDoNotSound()
        {
            uut.CheckSubakutAlarmSys(130);

            Assert.That(subAkutAlarmPlayer.PlayAlarmIsCalled, Is.EqualTo(false));
        }

        [Test]

        public void CheckSubakutAlarmSys_SysIs102_AlarmDoNotSound()
        {
            uut.CheckSubakutAlarmSys(102);

            Assert.That(subAkutAlarmPlayer.PlayAlarmIsCalled, Is.EqualTo(false));
        }

        [Test]

        public void CheckSubakutAlarmSys_SysIs90_AlarmSound()
        {
            uut.CheckSubakutAlarmSys(90);

            Assert.That(subAkutAlarmPlayer.PlayAlarmIsCalled, Is.EqualTo(true));
        }

        
        [Test]
        public void CheckSubakutAlarmDia_DiaIs92_AlarmDoNotSound()
        {
            uut.CheckSubakutAlarmDia(92);

            Assert.That(subAkutAlarmPlayer.PlayAlarmIsCalled, Is.EqualTo(false));
        }

        [Test]
        public void CheckSubakutAlarmDia_DiaIs95_AlarmSound()
        {
            uut.CheckSubakutAlarmDia(95);

            Assert.That(subAkutAlarmPlayer.PlayAlarmIsCalled, Is.EqualTo(true));
        }

        [Test]
        public void CheckSubakutAlarmDia_DiaIs68_AlarmDoNotSound()
        {
            uut.CheckSubakutAlarmDia(68);

            Assert.That(subAkutAlarmPlayer.PlayAlarmIsCalled, Is.EqualTo(false));
        }

        [Test]

        public void CheckSubakutAlarmDia_DiaIs60_AlarmSound()
        {
            uut.CheckSubakutAlarmDia(60);

            Assert.That(subAkutAlarmPlayer.PlayAlarmIsCalled, Is.EqualTo(true));
        }

        [Test]
        public void CheckAkutAlarm_SysFallsWith10procent_AlarmSound()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i == 0)
                {
                    uut.CheckAkutAlarm(100);
                }
                else if (i == 99)
                {
                    uut.CheckAkutAlarm(90);
                }
                else
                {
                    uut.CheckAkutAlarm(i);
                }
            }

            Assert.That(akutAlarmPlayer.PlayAlarmIsCalled,Is.EqualTo(true));
        }

        [Test]
        public void CheckAkutAlarm_SysFallsWith15procent_AlarmSound()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i == 0)
                {
                    uut.CheckAkutAlarm(100);
                }
                else if (i == 99)
                {
                    uut.CheckAkutAlarm(85);
                }
                else
                {
                    uut.CheckAkutAlarm(i);
                }
            }

            Assert.That(akutAlarmPlayer.PlayAlarmIsCalled, Is.EqualTo(true));
        }

        [Test]
        public void CheckAkutAlarm_SysStayTheSame_AlarmDoNotSound()
        {
            for (int i = 0; i < 100; i++)
            {
                uut.CheckAkutAlarm(100);
            }

            Assert.That(akutAlarmPlayer.PlayAlarmIsCalled, Is.EqualTo(false));
        }

        [Test]
        public void CheckAkutAlarm_SysFallsWith5procent_AlarmDoNotSound()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i == 0)
                {
                    uut.CheckAkutAlarm(100);
                }
                else if (i == 99)
                {
                    uut.CheckAkutAlarm(95);
                }
                else
                {
                    uut.CheckAkutAlarm(i);
                }
            }

            Assert.That(akutAlarmPlayer.PlayAlarmIsCalled, Is.EqualTo(false));
        }

        [Test]
        public void CheckAkutAlarm_SysIncreases5procent_AlarmDoNotSound()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i == 0)
                {
                    uut.CheckAkutAlarm(100);
                }
                else if (i == 99)
                {
                    uut.CheckAkutAlarm(105);
                }
                else
                {
                    uut.CheckAkutAlarm(i);
                }
            }

            Assert.That(akutAlarmPlayer.PlayAlarmIsCalled, Is.EqualTo(false));
        }

    }
}
