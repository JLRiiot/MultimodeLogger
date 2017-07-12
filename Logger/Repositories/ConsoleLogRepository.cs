using System;
using System.Collections.Generic;
using Logger.Contracts;
using Logger.Factories;

namespace Logger.Repositories
{
    public class ConsoleLogRepository : LogRepository
    {
		private Dictionary<String, ConsoleColor> _colorCodes = new Dictionary<string, ConsoleColor>();

		public ConsoleLogRepository()
        {
            this.Initialize();
        }

        private void Initialize()
        {
			this._colorCodes.Add("ERROR", ConsoleColor.Red);
			this._colorCodes.Add("WARNING", ConsoleColor.Yellow);
			this._colorCodes.Add("MESSAGE", ConsoleColor.Blue);
        }

        public override string Type { get => "console"; }

		public override string WriteLog(LogEntityFactory logEntityFactory)
        {
            var logEntity = logEntityFactory.CreateLogEntity();

			this.SetConsoleForegroundColor(logEntity.Type);
            string line = logEntity.ToJSON();

            Console.WriteLine(line);

            return logEntity.ToJSON();
        }

		public override void Dispose()
        {
            //Nothing to dispose here.
		}

		private void SetConsoleForegroundColor(string type)
		{
			Console.ForegroundColor = this._colorCodes[type];
		}
    }
}