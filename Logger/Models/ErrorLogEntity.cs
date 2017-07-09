using System;
using Logger.Contracts;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Logger.Models
{
    [BsonDiscriminator]
    public class ErrorLogEntity : ILogEntity
    {
        public ErrorLogEntity(string message, DateTime logDate)
        {
            Message = message;
            Date = logDate;
        }

		public ObjectId LogId { get; set; }
		public string Type
		{
			get => "ERROR";
			set
			{
				//TODO: remove this setter. Research how to configure BsonMapper 
			}
		}
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string FormattedDate
        {
            get
            {
                return Date.ToString("yyyy-M-d hh:mm:ss");
            }
            set
            {
                //TODO: remove this setter. Research how to configure BsonMapper
            }
        }

        public string ToJSON()
        {
            return this.ToJson();
        }
    }
}
