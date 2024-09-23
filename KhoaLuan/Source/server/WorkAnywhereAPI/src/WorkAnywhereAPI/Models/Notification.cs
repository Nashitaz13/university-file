using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace WorkAnywhereAPI.Models
{
    public class Notification : EntityBase
    {
        [BsonElement("Type")]
        public string Type { get; set; }

        [BsonElement("SensorId")]
        public string SensorId { get; set; }

        [BsonElement("ReceiveId")]
        public string ReceiveId { get; set; }
        
        [BsonElement("Message")]
        public NotificationMessage Message { get; set; }

        [BsonElement("Channel")]
        public string Channel { get; set; }

        [BsonElement("Created")]
        public DateTime Created { get; set; }

    }
}
