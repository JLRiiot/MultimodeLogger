using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Logger.Services;
using MongoDB.Driver;

namespace Logger.Repositories
{
    public static class LogRepositoryFactory
    {
        private const string DEFAULT_CONNECTION_STRING = "";
        private const string DEFAULT_DATABASE = "";

        private static readonly string _connectionString;
		private static readonly string _dataBaseName;

		public static IConfigurationRoot Configuration { get; set; }

        static LogRepositoryFactory()
        {
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");

			Configuration = builder.Build();

            _connectionString = !String.IsNullOrEmpty(Configuration["mongo_connection"]) ? Configuration["mongo_connection"] : DEFAULT_CONNECTION_STRING;
            _dataBaseName = !String.IsNullOrEmpty(Configuration["mongo_database"]) ? Configuration["mongo_database"] : DEFAULT_DATABASE;
        }

        public static LogRepository CreateConsoleRepository()
        {
            return new ConsoleLogRepository();
        }

        public static LogRepository CreateDatabaseRepository()
		{
			var client = new MongoClient(_connectionString);
			var dataBase = client.GetDatabase(_dataBaseName);

            return new MongoDbLogRepository(new MongoLogService(dataBase));
        }

        public static LogRepository CreateFileSystemRepository()
		{
            return new FileSystemLogRepository(Assembly.GetEntryAssembly().Location + ".log");
        }
    }
}
