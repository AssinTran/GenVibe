namespace GenVibeServer.Asset.DTO.Conversation
{
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
        public required string Id { get; set; }
        public required string Message { get; set; }
        public DateTime Date { get; set; }
        public required string Sender { get; set; }
        public required string Receiver { get; set; }
        #endregion
    }
}
