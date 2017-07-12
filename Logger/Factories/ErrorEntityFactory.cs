using System;
using Logger.Contracts;
using Logger.Models;

namespace Logger.Factories
{
    public class ErrorEntityFactory : LogEntityFactory
    {
        public ErrorEntityFactory(string message) : base(message)
        {
        }

        public override ILogEntity CreateLogEntity()
        {
            return new ErrorLogEntity(this._message, DateTime.Now);
        }
    }
}
