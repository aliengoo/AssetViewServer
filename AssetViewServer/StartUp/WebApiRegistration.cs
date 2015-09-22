namespace AssetViewServer.StartUp
{
	using System.Web.Http;

	using AssetViewServer.Configuration;

	using Owin;

	public class WebApiRegistration
	{
		public static void Register(IAppBuilder app, HttpConfiguration config)
		{
			config.MapHttpAttributeRoutes(new CustomDirectRouteProvider());

			//// Convention-based routing.
			//config.Routes.MapHttpRoute(
			//	name: "DefaultApi",
			//	routeTemplate: "api/{controller}/{id}",
			//	defaults: new { id = RouteParameter.Optional }
			//);

			//config.Routes.MapHttpRoute(
			//	name: "DefaultWithActionApi",
			//	routeTemplate: "api/{controller}/{action}/{id}",
			//	defaults: new { id = RouteParameter.Optional }
			//);

			app.UseWebApi(config);
		}
	}
}