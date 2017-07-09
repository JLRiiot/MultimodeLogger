using System;
using Logger.Contracts;

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

        public override void WriteLog(ILogEntity logEntity)
        {
            MongoDbLogService.Insert(logEntity);
        }
    }
}
