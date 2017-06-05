using System;

namespace Didstopia.RealmExtensions.Tests
{
    using NUnit.Framework;
    using Realms;

    [TestFixture]
    public class Tests
    {
        Realm _realm;

        public Tests()
        {
            Console.WriteLine("Tests()");
        }

        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("SetUp()");

            Assert.IsNull(_realm, "Realm was not null before setting up");
            _realm = Realm.GetInstance();
            Assert.IsNotNull(_realm, "Realm was null after setting up");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TearDown()");

            Assert.IsNotNull(_realm, "Realm was null before tearing down");
            _realm.Dispose();
            _realm = null;
            Assert.IsNull(_realm, "Realm was not null after tearing down");
        }

        [Test]
        public void TestSomething()
        {
            Console.WriteLine("TestSomething()");
        }
    }
}
