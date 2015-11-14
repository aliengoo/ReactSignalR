using System.Web.Http;
using ReactSignalR.StartUp;

using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(StartUpApp))]

namespace ReactSignalR.StartUp
{
    public class StartUpApp
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            // Dependencies must be resolved first - subsequent steps rely on it.
            DependencyRegistration.Register(config);

            CorsRegistration.Register(app, config);

            JsonRegistration.Register(config);

            WebApiRegistration.Register(app, config);

            SignalRRegistration.Register(app);
            
			StaticContentRegistration.Register(app);

#if (DEBUG)
            config.EnableSystemDiagnosticsTracing();
#endif
        }
    }
}