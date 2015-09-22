﻿using MongoDB.Driver;

namespace AssetViewServer.Database
{
	using AssetViewServer.Configuration;
	using AssetViewServer.Database.Models;

	using MongoDB.Bson;
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
			// register the conventions
			var pack = new ConventionPack
							{
								new CamelCaseElementNameConvention(),
								new EnumRepresentationConvention(BsonType.String)
							};

			ConventionRegistry.Register("conventions", pack, t => true);
		}

		public AssetViewDatabase(IAssetViewConfiguration assetViewConfiguration)
        {
            var url = MongoUrl.Create(assetViewConfiguration.AssetViewConnectionString);
            _database =  new MongoClient(url).GetDatabase(url.DatabaseName);
        }

        // functions
    }
}