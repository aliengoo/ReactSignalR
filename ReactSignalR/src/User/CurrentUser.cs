using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace ReactSignalR.User
{
    public class CurrentUser : ICurrentUser
    {
        public AppUser Get()
        {
            var identity = System.Web.HttpContext.Current.User.Identity;
            return new AppUser
            {
                IsAuthenticated = identity.IsAuthenticated,
                Username = identity.Name
            };
        }
    }
}