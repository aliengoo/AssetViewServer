namespace AssetViewServer.Database.Models
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using AssetViewServer.Database.Collections;

	public class EntityLinkValidator : IEntityLinkValidator
	{
		private readonly IEntityLinks _entityLinks;

		private readonly IEntities _entities;

		public EntityLinkValidator(IEntityLinks entityLinks, IEntities entities)
		{
			_entityLinks = entityLinks;
			_entities = entities;
		}

		public async Task<IDictionary<string, string>> Validate(EntityLink entityLink)
		{
			var lhsExists = await _entities.Exists(TODO);

			var result = new Dictionary<string, string>();
			
			if (!lhsExists)
			{
				result.Add("Lhs", $"Link invalid - Entity identified by {entityLink.Lhs} on the LHS was not found");
			}

			var rhsExists = await _entities.Exists(TODO);

			if (!rhsExists)
			{
				result.Add("Rhs", $"Link invalid - Entity identified by {entityLink.Rhs} on the RHS was not found");
			}

			var entity = await _entities.FindByIdAsync(entityLink.Link);

			if (entity == null)
			{
				result.Add("Link", $"Link invalid - Entity identified by {entityLink.Link} was not found");
			}
			else if (entity.Classificiation != EntityClassification.Adjective)
			{
				result.Add("Link", $"Link invalid - Entity identified by {entityLink.Link} was not an Adjective");
			}

			return result;
		}
	}
}