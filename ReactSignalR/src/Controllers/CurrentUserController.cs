using System.Web.Http;
using ReactSignalR.User;

namespace ReactSignalR.Controllers
{
    [RoutePrefix("api/current-user")]
    public class CurrentUserController : ApiController
    {
        private readonly ICurrentUser _currentUser;

        public CurrentUserController(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        [Route]
        public AppUser Get()
        {
            return _currentUser.Get();
        }
    }
}