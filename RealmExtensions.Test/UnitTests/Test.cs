using System;
using NUnit.Framework;

namespace Didstopia.RealmExtensions.Test.UnitTests
{
    [TestFixture]
    public class Test : TestBase
    {
        public Test()
        {
            Console.WriteLine("Test()");
        }

        [Test]
        public void TestTrue()
        {
            Console.WriteLine("Test::TestTrue()");

            Assert.True(true);
        }

        [Test]
        public void TestFalse()
        {
            Console.WriteLine("Test::TestTrue()");

            Assert.True(false);
        }
    }
}
