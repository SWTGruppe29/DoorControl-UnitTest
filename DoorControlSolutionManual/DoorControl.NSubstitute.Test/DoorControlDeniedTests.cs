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

        }
    }
}
