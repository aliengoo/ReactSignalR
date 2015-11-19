namespace ReactSignalR.Controllers
{
    using System.Web.Http;

    using ReactSignalR.User.Security;

    public class AuthorizeController : ApiController
    {
        private readonly IAuthorization _authorization;

        public AuthorizeController(IAuthorization authorization)
        {
            _authorization = authorization;
        }
    }
}