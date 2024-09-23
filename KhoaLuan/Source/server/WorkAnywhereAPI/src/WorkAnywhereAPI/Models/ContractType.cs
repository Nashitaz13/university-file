namespace WorkAnywhereAPI.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    public class ContractType : EntityBase
    {
        [BsonElement("ContractTypeId")]
        public int ContractTypeId {get; set;}

        [BsonElementAttribute("Name")]
        public string Name {get; set;}

    }
}