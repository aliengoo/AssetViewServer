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

		public Task<IEnumerable<EntityLink>> FindOnLhs(string entityId)
		{
			return FindOnSide(Side.Lhs, entityId);
		}

		public Task<IEnumerable<EntityLink>> FindOnRhs(string entityId)
		{
			return FindOnSide(Side.Rhs, entityId);
		}

		private async Task<IEnumerable<EntityLink>> FindOnSide(Side side, string entityId)
		{
			
			var filter = side == Side.Lhs
							? Builders<EntityLink>.Filter.Eq(el => el.Rhs, entityId)
							: Builders<EntityLink>.Filter.Eq(el => el.Lhs, entityId);

			return await Collection.Find(filter).ToListAsync();
		}

		public async new Task<EntityLinkResult> SaveAsync(EntityLink entityLink)
		{
			// before saving, the lhs, rhs and link entities must exist

			
		}
    }
}