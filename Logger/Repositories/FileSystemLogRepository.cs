using System;
using System.IO;
using Logger.Contracts;

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

		public override void WriteLog(ILogEntity logEntity)
		{
            var line = logEntity.ToJSON();
            File.AppendAllText(FilePath, line);
		}

		public override void Dispose()
		{
            
		}
    }
}