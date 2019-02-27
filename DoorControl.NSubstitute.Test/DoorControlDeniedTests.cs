using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace DoorControl.NSubstitute.Test
{
    [TestFixture]
    class DoorControlDeniedTests
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
            _uut = new DoorControl(_userValidation,_door,_entryNotification,_alarm);
        }

        [Test]
        public void RequestEntry_CardDbDeniesEntryRequest_DoorNotOpened()
        {
            _userValidation.ValidateEntryRequest("TFJ").Returns(false);
            _uut.RequestEntry("TFJ");
            _door.Received(0).Open();
        }
        [Test]
        public void RequestEntry_CardDbDeniesEntryRequest_NotifyEntryDeniedCalled()
        {
            _userValidation.ValidateEntryRequest("TFJ").Returns(false);
            _uut.RequestEntry("TFJ");
            _entryNotification.Received(1).NotifyEntryDenied();
        }
        [Test]
        public void RequestEntry_CardDbDeniesEntryRequest_NotifyEntryNotCalled()
        {
            _userValidation.ValidateEntryRequest("TFJ").Returns(false);
            _uut.RequestEntry("TFJ");
            _entryNotification.Received(0).NotifyEntryGranted();
        }
        [Test]
        public void RequestEntry_CardDbDeniesEntryRequest_AlarmNotCalled()
        {
            _userValidation.ValidateEntryRequest("TFJ").Returns(false);
            _uut.RequestEntry("TFJ");
            _alarm.Received(0).SoundAlarm();
        }

        [Test]
        public void RequestEntry_CardDbDeniesEntryRequest_BeeperMakeHappyNoiseNotCalled()
        {
            _userValidation.ValidateEntryRequest("TFJ").Returns(false);
            _uut.RequestEntry("TFJ");
            _entryNotification.Received(0).NotifyEntryGranted();
        }
    }
}
