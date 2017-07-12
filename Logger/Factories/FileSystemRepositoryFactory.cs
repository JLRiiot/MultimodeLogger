using System;
using System.Reflection;
using Logger.Repositories;

namespace Logger.Factories
{
    public class FileSystemRepositoryFactory : LogRepositoryFactory
    {
        public FileSystemRepositoryFactory()
        {
        }

        public override LogRepository CreateRepository()
		{
			return new FileSystemLogRepository(Assembly.GetEntryAssembly().Location + ".log");
        }
    }
}
