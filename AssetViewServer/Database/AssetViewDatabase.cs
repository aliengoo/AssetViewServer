using AssetViewServer.Models;
using MongoDB.Driver;

namespace AssetViewServer.Database
{
    public class AssetViewDatabase : IAssetViewDatabase
    {
        // fields
        private readonly IMongoDatabase _database;

        // properties
        public IMongoCollection<Entity> Entities => _database.GetCollection<Entity>("entities");

        public IMongoCollection<EntityLink> EntityLinks => _database.GetCollection<EntityLink>("entity-links");

        // constructors
        public AssetViewDatabase(string databaseUrl)
        {
            var url = MongoUrl.Create(databaseUrl);
            _database =  new MongoClient(url).GetDatabase(url.DatabaseName);
        }

        // functions
    }
}