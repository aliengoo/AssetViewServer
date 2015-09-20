using System.Collections.Generic;
using System.Threading.Tasks;
using AssetViewServer.Models;
using MongoDB.Driver;

namespace AssetViewServer.Database.Collections
{
    public class EntityLinks : IEntityLinks
    {
        private readonly IAssetViewDatabase _assetViewDatabase;

        public EntityLinks(IAssetViewDatabase assetViewDatabase)
        {
            _assetViewDatabase = assetViewDatabase;
        }

        /// <summary>
        /// Finds <see cref="EntityLink"/> where either the lhs or rhs match the <paramref name="entityId"/>.
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>Async enumerable of <see cref="EntityLink"/></returns>
        public async Task<IEnumerable<EntityLink>> FindOnEitherSideAsync(string entityId)
        {
            var query = Builders<EntityLink>
              .Filter
              .Where(el => el.Lhs == entityId || el.Rhs == entityId);

            return await _assetViewDatabase.EntityLinks.Find(query).ToListAsync();
        }
    }
}