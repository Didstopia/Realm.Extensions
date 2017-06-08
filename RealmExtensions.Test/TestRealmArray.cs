﻿﻿using System;
using Xunit;
using Realms;
using Didstopia.RealmExtensions;

namespace Didstopia.RealmExtensions.Test
{
    [Collection("RealmCollection")]
    public class TestRealmArray
    {
        #region Private Properties
        RealmFixture _fixture { get; set; }
        #endregion

        #region Constructor
        public TestRealmArray(RealmFixture realmFixture)
        {
            Console.WriteLine("TestRealmArray()");

            Assert.NotNull(realmFixture);
            _fixture = realmFixture;
        }
        #endregion

        #region Test Methods
        [Fact]
        public void TestSupportedTypes()
        {
            Console.WriteLine("TestRealmArray::Testing supported types");

            Validate<bool>();
            Validate<char>();
            Validate<byte>();
            Validate<short>();
            Validate<int>();
            Validate<long>();
            Validate<float>();
            Validate<double>();

            Validate<string>();
            Validate<DateTimeOffset>();
        }

        [Fact]
        public void TestUnsupportedTypes()
        {
            Console.WriteLine("TestRealmArray::Testing unsupported types");

            Validate<uint>();
            Validate<DateTime>();
        }
        #endregion

        #region Utility Methods
        void Validate<T>()
        {
            Console.WriteLine($"TestRealmArray::Validating type {typeof(T).ToString()}");

            var array = new RealmArray<T>();
            Assert.NotNull(array);
            Assert.NotNull(array.Get());

            Assert.Empty(array.Get());
            array.Get()[array.Get().Length] = default(T);
            Assert.NotEmpty(array.Get());
        }
        #endregion
    }
}