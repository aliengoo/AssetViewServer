namespace AssetViewServer.Models
{
    public class EntityLinkBundle
    {
        public Entity Entity { get; set; }

        public Entity Lhs { get; set; }
        public Entity Rhs { get; set; }
        
        public EntityLink Link { get; set; }

        public string Description { get; set; }
    }
}