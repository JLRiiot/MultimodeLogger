using System;
using Logger;
using Logger.Contracts;
using Logger.Factories;
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
            string message = "TEST MESSAGE";

            var repo = new FileSystemRepositoryFactory().CreateRepository();
            var errorFactory = new ErrorEntityFactory(message);

            var stringResult = repo.WriteLog(errorFactory);

            var result = this.DeserializeJsonObject<ErrorLogEntity>(stringResult);

            Assert.Equal(result.Type, "ERROR");
            Assert.Equal(result.Message, message);
        }
        [Fact]
        public void LogMessageToFile()
		{
			string message = "TEST MESSAGE";

			var repo = new FileSystemRepositoryFactory().CreateRepository();
			var errorFactory = new MessageEntityFactory(message);

			var stringResult = repo.WriteLog(errorFactory);

			var result = this.DeserializeJsonObject<MessageLogEntity>(stringResult);

			Assert.Equal(result.Type, "MESSAGE");
			Assert.Equal(result.Message, message);
        }
        [Fact]
        public void LogWarningToFile()
		{
			string message = "TEST MESSAGE";

			var repo = new FileSystemRepositoryFactory().CreateRepository();
			var errorFactory = new WarningEntityFactory(message);

			var stringResult = repo.WriteLog(errorFactory);

			var result = this.DeserializeJsonObject<WarningLogEntity>(stringResult);

			Assert.Equal(result.Type, "WARNING");
			Assert.Equal(result.Message, message);
        }
		#endregion

		#region Console log tests
		[Fact]
		public void LogErrorToConsole()
		{
			string message = "TEST MESSAGE";

			var repo = new ConsoleRepositoryFactory().CreateRepository();
			var errorFactory = new ErrorEntityFactory(message);

			var stringResult = repo.WriteLog(errorFactory);

			var result = this.DeserializeJsonObject<ErrorLogEntity>(stringResult);

			Assert.Equal(result.Type, "ERROR");
			Assert.Equal(result.Message, message);
            Assert.Equal(ConsoleColor.Red, Console.ForegroundColor);
		}
		[Fact]
		public void LogMessageToConsole()
		{
			string message = "TEST MESSAGE";

			var repo = new ConsoleRepositoryFactory().CreateRepository();
			var errorFactory = new MessageEntityFactory(message);

			var stringResult = repo.WriteLog(errorFactory);

			var result = this.DeserializeJsonObject<MessageLogEntity>(stringResult);

			Assert.Equal(result.Type, "MESSAGE");
			Assert.Equal(result.Message, message);
			Assert.Equal(ConsoleColor.Blue, Console.ForegroundColor);
		}
		[Fact]
		public void LogWarningToConsole()
		{
			string message = "TEST MESSAGE";

			var repo = new ConsoleRepositoryFactory().CreateRepository();
			var errorFactory = new WarningEntityFactory(message);

			var stringResult = repo.WriteLog(errorFactory);

			var result = this.DeserializeJsonObject<WarningLogEntity>(stringResult);

			Assert.Equal(result.Type, "WARNING");
			Assert.Equal(result.Message, message);
			Assert.Equal(ConsoleColor.Yellow, Console.ForegroundColor);
		}
		#endregion

		#region Mongo log test
		[Fact]
		public void LogErrorToMongoDb()
		{
			string message = "TEST MESSAGE";

			var repo = new MongoRepositoryFactory().CreateRepository();
			var errorFactory = new ErrorEntityFactory(message);

			var stringResult = repo.WriteLog(errorFactory);

			var result = this.DeserializeJsonObject<ErrorLogEntity>(stringResult);

			Assert.Equal(result.Type, "ERROR");
			Assert.Equal(result.Message, message);
		}
		[Fact]
		public void LogMessageToMongoDb()
		{
			string message = "TEST MESSAGE";

			var repo = new MongoRepositoryFactory().CreateRepository();
			var errorFactory = new MessageEntityFactory(message);

			var stringResult = repo.WriteLog(errorFactory);

			var result = this.DeserializeJsonObject<MessageLogEntity>(stringResult);

			Assert.Equal(result.Type, "MESSAGE");
			Assert.Equal(result.Message, message);
		}
		[Fact]
		public void LogWarningToMongoDb()
		{
			string message = "TEST MESSAGE";

			var repo = new MongoRepositoryFactory().CreateRepository();
			var errorFactory = new WarningEntityFactory(message);

			var stringResult = repo.WriteLog(errorFactory);

			var result = this.DeserializeJsonObject<WarningLogEntity>(stringResult);

			Assert.Equal(result.Type, "WARNING");
			Assert.Equal(result.Message, message);
		}
        #endregion
    }
}
