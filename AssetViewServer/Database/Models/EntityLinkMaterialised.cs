namespace AssetViewServer.Database.Models
{
	public class EntityLinkMaterialised
	{
		public Entity Lhs { get; set; }

		public Entity Rhs { get; set; }
        
		public Entity Link { get; set; }

		public string Description { get; set; }
	}
}