namespace AssetViewServer.Controllers
{
	using System.Web.Http;

	using AssetViewServer.Database.Collections;
	using AssetViewServer.Database.Models;

	[RoutePrefix("api/entity-link")]
	public class EntityLinkController : AssetViewController<EntityLink, IEntityLinks>
	{
		public EntityLinkController(IEntityLinks collection)
			: base(collection)
		{
		}
	}
}