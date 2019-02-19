using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoorControl.Test.Unit.Mocks;
using NUnit.Framework;

namespace DoorControl.NSubstitute.Test
{
    [TestFixture]
    class DoorControlDeniedTests
    {
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

        }
    }
}
