using System;
using Realms;
using NUnit.Framework;

namespace Didstopia.RealmExtensions.Tests
{
    [TestFixture]
    public class TestRealmArray : TestBase
    {
        [Test]
        public void TestSupportedTypes()
        {
            var boolArray = new RealmArray<bool>();
            var charArray = new RealmArray<char>();
            var byteArray = new RealmArray<byte>();
            var shortArray = new RealmArray<short>();
            var intArray = new RealmArray<int>();
            var longArray = new RealmArray<long>();
            var floatArray = new RealmArray<float>();
            var doubleArray = new RealmArray<double>();

            var stringArray = new RealmArray<string>();
            var dateTimeOffsetArray = new RealmArray<DateTimeOffset>();
        }

        [Test]
        public void TestUnsupportedTypes()
        {
            var uintArray = new RealmArray<uint>();
        }
    }
}
