using System;
using Logger.Repositories;

namespace Logger.Factories
{
    public class ConsoleRepositoryFactory : LogRepositoryFactory
    {
        public ConsoleRepositoryFactory()
        {
        }

        public override LogRepository CreateRepository()
		{
			return new ConsoleLogRepository();
        }
    }
}
