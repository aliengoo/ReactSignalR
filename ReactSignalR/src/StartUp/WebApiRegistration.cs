using System.Web.Http;
using Owin;
using ReactSignalR.Configuration;

namespace ReactSignalR.StartUp
{
    public class WebApiRegistration
    {
		public static void Register(IAppBuilder app, HttpConfiguration config)
		{
			config.MapHttpAttributeRoutes(new CustomDirectRouteProvider());

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional });

			app.UseWebApi(config);
		}
    }
}