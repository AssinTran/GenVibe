using GenVibeServer.Asset.DAL.Auth;
using GenVibeServer.Asset.DAL.IAuth;
using GenVibeServer.Asset.DTO.Common;

namespace GenVibeServer.Asset.BUS.Auth
{
    public class AuthBUS
    {
        private IAuthDAO _authDAO;
        public string Error { get; set; }
        private static AuthBUS? instance;
        private static readonly object Lock = new object();
        AuthBUS()
        {
            this._authDAO = AuthDAO.Instance;
        }
        public static AuthBUS Instance
        {
            get
            {
                lock (Lock)
                {
                    return (instance == null) ? new AuthBUS() : instance;
                }
            }
        }

        #region Enforcement
        public bool Login(string username, string password)
        {
            this.Error = _authDAO.Error;
            return _authDAO.Login(username, password);
        }

        public bool Register(UserDTO user)
        {
            this.Error = _authDAO.Error;
            return _authDAO.Register(user);
        }
        #endregion
    }
}
