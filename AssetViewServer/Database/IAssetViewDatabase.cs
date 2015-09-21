using MongoDB.Driver;

namespace AssetViewServer.Database
{
	using AssetViewServer.Database.Models;

	public interface IAssetViewDatabase
    {
        IMongoCollection<Entity> Entities { get; }
        IMongoCollection<EntityLink> EntityLinks { get; }

		IMongoDatabase Database { get; }
    }
}