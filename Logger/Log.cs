using System;
using System.Collections.Generic;
using Logger.Contracts;
using Logger.Models;
using Logger.Repositories;

namespace Logger
{
    public class Log : ILogger
    {
        private const string INVALID_CONFIG_ERROR = "Invalid configuration";

        private List<LogRepository> Repositories { get; set; } = new List<LogRepository>();
        public bool ErrorEnabled { get; private set; }
        public bool MessageEnabled { get; private set; }
        public bool WarningEnabled { get; private set; }

        public Log()
        {
			Repositories.Add(LogRepositoryFactory.CreateConsoleRepository());
            Repositories.Add(LogRepositoryFactory.CreateFileSystemRepository());
        }

        public Log(LogRepository logRepository)
		{
			Repositories.Add(logRepository);

			if (Repositories.Count == 0) throw new Exception(INVALID_CONFIG_ERROR);
        }

        public Log(List<LogRepository> logRepositories)
        {
            Repositories.AddRange(logRepositories);

			if (Repositories.Count == 0) throw new Exception(INVALID_CONFIG_ERROR);
        }

        public void AddPersistenceRepository(LogRepository logRepository)
        {
            if (!Repositories.Exists(r => r.Type.Equals(logRepository.Type)))
                Repositories.Add(logRepository);

            if (Repositories.Count == 0) throw new Exception(INVALID_CONFIG_ERROR);
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

        public string WriteError(string message)
        {
            if (!ErrorEnabled) return String.Empty;

            var error = new ErrorLogEntity(message, DateTime.Now);
            this.WriteLog(error);

            return error.ToJSON();
        }

        public string WriteMessage(string message)
		{
			if (!ErrorEnabled) return String.Empty;

			var error = new MessageLogEntity(message, DateTime.Now);
			this.WriteLog(error);

			return error.ToJSON();
        }

        public string WriteWarning(string message)
		{
			if (!ErrorEnabled) return String.Empty;

			var error = new WarningLogEntity(message, DateTime.Now);
			this.WriteLog(error);

			return error.ToJSON();
        }

        public void WriteLog(ILogEntity logEntity)
        {
            foreach (var repository in Repositories)
            {
                repository.WriteLog(logEntity);
            }
        }
    }
}
