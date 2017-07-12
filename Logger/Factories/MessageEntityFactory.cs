using System;
using Logger.Contracts;
using Logger.Models;

namespace Logger.Factories
{
    public class MessageEntityFactory : LogEntityFactory
    {
        public MessageEntityFactory(string message) : base(message)
        {
        }

        public override ILogEntity CreateLogEntity()
        {
            return new MessageLogEntity(this._message, DateTime.Now);
        }
    }
}
