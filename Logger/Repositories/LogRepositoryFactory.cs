using System;
using System.IO;
using System.Reflection;
using Logger.Services;
using MongoDB.Driver;

namespace Logger.Repositories
{
    public static class LogRepositoryFactory
    {
        public static LogRepository CreateConsoleRepository()
        {
            return new ConsoleLogRepository();
        }

        public static LogRepository CreateDatabaseRepository(string connectionString, string dataBaseName)
		{
			var client = new MongoClient(connectionString);
			var dataBase = client.GetDatabase(dataBaseName);

            return new MongoDbLogRepository(new MongoLogService(dataBase));
        }

        public static LogRepository CreateFileSystemRepository()
		{
            return new FileSystemLogRepository(Assembly.GetEntryAssembly().Location + ".log");
        }
    }
}
