namespace AssetViewServer.Controllers
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using System.Web.Http;

	using AssetViewServer.Database.Collections;
	using AssetViewServer.Database.Models;

	[RoutePrefix("api/entity-links")]
	public class EntityLinksController : AssetViewController<EntityLink, IEntityLinks>
	{
		private readonly IEntityLinkMaterialiser _entityLinkMaterialiser;

		public EntityLinksController(IEntityLinks collection, IEntityLinkMaterialiser entityLinkMaterialiser)
			: base(collection)
		{
			_entityLinkMaterialiser = entityLinkMaterialiser;
		}

		[HttpGet]
		[Route("bundle/{id}")]
		public Task<EntityLinksMaterialised> GetBundle(string id)
		{
			return _entityLinkMaterialiser.GetLinksAsync(id);
		}
	}
}