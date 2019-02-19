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
        private IDoorControlFactory _doorControlFactory;

        [SetUp]
        public void Setup()
        {
            _doorControlFactory = new NSubstituteDoorControlFactory();
            _uut = new DoorControl(_doorControlFactory);
        }

        [Test]
        public void DoorBreached_DoorStateIsBreached()
        {
            _uut.DoorOpened();
            Assert.That(_doorControlFactory.CreateAlarm().Equals(false));
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
