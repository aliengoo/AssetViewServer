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

		/// <summary>
		/// Returns every link <paramref name="entityId"/> is on the rhs
		/// </summary>
		/// <param name="entityId"></param>
		/// <returns>Enumerable of <see cref="EntityLink"/></returns>
		[HttpGet]
		[Route("lhs/{id}")]
		public Task<IEnumerable<EntityLink>> GetLhs(string entityId)
		{
			return Collection.FindOnLhs(entityId);
		}

		/// <summary>
		/// Returns every link <paramref name="entityId"/> is on the lhs
		/// </summary>
		/// <param name="entityId"></param>
		/// <returns>Enumerable of <see cref="EntityLink"/></returns>
		[HttpGet]
		[Route("rhs/{id}")]
		public Task<IEnumerable<EntityLink>> GetRhs(string entityId)
		{
			return Collection.FindOnRhs(entityId);
		}
	}
}