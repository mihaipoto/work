﻿using NUnit.Framework;

using static Testing;

namespace TestClean.Application.IntegrationTests;
[TestFixture]
public abstract class BaseTestFixture
{
    [SetUp]
    public async Task TestSetUp()
    {
        await ResetState();
    }
}
