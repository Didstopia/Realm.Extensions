using System;
using NUnit.Framework;
using Realms;

namespace Didstopia.RealmExtensions.Test.UnitTests
{
    public class TestBase
    {
        public TestBase()
        {
            Console.WriteLine("TestBase()");
        }

        [SetUp]
        public virtual void SetUp()
        {
            Console.WriteLine("TestBase::SetUp()");

            var config = new RealmConfiguration("Didstopia.RealmExtensions.Test.realm");

            //config.ObjectClasses = new[] { typeof(RealmDictionary), typeof(RealmArray) };

            try
            {
                Realm.DeleteRealm(config);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error removing previous Realm: " + e.Message);
                throw;
            }

            try
            {
                var realm = Realm.GetInstance(config);
                Assert.IsNotNull(realm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error initializing Realm: " + e.Message);
                throw;
            }
        }

        [TearDown]
        public virtual void TearDown()
        {
            Console.WriteLine("TestBase::TearDown()");
        }
    }
}
