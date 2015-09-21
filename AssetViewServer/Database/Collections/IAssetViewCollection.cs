namespace AssetViewServer.Database.Collections
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using AssetViewServer.Database.Models;

	using MongoDB.Driver;

	public interface IAssetViewCollection<TDoc>
		where TDoc : IDocument
	{
		Task<TDoc> FindByIdAsync(string id);

		Task<IEnumerable<TDoc>> FindAsync(FilterDefinition<TDoc> filter);

		Task<TDoc> SaveAsync(TDoc doc);

		Task<bool> DeleteAsync(string id);
	}
}