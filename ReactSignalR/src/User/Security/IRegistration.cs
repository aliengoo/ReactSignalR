namespace ReactSignalR.User.Security
{
    using System.Threading.Tasks;

    using ReactSignalR.User.Security.Models;

    public interface IRegistration
    {
        Task<RegistrationResult> Register(string username, string password);

        Task<RegistrationResult> Register(RegistrationRequest registrationRequest);
    }
}