﻿using System;
using Xunit;

namespace Didstopia.RealmExtensions.Test
{
    [Collection("RealmCollection")]
    public class Test
    {
        #region Private Properties
        RealmFixture _fixture { get; set; }
        #endregion

        public Test(RealmFixture realmFixture)
        {
            Assert.NotNull(realmFixture);
          
            _fixture = realmFixture;
        }

        [Fact]
        public void TestTrue()
        {
            Assert.True(true);
        }

        [Fact]
        public void TestFalse()
        {
            Assert.True(false);
        }
    }
}
