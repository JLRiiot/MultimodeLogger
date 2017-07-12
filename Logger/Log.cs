using System;
using System.Collections.Generic;
using Logger.Contracts;
using Logger.Factories;
using Logger.Models;
using Logger.Repositories;

namespace Logger
{
    public class Log : ILogger
	{

        private const string INVALID_CONFIG_ERROR = "Invalid configuration";

        public List<LogRepository> Repositories { get; private set; } = new List<LogRepository>();
        public bool ErrorEnabled { get; private set; }
        public bool MessageEnabled { get; private set; }
        public bool WarningEnabled { get; private set; }

        public Log(bool logMessage, bool logWarning, bool logError)
        {
			this.SetVerbosityLevels(logError, logWarning, logMessage);
        }

        public void EnableOther(LogRepositoryFactory logRepositoryFactory)
        {
            this.AddRepository(logRepositoryFactory);
        }

        public void ClearPersistenceRepositories()
        {
            Repositories.Clear();
        }

        public void SetVerbosityLevels(bool enableError, bool enableWarning, bool enableMessage)
        {
            ErrorEnabled = enableError;
            MessageEnabled = enableMessage;
            WarningEnabled = enableWarning;

            if (!ErrorEnabled && !MessageEnabled && !WarningEnabled) throw new Exception(INVALID_CONFIG_ERROR);
        }

        public void WriteError(string message)
        {
			if (ErrorEnabled)
				this.WriteLog(new ErrorEntityFactory(message));
        }

        public void WriteMessage(string message)
		{
			if (ErrorEnabled)
				this.WriteLog(new MessageEntityFactory(message));
        }

        public void WriteWarning(string message)
		{
			if (ErrorEnabled)
                this.WriteLog(new WarningEntityFactory(message));
        }

        private void WriteLog(LogEntityFactory logEntityFactory)
		{
			foreach (var repository in Repositories)
			{
				repository.WriteLog(logEntityFactory);
			}
		}

        public void EnableConsole()
		{
            this.AddRepository(new ConsoleRepositoryFactory());
        }

        public void EnableMongo()
        {
            this.AddRepository(new MongoRepositoryFactory());
        }

        public void EnableFileSystem()
        {
            this.AddRepository(new FileSystemRepositoryFactory());
        }

        private void AddRepository(LogRepositoryFactory factory)
        {
            var repository = factory.CreateRepository();

			if (!Repositories.Exists(r => r.Type.Equals(repository.Type)))
				Repositories.Add(repository);
        }
    }
}
