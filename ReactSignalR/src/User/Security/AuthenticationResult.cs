﻿namespace ReactSignalR.User.Security
{
    public class AuthenticationResult
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public string Token { get; set; }
    }
}