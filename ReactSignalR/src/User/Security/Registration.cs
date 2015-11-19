namespace ReactSignalR.User.Security
{
    using System.Threading.Tasks;

    using MongoDB.Driver;

    using ReactSignalR.Database;
    using ReactSignalR.User.Security.Models;

    public class Registration : IRegistration
    {
        private readonly IMongoCollection<UserAccount> _userAccounts;

        public Registration(string databaseUrl)
        {
            _userAccounts =
                DatabaseHelper.GetCollection<UserAccount>(databaseUrl);
        }

        public async Task<RegistrationResult> Register(string username, string password)
        {
            username = username?.Trim().ToLower();

            var existingUserAccount = await _userAccounts.Find(ua => ua.Username == username).FirstOrDefaultAsync();

            if (existingUserAccount != null)
            {
                return new RegistrationResult
                           {
                               Success = false,
                               Message = $"The username is already in use."
                           };
            }


            var userAccount = new UserAccount { Username = username, Password = password };

            await _userAccounts.InsertOneAsync(userAccount);

            return new RegistrationResult
                       {
                           Success = true
                       };
        }

        public Task<RegistrationResult> Register(RegistrationRequest registrationRequest)
        {
            return Register(registrationRequest.Username, registrationRequest.Password);
        }
    }
}