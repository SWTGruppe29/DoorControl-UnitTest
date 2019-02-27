using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DoorControl;
using NSubstitute;

namespace DoorControl.NSubstitute.Test
{
    [TestFixture]
    public class DoorControlDoorBreachedTests
    {
        private DoorControl _uut;
        private IDoor _door;
        private IAlarm _alarm;
        private IUserValidation _userValidation;
        private IEntryNotification _entryNotification;


        [SetUp]
        public void Setup()
        {
            _alarm = Substitute.For<IAlarm>();
            _door = Substitute.For<IDoor>();
            _userValidation = Substitute.For<IUserValidation>();
            _entryNotification = Substitute.For<IEntryNotification>();
            _uut = new DoorControl(_userValidation, _door, _entryNotification, _alarm);
        }

        [Test]
        public void DoorBreached_DoorStateIsBreached()
        {
            _uut.DoorOpened();
            _alarm.Received(1).SoundAlarm();
        }
/*

        [Test]
        public void DoorBreached_DoorStateIsBreached()
        {
            _uut.DoorOpened();  // Breach door
            Assert.That(_mockFactory.Alarm.WasAlarmCalled, Is.True);
        }
    }
             */
    }
}
