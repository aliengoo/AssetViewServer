namespace AssetViewServer.Configuration
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Configuration;

	public class AssetViewConfiguration : IAssetViewConfiguration
	{
		private readonly string _connectionStringName;

		private string _assetViewConnectionString;

		private IEnumerable<string> _corsOrigins;

		public AssetViewConfiguration(string connectionStringName = "assetView")
		{
			_connectionStringName = connectionStringName;
		}

		public string AssetViewConnectionString
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_assetViewConnectionString))
				{
					var connectionString = ConfigurationManager.ConnectionStrings[_connectionStringName];

					if (connectionString == null)
					{
						throw new ConfigurationErrorsException($"'{_connectionStringName}' connectionString was not found");
					}

					_assetViewConnectionString = connectionString.ConnectionString;
				}

				return _assetViewConnectionString;
			}
		}

		public IEnumerable<string> CorsOrigins
		{
			get
			{
				if (_corsOrigins == null)
				{
					var corsOrigins = ConfigurationManager.AppSettings["CorsOrigins"];

					if (string.IsNullOrWhiteSpace(corsOrigins))
					{
						// Empty
						_corsOrigins = new List<string>();
					}
					else
					{
						_corsOrigins = corsOrigins.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
					}
				}

				return _corsOrigins;
			}
		}
	}
}