using System;
using System.IO;
using Logger.Contracts;
using Logger.Factories;

namespace Logger.Repositories
{
    public class FileSystemLogRepository : LogRepository
    {
        private string FilePath { get; set; }

        public FileSystemLogRepository(string filePath)
        {
            FilePath = filePath;
		}

		public override string Type { get => "file_system"; }

		public override string WriteLog(LogEntityFactory logEntityFactory)
		{
            var logEntity = logEntityFactory.CreateLogEntity();

            var line = logEntity.ToJSON();
            File.AppendAllText(FilePath, line);

            return logEntity.ToJSON();
		}

		public override void Dispose()
		{
            
		}
    }
}