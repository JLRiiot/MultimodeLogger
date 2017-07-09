using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Logger.Contracts
{
    public interface ILogEntity
    {
        [BsonId]
        ObjectId LogId { get; set; }
        [BsonRequired]
        string Type { get; set; }
        [BsonRequired]
        DateTime Date { get; set; }
        [BsonRequired]
        string Message { get; set; }
        [BsonRequired]
        string FormattedDate { get; set; }

        string ToJSON();
    }
}
