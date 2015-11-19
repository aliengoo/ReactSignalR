namespace ReactSignalR.User.Security
{
    using System.Threading.Tasks;

    /// <summary>
    /// TODO: Handle specific URI's
    /// </summary>
    public class Authorization : IAuthorization
    {
        public Authorization(string databaseUrl)
        {

        }

        public Task<AuthorizationResult> IsAuthorized(string userToken)
        {
            
        }
    }
}