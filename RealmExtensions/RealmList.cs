using System;
using System.Collections;
using System.Collections.Generic;
using Realms;

namespace Didstopia.RealmExtensions
{
    public class RealmList<T> : RealmObject, IList
    {
        [PrimaryKey]
        public string Id { get; set; }
        public int Length { get; set; }

        [MapTo("Values")]
        IList<RealmExtensionsObject> _values { get; set; }

        public RealmList()
        {
            Id = Guid.NewGuid().ToString();
        }

        #region IList
        bool IList.IsFixedSize => false;
        bool IList.IsReadOnly => _values.IsReadOnly;
        int ICollection.Count => _values.Count;
        bool ICollection.IsSynchronized => throw new NotImplementedException();
        object ICollection.SyncRoot => throw new NotImplementedException();
        object IList.this[int index] { get => _values[index]; set => _values[index] = value; }

        int IList.Add(object value) => _values.Add(value);

        void IList.Clear() => _values.Clear();

        bool IList.Contains(object value) => _values.Contains(value);

        int IList.IndexOf(object value) => _values.IndexOf(value);

        void IList.Insert(int index, object value) => _values.Insert(index, value);

        void IList.Remove(object value) => _values.Remove(value);

        void IList.RemoveAt(int index) => _values.RemoveAt(index);

        void ICollection.CopyTo(Array array, int index) => _values.CopyTo(array, index);

        IEnumerator IEnumerable.GetEnumerator() => _values.GetEnumerator();
        #endregion
    }
}
