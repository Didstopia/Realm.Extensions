﻿using System;
using NUnit.Framework;
using Realms;
using Didstopia.RealmExtensions;

namespace Didstopia.RealmExtensions.Test.UnitTests
{
    //[TestFixture]
    public class TestRealmDictionary : TestBase
	{
        #region Constructor
        public TestRealmDictionary()
        {
            Console.WriteLine("TestRealmDictionary()");
        }
        #endregion

        #region Test Methods
        /*[Test]
	    public void TestSupportedTypes()
	    {
	        Console.WriteLine("TestRealmDictionary::Testing supported types");

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
	        Console.WriteLine("TestRealmDictionary::Testing unsupported types");

	        Validate<uint, uint>();
	        Validate<DateTime, DateTime>();
	    }*/
	    #endregion

	    #region Utility Methods
	    void Validate<T1, T2>(T1 value1, T2 value2)
	    {
	        Console.WriteLine($"TestRealmDictionary::Validating types {typeof(T1).ToString()} and {typeof(T2).ToString()}");

	        var dictionary = new RealmDictionary<T1, T2>();
	        Assert.NotNull(dictionary);
	        Assert.NotNull(dictionary.Get());

            Assert.IsTrue(dictionary.Get().Count == 0, $"Expected dictionary count to be 0 but it was ${dictionary.Get().Count} instead");
            dictionary.Get().Add(value1, value2);
            Assert.IsFalse(dictionary.Get().Count == 0, $"Expected dictionary count to not be 0 but it was ${dictionary.Get().Count} instead");
        }
	    #endregion
	}
}