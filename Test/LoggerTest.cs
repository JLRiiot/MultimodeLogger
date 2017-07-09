using System;
using Logger;
using Logger.Contracts;
using Xunit;

namespace Test
{
    public class LoggerTest
    {
        [Fact]
        public void LogToFileTest()
        {
            ILogger logger = new Log();
        }

        [Fact]
        public void LogToConsoleTest()
        {
            
        }

        [Fact]
        public void LogToMongoDbTest()
        {
            
        }
    }
}
