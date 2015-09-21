using Microsoft.Owin;
[assembly: OwinStartup(typeof(AssetViewServer.Startup))]
namespace AssetViewServer
{
	using Owin;
	using System.Web.Http;

	using AssetViewServer.StartUp;

	public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

			WebApi.Register(app, config);
			Dependencies.Register(config);
		}
    }
}