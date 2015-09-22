namespace AssetViewServer.StartUp
{
	using System.Web.Http;

	using Newtonsoft.Json.Serialization;

	public class JsonRegistration
	{
		public static void Register(HttpConfiguration config)
		{
			config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
		} 
	}
}