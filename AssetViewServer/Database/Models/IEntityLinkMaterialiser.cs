namespace AssetViewServer.Database.Models
{
	using System.Threading.Tasks;

	public interface IEntityLinkMaterialiser
    {
		Task<EntityLinksMaterialised> GetLinksAsync(string entityId);
    }
}