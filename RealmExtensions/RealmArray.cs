using System;
using Realms;

namespace Didstopia.RealmExtensions
{
    public class RealmArray<T> : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }

        public RealmArray()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
