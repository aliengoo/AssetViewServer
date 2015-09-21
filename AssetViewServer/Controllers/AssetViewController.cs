namespace AssetViewServer.Controllers
{
	using System.Net;
	using System.Net.Http;
	using System.Threading.Tasks;

	using AssetViewServer.Database.Collections;
	using AssetViewServer.Database.Models;

	public class AssetViewController<TDoc, TCollection>
		where TDoc: IDocument
		where TCollection : IAssetViewCollection<TDoc>
	{
		private readonly TCollection _collection;


		public AssetViewController(TCollection collection)
		{
			_collection = collection;
		}

		public async Task<TDoc> GetAsync(string id)
		{
			return await _collection.FindByIdAsync(id);
		}

		public async Task<TDoc> SaveAsync(TDoc doc)
		{
			return await _collection.SaveAsync(doc);
		}

		public async Task<HttpResponseMessage> DeleteAsync(string id)
		{
			await _collection.DeleteAsync(id);

			return new HttpResponseMessage(HttpStatusCode.OK);
		}
	}
}