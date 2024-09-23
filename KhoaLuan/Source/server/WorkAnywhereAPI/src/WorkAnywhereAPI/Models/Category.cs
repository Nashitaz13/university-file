namespace WorkAnywhereAPI.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    public class Category : EntityBase
    {
        [BsonElement("CategoryId")]
        public int CategoryId {get; set;}

        [BsonElementAttribute("Name")]
        public string Name {get; set;}

        [BsonElementAttribute("ImagePath")]
        public string ImagePath {get; set;}
    }
}