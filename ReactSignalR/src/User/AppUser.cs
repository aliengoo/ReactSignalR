using System.Collections.Generic;

namespace ReactSignalR.User
{
    public class AppUser
    {
        public string Username { get; set; }

        public List<string> Groups { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}