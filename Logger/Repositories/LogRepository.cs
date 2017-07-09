using System;
using System.Collections.Generic;
using Logger.Contracts;

namespace Logger.Repositories
{
    public abstract class LogRepository : IDisposable
    {
        public abstract string Type { get; }

        public abstract void WriteLog(ILogEntity logEntity);
        public abstract void Dispose();
    }
}
