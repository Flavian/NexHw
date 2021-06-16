using NexHw.BLL.SimpleJobFinder;
using NexHw.DAL;
using NexHw.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class FinderTests
    {
        [Test]
        public void FirstTest()
        {
            List<IVehicle> vehicles = new List<IVehicle>
            {
                new Vehicle(1, new List<string> { "A", "B" }),
                new Vehicle(2, new List<string> { "A" })
            };

            List<IJob> jobs = new List<IJob>
            {
                new Job(1,"A"),
                new Job(2,"B")
            };

            var finder = new SimpleJobFinderStrategy(vehicles, jobs);
            finder.Find();
            var results = finder.Result;

            

            Assert.That(results.Count, Is.EqualTo(2));
            Assert.That(results[0].ToString(), Is.EqualTo("1 2"));
            Assert.That(results[1].ToString(), Is.EqualTo("2 1"));


        }


    }
}
