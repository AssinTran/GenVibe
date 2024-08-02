namespace GenVibeServer.Asset.DTO.Conversation
{
    public class ConversationDTO
    {
        #region Attributes
        private List<string> participants; // list participants in the conversation
        private List<string> messages; // list id of message

        public ConversationDTO()
        {
            this.participants = new List<string>();
            this.messages = new List<string>();
        }

        #endregion

        #region Properties
        public List<string> Participants { get; set; } // list participants in the conversation
        public List<string> Messages { get; set; } // list id of message
        #endregion
    }
}
