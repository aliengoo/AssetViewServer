using System.Threading.Tasks;
using System.Xml.Linq;

using MongoDB.Driver;

namespace AssetViewServer.Database.Collections
{
	using AssetViewServer.Database.Models;

	public class Entities : AssetViewCollection<Entity>, IEntities
    {
		public Entities(IAssetViewDatabase assetViewDatabase)
			: base("entities", assetViewDatabase)
		{
		}
    }
}