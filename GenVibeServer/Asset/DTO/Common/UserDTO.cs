using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GenVibeServer.Asset.DTO.Common
{
    [BsonIgnoreExtraElements]
    public class UserDTO
    {
        #region Attributes
        private string username;
        private string password;
        private string email;
        private string phone;
        private string fullname;
        private string avatar;

        public UserDTO() { }

        public UserDTO(string username, string password, string email, string phone, string fullname)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.phone = phone;
            this.fullname = fullname;
        }
        #endregion

        #region Properties
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("username")]
        public string Username { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
        [BsonElement("fullname")]
        public string FullName { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("phone")]
        public string? Phone { get; set; }
        [BsonElement("avatar")]
        public string? Avatar { get; set; }
        [BsonElement("posts")]
        public string[]? Posts { get; set; } // list id of post
        [BsonElement("friends")]
        public string[]? Friends { get; set; } // list id of friends
        #endregion
    }
}
