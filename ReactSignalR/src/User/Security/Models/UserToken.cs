namespace ReactSignalR.User.Security.Models
{
    using System;

    using MongoDB.Bson.Serialization.Attributes;

    using ReactSignalR.Database.Models;

    public class UserToken : IDocument
    {
        [BsonId]
        public string Id { get; set; }

        [BsonRequired]
        public string Username { get; set; }

        [BsonRequired]
        public string Token { get; set; }

        [BsonRequired]
        public DateTime Created { get; set; }
    }
}