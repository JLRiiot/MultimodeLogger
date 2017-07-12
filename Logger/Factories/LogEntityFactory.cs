using System;
using Logger.Contracts;

namespace Logger.Factories
{
    public abstract class LogEntityFactory
    {
        protected string _message = string.Empty;

        protected LogEntityFactory(string message)
        {
            this._message = message;
        }

        public abstract ILogEntity CreateLogEntity();
    }
}
