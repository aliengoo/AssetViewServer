namespace AssetViewServer.Database.Models
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	using AssetViewServer.Database.Collections;

	public class EntityLinkMaterialiser : IEntityLinkMaterialiser
    {
        private readonly IEntityLinks _entityLinks;
        private readonly IEntities _entities;

        public EntityLinkMaterialiser(IEntityLinks entityLinks, IEntities entities)
        {
            _entityLinks = entityLinks;
            _entities = entities;
        }

        public async Task<EntityLinksMaterialised> GetLinksAsync(string entityId)
        {
            var entityLinks = await _entityLinks.FindOnEitherSideAsync(entityId);

            var tasks = entityLinks.Select(async el =>
            {
                var elb = new EntityLinkMaterialised()
                {
                    Description = el.Description,
					Link = await _entities.FindByIdAsync(el.Link)
                };

				if (el.Lhs != entityId)
				{
					elb.Lhs = await _entities.FindByIdAsync(el.Lhs);
				}

				if (el.Rhs != entityId)
				{
					elb.Rhs = await _entities.FindByIdAsync(el.Rhs);
				}

                return elb;
            });

            var links = await Task.WhenAll(tasks);

	        var entityLinksMaterialised = new EntityLinksMaterialised
																{
																	Entity = await _entities.FindByIdAsync(entityId),
																	Links = links
																};

	        return entityLinksMaterialised;
        }
    }
}