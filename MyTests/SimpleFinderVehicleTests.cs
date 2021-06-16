using Moq;
using NexHw.BLL.SimpleJobFinder;
using NexHw.DAL;
using NexHw.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTests
{
    [TestFixture]
    class SimpleFinderVehicleTests
    {
        [Test]
        public void OneType()
        {
            var originalVehicle = new Mock<IVehicle>();
            originalVehicle.Setup(v => v.ID).Returns(1);
            originalVehicle.Setup(v => v.JobTypes).Returns(new List<string> { "a" });

            var vehicle = new SimpelFinderVehicle(originalVehicle.Object);

            Assert.That(vehicle.ID,Is.EqualTo(originalVehicle.Object.ID));
            Assert.That(vehicle.JobTypes, Is.EquivalentTo(originalVehicle.Object.JobTypes));
        }

        [Test]
        public void MultipleType()
        {
            var originalVehicle = new Vehicle(1, new List<string> { "a", "b" });
            var vehicle = new SimpelFinderVehicle(originalVehicle);

            Assert.That(vehicle.ID, Is.EqualTo(originalVehicle.ID));
            Assert.That(vehicle.JobTypes, Is.EquivalentTo(originalVehicle.JobTypes));
            Assert.That(vehicle.Vehicle, Is.EqualTo(originalVehicle));
        }
        [Test]
        public void VehicleIsEqual()
        {
            var originalVehicle = new Vehicle(1, new List<string> { "a", "b" });
            var vehicle = new SimpelFinderVehicle(originalVehicle);
            Assert.That(vehicle.Vehicle, Is.EqualTo(originalVehicle));
        }

        [Test]
        public void TwoTypeHaseMoreTrue()
        {
            var originalVehicle = new Vehicle(1, new List<string> { "a", "b" });
            var vehicle = new SimpelFinderVehicle(originalVehicle);
            Assert.That(vehicle.HasMoreJobType, Is.True);
        }

        [Test]
        public void OneTypeHaseMoreTrue()
        {
            var originalVehicle = new Vehicle(1, new List<string> { "a" });
            var vehicle = new SimpelFinderVehicle(originalVehicle);
            Assert.That(vehicle.HasMoreJobType, Is.True);
        }

        [Test]
        public void LotOfTypeHaseMoreTrue()
        {
            var originalVehicle = new Vehicle(1, new List<string> { "a", "b", "c"  });
            var vehicle = new SimpelFinderVehicle(originalVehicle);
            var actualJobType = vehicle.ActualJobType;
            Assert.That(actualJobType, Is.EqualTo("a"));

            vehicle.NextJob();
            Assert.That(vehicle.HasMoreJobType, Is.True);
            actualJobType = vehicle.ActualJobType;
            Assert.That(actualJobType, Is.EqualTo("b"));

            vehicle.NextJob();
            Assert.That(vehicle.HasMoreJobType, Is.True);
            actualJobType = vehicle.ActualJobType;
            Assert.That(actualJobType, Is.EqualTo("c"));

            var result = vehicle.NextJob();
            actualJobType = vehicle.ActualJobType;
            Assert.That(actualJobType, Is.EqualTo("c"));
            Assert.That(result, Is.True);
            Assert.That(vehicle.HasMoreJobType, Is.False);
        }


    }
}
