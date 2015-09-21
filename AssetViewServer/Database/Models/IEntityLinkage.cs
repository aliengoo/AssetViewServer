namespace AssetViewServer.Database.Models
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public interface IEntityLinkage
    {
        Task<IList<EntityLinkBundle>> GetLinksAsync(string entityId);
    }
}