namespace ReactSignalR.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;

    using ReactSignalR.User.Security;
    using ReactSignalR.User.Security.Models;

    [RoutePrefix("api/registration")]
    public class RegistrationController : ApiController
    {
        private readonly IRegistration _registration;

        public RegistrationController(IRegistration registration)
        {
            _registration = registration;
        }

        [HttpPost]
        [Route]
        public Task<RegistrationResult> Register(RegistrationRequest registrationRequest)
        {
            return _registration.Register(registrationRequest);
        }
    }
}