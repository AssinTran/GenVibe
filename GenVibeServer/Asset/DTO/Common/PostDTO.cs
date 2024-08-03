using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GenVibeServer.Asset.DTO.Common
{
    [BsonIgnoreExtraElements]
    public class PostDTO
    {
        #region Attributes
        private string content;
        private DateTime date;
        private List<string> likes; // list id of user who like the post
        private List<string> comments; // list id of user who comment the post
        private List<string> rePost; // list id of user who re-post the post

        public PostDTO() { }

        public PostDTO(string content, DateTime date)
        {
            this.content = content;
            this.date = date;
            this.likes = new List<string>();
            this.comments = new List<string>();
            this.rePost = new List<string>();
        }
        #endregion

        #region Properties
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }
        [BsonElement("content")]   
        public required string Content { get; set; }
        [BsonElement("date")]
        public required DateTime Date { get; set; }
        [BsonElement("likes")]
        public string[]? Likes { get; set; } // list id of user who like the post
        [BsonElement("comments")]
        public string[]? Comments { get; set; } // list id of user who comment the post
        [BsonElement("reposts")]
        public string[]? RePost { get; set; } // list id of user who re-post the post
        #endregion
    }
}
