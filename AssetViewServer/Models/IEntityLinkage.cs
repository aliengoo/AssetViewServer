using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetViewServer.Models
{
    public interface IEntityLinkage
    {
        Task<IList<EntityLinkBundle>> GetLinksAsync(string entityId);
    }
}