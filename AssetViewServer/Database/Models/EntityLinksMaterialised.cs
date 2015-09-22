namespace AssetViewServer.Database.Models
{
	using System.Collections.Generic;

	public class EntityLinksMaterialised	
	{
		public Entity Entity { get; set; }

		public IEnumerable<EntityLinkMaterialised> LhsLinks { get; set; }
		public IEnumerable<EntityLinkMaterialised> RhsLinks { get; set; }
	}
}