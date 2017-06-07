using System;
using Realms;
using NUnit.Framework;

namespace Didstopia.RealmExtensions.Test
{
    public class TestBase
    {
        Realm _realm;

        [OneTimeSetUp]
        public virtual void OneTimeSetUpAttribute()
        {
            _realm = Realm.GetInstance();
            Assert.IsNotNull(_realm, "Realm was null before one time set up");
			_realm.Dispose();
			_realm = null;
			Assert.IsNull(_realm, "Realm was not null after one time set up");
        }

        [SetUp]
        public virtual void SetUp()
        {
            Console.WriteLine("SetUp()");

            Assert.IsNull(_realm, "Realm was not null before setting up");
            _realm = Realm.GetInstance();
            Assert.IsNotNull(_realm, "Realm was null after setting up");
        }

        [TearDown]
        public virtual void TearDown()
        {
            Console.WriteLine("TearDown()");

            Assert.IsNotNull(_realm, "Realm was null before tearing down");
            _realm.Dispose();
            _realm = null;
            Assert.IsNull(_realm, "Realm was not null after tearing down");
        }
    }
}
