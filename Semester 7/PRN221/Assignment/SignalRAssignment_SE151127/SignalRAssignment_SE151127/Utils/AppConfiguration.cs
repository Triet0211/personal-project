﻿using Microsoft.Extensions.Configuration;
using System.IO;

namespace SignalRAssignment_SE151127.Utils
{
    public static class AppConfiguration
    {
        public static string GetAppsetting(string section, params string[] childrensection)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, true, true);
            var root = configurationBuilder.Build();
            var value = root.GetSection(section);
            foreach (var child in childrensection)
            {
                value = value.GetSection(child);
            }
            return value.Value;
        }
        public static string GetAdminEmail()
        {
            return GetAppsetting("AdministratorAccount", "Email");
        }
    }
}
