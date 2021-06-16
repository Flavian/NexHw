using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class SimpleTest
    {
        [Test]
        public void FirstTest()
        {
            int i = 1;
            Assert.That(i=1, Is.True);
        }
    }
}
