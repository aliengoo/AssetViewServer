namespace AssetViewServer.Database.Models
{
	/// <summary>
	/// Returns the result of a link operation.
	/// </summary>
	public class EntityLinkResult
	{
		public EntityLinkResult(EntityLink entityLink) : this(entityLink, false)
		{
		}

		public EntityLinkResult(EntityLink entityLink, bool success) : this(entityLink, success, string.Empty)
		{
		}

		public EntityLinkResult(EntityLink entityLink, bool success, string message)
		{
			EntityLink = entityLink;
			Success = success;
			Message = message;
		}

		public EntityLink EntityLink { get; private set; }

		public bool Success { get; set; }

		public string Message { get; set; }
	}
}