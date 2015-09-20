using System.Threading.Tasks;
using System.Xml.Linq;
using AssetViewServer.Models;
using MongoDB.Driver;

namespace AssetViewServer.Database.Collections
{
    public class Entities : IEntities
    {
        private readonly IMongoCollection<Entity> _entities;

        public Entities(IAssetViewDatabase assetViewDatabase)
        {
            _entities = assetViewDatabase.Entities;
        }

        public async Task<Entity> FindAsync(string entityId)
        {
            var filter = Builders<Entity>.Filter.Eq(e => e.Id, entityId);

            return await _entities.Find(filter).FirstAsync();
        }

        public async Task<Entity> Save(Entity entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                await _entities.InsertOneAsync(entity);
            }
            else
            {
                
                return _entities.FindOneAndUpdateAsync()
            }

            return entity;
        }

        public async Task Delete(string entityId)
        {
            var filter = Builders<Entity>.Filter.Eq(e => e.Id, entityId);

            await _entities.DeleteOneAsync(filter);
        } 
    }
}