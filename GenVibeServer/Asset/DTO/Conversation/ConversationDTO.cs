using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GenVibeServer.Asset.DTO.Conversation
{
    [BsonIgnoreExtraElements]
    public class ConversationDTO
    {
        #region Attributes
        private string[]? participants; // list participants in the conversation
        private string[]? messages; // list id of message

        public ConversationDTO() { }

        #endregion

        #region Properties
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("participants")]
        public string[]? Participants { get; set; } // list participants in the conversation
        [BsonElement("messages")]
        public string[]? Messages { get; set; } // list id of message
        #endregion
    }
}
