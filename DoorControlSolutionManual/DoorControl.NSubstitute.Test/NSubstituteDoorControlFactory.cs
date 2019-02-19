using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;

namespace DoorControl.NSubstitute.Test
{
    class NSubstituteDoorControlFactory : IDoorControlFactory
    {
        public IUserValidation UserValidation { get; set; }
        public IDoor Door { get; set; }
        public IEntryNotification EntryNotification { get; set; }
        public IAlarm Alarm { get; set; }

        public NSubstituteDoorControlFactory()
        {
            UserValidation = Substitute.For<IUserValidation>();
            Door = Substitute.For<IDoor>();
            EntryNotification = Substitute.For<IEntryNotification>();
            Alarm = Substitute.For<IAlarm>();
        }

        // From IDoorControlFactory
        public IUserValidation CreateUserValidation() { return UserValidation; }
        public IDoor CreateDoor() { return Door; }
        public IEntryNotification CreateEntryNotification() { return EntryNotification; }
        public IAlarm CreateAlarm() { return Alarm; }
    }
}
