using AssetViewServer.StartUp;

using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace AssetViewServer.StartUp
{
	using System.Web.Http;

	using Owin;

	public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

			// Dependencies must be resolved first - subsequent steps rely on it.
			DependencyRegistration.Register(config);

			WebApiRegistration.Register(app, config);

			CorsRegistration.Register(app, config);
			
		}
    }
}