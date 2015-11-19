namespace ReactSignalR.Database
{
    using MongoDB.Driver;

    public static class DatabaseHelper
    {
        public static IMongoDatabase GetDatabase(string url)
        {
            var mongoUrl = MongoUrl.Create(url);

            return new MongoClient(mongoUrl).GetDatabase(mongoUrl.DatabaseName);
        }

        public static IMongoCollection<TDocument> GetCollection<TDocument>(
            string url)
        {
            return GetDatabase(url).GetCollection<TDocument>(nameof(TDocument));
        }
    }
}