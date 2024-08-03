using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GenVibeServer.Asset.DTO.Conversation
{
    [BsonIgnoreExtraElements]
    public class MessageDTO
    {
        #region Attributes
        private string message;
        private DateTime date;
        private string sender; // Id of sender
        private string receiver; // Id of receiver

        public MessageDTO() { }
        public MessageDTO(string message, DateTime date, string sender, string receiver)
        {
            this.message = message;
            this.date = date;
            this.sender = sender;
            this.receiver = receiver;
        }
        #endregion

        #region Properties
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }
        [BsonElement("message")]
        public required string Message { get; set; }
        [BsonElement("date")]
        public DateTime Date { get; set; }
        [BsonElement("sender")]
        public required string Sender { get; set; }
        [BsonElement("receiver")]
        public required string Receiver { get; set; }
        #endregion
    }
}
