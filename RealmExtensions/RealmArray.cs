using System;
using Realms;

namespace Didstopia.RealmExtensions
{
    public class RealmArray<T> : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }

        T[] _array;

        public RealmArray()
        {
            Id = Guid.NewGuid().ToString();
        }

        public T[] Get()
        {
            if (_array == null)
                _array = new T[] { };

            return _array;
        }
    }
}
