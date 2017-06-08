﻿using System;
using Realms;
using Didstopia.RealmExtensions;

namespace Didstopia.RealmExtensions.Test
{
    public class RealmFixture : IDisposable
    {
        public Realm RealmDatabase { get; private set; }

        public RealmFixture()
        {
            Console.WriteLine("RealmFixture(): Creating RealmDatabase");

            System.Environment.SetEnvironmentVariable("OSVersion", "");

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
                RealmDatabase = Realm.GetInstance(config);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error initializing Realm: " + e.Message);
                throw;
            }
        }

        public void Dispose()
        {
            Console.WriteLine("RealmFixture(): Flushing and disposing RealmDatabase");
            //RealmDatabase.RemoveAll();
            //RealmDatabase.Dispose();
            //RealmDatabase = null;
        }
    }
}
