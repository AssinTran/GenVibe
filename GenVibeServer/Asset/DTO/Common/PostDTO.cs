namespace GenVibeServer.Asset.DTO.Common
{
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
        public required string Id { get; set; }
        public required string Content { get; set; }
        public required DateTime Date { get; set; }
        public List<string> Likes { get; set; } // list id of user who like the post
        public List<string> Comments { get; set; } // list id of user who comment the post
        public List<string> RePost { get; set; } // list id of user who re-post the post
        #endregion
    }
}
