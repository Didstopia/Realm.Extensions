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
        public bool IsFixedSize => false;
        public bool IsReadOnly => _values.IsReadOnly;
        public int Count => _values.Count;
        public bool IsSynchronized => throw new NotImplementedException(); // TODO: What's this?
        public T SyncRoot => throw new NotImplementedException(); // TODO: What's this?
        public T this[int index]
        {
            get
            {
                if (IsIndexInsideBounds(index))
                {
                    return _values[index].Value;
                }
                else throw new NullReferenceException($"Index {index} is out of bounds (current count is {_values.Count()})");
            }
            set
            {
                // TODO: How would this work? Check for null at index like above, I guess?
                _values[index].Value = value;
            }
        }

        public int Add(T value)
        {
            var newObject = new RealmExtensionsObject<T> { Value = value };
            _values.Add(newObject);
            return _values.IndexOf(newObject);
        }

        public void Clear() => _values.Clear();

        public bool Contains(T value) => GetContains(value);

        public int IndexOf(T value) => GetIndexOf(value);

        public void Insert(int index, T value) => _values.Insert(index, value);

        public void Remove(T value) => _values.Remove(value);

        public void RemoveAt(int index) => _values.RemoveAt(index);

        public void CopyTo(Array array, int index) => _values.CopyTo(array, index);

        public IEnumerator GetEnumerator() => _values.GetEnumerator(); // TODO: This needs to return r.Value enumerator
        #endregion

        #region Utility Methods
        T GetAtIndex(int index)
        {
            // TODO: Implement
        }

        bool GetContains(T value)
        {
            foreach (var r in _values)
                if (r.Value.Equals(value))
                    return true;
            
            return false;
        }

		int GetIndexOf(T value)
		{
			foreach (var r in _values)
				if (r.Value.Equals(value))
                    return _values.IndexOf(r);

			return -1;
		}

        bool IsIndexInsideBounds(int index)
        {
            // TODO: Implement

        }
        #endregion
    }
}
