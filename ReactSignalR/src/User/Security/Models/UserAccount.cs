namespace ReactSignalR.User.Security.Models
{
    using MongoDB.Bson.Serialization.Attributes;

    using ReactSignalR.Database.Models;

    public class UserAccount : IDocument
    {
        [BsonId]
        public string Id { get; set; }

        [BsonRequired]
        public string Username { get; set; }

        // TODO: Hash password
        [BsonRequired]
        public string Password { get; set; }
    }
}