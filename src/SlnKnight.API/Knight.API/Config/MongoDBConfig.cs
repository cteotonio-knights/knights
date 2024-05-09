using MongoDB.Driver;

namespace Knight.API.Config
{
    public class MongoDBConfig
    {
        public static IMongoDatabase Connect(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MongoDBConnection");
            var client = new MongoClient(connectionString);
            return client.GetDatabase("db_knight");
        }
    }
}
