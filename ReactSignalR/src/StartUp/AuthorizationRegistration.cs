using System.Web.Http;

namespace ReactSignalR.StartUp
{
    public class AuthorizationRegistration
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new AuthorizeAttribute());
        }
    }
}