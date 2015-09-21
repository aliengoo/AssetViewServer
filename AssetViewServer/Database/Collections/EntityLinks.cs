using System.Collections.Generic;
using System.Threading.Tasks;

using MongoDB.Driver;

namespace AssetViewServer.Database.Collections
{
	using AssetViewServer.Database.Models;

	public class EntityLinks : AssetViewCollection<EntityLink>, IEntityLinks
    {
		public EntityLinks(IAssetViewDatabase assetViewDatabase)
			: base("entityLinks", assetViewDatabase)
		{
		}

		/// <summary>
        /// Finds <see cref="EntityLink"/> where either the lhs or rhs match the <paramref name="entityId"/>.
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>Async enumerable of <see cref="EntityLink"/></returns>
        public async virtual Task<IEnumerable<EntityLink>> FindOnEitherSideAsync(string entityId)
        {
            var query = Builders<EntityLink>
              .Filter
              .Where(el => el.Lhs == entityId || el.Rhs == entityId);

            return await Collection.Find(query).ToListAsync();
        }
    }
}