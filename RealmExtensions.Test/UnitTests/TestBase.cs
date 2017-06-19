using System;
using NUnit.Framework;
using Realms;

namespace Didstopia.RealmExtensions.Test.UnitTests
{
    public class TestBase
    {
        protected Realm Realm;

        public TestBase()
        {
            Console.WriteLine("TestBase()");
        }

        [SetUp]
        public virtual void SetUp()
        {
            Console.WriteLine("TestBase::SetUp()");

            var config = new RealmConfiguration($"{GetType().Name}.realm");
            Console.WriteLine("Realm location: " + config.DatabasePath);

            //config.ObjectClasses = new[] { typeof(RealmDictionary), typeof(RealmArray) };

            // TODO: Not sure if this makes sense as it is right now,
            //       maybe we can use this when running tests in "production", but not when debugging?

            /*try
            {
                Console.WriteLine("Removing previous Realm instance");
                Realm.DeleteRealm(config);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error removing previous Realm: " + e.Message);
                throw;
            }*/

            try
            {
                Console.WriteLine("Creating a new Realm instance");
                Realm = Realm.GetInstance(config);
                Assert.IsNotNull(Realm, "Expected Realm to not be null");
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
