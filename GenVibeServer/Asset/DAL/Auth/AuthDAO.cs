namespace GenVibeServer.Asset.DAL.Auth
{
    public class AuthDAO
    {
        #region Singleton
        AuthDAO() { }
        private static AuthDAO instance = null;
        private static readonly object Lock = new object();
        public static AuthDAO Instance
        {
            get
            {
                lock (Lock)
                {
                    return (instance == null) ? new AuthDAO() : instance;
                }
            }
        }
        #endregion

        #region Features
        /*
         * @attribute error - contain error message
         */
        private string error;

        /**
         * Login account to website
         * 
         * Check username and password match with data of user in database (db).
         * @return 
         *      - true: username and password match with data of user in db.
         *      - false: username and password do not match.
         * @params username - username need to check.
         * @params password - password need to check.
         */
        public bool Login(string username, string password)
        {
            return false;
        }

        /**
         * Register new account
         * 
         * It will have checked all information that is valid before it's
         * created new account and save in database.
         * 
         * @return
         *      - true: create new account successfully.
         *      - false: can not create new account with some problem.
         * @params User - object User has all informatiom to create account.
         */
        public bool Register(UserDTO User)
        {
            return false;
        }
        #endregion
    }
}
