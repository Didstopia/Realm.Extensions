﻿﻿using System;
using Xunit;
using Realms;
using Didstopia.RealmExtensions;

namespace Didstopia.RealmExtensions.Test
{
    [Collection("RealmCollection")]
    public class TestRealmDictionary
	{
        #region Private Properties
        RealmFixture _fixture { get; set; }
        #endregion

        #region Constructor
        public TestRealmDictionary(RealmFixture realmFixture)
        {
            Console.WriteLine("TestRealmDictionary()");

            Assert.NotNull(realmFixture);
            _fixture = realmFixture;
        }
        #endregion

        #region Test Methods
        [Fact]
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

	    [Fact]
	    public void TestUnsupportedTypes()
	    {
	        Console.WriteLine("TestRealmDictionary::Testing unsupported types");

	        Validate<uint, uint>();
	        Validate<DateTime, DateTime>();
	    }
	    #endregion

	    #region Utility Methods
	    void Validate<T1, T2>()
	    {
	        Console.WriteLine($"TestRealmDictionary::Validating types {typeof(T1).ToString()} and {typeof(T2).ToString()}");

	        var dictionary = new RealmDictionary<T1, T2>();
	        Assert.NotNull(dictionary);
	        Assert.NotNull(dictionary.Get());

            Assert.Empty(dictionary.Get());
	        dictionary.Get().Add(default(T1), default(T2));
	        Assert.NotEmpty(dictionary.Get());
	    }
	    #endregion
	}
}