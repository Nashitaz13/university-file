using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WorkAnywhereAPI.Models
{
    public abstract class EntityBase
    {
        /// <summary>
        /// Object Id
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
    }
}
