using MongoDB.Bson.Serialization.Attributes;
using WorkAnywhereAPI.Utilities;

namespace WorkAnywhereAPI.Models
{
    public class Post : EntityBase
    {
        #region Properties

        /// <summary>
        /// The Id of post
        /// </summary>
        [BsonElement("PostId")]
        public string PostId { get; set; }

        /// <summary>
        /// The author id of post
        /// </summary>
        [BsonElement("AuthorId")]
        public string AuthorId { get; set; }

        /// <summary>
        /// The author name of post
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// The title of post
        /// </summary>
        [BsonElement("Title")]
        public string Title { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        [BsonElement("Description")]
        public string Description { get; set; }

        /// <summary>
        /// The Category of post
        /// </summary>
        [BsonElement("Category")]
        public int Category { get; set; }

        /// <summary>
        /// The state of post
        /// </summary>
        [BsonElement("State")]
        public StateMachineEnum State { get; set; }

        /// <summary>
        /// The date expired of post
        /// </summary>
        [BsonElement("DateExpired")]
        public string DateExpired { get; set; }

        /// <summary>
        /// The location of post
        /// </summary>
        [BsonElement("Location")]
        public GeoPoint Location { get; set; }

        /// <summary>
        /// Distance from location of user to location post
        /// </summary>
        public string Distance { get; set; }

        /// <summary>
        /// Distance from location of user to location post
        /// </summary>
        public double DistanceNumber { get; set; }

        /// <summary>
        /// The counts a view of post 
        /// </summary>
        [BsonElement("PostViewCount")]
        public long PostViewCount { get; set; }

        /// <summary>
        /// The last modified of post
        /// </summary>
        [BsonElement("LastModified")]
        public string LastModified { get; set; }

        /// <summary>
        /// The created of post
        /// </summary>
        [BsonElement("CreateDate")]
        public string CreatedDate { get; set; }

        /// <summary>
        /// The salary of post
        /// </summary>
        [BsonElement("Salary")]
        public double Salary { get; set; }

        /// <summary>
        /// The units  of salary
        /// </summary>
        [BsonElement("Unit")]
        public int Unit { get; set; }

        /// <summary>
        /// The contract type of post
        /// </summary>
        [BsonElement("ContractType")]
        public int ContractType { get; set; }

        /// <summary>
        /// The key word of post
        /// </summary>
        [BsonElement("KeyWord")]
        public string KeyWord { get; set; }

        [BsonElement("Type")]
        public string Type { get; set; }

        #endregion
    }
}
