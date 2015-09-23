using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetViewServer.Database.Collections
{
	using AssetViewServer.Database.Models;

	public interface IEntityLinks : IAssetViewCollection<EntityLink>
	{
        Task<IEnumerable<EntityLink>> FindOnEitherSideAsync(string entityId);

		Task<IEnumerable<EntityLink>> FindOnLhs(string entityId);

		Task<IEnumerable<EntityLink>> FindOnRhs(string entityId);
    }
}