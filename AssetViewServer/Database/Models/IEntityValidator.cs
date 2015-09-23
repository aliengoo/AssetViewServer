namespace AssetViewServer.Database.Models
{
	using System.Threading.Tasks;

	public interface IEntityValidator
	{
		Task<bool> Is(string entityId, EntityClassification entityClassification);
	}
}