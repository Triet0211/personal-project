using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Utils
{
    public class EnvConfig
    {
        public class _Config
        {
            public string API_PATH { get; set; }
            public string ACCESS_TOKEN_SECRET { get; set; }
            public string REFRESH_TOKEN_SECRET { get; set; }
            public string ERECRUITMENT_DB { get; set; }
            public string GOOGLE_CLIENT_ID { get; set; }
            public string GOOGLE_CLIENT_SECRET { get; set; }
            public string ADMIN_EMAIL { get; set; }
            public string ENVIRONMENT { get { return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"); } }
            public bool IsProduction { get { return (ENVIRONMENT != null && ENVIRONMENT.ToLower() == "Production".ToLower()); } }
            public bool IsTest { get { return (ENVIRONMENT != null && ENVIRONMENT.ToLower() == "Test".ToLower()); } }
            public bool IsDevelopment { get { return !IsProduction && !IsTest; } }
        }

        private static _Config Value = new _Config();

        public static _Config Get()
        {
            if (Value.ERECRUITMENT_DB == null)
            {
                Load();
            }

            return Value;
        }

        public static void AdaptEnv(string EnvName)
        {
            Console.WriteLine("Adjust Config depend on env: " + EnvName);
            if (EnvName.ToLower() == "test")
            {
            }
        }

        public static void Load()
        {
            string appSettingsPath = "../appsettings.json";

            if (Value.IsProduction || Value.IsTest)
            {
                appSettingsPath = "./appsettings.json";
            }

            Console.WriteLine("appsettings.jsons file path: " + appSettingsPath);
            using (StreamReader r = new StreamReader(appSettingsPath))
            {
                string json = r.ReadToEnd();
                Console.WriteLine(json);
                Value = JsonConvert.DeserializeObject<_Config>(json);
            }
        }

        public static void Load(IConfiguration configuration)
        {
            try
            {
                Value.ERECRUITMENT_DB = configuration.GetValue<string>("DB_HOST_NAME");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load environment variables, error: " + ex.Message);
                throw;
            }
        }


    }

}
