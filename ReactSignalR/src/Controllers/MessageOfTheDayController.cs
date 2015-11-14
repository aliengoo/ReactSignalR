using System.Web.Http;

namespace ReactSignalR.Controllers
{
    [RoutePrefix("api/message-of-the-day")]
    public class MessageOfTheDayController : ApiController
    {
        [Route]
        public object Get()
        {
            return new
            {
                message = "Hello, World"
            };
        }
    }
}