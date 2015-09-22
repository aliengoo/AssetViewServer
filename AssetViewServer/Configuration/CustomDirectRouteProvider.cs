namespace AssetViewServer.Configuration
{
	using System.Collections.Generic;
	using System.Web.Http.Controllers;
	using System.Web.Http.Routing;

	public class CustomDirectRouteProvider: DefaultDirectRouteProvider
	{
		protected override IReadOnlyList<IDirectRouteFactory> GetActionRouteFactories(HttpActionDescriptor actionDescriptor)
		{
			return actionDescriptor.GetCustomAttributes<IDirectRouteFactory>(inherit: true);
		}

		protected override IReadOnlyList<IDirectRouteFactory> GetControllerRouteFactories(HttpControllerDescriptor controllerDescriptor)
		{
			return controllerDescriptor.GetCustomAttributes<IDirectRouteFactory>(inherit: true);
		}
	}
}