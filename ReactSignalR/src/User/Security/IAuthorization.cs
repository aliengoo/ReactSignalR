namespace ReactSignalR.User.Security
{
    using System.Threading.Tasks;

    public interface IAuthorization
    {
        Task<AuthorizationResult> IsAuthorized(string userToken);
    }
}