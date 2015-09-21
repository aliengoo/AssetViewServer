using System.Threading.Tasks;
using AssetViewServer.Database;

namespace AssetViewServer.Controllers
{
	using AssetViewServer.Database.Models;

	public class EntityController
    {
        private readonly IAssetViewDatabase _assetViewDatabase;

        public EntityController(IAssetViewDatabase assetViewDatabase)
        {
            _assetViewDatabase = assetViewDatabase;
        }

        public async Task<Entity> Get(string entityId)
        {
            return
        }
    }
}