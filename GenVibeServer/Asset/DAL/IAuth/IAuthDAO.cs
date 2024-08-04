using GenVibeServer.Asset.DTO.Common;

namespace GenVibeServer.Asset.DAL.IAuth
{
    public interface IAuthDAO
    {
        public string Error { get; set; }
        public bool Login(string username, string password);
        public bool Register(UserDTO user);
    }
}
