using System.Web.Http;
using Microsoft.Practices.Unity;
using ReactSignalR.Configuration;
using ReactSignalR.User;
using Unity.WebApi;

namespace ReactSignalR.StartUp
{
	public class DependencyRegistration
    {
        public static void Register(HttpConfiguration config)
        {
            var c = new UnityContainer();
            config.Properties["container"] = c;

            config.DependencyResolver = new UnityDependencyResolver(c);

            // TODO: Dependencies here

			// configuration
	        c.RegisterType<IApplicationConfiguration, ApplicationConfiguration>(new InjectionConstructor("react"));

            c.RegisterType<ICurrentUser, CurrentUser>();
        }
    }
}