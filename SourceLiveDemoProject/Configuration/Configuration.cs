﻿using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace SourceLiveDemoProject.Configuration
{
    public class ConfigurationManager
    {
        static readonly IConfiguration _configuration;

        static ConfigurationManager()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();
        }

        public static string BrowserName => GetConfigurationValue("Browser");
        public static string Url => GetConfigurationValue("BaseUrl");
        public static string MobileDeviceName => GetConfigurationValue("Mobile Device Name");
        public static bool Headless => bool.Parse(GetConfigurationValue("Headless"));

        static string GetConfigurationValue(string key)
        {
            var value = _configuration[key];
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ConfigurationErrorsException($"Configuration value for '{key}' is missing or empty.");
            }
            return value;
        }
    }
}

