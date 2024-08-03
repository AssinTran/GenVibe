using MongoDB.Driver;

namespace GenVibeServer.Asset.DAL.Database
{
    public class Connector
    {
        private IMongoDatabase _database;

        Connector()
        {
            var connectionString = "";
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("GenVibe");
        }

        private static readonly object Lock = new object();
        private static Connector instance = null;
        public static Connector Instance
        {
            get
            {
                lock (Lock)
                {
                    return ( instance == null ) ? new Connector() : instance;
                }
            }
        }

        public IMongoDatabase Database { get; set; }
    }
}
