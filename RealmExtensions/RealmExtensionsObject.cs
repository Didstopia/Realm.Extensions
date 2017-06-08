using System;
using System.Collections.Generic;
using Didstopia.RealmExtensions.Exceptions;
using Realms;

namespace Didstopia.RealmExtensions
{
    class RealmExtensionsObject<T> : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }
        public Type Type { get; set; }

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
        [MapTo("RealmObjectValue")] RealmObject _realmObjectValue { get; set; }
        #endregion

        [Ignored]
        public T Value { get => GetValue(); set => SetValue(value); }

        public RealmExtensionsObject()
        {
            Console.WriteLine("RealmExtensionsObject()");

            ValidateSupportedType(typeof(T));

            Id = Guid.NewGuid().ToString();
            Type = typeof(T);

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

        T GetValue()
        {
            Console.WriteLine("GetValue()");

            // TODO: Get the value

            return default(T);
        }

        void SetValue(T value)
        {
            Console.WriteLine("SetValue(): " + value);

            ValidateSupportedType(value);

            var t = value;

            // TODO: Set the value
        }

        void ValidateSupportedType(Type type)
        {
            Console.WriteLine("ValidateSupportedType(): " + type);

            // TODO: Add support for "base type", in case the RealmObject approach works?
            if (!_supportedTypes.Contains(type))
                throw new InvalidTypeException(type);
        }
    }
}
