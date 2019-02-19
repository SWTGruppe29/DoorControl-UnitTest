using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace DoorControl.NSubstitute.Test
{
    class DoorControlEntryGrantedTests
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
            _userValidation.ValidateEntryRequest("TFJ").Returns(true);
        }

        [Test]
        public void RequestEntry_CorrectIDUsedForDbQuery()
        {
            _uut.RequestEntry("TFJ");
            _userValidation.Received(1).ValidateEntryRequest("TFJ");
        }

        [Test]
        public void RequestEntry_CardDbApprovesEntryRequest_DoorOpenCalled()
        {
            _uut.RequestEntry("TFJ");
            _door.Received(1).Open();
        }

        [Test]
        public void RequestEntry_CardDbApprovesEntryRequest_DoorCloseNotCalled()
        {
            _uut.RequestEntry("TFJ");
            _door.Received(0).Close();
        }

        [Test]
        public void RequestEntry_CardDbApprovedEntryRequest_BeeperMakeHappyNoiseCalled()
        {
            _uut.RequestEntry("TFJ");
            _entryNotification.Received(1).NotifyEntryGranted();
        }

        [Test]
        public void RequestEntry_CardDbApprovedEntryRequest_BeeperMakeUnHappyNoiseCalled()
        {
            _uut.RequestEntry("TFJ");
            _entryNotification.Received(0).NotifyEntryDenied();
        }

        [Test]
        public void RequestEntry_DoorOpened_DoorIsClosed()
        {
            _uut.RequestEntry("TFJ");
            _uut.DoorOpened();
            _door.Received(1).Close();
        }
    }
}
