using System.Threading.Tasks;
using AssetViewServer.Models;

namespace AssetViewServer.Database.Collections
{
    public interface IEntities
    {
        Task<Entity> FindAsync(string entityId);
    }
}