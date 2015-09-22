namespace AssetViewServer.StartUp
{
	using System.Configuration;
	using System.Linq;
	using System.Threading.Tasks;
	using System.Web.Cors;
	using System.Web.Http;
	using System.Web.Http.Dependencies;

	using AssetViewServer.Configuration;

	using Microsoft.Owin.Cors;

	using Owin;

	public class CorsRegistration
	{
		public static void Register(IAppBuilder app, HttpConfiguration config)
		{
			var corsPolicy = new CorsPolicy
								{
									AllowAnyHeader = true,
									AllowAnyMethod = true
								};



			var assetViewConfiguration = config.DependencyResolver.GetService(typeof(IAssetViewConfiguration)) as IAssetViewConfiguration;

			if (assetViewConfiguration == null)
			{
				throw new ConfigurationErrorsException("AssetViewConfiguration was not available");
			}

			if (assetViewConfiguration.CorsOrigins.Any())
			{
				foreach (var corsOrigin in assetViewConfiguration.CorsOrigins)
				{
					corsPolicy.Origins.Add(corsOrigin);
                }
			}
			else
			{
				corsPolicy.AllowAnyOrigin = true;
			}

			var corsOptions = new CorsOptions
								{
									PolicyProvider =
										new CorsPolicyProvider { PolicyResolver = context => Task.FromResult(corsPolicy) }
								};
		

			app.UseCors(corsOptions);
		}
	}
}