using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Realms;

namespace Didstopia.RealmExtensions
{
    public sealed class RealmList<T> : RealmObject, IList<T>/*, IList*/
    {
        [PrimaryKey]
        public string Id { get; set; }

        [MapTo("Values")]
        IList<RealmExtensionsObject<T>> _internalList { get; }

        #region Constructor
        public RealmList()
        {
            Console.WriteLine("RealmList()");
            Id = Guid.NewGuid().ToString();
        }
        #endregion

        #region IList
        [Ignored] public int Count => ((IList)_internalList).Count;
        [Ignored] public bool IsReadOnly => ((IList)_internalList).IsReadOnly;
        [Ignored] public T this[int index]
        {
            get => _internalList[index].Value;
            set
            {
                Console.WriteLine("Set index: " + index);
                if (!IsManaged) _internalList[index].Value = value;
                else Realm.Write(() => _internalList[index].Value = value);
            }
        }

        public int IndexOf(T item)
        {
            Console.WriteLine("IndexOf: " + item);
            // TODO: Test this, because it might not work as expected
            foreach (var obj in _internalList.Select((value, i) => new { i, value }))
            {
                var value = obj.value;
                var index = obj.i;

                if (item.Equals(value.Value))
                    return index;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            Console.WriteLine("Insert: " + index + " -> " + item);
            if (!IsManaged) _internalList.Insert(index, new RealmExtensionsObject<T> { Value = item });
            else Realm.Write(() => _internalList.Insert(index, new RealmExtensionsObject<T> { Value = item }));
        }

        public void RemoveAt(int index)
        {
            Console.WriteLine("RemoveAt: " + index);
            if (!IsManaged) _internalList.RemoveAt(index);
            else Realm.Write(() => _internalList.RemoveAt(index));
        }

        public void Add(T item)
        {
            Console.WriteLine("Add: " + item);
            if (!IsManaged) _internalList.Add(new RealmExtensionsObject<T> { Value = item });
            else Realm.Write(() => _internalList.Add(new RealmExtensionsObject<T> { Value = item }));
        }

        public void Clear()
        {
            Console.WriteLine("Clear");
            if (!IsManaged) _internalList.Clear();
            else Realm.Write(() => _internalList.Clear());
        }

        public bool Contains(T item)
        {
            Console.WriteLine("Contains: " + item);
            // TODO: Test this, because it might not work as expected
            foreach (var obj in _internalList)
                if (item.Equals(obj.Value))
                    return true;
            
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Console.WriteLine("CopyTo");
            // TODO: Test this, because it might not work as expected
            int count = 0;
            foreach (var item in _internalList.Select((value, i) => new { i, value }))
            {
                var value = item.value;
                var index = item.i;

                if (index >= arrayIndex)
                    array[count++] = value.Value;
            }
        }

        public bool Remove(T item)
        {
            Console.WriteLine("Remove: " + item);
            // TODO: Test this, because it might not work as expected
            RealmExtensionsObject<T> foundObj = null;

            foreach (var obj in _internalList)
            {
                if (item.Equals(obj.Value))
                {
                    foundObj = obj;
                    break;
                }
            }

            if (foundObj != null)
            {
                if (!IsManaged) _internalList.Remove(foundObj);
                else Realm.Write(() => _internalList.Remove(foundObj));
            }

            return foundObj != null;
        }

        // TODO: Test both enumerators that they work properly
        public IEnumerator<T> GetEnumerator()
        {
            Console.WriteLine("GetEnumerator");
            foreach (var obj in _internalList)
                yield return obj.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Console.WriteLine("IEnumerable.GetEnumerator");
            foreach (var obj in _internalList)
                yield return obj.Value;
        }
        #endregion
    }
}
