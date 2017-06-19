﻿using System;
using NUnit.Framework;
using Realms;
using Didstopia.RealmExtensions;
using Didstopia.RealmExtensions.Exceptions;

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

            Assert.That(() => Validate<uint>(2147483647), Throws.TypeOf<InvalidTypeException>());
            Assert.That(() => Validate<DateTime>(DateTime.Now), Throws.TypeOf<InvalidTypeException>());
        }
        #endregion

        #region Utility Methods
        void Validate<T>(T value)
        {
            Console.WriteLine($"TestRealmList::Validating type {typeof(T).ToString()} with value {value}");

            // Test list creation
            var list = new RealmList<T>();
            Assert.NotNull(list, "Expected list to not be null");

            // Test adding value to the list
            Assert.IsTrue(list.Count == 0, $"Expected list count to be 0 but it was ${list.Count} instead");
            list.Add(value);
            Assert.IsFalse(list.Count == 0, $"Expected list count to not be 0 but it was ${list.Count} instead");

            // Test saving the list
            Realm.Write(() =>
            {
                var savedList = Realm.Add(list);
                Assert.NotNull(savedList, "Expected saved list to not be null");
                Assert.IsTrue(savedList.IsManaged, $"Expected saved list IsManaged to be true, but it was ${savedList.IsManaged} instead");
                Assert.IsTrue(savedList.IsValid, $"Expected saved list IsValid to be true, but it was ${savedList.IsValid} instead");

                // Test loading the list
                var loadedList = Realm.Find<RealmList<T>>(savedList.Id);
                Assert.NotNull(loadedList, "Expected loaded list to not be null");
                Assert.IsTrue(loadedList.IsManaged, $"Expected loaded list IsManaged to be true, but it was ${loadedList.IsManaged} instead");
                Assert.IsTrue(loadedList.IsValid, $"Expected loaded list IsValid to be true, but it was ${loadedList.IsValid} instead");
            });
        }
        #endregion
    }
}