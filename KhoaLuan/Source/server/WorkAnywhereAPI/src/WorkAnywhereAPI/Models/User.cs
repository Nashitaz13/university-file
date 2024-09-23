using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WorkAnywhereAPI.Models
{    
    public class User : EntityBase
    {
        #region Properties

        /// <summary>
        /// The Id of user
        /// </summary>
        [BsonElement("UserId")]
        public string UserId { get; set; }

        /// <summary>
        /// Is admin user
        /// </summary>
        [BsonElement("IsAdmin")]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// The display name of user
        /// </summary>
        [BsonElement("DisplayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The user name
        /// </summary>
        [BsonElement("UserName")]
        public string UserName { get; set; }

        /// <summary>
        /// The password
        /// </summary>
        [BsonElement("Password")]
        public string Password { get; set; }

        /// <summary>
        /// The gender
        /// True: Male
        /// False: Female
        /// </summary>
        [BsonElement("Gender")]
        public bool Gender { get; set; }

        /// <summary>
        /// The email of user
        /// </summary>
        [BsonElement("Email")]
        public string Email { get; set; }

        /// <summary>
        /// The phone of user
        /// </summary>
        [BsonElement("Phone")]
        public string Phone { get; set; }
        
        /// <summary>
        /// The address of user
        /// </summary>
        [BsonElement("Location")]
        public GeoPoint Location { get; set; }
        
        /// <summary>
        /// True if user is verified, else false
        /// </summary>
        [BsonElement("IsVerified")]
        public bool IsVerified { get; set; }

        [BsonElement("BirthDay")]
        public string BirthDay { get; set; }

        /// <summary>
        /// Auth type of user
        /// </summary>
        [BsonElement("AuthType")]
        public AuthTypeEnum AuthType { get; set; }

        [BsonElement("AvartarPath")]
        public string AvartarPath { get; set; }

        [BsonElement("AboutMe")]
        public string AboutMe { get; set; }
        
        #endregion

    }
}
