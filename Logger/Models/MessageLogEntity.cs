using System;
using Logger.Contracts;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Logger.Models
{
    public class MessageLogEntity : ILogEntity
    {
        public MessageLogEntity(string message, DateTime logDate)
		{
			Message = message;
			Date = logDate;
		}

		public string Type { 
            get => "MESSAGE"; 
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
			return JsonConvert.SerializeObject(this);
		}
    }
}
