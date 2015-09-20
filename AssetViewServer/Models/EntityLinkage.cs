using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetViewServer.Database.Collections;

namespace AssetViewServer.Models
{
    public class EntityLinkage : IEntityLinkage
    {
        private readonly IEntityLinks _entityLinks;
        private readonly IEntities _entities;

        public EntityLinkage(IEntityLinks entityLinks, IEntities entities)
        {
            _entityLinks = entityLinks;
            _entities = entities;
        }

        public async Task<IList<EntityLinkBundle>> GetLinksAsync(string entityId)
        {
            var entityLinks = await _entityLinks.FindOnEitherSideAsync(entityId);

            var tasks = entityLinks.Select(async el =>
            {
                var elb = new EntityLinkBundle
                {
                    Description = el.Description,
                    Entity = await _entities.FindAsync(entityId),
                    Lhs = await _entities.FindAsync(el.Lhs),
                    Rhs = await _entities.FindAsync(el.Rhs)
                };

                return elb;
            });

            var results = await Task.WhenAll(tasks);
            
            return results;
        }
    }
}