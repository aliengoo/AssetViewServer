namespace AssetViewServer.Common
{
	using System.Configuration;

	public class AssetViewConfiguration : IAssetViewConfiguration
	{
		private string _databaseUrl;

		public string DatabaseUrl
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_databaseUrl))
				{
					var connectionString = ConfigurationManager.ConnectionStrings["databaseUrl"];

					if (connectionString == null)
					{
						throw new ConfigurationErrorsException("The 'databaseUrl' connectionString was not found");
					}

					_databaseUrl = connectionString.ConnectionString;
				}

				return _databaseUrl;
			}
		}
	}
}