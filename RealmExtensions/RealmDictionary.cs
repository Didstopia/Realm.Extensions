using System;
using System.Collections.Generic;
using Realms;

namespace Didstopia.RealmExtensions
{
    public class RealmDictionary<T1, T2> : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }

        // TODO: How do we store values/keys? Using a new type of RealmObject for each value/key type?

        [Ignored]
        Dictionary<T1, T2> _dictionary { get; set; }

        [MapTo("Keys")]
        IList<RealmExtensionsObject<T1>> _keys { get; set; }

        [MapTo("Values")]
        IList<RealmExtensionsObject<T2>> _values { get; set; }

        // TODO: Figure out how to do this, there's plenty of options:
        // - Should we go for some sort of factory methods?
        // - Should we just serialize everything to a byte array instead?
        // - Should we strictly implement classes for each type?
        // - Should we inherit from IDictionary and simply emulate a Dictionary?

        public RealmDictionary()
        {
            Id = Guid.NewGuid().ToString();
        }

        // TODO: Get rid of "Get()" and add middleware functions for Dictionary stuff instead?
        //       Perhaps by using IDictionary interface?

        public Dictionary<T1, T2> Get()
        {
            if (_dictionary == null)
                _dictionary = new Dictionary<T1, T2>();
            
            return _dictionary;
        }
    }
}
