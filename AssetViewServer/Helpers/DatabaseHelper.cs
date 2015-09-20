using MongoDB.Driver;

namespace AssetViewServer.Helpers
{
    public static class DatabaseHelper
    {
        public static MongoDatabase Connect(string databaseUrl)
        {
            var url = MongoUrl.Create(databaseUrl);

            return new MongoClient(url).GetServer().GetDatabase(url.DatabaseName);
        }
 
    }
}