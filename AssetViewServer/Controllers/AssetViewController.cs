namespace AssetViewServer.Controllers
{
	using System.Net;
	using System.Net.Http;
	using System.Threading.Tasks;
	using System.Web.Http;

	using AssetViewServer.Database.Collections;
	using AssetViewServer.Database.Models;

	public class AssetViewController<TDoc, TCollection> : ApiController
		where TDoc: IDocument
		where TCollection : IAssetViewCollection<TDoc>
	{
		private readonly TCollection _collection;

		public AssetViewController(TCollection collection)
		{
			_collection = collection;
		}

		[HttpGet]
		[Route("{id}")]
		public async virtual Task<TDoc> GetAsync(string id)
		{
			return await _collection.FindByIdAsync(id);
		}

		[HttpPost]
		[Route("{id}")]
		public async virtual Task<TDoc> PostAsync(TDoc doc)
		{
			return await _collection.SaveAsync(doc);
		}

		[HttpPut]
		[Route("{id}")]
		public async virtual Task<TDoc> PutAsync(TDoc doc)
		{
			return await _collection.SaveAsync(doc);
		}

		[HttpDelete]
		[Route("{id}")]
		public async virtual Task<HttpResponseMessage> DeleteAsync(string id)
		{
			await _collection.DeleteAsync(id);

			return new HttpResponseMessage(HttpStatusCode.OK);
		}
	}
}