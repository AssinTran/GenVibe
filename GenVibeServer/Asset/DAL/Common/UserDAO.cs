namespace GenVibeServer.Asset.DAL.Common
{
    public class UserDAO
    {
        #region Singleton
        private static readonly object Lock = new object();
        private static UserDAO instance = null;
        public static UserDAO Instance
        {
            get
            {
                lock (Lock)
                {
                    return (instance == null) ? new UserDAO() : instance;
                }
            }
        }
        UserDAO() { }
        #endregion

        #region Logic

        #endregion
    }
}
