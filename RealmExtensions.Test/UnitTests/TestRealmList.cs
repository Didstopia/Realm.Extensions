﻿using System;
using NUnit.Framework;
using Realms;
using Didstopia.RealmExtensions;

namespace Didstopia.RealmExtensions.Test.UnitTests
{
    //[TestFixture]
    public class TestRealmList : TestBase
    {
        #region Constructor
        public TestRealmList()
        {
            Console.WriteLine("TestRealmList()");
        }
        #endregion

        // TODO: The validation logic is probably not good as is and definitely needs more work.
        //       Note that we should be able to validate this at compile time if our RealmExtensionsObject
        //       has supported types as properties already, right?

        #region Test Methods
        [Test]
        public void TestSupportedTypes()
        {
            Console.WriteLine("TestRealmList::Testing supported types");

            Validate<bool>(true);
            Validate<char>('c');
            Validate<byte>(1);
            Validate<short>(1);
            Validate<int>(1);
            Validate<long>(1);
            Validate<float>(1.0f);
            Validate<double>(1.0);

            Validate<string>("");
            Validate<DateTimeOffset>(DateTimeOffset.Now);
        }

        [Test]
        public void TestUnsupportedTypes()
        {
            Console.WriteLine("TestRealmList::Testing unsupported types");

            Validate<uint>(2147483647);
            Validate<DateTime>(DateTime.Now);
        }
        #endregion

        #region Utility Methods
        void Validate<T>(T value)
        {
            Console.WriteLine($"TestRealmList::Validating type {typeof(T).ToString()} with value {value}");

            var list = new RealmList<T>();
            Assert.NotNull(list);
            Assert.NotNull(list.Get());

            Assert.IsTrue(list.Get().Count == 0, $"Expected list count to be 0 but it was ${list.Get().Count} instead");
            list.Get().Add(value);
            Assert.IsFalse(list.Get().Count == 0, $"Expected list count to not be 0 but it was ${list.Get().Count} instead");
        }
        #endregion
    }
}