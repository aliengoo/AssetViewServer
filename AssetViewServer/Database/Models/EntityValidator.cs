namespace AssetViewServer.Database.Models
{
	using System.Threading.Tasks;

	using AssetViewServer.Database.Collections;

	using MongoDB.Driver;

	public class EntityValidator : IEntityValidator
	{
		private readonly IEntities _entities;

		public EntityValidator(IEntities entities)
		{
			_entities = entities;
		}

		public async Task<bool> Is(string entityId, EntityClassification entityClassification)
		{
			var filter =
				Builders<Entity>.Filter.Where(
					e => e.Id == entityId && e.Classificiation == entityClassification);

			return await _entities.Exists(filter);
		}
	}
}