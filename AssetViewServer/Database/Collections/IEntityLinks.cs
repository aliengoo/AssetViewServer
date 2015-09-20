using System.Collections.Generic;
using System.Threading.Tasks;
using AssetViewServer.Models;

namespace AssetViewServer.Database.Collections
{
    public interface IEntityLinks
    {
        Task<IEnumerable<EntityLink>> FindOnEitherSideAsync(string entityId);
    }
}