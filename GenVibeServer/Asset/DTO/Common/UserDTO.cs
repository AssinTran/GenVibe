namespace GenVibeServer.Asset.DTO.Common
{
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

        public UserDTO(string username, string password, string email, string phone, string fullname, string avatar)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.phone = phone;
            this.fullname = fullname;
            this.avatar = avatar;
        }
        #endregion

        #region Properties
        public required string Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public string? Avatar { get; set; }
        public List<string> Posts { get; set; } // list id of post
        public List<string> Friends { get; set; } // list id of friends
        #endregion
    }
}
