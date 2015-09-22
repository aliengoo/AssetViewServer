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
	    protected TCollection Collection { get; }

	    public AssetViewController(TCollection collection)
		{
			Collection = collection;
		}
        
		[HttpGet]
		[Route("{id}")]
		public async virtual Task<TDoc> GetAsync(string id)
		{
			return await Collection.FindByIdAsync(id);
		}

		[HttpPost]
		[Route("{id}")]
		public async virtual Task<TDoc> PostAsync(TDoc doc)
		{
			return await Collection.SaveAsync(doc);
		}

		[HttpPut]
		[Route("{id}")]
		public async virtual Task<TDoc> PutAsync(TDoc doc)
		{
			return await Collection.SaveAsync(doc);
		}

		[HttpDelete]
		[Route("{id}")]
		public async virtual Task<HttpResponseMessage> DeleteAsync(string id)
		{
			await Collection.DeleteAsync(id);

			return new HttpResponseMessage(HttpStatusCode.OK);
		}
	}   
}