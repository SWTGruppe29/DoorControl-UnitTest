using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DoorControl;

namespace DoorControl.NSubstitute.Test
{
    [TestFixture]
    public class DoorControlDoorBreachedTests
    {
        private DoorControl _doorControl;
        private IUserValidation _userValidation;
        private IDoor _door;
        private IEntryNotification _entryNotification;
        private IAlarm _alarm;

        [SetUp]
        public void Setup()
        {
            //_mockFactory = new Substitute.For<MockDoorControlFactory>();
            //var _uut = new DoorControl(_mockFactory);
        }

        [Test]
        public void DoorBreached_DoorStateIsBreached()
        {

        }

            /*
                     private DoorControl _uut;
        private MockDoorControlFactory _mockFactory;

        [SetUp]
        public void Setup()
        {
            _mockFactory = new MockDoorControlFactory();
            _uut = new DoorControl(_mockFactory);
        }

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
