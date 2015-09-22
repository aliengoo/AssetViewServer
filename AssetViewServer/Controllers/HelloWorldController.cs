namespace AssetViewServer.Controllers
{
	using System.Web.Http;

	public class HelloWorldController : ApiController
	{
		public string Get()
		{
			return "Hello, World!";
		}

	}
}