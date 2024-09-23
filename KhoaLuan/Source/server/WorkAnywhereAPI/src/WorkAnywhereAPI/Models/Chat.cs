namespace WorkAnywhereAPI.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    public class Chat : EntityBase
    {
        [BsonElement("Chanel")]
        public string Chanel { get; set; }

        [BsonElement()]
        public string SensorId { get; set; }

        [BsonElement()]
        public string ReceiveId { get; set; }

        [BsonElement()]
        public string Name { get; set; }

        [BsonElement()]
        public string Time { get; set; }

        [BsonElement()]
        public string ImagePath { get; set; }
    }
}
