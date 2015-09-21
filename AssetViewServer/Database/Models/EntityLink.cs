namespace AssetViewServer.Database.Models
{
    public class EntityLink : IDocument
    {
        public string Id { get; set; }

        public string Lhs { get; set; }

        public string Rhs { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }
    }
}