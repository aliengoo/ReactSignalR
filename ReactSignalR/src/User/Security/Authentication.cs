namespace ReactSignalR.User.Security
{
    using System;
    using System.Threading.Tasks;

    using MongoDB.Driver;

    using ReactSignalR.Database;
    using ReactSignalR.User.Security.Models;

    public class Authentication : IAuthentication
    {
        private readonly IMongoCollection<UserAccount> _userAccounts;

        private readonly IMongoCollection<UserToken> _userTokens;

        public Authentication(string databaseUrl)
        {
            _userAccounts =
                DatabaseHelper.GetCollection<UserAccount>(databaseUrl);

            _userTokens = DatabaseHelper.GetCollection<UserToken>(databaseUrl);

            var index = new CreateIndexOptions { ExpireAfter = new TimeSpan(0, 30, 0, 0) };
            var keysDefinitionBuilder = new IndexKeysDefinitionBuilder<UserToken>();
            var indexKeysDef = keysDefinitionBuilder.Ascending(x => x.Created);

            _userTokens.Indexes.CreateOneAsync(indexKeysDef, index);
        }

        public async Task<AuthenticationResult> Authenticate(string username, string password)
        {
            username = username?.Trim().ToLower();

            var existingUserAccount = await _userAccounts.Find(ua => ua.Username == username).FirstOrDefaultAsync();

            if (existingUserAccount != null)
            {
                var passwordMatch = password == existingUserAccount.Password;

                if (passwordMatch)
                {
                    var userToken = await GenerateToken(existingUserAccount);

                    return new AuthenticationResult
                               {
                                   Success = true,
                                   Token = userToken.Token
                               };
                }
            }

            return new AuthenticationResult
                       {
                           Success = false,
                           Message = "Invalid username or password"
                       };
        }

        public Task Logout(string token)
        {
            return ClearToken(token);
        }

        public Task<AuthenticationResult> Authenticate(AuthenticationRequest authenticationRequest)
        {
            return Authenticate(authenticationRequest.Username, authenticationRequest.Password);
        }

        private async Task<UserToken> GenerateToken(UserAccount userAccount)
        {
            await ClearToken(userAccount);

            var userToken = new UserToken
                                {
                                    Username = userAccount.Username,
                                    Created = DateTime.UtcNow,
                                    Token = Guid.NewGuid().ToString("D")
                                };

            await _userTokens.InsertOneAsync(userToken);

            return userToken;
        }

        private async Task ClearToken(UserAccount userAccount)
        {
            await _userTokens.DeleteOneAsync(ut => ut.Username == userAccount.Username);
        }

        private async Task ClearToken(string token)
        {
            await _userTokens.DeleteOneAsync(ut => ut.Token == token);
        }
    }
}