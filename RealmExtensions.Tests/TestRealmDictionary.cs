using System;
using Realms;
using NUnit.Framework;

namespace Didstopia.RealmExtensions.Tests
{
    [TestFixture]
    public class TestRealmDictionary : TestBase
    {
        #region Test Methods
        [Test]
        public void TestSupportedTypes()
        {
            Console.WriteLine("Testing supported types");

            Validate<bool, bool>();
            Validate<char, char>();
            Validate<byte, byte>();
            Validate<short, short>();
            Validate<int, int>();
            Validate<long, long>();
            Validate<float, float>();
            Validate<double, double>();

            Validate<string, string>();
            Validate<DateTimeOffset, DateTimeOffset>();
        }

        [Test]
        public void TestUnsupportedTypes()
        {
            Console.WriteLine("Testing unsupported types");

            Validate<uint, uint>();
            Validate<DateTime, DateTime>();
        }
        #endregion

        #region Utility Methods
        void Validate<T1, T2>()
        {
            Console.WriteLine($"Validating types {typeof(T1).ToString()} and {typeof(T2).ToString()}");

            var dictionary = new RealmDictionary<T1, T2>();
            Assert.IsNotNull(dictionary, $"RealmDictionary was null for types {typeof(T1).ToString()} and {typeof(T2).ToString()}");
            Assert.IsNotNull(dictionary.Get(), $"Internal dictionary was null for types {typeof(T1).ToString()} and {typeof(T2).ToString()}");

            dictionary.Get().Add(default(T1), default(T2));
            Assert.IsNotEmpty(dictionary.Get(), $"Internal dictionary was empty for types {typeof(T1).ToString()} and {typeof(T2).ToString()}");
        }
        #endregion
    }
}
