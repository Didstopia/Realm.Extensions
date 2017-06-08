using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Realms;

namespace Didstopia.RealmExtensions
{
    public class RealmList<T> : RealmObject, IList
    {
        [PrimaryKey]
        public string Id { get; set; }
        public int Length { get; set; }

        [MapTo("Values")]
        IList<RealmExtensionsObject<T>> _values { get; set; }

        public RealmList()
        {
            Console.WriteLine("RealmList()");

            Id = Guid.NewGuid().ToString();
        }

        // TODO: Make sure that these aren't included in Realm!
        #region IList
        bool IList.IsFixedSize => false;
        bool IList.IsReadOnly => _values.IsReadOnly;
        int ICollection.Count => _values.Count;
        bool ICollection.IsSynchronized => throw new NotImplementedException(); // TODO: What's this?
        object ICollection.SyncRoot => throw new NotImplementedException(); // TODO: What's this?
        object IList.this[int index] { get => _values[index]; set => _values[index] = value; }

        int IList.Add(object value) => _values.Add(value);

        void IList.Clear() => _values.Clear();

        bool IList.Contains(object value) => ContainsRealmExtensionObjectForValue(value);

        int IList.IndexOf(object value) => _values.IndexOf(value);

        void IList.Insert(int index, object value) => _values.Insert(index, value);

        void IList.Remove(object value) => _values.Remove(value);

        void IList.RemoveAt(int index) => _values.RemoveAt(index);

        void ICollection.CopyTo(Array array, int index) => _values.CopyTo(array, index);

        IEnumerator IEnumerable.GetEnumerator() => _values.GetEnumerator();
        #endregion

        #region Utility Methods
        bool ContainsRealmExtensionObjectForValue(object value)
        {
            _values.Where(r => r.Type == value.GetType());
        }
        #endregion
    }
}
