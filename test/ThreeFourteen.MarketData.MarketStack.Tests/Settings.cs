﻿using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace ThreeFourteen.MarketData.MarketStack.Tests;

public static class Settings
{
    public static string AccessToken =>
        new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
            .Build()["AccessToken"];
}