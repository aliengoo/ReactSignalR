namespace ReactSignalR.Controllers
{
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http;

    using ReactSignalR.User.Security;
    using ReactSignalR.User.Security.Models;

    public class AuthenticationController : ApiController
    {
        private readonly IAuthentication _authentication;

        public AuthenticationController(IAuthentication authentication)
        {
            _authentication = authentication;
        }

        public Task<AuthenticationResult> Authenticate(AuthenticationRequest authenticationRequest)
        {
            return _authentication.Authenticate(authenticationRequest);
        }

        public Task Logout()
        {
            return _authentication.Logout(HttpContext.Current.Request.Headers["reactsignalr_token"]);
        }
    }
}