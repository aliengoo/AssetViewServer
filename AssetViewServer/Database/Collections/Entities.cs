using System.Threading.Tasks;
using AssetViewServer.Models;
using MongoDB.Driver;

namespace AssetViewServer.Database.Collections
{
    public class Entities : IEntities
    {
        private readonly IAssetViewDatabase _database;

        public Entities(IAssetViewDatabase database)
        {
            _database = database;
            
        }

        public async Task<Entity> FindAsync(string entityId)
        {
            var filter = Builders<Entity>.Filter.Eq(e => e.Id, entityId);

            return await _database.Entities.Find(filter).FirstAsync();
        } 
    }
}