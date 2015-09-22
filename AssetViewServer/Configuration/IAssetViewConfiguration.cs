namespace AssetViewServer.Configuration
{
	using System.Collections.Generic;

	public interface IAssetViewConfiguration
	{
		string AssetViewConnectionString { get; }

		IEnumerable<string> CorsOrigins { get; }
    }
}