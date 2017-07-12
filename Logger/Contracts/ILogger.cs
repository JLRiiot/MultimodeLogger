﻿using System;
using System.Collections.Generic;
using Logger.Factories;
using Logger.Repositories;

namespace Logger.Contracts
{
    public interface ILogger
    {
        List<LogRepository> Repositories { get; }
        void EnableConsole();
        void EnableMongo();
        void EnableFileSystem();
        void EnableOther(LogRepositoryFactory factory);
        void ClearPersistenceRepositories();
		void SetVerbosityLevels(bool enableError, bool enableWarning, bool enableMessage);
        void WriteMessage(string mesage);
        void WriteError(string message);
        void WriteWarning(string message);
    }
}
