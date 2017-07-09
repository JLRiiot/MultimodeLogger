using System;
using MongoDB.Driver;
using Logger.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Logger.Services
{
	public class MongoLogService : ILogService
    {
        private const string COLLECTION_NAME = "LogCollection";
        private IMongoCollection<ILogEntity> LogCollection;

        public MongoLogService(IMongoDatabase mongoClient)
        {
            this.LogCollection = mongoClient.GetCollection<ILogEntity>(COLLECTION_NAME);
        }

        public async Task<List<ILogEntity>> GetAllAsync()
        {
            var logs = new List<ILogEntity>();

            var allLogDocuments = await LogCollection.FindAsync(new BsonDocument());
            await allLogDocuments.ForEachAsync(doc => logs.Add(doc));

            return logs;
        }

        public string Insert(ILogEntity logEntity)
        {
            LogCollection.InsertOne(logEntity);

            return logEntity.ToJSON();
        }

		public void Dispose()
		{
			LogCollection = null;
		}
    }
}