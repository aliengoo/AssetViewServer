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
		public EntityLinksController(
            IEntityLinks collection)
			: base(collection)
		{
		}
        
        [HttpGet]
        [Route("either-side/{id}")]
        public Task<IEnumerable<EntityLink>> GetEitherSide(string entityId)
	    {
	        return Collection.FindOnEitherSideAsync(entityId);
	    }
	}
}