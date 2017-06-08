﻿using System;
using Xunit;

namespace Didstopia.RealmExtensions.Test
{
    [CollectionDefinition("RealmCollection")]
    public class RealmCollectionFixture : ICollectionFixture<RealmFixture>
    {
        // Intentionally left blank.
        // This class only serves as an anchor for CollectionDefinition.
    }
}
