using GenVibeServer.Asset.DAL.Auth;
using GenVibeServer.Asset.DAL.IAuth;
using GenVibeServer.Asset.DTO.Common;

namespace GenVibeServer.Asset.BUS.Auth
{
    public class AuthBUS
    {
        private IAuthDAO _authDAO;
        public string Error { get; set; }
        public string User { get; set; }
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
            bool status = _authDAO.Login(username, password);
            this.Error = _authDAO.Error;
            this.User = _authDAO.User;

            return status;
        }

        public bool Register(UserDTO user)
        {
            bool status = _authDAO.Register(user);
            this.Error = _authDAO.Error;
            this.User = _authDAO.User;
            
            return status;
        }
        #endregion
    }
}
