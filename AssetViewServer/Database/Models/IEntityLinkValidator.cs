namespace AssetViewServer.Database.Models
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public interface IEntityLinkValidator
	{
		Task<IDictionary<string, string>> Validate(EntityLink entityLink);
	}
}