using System;
using System.IO;
using Logger.Repositories;
using Logger.Services;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Logger.Factories
{
    public class MongoRepositoryFactory : LogRepositoryFactory
    {

        private const string DEFAULT_CONNECTION_STRING = "";
        private const string DEFAULT_DATABASE = "";

        private readonly string _connectionString;
        private readonly string _dataBaseName;

        internal static IConfigurationRoot Configuration { get; set; }

        public MongoRepositoryFactory()
        {
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");

			Configuration = builder.Build();

			this._connectionString = !String.IsNullOrEmpty(Configuration["mongo_connection"]) ? Configuration["mongo_connection"] : DEFAULT_CONNECTION_STRING;
			this._dataBaseName = !String.IsNullOrEmpty(Configuration["mongo_database"]) ? Configuration["mongo_database"] : DEFAULT_DATABASE;
        }

        public override LogRepository CreateRepository()
		{
			var client = new MongoClient(_connectionString);
			var dataBase = client.GetDatabase(_dataBaseName);

			return new MongoDbLogRepository(new MongoLogService(dataBase));
        }
    }
}
