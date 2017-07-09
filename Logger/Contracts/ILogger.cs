﻿using System;
using Logger.Repositories;

namespace Logger.Contracts
{
    public interface ILogger
    {
        /// <summary>
        /// Adds one persistence repository, enabling extension.
        /// </summary>
        /// <param name="repository">Repository (Create your own repositories eg. EmailLogRepository.</param>
        void AddPersistenceRepository(LogRepository repository);
        void ClearPersistenceRepositories();
		void SetVerbosityLevels(bool enableError, bool enableWarning, bool enableMessage);
		void WriteLog(ILogEntity logEntity);
        string WriteMessage(string mesage);
        string WriteError(string message);
        string WriteWarning(string message);
    }
}
