namespace WorkAnywhereAPI.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    public class Unit : EntityBase
    {
        [BsonElement("UnitId")]
        public int UnitId {get; set;}

        [BsonElementAttribute("Name")]
        public string Name {get; set;}

    }
}