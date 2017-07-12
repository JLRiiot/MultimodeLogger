using System;
using Logger.Factories;

namespace Logger.Repositories
{
    public abstract class LogRepository : IDisposable
    {
        public abstract string Type { get; }

        public abstract string WriteLog(LogEntityFactory logEntityFactory);
        public abstract void Dispose();
    }
}
