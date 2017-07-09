using System;
using Logger;
using Logger.Contracts;
using Logger.Models;
using Logger.Repositories;
using Xunit;

namespace Test
{
    public class LoggerTest : BaseTest
    {
        public LoggerTest() : base()
        {
            
        }

        #region File log tests
        [Fact]
        public void LogErrorToFile()
        {
            var repo = LogRepositoryFactory.CreateFileSystemRepository();
            ILogger logger = new Log(repo);
            this.EnableAllVerboseLevels(logger);

            string message = "TEST MESSAGE";
            string json = logger.WriteError(message);

            var result = this.DeserializeJsonObject<ErrorLogEntity>(json);

            Assert.Equal(result.Type, "ERROR");
            Assert.Equal(result.Message, message);
        }
        [Fact]
        public void LogMessageToFile()
		{
			var repo = LogRepositoryFactory.CreateFileSystemRepository();
			ILogger logger = new Log(repo);
			this.EnableAllVerboseLevels(logger);

			string message = "TEST MESSAGE";
			string json = logger.WriteError(message);

			var result = this.DeserializeJsonObject<MessageLogEntity>(json);

			Assert.Equal(result.Type, "MESSAGE");
			Assert.Equal(result.Message, message);
        }
        [Fact]
        public void LogWarningToFile()
		{
			var repo = LogRepositoryFactory.CreateFileSystemRepository();
			ILogger logger = new Log(repo);
			this.EnableAllVerboseLevels(logger);

			string message = "TEST MESSAGE";
			string json = logger.WriteError(message);

			var result = this.DeserializeJsonObject<WarningLogEntity>(json);

			Assert.Equal(result.Type, "WARNING");
			Assert.Equal(result.Message, message);
        }
		#endregion

		#region Console log tests
		[Fact]
		public void LogErrorToConsole()
		{
			var repo = LogRepositoryFactory.CreateConsoleRepository();
			ILogger logger = new Log(repo);
			this.EnableAllVerboseLevels(logger);

			string message = "TEST MESSAGE";
			string json = logger.WriteError(message);

			var result = this.DeserializeJsonObject<ErrorLogEntity>(json);

			Assert.Equal(result.Type, "ERROR");
			Assert.Equal(result.Message, message);
            Assert.Equal(ConsoleColor.Red, Console.ForegroundColor);
		}
		[Fact]
		public void LogMessageToConsole()
		{
			var repo = LogRepositoryFactory.CreateConsoleRepository();
			ILogger logger = new Log(repo);
			this.EnableAllVerboseLevels(logger);

			string message = "TEST MESSAGE";
			string json = logger.WriteMessage(message);

			var result = this.DeserializeJsonObject<MessageLogEntity>(json);

			Assert.Equal(result.Type, "MESSAGE");
			Assert.Equal(result.Message, message);
			Assert.Equal(ConsoleColor.Blue, Console.ForegroundColor);
		}
		[Fact]
		public void LogWarningToConsole()
		{
			var repo = LogRepositoryFactory.CreateConsoleRepository();
			ILogger logger = new Log(repo);
			this.EnableAllVerboseLevels(logger);

			string message = "TEST MESSAGE";
            string json = logger.WriteWarning(message);

			var result = this.DeserializeJsonObject<WarningLogEntity>(json);

			Assert.Equal(result.Type, "WARNING");
			Assert.Equal(result.Message, message);
			Assert.Equal(ConsoleColor.Yellow, Console.ForegroundColor);
		}
		#endregion

		#region Mongo log test
		[Fact]
		public void LogErrorToMongoDb()
		{
			var repo = this.CreateMongoRepository();
			ILogger logger = new Log(repo);
			this.EnableAllVerboseLevels(logger);

			string message = "TEST ERROR";
			string json = logger.WriteError(message);

			var result = this.DeserializeJsonObject<ErrorLogEntity>(json);

			Assert.Equal(result.Type, "ERROR");
			Assert.Equal(result.Message, message);
		}
		[Fact]
		public void LogMessageToMongoDb()
		{
			var repo = this.CreateMongoRepository();
			ILogger logger = new Log(repo);
			this.EnableAllVerboseLevels(logger);

			string message = "TEST ERROR";
			string json = logger.WriteMessage(message);

			var result = this.DeserializeJsonObject<MessageLogEntity>(json);

			Assert.Equal(result.Type, "MESSAGE");
			Assert.Equal(result.Message, message);
		}
		[Fact]
		public void LogWarningToMongoDb()
		{
			var repo = this.CreateMongoRepository();
			ILogger logger = new Log(repo);
			this.EnableAllVerboseLevels(logger);

			string message = "TEST ERROR";
			string json = logger.WriteWarning(message);

			var result = this.DeserializeJsonObject<WarningLogEntity>(json);

			Assert.Equal(result.Type, "WARNING");
			Assert.Equal(result.Message, message);
		}
        #endregion
    }
}
