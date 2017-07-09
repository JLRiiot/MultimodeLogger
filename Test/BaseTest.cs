using System;
using System.IO;
using Logger.Contracts;
using Logger.Repositories;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Test
{
    public class BaseTest
	{
        protected BaseTest()
        {
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");

			Configuration = builder.Build();
        }

		protected static IConfigurationRoot Configuration { get; set; }

        protected T DeserializeJsonObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        protected void EnableAllVerboseLevels(ILogger logger)
		{
			logger.SetVerbosityLevels(true, true, true);
		}

        protected LogRepository CreateMongoRepository()
        {
            return LogRepositoryFactory.CreateDatabaseRepository(
                    Configuration["mongo_connection"],
                    Configuration["mongo_database"]
            );
        }
    }
}
