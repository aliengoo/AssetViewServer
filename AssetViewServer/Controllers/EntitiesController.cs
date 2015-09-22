namespace AssetViewServer.Controllers
{
	using System.Web.Http;

	using AssetViewServer.Database.Collections;
	using AssetViewServer.Database.Models;

	[RoutePrefix("api/entities")]
	public class EntitiesController : AssetViewController<Entity, IEntities>
	{
		public EntitiesController(IEntities collection)
			: base(collection)
		{
		}
	}
}