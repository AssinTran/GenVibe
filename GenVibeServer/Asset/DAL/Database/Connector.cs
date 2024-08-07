using MongoDB.Driver;

namespace GenVibeServer.Asset.DAL.Database
{
    public class Connector
    {
        private MongoClient client;

        Connector()
        {
            var connectionString = "mongodb+srv://owner:owner@cluster0.3rp8zzn.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
            client = new MongoClient(connectionString);
            Database = client.GetDatabase("GenVibe");
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
