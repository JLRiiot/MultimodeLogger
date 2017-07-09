using System;
using Microsoft.Extensions.Configuration;
using Logger;
using Logger.Repositories;
using MongoDB.Driver;
using System.IO;
using Logger.Services;

namespace LoggerPlayground
{
    class Program
	{
		public static IConfigurationRoot Configuration { get; set; }

        static Program()
        {
			var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

			Configuration = builder.Build();
        }

        static void Main(string[] args)
        {
            Log log1 = new Log();
            log1.SetVerbosityLevels(true, true, true);
            log1.AddPersistenceRepository(
                LogRepositoryFactory.CreateDatabaseRepository(
                    Configuration["mongo_connection"], 
                    Configuration["mongo_database"]
                )
            );

            log1.WriteError("Testing error");
			log1.WriteMessage("Testing if polymorphism works");
            log1.WriteWarning("For this entry _t must be WarningLogEntity");
        }
    }
}
