namespace ReactSignalR.StartUp
{
    using System.Configuration;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Cors;
    using System.Web.Http;
    using System.Web.Http.Dependencies;
    using Microsoft.Owin.Cors;
    using Microsoft.Practices.Unity;

    using Owin;

    using ReactSignalR.Configuration;

    public class CorsRegistration
    {
        public static void Register(IAppBuilder app, HttpConfiguration config)
        {
            var corsPolicy = new CorsPolicy
            {
                AllowAnyHeader = true,
                AllowAnyMethod = true
            };

            var applicationConfiguration =
                (config.Properties["container"] as IUnityContainer).Resolve<IApplicationConfiguration>();

            if (applicationConfiguration == null)
            {
                throw new ConfigurationErrorsException("AssetViewConfiguration was not available");
            }

            if (applicationConfiguration.CorsOrigins.Any())
            {
                foreach (var corsOrigin in applicationConfiguration.CorsOrigins)
                {
                    corsPolicy.Origins.Add(corsOrigin);
                }
            }
            else
            {
                corsPolicy.AllowAnyOrigin = true;
            }

            var corsOptions = new CorsOptions
            {
                PolicyProvider =
                    new CorsPolicyProvider {PolicyResolver = context => Task.FromResult(corsPolicy)}
            };


            app.UseCors(corsOptions);
        }
    }
}