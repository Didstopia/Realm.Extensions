using System;
using Realms;
using System.Linq;

namespace Didstopia.RealmExtensions.Tests
{
    public class DatabaseFixture : IDisposable
    {
        public Realm Realm => Realm.GetInstance();

        public DatabaseFixture()
        {
            // Create and prepare database
            //Realm = Realm.GetInstance();
        }

        public void Dispose()
        {
            // TODO: Rewrite at some point
            try
            {
                // Clean and dispose of database
                Realm.Write(() =>
                {
                    Realm.RemoveAll();
                });
                Realm.Dispose();
            } catch { }
        }

        public void Add(RealmObject realmObject, bool update = false)
        {
            Realm.Write(() =>
            {
                Realm.Add(realmObject, update);
            });
        }

        public void Remove(RealmObject realmObject)
        {
            Realm.Write(() =>
            {
                Realm.Remove(realmObject);
            });
        }
    }
}
