using AssetViewServer.Models;
using MongoDB.Driver;

namespace AssetViewServer.Database
{
    public interface IAssetViewDatabase
    {
        IMongoCollection<Entity> Entities { get; }
        IMongoCollection<EntityLink> EntityLinks { get; }
    }
}