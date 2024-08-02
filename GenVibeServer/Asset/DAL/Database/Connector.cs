using MongoDB.Driver;

namespace GenVibeServer.Asset.DAL.Database
{
    public class Connector
    {
        private readonly IMongoDatabase _database;

        public Connector()
        {
            var connectionString = "";
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("GenVibe");
        }
    }
}
