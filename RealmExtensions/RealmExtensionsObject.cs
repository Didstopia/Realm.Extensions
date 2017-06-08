using System;
using System.Collections.Generic;
using Didstopia.RealmExtensions.Exceptions;
using Realms;

namespace Didstopia.RealmExtensions
{
    class RealmExtensionsObject : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }

        #region Supported Types
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
        [MapTo("RealmObjectValue")] RealmObject _realmObjectValue { get; set; }
        #endregion

        [Ignored]
        List<Type> _supportedTypes { get; set; }

        public RealmExtensionsObject()
        {
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
        }

        public void GetValue<T>(T value)
        {
            ValidateSupportedType<T>();

            // TODO: Get the value
        }

        public void SetValue<T>(T value)
        {
            ValidateSupportedType<T>();

            // TODO: Set the value
        }

        void ValidateSupportedType<T>()
        {
            if (!_supportedTypes.Contains(typeof(T)))
                throw new InvalidTypeException(typeof(T));
        }
    }
}
