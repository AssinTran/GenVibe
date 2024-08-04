using MongoDB.Driver;

namespace GenVibeServer.Asset.DAL.Database
{
    public class Connector
    {
        private IMongoDatabase _database;

        Connector()
        {
            var connectionString = "mongodb+srv://owner:owner@cluster0.3rp8zzn.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
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
