using MongoDB.Driver;

namespace AssetViewServer.Database
{
	using AssetViewServer.Common;
	using AssetViewServer.Database.Models;

	using MongoDB.Bson.Serialization.Conventions;

	public class AssetViewDatabase : IAssetViewDatabase
    {
        // fields
        private readonly IMongoDatabase _database;

        // properties
        public IMongoCollection<Entity> Entities => _database.GetCollection<Entity>("entities");

        public IMongoCollection<EntityLink> EntityLinks => _database.GetCollection<EntityLink>("entityLinks");

		public IMongoDatabase Database => _database;

		// constructors
		static AssetViewDatabase()
		{
			var pack = new ConventionPack { new CamelCaseElementNameConvention() };

		}

        public AssetViewDatabase(IAssetViewConfiguration assetViewConfiguration)
        {
            var url = MongoUrl.Create(assetViewConfiguration.DatabaseUrl);
            _database =  new MongoClient(url).GetDatabase(url.DatabaseName);
        }

        // functions
    }
}