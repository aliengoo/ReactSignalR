namespace ReactSignalR.User.Security
{
    using System.Threading.Tasks;
    using Models;

    public interface IAuthentication
    {
        Task<AuthenticationResult> Authenticate(string username, string password);

        Task Logout(string token);

        Task<AuthenticationResult> Authenticate(AuthenticationRequest authenticationRequest);
    }
}