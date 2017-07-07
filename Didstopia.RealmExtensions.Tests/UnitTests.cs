using System;
using Xunit;
using Didstopia.RealmExtensions;

namespace Didstopia.RealmExtensions.Tests
{
    [Collection("Realm collection")]
    public class UnitTests
    {
        DatabaseFixture _databaseFixture { get; set; }

        public UnitTests(DatabaseFixture fixture)
        {
            _databaseFixture = fixture;
        }

        // TODO: Can we make this so that only the CI will skip this, but our IDE won't?
        [Fact(Skip = "Skipping test because it's still a work in progress and broken")]
        public void TestRealmList()
        {
            var list = new RealmList<string>();
            Assert.NotNull(list);
            Assert.True(list.Count == 0);

            list.Add("Test #1");
            Assert.True(list.Count == 1);

            try
            {
                _databaseFixture.Add(list);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }

            try
            {
                _databaseFixture.Remove(list);
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }
        }
    }
}
