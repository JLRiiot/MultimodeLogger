using System;
using Logger.Contracts;
using Logger.Factories;

namespace Logger.Repositories
{
    public class MongoDbLogRepository : LogRepository
    {
        private ILogService MongoDbLogService { get; set; }

        public MongoDbLogRepository(ILogService mongoDbLogService)
        {
            MongoDbLogService = mongoDbLogService;
        }

        public override string Type => "MONGO_DB";

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override string WriteLog(LogEntityFactory logEntityFactory)
        {
            var logEntity = logEntityFactory.CreateLogEntity();

            MongoDbLogService.Insert(logEntity);

            return logEntity.ToJSON();
        }
    }
}
