using System.Collections.Concurrent;
using System.Web.Configuration;
using System.Web.Http;
using Owin;

namespace AssetViewServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new
            {
                id = RouteParameter.Optional
            });

            app.UseWebApi(config);
        }
    }
}