using System;
using System.Collections.Generic;
using Didstopia.RealmExtensions.Exceptions;
using Realms;

namespace Didstopia.RealmExtensions
{
    sealed class RealmExtensionsObject<T> : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Type { get; private set; }

        #region Supported Types
        [Ignored] List<Type> _supportedTypes { get; set; }

        [MapTo("BoolValue")] bool _boolValue { get; set; }
        [MapTo("CharValue")] char _charValue { get; set; }
        [MapTo("ByteValue")] byte _byteValue { get; set; }
        [MapTo("ShortValue")] short _shortValue { get; set; }
        [MapTo("IntValue")] int _intValue { get; set; }
        [MapTo("LongValue")] long _longValue { get; set; }
        [MapTo("FloatValue")] float _floatValue { get; set; }
        [MapTo("DoubleValue")] double _doubleValue { get; set; }
        [MapTo("StringValue")] string _stringValue { get; set; }
        [MapTo("DateTimeOffsetValue")] DateTimeOffset _dateTimeOffsetValue { get; set; }
        // FIXME: Not sure how to fix this, but it needs to be fixed!
        //[MapTo("RealmObjectValue")] RealmObject _realmObjectValue { get; set; }
        #endregion

        [Ignored] public T Value { get => GetValue(); set => SetValue(value); }

        #region Constructor
        public RealmExtensionsObject()
        {
            Console.WriteLine("RealmExtensionsObject()");

            Id = Guid.NewGuid().ToString();

            if (_supportedTypes == null)
            {
                _supportedTypes = new List<Type>();

                _supportedTypes.Add(typeof(bool));
                _supportedTypes.Add(typeof(char));
                _supportedTypes.Add(typeof(byte));
                _supportedTypes.Add(typeof(short));
                _supportedTypes.Add(typeof(int));
                _supportedTypes.Add(typeof(long));
                _supportedTypes.Add(typeof(float));
                _supportedTypes.Add(typeof(double));
                _supportedTypes.Add(typeof(string));
                _supportedTypes.Add(typeof(DateTimeOffset));
                _supportedTypes.Add(typeof(RealmObject));
            }

            ValidateSupportedType(typeof(T));
        }
        #endregion

        #region Utilities
        T GetValue()
        {
            Console.WriteLine("GetValue()");

            // TODO: Get the value

            if (Type.Equals(typeof(bool)))
                return (T)(object)_boolValue;
            if (Type.Equals(typeof(char)))
                return (T)(object)_charValue;
            if (Type.Equals(typeof(byte)))
                return (T)(object)_byteValue;
            if (Type.Equals(typeof(short)))
                return (T)(object)_shortValue;
            if (Type.Equals(typeof(int)))
                return (T)(object)_intValue;
            if (Type.Equals(typeof(long)))
                return (T)(object)_longValue;
            if (Type.Equals(typeof(float)))
                return (T)(object)_floatValue;
            if (Type.Equals(typeof(double)))
                return (T)(object)_doubleValue;
            if (Type.Equals(typeof(string)))
                return (T)(object)_stringValue;
            if (Type.Equals(typeof(DateTimeOffset)))
                return (T)(object)_dateTimeOffsetValue;
            // FIXME: Not sure how to fix this, but it needs to be fixed!
            //if (Type.Equals(typeof(RealmObject)))
            //    return (T)(object)_realmObjectValue;

            return default(T);
        }

        void SetValue(T value)
        {
            Console.WriteLine("SetValue(): " + value);

            ValidateSupportedType(typeof(T));

            if (!IsManaged) Type = typeof(T).ToString();
            else Realm.Write(() => Type = typeof(T).ToString());

            if (Type.Equals(typeof(bool)))
            {
                if (!IsManaged) _boolValue = Convert.ToBoolean(value);
                else Realm.Write(() => _boolValue = Convert.ToBoolean(value));
            }
            if (Type.Equals(typeof(char)))
            {
                if (!IsManaged) _charValue = Convert.ToChar(value);
                else Realm.Write(() => _charValue = Convert.ToChar(value));
            }
            if (Type.Equals(typeof(byte)))
            {
                if (!IsManaged) _byteValue = Convert.ToByte(value);
                else Realm.Write(() => _byteValue = Convert.ToByte(value));
            }
            if (Type.Equals(typeof(short)))
            {
                if (!IsManaged) _shortValue = Convert.ToInt16(value);
                else Realm.Write(() => _shortValue = Convert.ToInt16(value));
            }
            if (Type.Equals(typeof(int)))
            {
                if (!IsManaged) _intValue = Convert.ToInt32(value);
                else Realm.Write(() => _intValue = Convert.ToInt32(value));
            }
            if (Type.Equals(typeof(long)))
            {
                if (!IsManaged) _longValue = Convert.ToInt64(value);
                else Realm.Write(() => _longValue = Convert.ToInt64(value));
            }
            if (Type.Equals(typeof(float)))
            {
                if (!IsManaged) _floatValue = Convert.ToSingle(value);
                else Realm.Write(() => _floatValue = Convert.ToSingle(value));
            }
            if (Type.Equals(typeof(double)))
            {
                if (!IsManaged) _doubleValue = Convert.ToDouble(value);
                else Realm.Write(() => _doubleValue = Convert.ToDouble(value));
            }
            if (Type.Equals(typeof(string)))
            {
                if (!IsManaged) _stringValue = Convert.ToString(value);
                else Realm.Write(() => _stringValue = Convert.ToString(value));
            }
            if (Type.Equals(typeof(DateTimeOffset)))
            {
                // TODO: Validate that this works
                if (!IsManaged) _dateTimeOffsetValue = DateTimeOffset.Parse(Convert.ToString(value));
                else Realm.Write(() => _dateTimeOffsetValue = DateTimeOffset.Parse(Convert.ToString(value)));
            }
            // FIXME: Not sure how to fix this, but it needs to be fixed!
            //if (Type.Equals(typeof(RealmObject)))
            //    _realmObjectValue = value;

            // TODO: Handle IsManaged with a Realm.Write()
        }

        void ValidateSupportedType(Type type)
        {
            Console.WriteLine("ValidateSupportedType(): " + type);

            // TODO: Add support for "base type", in case the RealmObject approach works?
            if (!_supportedTypes.Contains(type))
                throw new InvalidTypeException(type);
        }
        #endregion
    }
}
