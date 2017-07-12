using System;
using Logger.Contracts;
using Logger.Models;

namespace Logger.Factories
{
    public class WarningEntityFactory : LogEntityFactory
    {
        public WarningEntityFactory(string message) : base(message)
        {
        }

        public override ILogEntity CreateLogEntity()
        {
            return new WarningLogEntity(this._message, DateTime.Now);
        }
    }
}
